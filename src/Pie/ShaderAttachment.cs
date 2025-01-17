using System.Text;
using Pie.ShaderCompiler;

namespace Pie;

/// <summary>
/// Attach shader code at the given <see cref="ShaderStage"/> to a new <see cref="Shader"/>.
/// </summary>
public struct ShaderAttachment
{
    /// <summary>
    /// The stage of this shader attachment.
    /// </summary>
    public ShaderStage Stage;
    
    /// <summary>
    /// The source code of this shader attachment.
    /// </summary>
    public byte[] Spirv;

    internal uint TempHandle;

    /// <summary>
    /// Create a new shader attachment.
    /// </summary>
    /// <param name="stage">The stage of this shader attachment.</param>
    /// <param name="spirv">The Spir-V of this shader attachment.</param>
    public ShaderAttachment(ShaderStage stage, byte[] spirv)
    {
        Stage = stage;
        Spirv = spirv;
        TempHandle = 0;
    }
    
    /// <summary>
    /// Create a new shader attachment.
    /// </summary>
    /// <param name="stage">The stage of this shader attachment.</param>
    /// <param name="source">The source code of this shader attachment.</param>
    /// <param name="language">The shading language to use.</param>
    /// <param name="entryPoint">The entry point function name.</param>
    public ShaderAttachment(ShaderStage stage, string source, Language language = Language.GLSL, string entryPoint = "main")
    {
        Stage = stage;

        CompilerResult result = Compiler.ToSpirv((Stage) stage, language, Encoding.UTF8.GetBytes(source), entryPoint);
        if (!result.IsSuccess)
            throw new PieException(result.Error);
        
        Spirv = result.Result;
        TempHandle = 0;
    }
}