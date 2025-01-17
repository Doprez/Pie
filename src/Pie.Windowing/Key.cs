namespace Pie.Windowing;

// Represents ASCII chars where possible, in order.
public enum Key
{
    Unknown = 0,
    
    Backspace = '\b',
    Tab = '\t',
    Enter = '\r',
    Return = Enter,
    Escape = '\x1B',

    Space = ' ',
    Hash = '#',
    Apostrophe = '\'',
    
    Comma = ',',
    Minus = '-',
    Period = '.',
    Dot = Period,
    ForwardSlash = '/',
    
    Num0 = '0',
    Num1 = '1',
    Num2 = '2',
    Num3 = '3',
    Num4 = '4',
    Num5 = '5',
    Num6 = '6',
    Num7 = '7',
    Num8 = '8',
    Num9 = '9',
    
    Semicolon = ';',
    Equals = '=',

    LeftBracket = '[',
    Backslash = '\\',
    RightBracket = ']',
    
    Backquote = '`',
    GraveAccent = Backquote,
    Backtick = Backquote,
    
    A = 'a',
    B = 'b',
    C = 'c',
    D = 'd',
    E = 'e',
    F = 'f',
    G = 'g',
    H = 'h',
    I = 'i',
    J = 'j',
    K = 'k',
    L = 'l',
    M = 'm',
    N = 'n',
    O = 'o',
    P = 'p',
    Q = 'q',
    R = 'r',
    S = 's',
    T = 't',
    U = 'u',
    V = 'v',
    W = 'w',
    X = 'x',
    Y = 'y',
    Z = 'z',
    
    Delete = '\x7F',
    
    Insert = 256,
    Right,
    Left,
    Down,
    Up,
    PageUp,
    PageDown,
    Home,
    End,
    
    CapsLock,
    ScrollLock,
    NumLock,
    PrintScreen,
    Pause,
    
    F1,
    F2,
    F3,
    F4,
    F5,
    F6,
    F7,
    F8,
    F9,
    F10,
    F11,
    F12,
    F13,
    F14,
    F15,
    F16,
    F17,
    F18,
    F19,
    F20,
    F21,
    F22,
    F23,
    F24,

    Keypad0,
    Keypad1,
    Keypad2,
    Keypad3,
    Keypad4,
    Keypad5,
    Keypad6,
    Keypad7,
    Keypad8,
    Keypad9,
    KeypadDecimal,
    KeypadDivide,
    KeypadMultiply,
    KeypadSubtract,
    KeypadAdd,
    KeypadEnter,
    KeypadEqual,
    
    LeftShift,
    LeftControl,
    LeftAlt,
    LeftSuper,
    RightShift,
    RightControl,
    RightAlt,
    RightSuper,
    
    Menu,
}