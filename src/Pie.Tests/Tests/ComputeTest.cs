using System.Drawing;
using System.IO;
using System.Numerics;
using Pie.ShaderCompiler;
using Pie.Utils;
using StbImageSharp;

namespace Pie.Tests.Tests;

// Basic compute shader test.
public class ComputeTest : TestBase
{
    private GraphicsBuffer _vertexBuffer;
    private GraphicsBuffer _indexBuffer;

    private Texture _texture;
    private SamplerState _samplerState;

    private Shader _shader;
    private InputLayout _layout;

    private DepthStencilState _depthStencilState;
    private RasterizerState _rasterizerState;
    
    protected override void Initialize()
    {
        base.Initialize();

        VertexPositionTexture[] vertices = new[]
        {
            new VertexPositionTexture(new Vector3(-1.0f, 1.0f, 0.0f), new Vector2(0, 0)),
            new VertexPositionTexture(new Vector3(1.0f, 1.0f, 0.0f), new Vector2(1, 0)),
            new VertexPositionTexture(new Vector3(1.0f, -1.0f, 0.0f), new Vector2(1, 1)),
            new VertexPositionTexture(new Vector3(-1.0f, -1.0f, 0.0f), new Vector2(0, 1)),
        };

        uint[] indices = new[]
        {
            0u, 1u, 3u,
            1u, 2u, 3u
        };

        const string shader = @"
struct VSInput
{
    float3 position: POSITION;
    float2 texCoords: TEXCOORD0;
};

struct VSOutput
{
    float4 position: SV_Position;
    float2 texCoords: TEXCOORD0;
};

struct PSOutput
{
    float4 color: SV_Target0;
};

Texture2DArray tex : register(t0);
SamplerState samp : register(s0);

VSOutput VertexShader(in VSInput input)
{
    VSOutput output;
    output.position = float4(input.position, 1.0);
    output.texCoords = input.texCoords;
    return output;
}

PSOutput PixelShader(in VSOutput input)
{
    PSOutput output;
    output.color = tex.Sample(samp, float3(input.texCoords, 0));
    return output;
}";

        _vertexBuffer = GraphicsDevice.CreateBuffer(BufferType.VertexBuffer, vertices);
        _indexBuffer = GraphicsDevice.CreateBuffer(BufferType.IndexBuffer, indices);
        
        ImageResult result1 = ImageResult.FromMemory(File.ReadAllBytes("/home/ollie/Pictures/awesomeface.png"), ColorComponents.RedGreenBlueAlpha);
        ImageResult result2 = ImageResult.FromMemory(File.ReadAllBytes("/home/ollie/Pictures/piegfx-logo-square-temp.png"), ColorComponents.RedGreenBlueAlpha);
        
        _texture = GraphicsDevice.CreateTexture(TextureDescription.Texture2D(result1.Width, result1.Height,
            Format.R8G8B8A8_UNorm, 0, 2, TextureUsage.ShaderResource), PieUtils.Combine(result1.Data, result2.Data));
        GraphicsDevice.GenerateMipmaps(_texture);

        _samplerState = GraphicsDevice.CreateSamplerState(SamplerStateDescription.PointRepeat);

        _shader = GraphicsDevice.CreateShader(new[]
        {
            new ShaderAttachment(ShaderStage.Vertex, shader, Language.HLSL, "VertexShader"),
            new ShaderAttachment(ShaderStage.Pixel, shader, Language.HLSL, "PixelShader")
        });

        _layout = GraphicsDevice.CreateInputLayout(
            new InputLayoutDescription(Format.R32G32B32_Float, 0, 0, InputType.PerVertex),
            new InputLayoutDescription(Format.R32G32_Float, 12, 0, InputType.PerVertex));

        _depthStencilState = GraphicsDevice.CreateDepthStencilState(DepthStencilStateDescription.Disabled);
        _rasterizerState = GraphicsDevice.CreateRasterizerState(RasterizerStateDescription.CullNone);
    }

    protected override void Draw(double dt)
    {
        base.Draw(dt);
        
        GraphicsDevice.ClearColorBuffer(Color.CornflowerBlue);
        
        GraphicsDevice.SetShader(_shader);
        GraphicsDevice.SetTexture(0, _texture, _samplerState);
        GraphicsDevice.SetRasterizerState(_rasterizerState);
        GraphicsDevice.SetDepthStencilState(_depthStencilState);
        GraphicsDevice.SetPrimitiveType(PrimitiveType.TriangleList);
        GraphicsDevice.SetVertexBuffer(0, _vertexBuffer, VertexPositionTexture.SizeInBytes, _layout);
        GraphicsDevice.SetIndexBuffer(_indexBuffer, IndexType.UInt);
        GraphicsDevice.DrawIndexed(6);
    }
}