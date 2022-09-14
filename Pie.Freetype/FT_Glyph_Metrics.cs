using FT_Pos = System.Runtime.InteropServices.CLong;

namespace Pie.Freetype;

public struct FT_Glyph_Metrics
{
    public FT_Pos Width;
    public FT_Pos Height;

    public FT_Pos HoriBearingX;
    public FT_Pos HoriBearingY;
    public FT_Pos HoriAdvance;

    public FT_Pos VertBearyingX;
    public FT_Pos VertBearingY;
    public FT_Pos VertAdvance;
}