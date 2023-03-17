﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Spirzza.Interop.Shaderc;
using Spirzza.Interop.SpirvCross;
using static Spirzza.Interop.Shaderc.Shaderc;
using static Spirzza.Interop.SpirvCross.SpirvCross;

namespace Pie.ShaderCompiler;

/// <summary>
/// Provides cross-platform API-independent shader compilation functions.
/// </summary>
public static class Compiler
{
    /// <summary>
    /// Compile GLSL/HLSL code to Spir-V.
    /// </summary>
    /// <param name="stage">The shader <see cref="Stage"/> to compile.</param>
    /// <param name="language">The source's shading language.</param>
    /// <param name="source">The source code, in ASCII representation.</param>
    /// <param name="entryPoint">The entry point of the shader. Usually "main" for GLSL.</param>
    /// <param name="reflect">Whether or not to return <see cref="ReflectionInfo"/>. This causes a slight performance
    /// hit, so use wisely.</param>
    /// <returns>The <see cref="CompilerResult"/> of this compilation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if an unsupported <paramref name="language"/> is used.</exception>
    public static unsafe CompilerResult ToSpirv(Stage stage, Language language, byte[] source, string entryPoint, bool reflect = false)
    {
        shaderc_compiler* compiler = shaderc_compiler_initialize();
        shaderc_compile_options* options = shaderc_compile_options_initialize();
        shaderc_compilation_result* result;

        shaderc_source_language sourceLanguage = language switch
        {
            Language.GLSL => shaderc_source_language.shaderc_source_language_glsl,
            Language.HLSL => shaderc_source_language.shaderc_source_language_hlsl,
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
        };

        shaderc_compile_options_set_source_language(options, sourceLanguage);
        
        shaderc_compile_options_set_auto_combined_image_sampler(options, 1);

        shaderc_shader_kind kind = stage switch
        {
            Stage.Vertex => shaderc_shader_kind.shaderc_vertex_shader,
            Stage.Fragment => shaderc_shader_kind.shaderc_fragment_shader,
            Stage.Geometry => shaderc_shader_kind.shaderc_geometry_shader,
            Stage.Compute => shaderc_shader_kind.shaderc_compute_shader,
            _ => throw new ArgumentOutOfRangeException(nameof(stage), stage, null)
        };

        fixed (byte* src = source)
        fixed (sbyte* fn = GetFromString("main"))
        fixed (sbyte* entpt = GetFromString(entryPoint))
        {
            result = shaderc_compile_into_spv(compiler, (sbyte*) src, (nuint) source.Length, kind, fn, entpt, options);
        }

        if (shaderc_result_get_compilation_status(result) !=
            shaderc_compilation_status.shaderc_compilation_status_success)
        {
            string error = ConvertToString(shaderc_result_get_error_message(result));
            
            shaderc_result_release(result);
            shaderc_compiler_release(compiler);

            return new CompilerResult(null, false, $"Failed to convert {stage.ToString().ToLower()} shader: " + error,
                null);
        }

        sbyte* bytes = shaderc_result_get_bytes(result);
        nuint length = shaderc_result_get_length(result);
        
        byte[] compiled = new byte[length];
        
        fixed (byte* cmpPtr = compiled)
            Unsafe.CopyBlock(cmpPtr, bytes, (uint) length);
        
        ReflectionInfo? info = null;
        if (reflect)
            info = ReflectionInfo.FromJson(Encoding.UTF8.GetString(SpirvToShaderCode(spvc_backend.SPVC_BACKEND_JSON, (byte*) bytes, length, null).Result), stage);
        
        shaderc_result_release(result);
        shaderc_compiler_release(compiler);

        return new CompilerResult(compiled, true, string.Empty, info);
    }

    private static sbyte[] GetFromString(string text)
    {
        return (sbyte[]) (Array) Encoding.ASCII.GetBytes(text);
    }

    private static unsafe string ConvertToString(sbyte* text)
    {
        return Marshal.PtrToStringAnsi((IntPtr) text);
    }

    private static unsafe CompilerResult SpirvToShaderCode(spvc_backend backend, byte* result, nuint length, SpecializationConstant[] constants)
    {
        spvc_context* context;
        spvc_context_create(&context);

        spvc_parsed_ir* ir;
        spvc_result spirvResult = spvc_context_parse_spirv(context, (SpvId*) result, length / (nuint) sizeof(SpvId), &ir);
        if (spirvResult != spvc_result.SPVC_SUCCESS)
        {
            string error = ConvertToString(spvc_context_get_last_error_string(context));
            spvc_context_destroy(context);

            return new CompilerResult(null, false, error, null);
        }
        
        spvc_compiler* compl;
        spvc_context_create_compiler(context, backend, ir, spvc_capture_mode.SPVC_CAPTURE_MODE_COPY, &compl);

        spvc_compiler_options* options;
        spvc_compiler_create_compiler_options(compl, &options);
        switch (backend)
        {
            case spvc_backend.SPVC_BACKEND_GLSL:
                spvc_compiler_options_set_uint(options, spvc_compiler_option.SPVC_COMPILER_OPTION_GLSL_VERSION, 430);
                spvc_compiler_options_set_bool(options, spvc_compiler_option.SPVC_COMPILER_OPTION_GLSL_ES, SPVC_FALSE);
                break;
            case spvc_backend.SPVC_BACKEND_HLSL:
                spvc_compiler_options_set_uint(options, spvc_compiler_option.SPVC_COMPILER_OPTION_HLSL_SHADER_MODEL,
                    50);
                spvc_compiler_options_set_bool(options,
                    spvc_compiler_option.SPVC_COMPILER_OPTION_HLSL_FLATTEN_MATRIX_VERTEX_INPUT_SEMANTICS, SPVC_TRUE);
                 break;
            case spvc_backend.SPVC_BACKEND_JSON:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(backend), backend, null);
        }
        spvc_compiler_install_compiler_options(compl, options);

        if (constants != null)
        {
            nuint numConstants;
            spvc_specialization_constant* sConstants;
            spvc_compiler_get_specialization_constants(compl, &sConstants, &numConstants);

            for (int i = 0; i < constants.Length; i++)
            {
                ref SpecializationConstant constant = ref constants[i];

                for (int c = 0; c < (int) numConstants; c++)
                {
                    if (sConstants[c].constant_id == constant.ID)
                    {
                        spvc_constant* sConst = spvc_compiler_get_constant_handle(compl, sConstants[c].id);

                        ulong value = constant.Value;

                        switch (constant.Type)
                        {
                            case ConstantType.U32:
                                spvc_constant_set_scalar_u32(sConst, 0, 0, *(uint*) &value);
                                break;
                            case ConstantType.I32:
                                spvc_constant_set_scalar_i32(sConst, 0, 0, *(int*) &value);
                                break;
                            case ConstantType.F32:
                                spvc_constant_set_scalar_fp32(sConst, 0, 0, *(float*) &value);
                                break;
                            //case ConstantType.U64:
                            //    spvc_constant_set_scalar_u64(sConst, 0, 0, value);
                            //    break;
                            //case ConstantType.I64:
                            //    spvc_constant_set_scalar_i64(sConst, 0, 0, *(long*) &value);
                            //    break;
                            case ConstantType.F64:
                                spvc_constant_set_scalar_fp64(sConst, 0, 0, *(double*) &value);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
        }

        spvc_variable_id id;
        spvc_compiler_build_dummy_sampler_for_combined_images(compl, &id);

        spvc_compiler_build_combined_image_samplers(compl);

        nuint numSamplers;
        spvc_combined_image_sampler* samplers;
        spvc_compiler_get_combined_image_samplers(compl, &samplers, &numSamplers);

        // build_combined_image_samplers removes the binding from the combined sampler. Fortunately, it does retain
        // the binding in the image id and the sampler id. And fortunately fortunately, it allows us to set the
        // binding value of the combined sampler, which is what we do here.
        
        for (int i = 0; i < (int) numSamplers; i++)
        {
            // HLSL requires that for combined samplers to work, the Texture2D and SamplerState must be at the same
            // register index. Therefore, either index will work here. I just use the image id.
            uint decoration =
                spvc_compiler_get_decoration(compl, samplers[i].image_id.Value, SpvDecoration.SpvDecorationBinding);

            spvc_compiler_set_decoration(compl, samplers[i].combined_id.Value, SpvDecoration.SpvDecorationBinding,
                decoration);
        }

        sbyte* compiledResult;
        spirvResult = spvc_compiler_compile(compl, &compiledResult);

        if (spirvResult != spvc_result.SPVC_SUCCESS)
        {
            string error = ConvertToString(spvc_context_get_last_error_string(context));
            spvc_context_destroy(context);

            return new CompilerResult(null, false, error, null);
        }
        
        byte[] compiled = Encoding.UTF8.GetBytes(ConvertToString(compiledResult));
        
        spvc_context_destroy(context);

        return new CompilerResult(compiled, true, string.Empty, null);
    }

    /// <summary>
    /// Transpile Spir-V to shader source code.
    /// </summary>
    /// <param name="language">The language to transpile to.</param>
    /// <param name="spirv">The Spir-V bytecode to transpile.</param>
    /// <returns>The <see cref="CompilerResult"/> of this compilation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if an unsupported <paramref name="language"/> is used.</exception>
    public static unsafe CompilerResult FromSpirv(Language language, byte[] spirv, SpecializationConstant[] constants)
    {
        CompilerResult result;

        spvc_backend backend = language switch
        {
            Language.GLSL => spvc_backend.SPVC_BACKEND_GLSL,
            Language.HLSL => spvc_backend.SPVC_BACKEND_HLSL,
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
        };

        fixed (byte* sPtr = spirv)
            result = SpirvToShaderCode(backend, sPtr, (nuint) spirv.Length, constants);

        return result;
    }

    private const string name = "spv-cross-temp";
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_fp16(spvc_constant* constant, uint row, uint column, Half value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_fp32(spvc_constant* constant, uint row, uint column, float value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_fp64(spvc_constant* constant, uint row, uint column, double value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_u32(spvc_constant* constant, uint row, uint column, uint value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_i32(spvc_constant* constant, uint row, uint column, int value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_u16(spvc_constant* constant, uint row, uint column, ushort value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_i16(spvc_constant* constant, uint row, uint column, short value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_u8(spvc_constant* constant, uint row, uint column, byte value);
    
    [DllImport(name)]
    private static extern unsafe void spvc_constant_set_scalar_i8(spvc_constant* constant, uint row, uint column, sbyte value);
}