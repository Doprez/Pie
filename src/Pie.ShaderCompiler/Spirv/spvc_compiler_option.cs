namespace Pie.ShaderCompiler.Spirv
{
    [NativeTypeName("unsigned int")]
    public enum spvc_compiler_option : uint
    {
        SPVC_COMPILER_OPTION_UNKNOWN = 0,
        SPVC_COMPILER_OPTION_FORCE_TEMPORARY = 1 | 0x1000000,
        SPVC_COMPILER_OPTION_FLATTEN_MULTIDIMENSIONAL_ARRAYS = 2 | 0x1000000,
        SPVC_COMPILER_OPTION_FIXUP_DEPTH_CONVENTION = 3 | 0x1000000,
        SPVC_COMPILER_OPTION_FLIP_VERTEX_Y = 4 | 0x1000000,
        SPVC_COMPILER_OPTION_GLSL_SUPPORT_NONZERO_BASE_INSTANCE = 5 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_SEPARATE_SHADER_OBJECTS = 6 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_ENABLE_420PACK_EXTENSION = 7 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_VERSION = 8 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_ES = 9 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_VULKAN_SEMANTICS = 10 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_ES_DEFAULT_FLOAT_PRECISION_HIGHP = 11 | 0x2000000,
        SPVC_COMPILER_OPTION_GLSL_ES_DEFAULT_INT_PRECISION_HIGHP = 12 | 0x2000000,
        SPVC_COMPILER_OPTION_HLSL_SHADER_MODEL = 13 | 0x4000000,
        SPVC_COMPILER_OPTION_HLSL_POINT_SIZE_COMPAT = 14 | 0x4000000,
        SPVC_COMPILER_OPTION_HLSL_POINT_COORD_COMPAT = 15 | 0x4000000,
        SPVC_COMPILER_OPTION_HLSL_SUPPORT_NONZERO_BASE_VERTEX_BASE_INSTANCE = 16 | 0x4000000,
        SPVC_COMPILER_OPTION_MSL_VERSION = 17 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_TEXEL_BUFFER_TEXTURE_WIDTH = 18 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_AUX_BUFFER_INDEX = 19 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SWIZZLE_BUFFER_INDEX = 19 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_INDIRECT_PARAMS_BUFFER_INDEX = 20 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_OUTPUT_BUFFER_INDEX = 21 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_PATCH_OUTPUT_BUFFER_INDEX = 22 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_TESS_FACTOR_OUTPUT_BUFFER_INDEX = 23 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_INPUT_WORKGROUP_INDEX = 24 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_POINT_SIZE_BUILTIN = 25 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_DISABLE_RASTERIZATION = 26 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_CAPTURE_OUTPUT_TO_BUFFER = 27 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SWIZZLE_TEXTURE_SAMPLES = 28 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_PAD_FRAGMENT_OUTPUT_COMPONENTS = 29 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_TESS_DOMAIN_ORIGIN_LOWER_LEFT = 30 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_PLATFORM = 31 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ARGUMENT_BUFFERS = 32 | 0x8000000,
        SPVC_COMPILER_OPTION_GLSL_EMIT_PUSH_CONSTANT_AS_UNIFORM_BUFFER = 33 | 0x2000000,
        SPVC_COMPILER_OPTION_MSL_TEXTURE_BUFFER_NATIVE = 34 | 0x8000000,
        SPVC_COMPILER_OPTION_GLSL_EMIT_UNIFORM_BUFFER_AS_PLAIN_UNIFORMS = 35 | 0x2000000,
        SPVC_COMPILER_OPTION_MSL_BUFFER_SIZE_BUFFER_INDEX = 36 | 0x8000000,
        SPVC_COMPILER_OPTION_EMIT_LINE_DIRECTIVES = 37 | 0x1000000,
        SPVC_COMPILER_OPTION_MSL_MULTIVIEW = 38 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_VIEW_MASK_BUFFER_INDEX = 39 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_DEVICE_INDEX = 40 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_VIEW_INDEX_FROM_DEVICE_INDEX = 41 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_DISPATCH_BASE = 42 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_DYNAMIC_OFFSETS_BUFFER_INDEX = 43 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_TEXTURE_1D_AS_2D = 44 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_BASE_INDEX_ZERO = 45 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_IOS_FRAMEBUFFER_FETCH_SUBPASS = 46 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_FRAMEBUFFER_FETCH_SUBPASS = 46 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_INVARIANT_FP_MATH = 47 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_EMULATE_CUBEMAP_ARRAY = 48 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_DECORATION_BINDING = 49 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_FORCE_ACTIVE_ARGUMENT_BUFFER_RESOURCES = 50 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_FORCE_NATIVE_ARRAYS = 51 | 0x8000000,
        SPVC_COMPILER_OPTION_ENABLE_STORAGE_IMAGE_QUALIFIER_DEDUCTION = 52 | 0x1000000,
        SPVC_COMPILER_OPTION_HLSL_FORCE_STORAGE_BUFFER_AS_UAV = 53 | 0x4000000,
        SPVC_COMPILER_OPTION_FORCE_ZERO_INITIALIZED_VARIABLES = 54 | 0x1000000,
        SPVC_COMPILER_OPTION_HLSL_NONWRITABLE_UAV_TEXTURE_AS_SRV = 55 | 0x4000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_OUTPUT_MASK = 56 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_DEPTH_BUILTIN = 57 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_STENCIL_REF_BUILTIN = 58 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ENABLE_CLIP_DISTANCE_USER_VARYING = 59 | 0x8000000,
        SPVC_COMPILER_OPTION_HLSL_ENABLE_16BIT_TYPES = 60 | 0x4000000,
        SPVC_COMPILER_OPTION_MSL_MULTI_PATCH_WORKGROUP = 61 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_INPUT_BUFFER_INDEX = 62 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_INDEX_BUFFER_INDEX = 63 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_VERTEX_FOR_TESSELLATION = 64 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_VERTEX_INDEX_TYPE = 65 | 0x8000000,
        SPVC_COMPILER_OPTION_GLSL_FORCE_FLATTENED_IO_BLOCKS = 66 | 0x2000000,
        SPVC_COMPILER_OPTION_MSL_MULTIVIEW_LAYERED_RENDERING = 67 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_ARRAYED_SUBPASS_INPUT = 68 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_R32UI_LINEAR_TEXTURE_ALIGNMENT = 69 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_R32UI_ALIGNMENT_CONSTANT_ID = 70 | 0x8000000,
        SPVC_COMPILER_OPTION_HLSL_FLATTEN_MATRIX_VERTEX_INPUT_SEMANTICS = 71 | 0x4000000,
        SPVC_COMPILER_OPTION_MSL_IOS_USE_SIMDGROUP_FUNCTIONS = 72 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_EMULATE_SUBGROUPS = 73 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_FIXED_SUBGROUP_SIZE = 74 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_FORCE_SAMPLE_RATE_SHADING = 75 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_IOS_SUPPORT_BASE_VERTEX_INSTANCE = 76 | 0x8000000,
        SPVC_COMPILER_OPTION_GLSL_OVR_MULTIVIEW_VIEW_COUNT = 77 | 0x2000000,
        SPVC_COMPILER_OPTION_RELAX_NAN_CHECKS = 78 | 0x1000000,
        SPVC_COMPILER_OPTION_MSL_RAW_BUFFER_TESE_INPUT = 79 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SHADER_PATCH_INPUT_BUFFER_INDEX = 80 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_MANUAL_HELPER_INVOCATION_UPDATES = 81 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_CHECK_DISCARDED_FRAG_STORES = 82 | 0x8000000,
        SPVC_COMPILER_OPTION_GLSL_ENABLE_ROW_MAJOR_LOAD_WORKAROUND = 83 | 0x2000000,
        SPVC_COMPILER_OPTION_MSL_ARGUMENT_BUFFERS_TIER = 84 | 0x8000000,
        SPVC_COMPILER_OPTION_MSL_SAMPLE_DREF_LOD_ARRAY_AS_GRAD = 85 | 0x8000000,
        SPVC_COMPILER_OPTION_INT_MAX = 0x7fffffff,
    }
}