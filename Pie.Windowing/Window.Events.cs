﻿using System.Drawing;
using Silk.NET.GLFW;

namespace Pie.Windowing;

public unsafe partial class Window
{
    public event OnResize Resize;
    public event OnKeyDown KeyDown;
    public event OnKeyUp KeyUp;

    public event OnTextInput TextInput;
    
    private GlfwCallbacks.WindowSizeCallback _windowSizeCallback;
    private GlfwCallbacks.KeyCallback _keyCallback;
    private GlfwCallbacks.CharCallback _charCallback;

    private void SetupCallbacks()
    {
        _windowSizeCallback = WindowSizeCallback;
        _keyCallback = KeyCallback;
        _charCallback = CharCallback;
        // TODO: Add all glfw callbacks https://www.glfw.org/docs/3.3/input_guide.html

        _glfw.SetWindowSizeCallback(_handle, _windowSizeCallback);
        _glfw.SetKeyCallback(_handle, _keyCallback);
        _glfw.SetCharCallback(_handle, _charCallback);
    }

    private void KeyCallback(WindowHandle* window, Silk.NET.GLFW.Keys key, int scancode, InputAction action, KeyModifiers mods)
    {
        switch (action)
        {
            case InputAction.Press:
                KeyDown?.Invoke((Keys) key);
                break;
            case InputAction.Release:
                KeyUp?.Invoke((Keys) key);
                break;
        }
    }

    private void WindowSizeCallback(WindowHandle* window, int width, int height)
    {
        Resize?.Invoke(new Size(width, height));
    }
    
    private void CharCallback(WindowHandle* window, uint codepoint)
    {
        TextInput?.Invoke((char) codepoint);
    }

    public delegate void OnResize(Size size);

    public delegate void OnKeyDown(Keys key);

    public delegate void OnKeyUp(Keys key);

    public delegate void OnTextInput(char c);
}