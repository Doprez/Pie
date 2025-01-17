﻿namespace Pie.DebugLayer;

internal sealed class DebugRasterizerState : RasterizerState
{
    public RasterizerState RasterizerState;
    
    public override bool IsDisposed { get; protected set; }

    public override RasterizerStateDescription Description => RasterizerState.Description;

    public DebugRasterizerState(GraphicsDevice device, RasterizerStateDescription description)
    {
        PieLog.Log(LogType.Debug, $@"Rasterizer state info:
    CullDirection: {description.CullDirection}
    CullFace: {description.CullFace}
    FillMode: {description.FillMode}
    ScissorTestEnabled: {description.ScissorTest}");
        
        RasterizerState = device.CreateRasterizerState(description);
    }
    
    public override void Dispose()
    {
        RasterizerState.Dispose();
        IsDisposed = RasterizerState.IsDisposed;
        PieLog.Log(LogType.Debug, "Rasterizer state disposed.");
    }
}