using System;
using System.Diagnostics;

namespace Pie.Graphics;

public static class Logging
{
    internal static void Log(string message)
    {
        Console.WriteLine(message);
        Debug.WriteLine(message);
    }
}