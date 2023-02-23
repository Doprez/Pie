using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.Core.Native;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.EXT;
using Silk.NET.Vulkan.Extensions.KHR;
using static Pie.Vulkan.VkUtils;

namespace Pie.Vulkan;

internal unsafe class VkGraphicsDevice : GraphicsDevice
{
    private Vk _vk;
    private Instance _instance;
    
    public VkGraphicsDevice()
    {
        _vk = Vk.GetApi();
        CreateInstance(true);
    }
    
    public override GraphicsApi Api { get; }
    public override Swapchain Swapchain { get; }
    public override GraphicsAdapter Adapter { get; }
    public override Rectangle Viewport { get; set; }
    public override Rectangle Scissor { get; set; }
    public override void Clear(Color color, ClearFlags flags = ClearFlags.None)
    {
        throw new NotImplementedException();
    }

    public override void Clear(Vector4 color, ClearFlags flags = ClearFlags.None)
    {
        throw new NotImplementedException();
    }

    public override void Clear(ClearFlags flags)
    {
        throw new NotImplementedException();
    }

    public override GraphicsBuffer CreateBuffer<T>(BufferType bufferType, T[] data, bool dynamic = false)
    {
        throw new NotImplementedException();
    }

    public override GraphicsBuffer CreateBuffer<T>(BufferType bufferType, T data, bool dynamic = false)
    {
        throw new NotImplementedException();
    }

    public override GraphicsBuffer CreateBuffer(BufferType bufferType, uint sizeInBytes, bool dynamic = false)
    {
        throw new NotImplementedException();
    }

    public override GraphicsBuffer CreateBuffer(BufferType bufferType, uint sizeInBytes, IntPtr data, bool dynamic = false)
    {
        throw new NotImplementedException();
    }

    public override unsafe GraphicsBuffer CreateBuffer(BufferType bufferType, uint sizeInBytes, void* data, bool dynamic = false)
    {
        throw new NotImplementedException();
    }

    public override Texture CreateTexture(TextureDescription description)
    {
        throw new NotImplementedException();
    }

    public override Texture CreateTexture<T>(TextureDescription description, T[] data)
    {
        throw new NotImplementedException();
    }

    public override Texture CreateTexture<T>(TextureDescription description, T[][] data)
    {
        throw new NotImplementedException();
    }

    public override Texture CreateTexture(TextureDescription description, IntPtr data)
    {
        throw new NotImplementedException();
    }

    public override unsafe Texture CreateTexture(TextureDescription description, void* data)
    {
        throw new NotImplementedException();
    }

    public override Shader CreateShader(params ShaderAttachment[] attachments)
    {
        throw new NotImplementedException();
    }

    public override InputLayout CreateInputLayout(params InputLayoutDescription[] inputLayoutDescriptions)
    {
        throw new NotImplementedException();
    }

    public override RasterizerState CreateRasterizerState(RasterizerStateDescription description)
    {
        throw new NotImplementedException();
    }

    public override BlendState CreateBlendState(BlendStateDescription description)
    {
        throw new NotImplementedException();
    }

    public override DepthState CreateDepthState(DepthStateDescription description)
    {
        throw new NotImplementedException();
    }

    public override SamplerState CreateSamplerState(SamplerStateDescription description)
    {
        throw new NotImplementedException();
    }

    public override Framebuffer CreateFramebuffer(params FramebufferAttachment[] attachments)
    {
        throw new NotImplementedException();
    }

    public override void UpdateBuffer<T>(GraphicsBuffer buffer, uint offsetInBytes, T[] data)
    {
        throw new NotImplementedException();
    }

    public override void UpdateBuffer<T>(GraphicsBuffer buffer, uint offsetInBytes, T data)
    {
        throw new NotImplementedException();
    }

    public override void UpdateBuffer(GraphicsBuffer buffer, uint offsetInBytes, uint sizeInBytes, IntPtr data)
    {
        throw new NotImplementedException();
    }

    public override unsafe void UpdateBuffer(GraphicsBuffer buffer, uint offsetInBytes, uint sizeInBytes, void* data)
    {
        throw new NotImplementedException();
    }

    public override void UpdateTexture<T>(Texture texture, int mipLevel, int arrayIndex, int x, int y, int z, int width, int height,
        int depth, T[] data)
    {
        throw new NotImplementedException();
    }

    public override void UpdateTexture(Texture texture, int mipLevel, int arrayIndex, int x, int y, int z, int width, int height, int depth,
        IntPtr data)
    {
        throw new NotImplementedException();
    }

    public override unsafe void UpdateTexture(Texture texture, int mipLevel, int arrayIndex, int x, int y, int z, int width, int height,
        int depth, void* data)
    {
        throw new NotImplementedException();
    }

    public override IntPtr MapBuffer(GraphicsBuffer buffer, MapMode mode)
    {
        throw new NotImplementedException();
    }

    public override void UnmapBuffer(GraphicsBuffer buffer)
    {
        throw new NotImplementedException();
    }

    public override void SetShader(Shader shader)
    {
        throw new NotImplementedException();
    }

    public override void SetTexture(uint bindingSlot, Texture texture, SamplerState samplerState)
    {
        throw new NotImplementedException();
    }

    public override void SetRasterizerState(RasterizerState state)
    {
        throw new NotImplementedException();
    }

    public override void SetBlendState(BlendState state)
    {
        throw new NotImplementedException();
    }

    public override void SetDepthState(DepthState state)
    {
        throw new NotImplementedException();
    }

    public override void SetPrimitiveType(PrimitiveType type)
    {
        throw new NotImplementedException();
    }

    public override void SetVertexBuffer(uint slot, GraphicsBuffer buffer, uint stride, InputLayout layout)
    {
        throw new NotImplementedException();
    }

    public override void SetIndexBuffer(GraphicsBuffer buffer, IndexType type)
    {
        throw new NotImplementedException();
    }

    public override void SetUniformBuffer(uint bindingSlot, GraphicsBuffer buffer)
    {
        throw new NotImplementedException();
    }

    public override void SetFramebuffer(Framebuffer framebuffer)
    {
        throw new NotImplementedException();
    }

    public override void Draw(uint vertexCount)
    {
        throw new NotImplementedException();
    }

    public override void Draw(uint vertexCount, int startVertex)
    {
        throw new NotImplementedException();
    }

    public override void DrawIndexed(uint indexCount)
    {
        throw new NotImplementedException();
    }

    public override void DrawIndexed(uint indexCount, int startIndex)
    {
        throw new NotImplementedException();
    }

    public override void DrawIndexed(uint indexCount, int startIndex, int baseVertex)
    {
        throw new NotImplementedException();
    }

    public override void DrawIndexedInstanced(uint indexCount, uint instanceCount)
    {
        throw new NotImplementedException();
    }

    public override void Present(int swapInterval)
    {
        throw new NotImplementedException();
    }

    public override void ResizeSwapchain(Size newSize)
    {
        throw new NotImplementedException();
    }

    public override void GenerateMipmaps(Texture texture)
    {
        throw new NotImplementedException();
    }

    public override void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
    {
        throw new NotImplementedException();
    }

    public override void Flush()
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        _vk.DestroyInstance(_instance, null);
    }

    private void CreateInstance(bool debug)
    {
        PieLog.Log(LogType.Debug, "Creating vk instance...");
        string[] extensions;
        string[] layers;

        if (debug)
        {
            extensions = new[] { KhrSurface.ExtensionName, ExtDebugUtils.ExtensionName };
            layers = new[] { "VK_LAYER_KHRONOS_validation" };
        }
        else
        {
            extensions = new[] { KhrSurface.ExtensionName };
            layers = Array.Empty<string>();
        }

        PieLog.Log(LogType.Debug, "Enabled instance extensions: " + string.Join(", ", extensions));
        PieLog.Log(LogType.Debug, "Enabled instance layers: " + string.Join(", ", layers));

        byte* appName = (byte*) SilkMarshal.StringToPtr("Pie Application");
        byte* engineName = (byte*) SilkMarshal.StringToPtr("Pie");
        byte** enabledExtensions = (byte**) SilkMarshal.StringArrayToPtr(extensions);
        byte** enabledLayers = (byte**) SilkMarshal.StringArrayToPtr(layers);
        
        ApplicationInfo appInfo = new ApplicationInfo();
        appInfo.SType = StructureType.ApplicationInfo;
        appInfo.PApplicationName = appName;
        appInfo.PEngineName = engineName;
        appInfo.ApiVersion = Vk.Version10;
        appInfo.EngineVersion = Vk.MakeVersion(1, 0, 0);

        InstanceCreateInfo iCreateInfo = new InstanceCreateInfo();
        iCreateInfo.SType = StructureType.InstanceCreateInfo;
        iCreateInfo.PApplicationInfo = &appInfo;
        iCreateInfo.EnabledExtensionCount = (uint) extensions.Length;
        iCreateInfo.PpEnabledExtensionNames = enabledExtensions;
        iCreateInfo.EnabledLayerCount = (uint) layers.Length;
        iCreateInfo.PpEnabledLayerNames = enabledLayers;
        
        CheckVkResult(_vk.CreateInstance(&iCreateInfo, null, out _instance));

        SilkMarshal.Free((nint) appName);
        SilkMarshal.Free((nint) engineName);
        SilkMarshal.Free((nint) enabledExtensions);
        SilkMarshal.Free((nint) enabledLayers);
        
        PieLog.Log(LogType.Debug, "Created vk instance.");
    }
}