using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Desktop.Robot
{

    /*
    * Keycode list
    * Linux: https://www.cl.cam.ac.uk/~mgk25/ucs/keysymdef.h
    * Windows: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    * OSX_1: http://www.meandmark.com/keycodes.html
    * OSX_2: https://eastmanreference.com/complete-list-of-applescript-key-codes
    */
    public enum Key
    {

        //Characters
        [Keycode(Platform = "OSX", Keycode = 0x00)]
        [Keycode(Platform = "Windows", Keycode = 0x41)]
        [Keycode(Platform = "Linux", Keycode = 0x0061)]
        A,

        [Keycode(Platform = "OSX", Keycode = 0x0B)]
        [Keycode(Platform = "Windows", Keycode = 0x42)]
        [Keycode(Platform = "Linux", Keycode = 0x0062)]
        B,

        [Keycode(Platform = "OSX", Keycode = 0x08)]
        [Keycode(Platform = "Windows", Keycode = 0x43)]
        [Keycode(Platform = "Linux", Keycode = 0x0063)]
        C,

        [Keycode(Platform = "OSX", Keycode = 0x02)]
        [Keycode(Platform = "Windows", Keycode = 0x44)]
        [Keycode(Platform = "Linux", Keycode = 0x0064)]
        D,

        [Keycode(Platform = "OSX", Keycode = 0x0E)]
        [Keycode(Platform = "Windows", Keycode = 0x45)]
        [Keycode(Platform = "Linux", Keycode = 0x0065)]
        E,

        [Keycode(Platform = "OSX", Keycode = 0x03)]
        [Keycode(Platform = "Windows", Keycode = 0x46)]
        [Keycode(Platform = "Linux", Keycode = 0x0066)]
        F,

        [Keycode(Platform = "OSX", Keycode = 0x05)]
        [Keycode(Platform = "Windows", Keycode = 0x47)]
        [Keycode(Platform = "Linux", Keycode = 0x0067)]
        G,

        [Keycode(Platform = "OSX", Keycode = 0x04)]
        [Keycode(Platform = "Windows", Keycode = 0x48)]
        [Keycode(Platform = "Linux", Keycode = 0x0068)]
        H,

        [Keycode(Platform = "OSX", Keycode = 0x22)]
        [Keycode(Platform = "Windows", Keycode = 0x49)]
        [Keycode(Platform = "Linux", Keycode = 0x0069)]
        I,

        [Keycode(Platform = "OSX", Keycode = 0x26)]
        [Keycode(Platform = "Windows", Keycode = 0x4A)]
        [Keycode(Platform = "Linux", Keycode = 0x006A)]
        J,

        [Keycode(Platform = "OSX", Keycode = 0x28)]
        [Keycode(Platform = "Windows", Keycode = 0x4B)]
        [Keycode(Platform = "Linux", Keycode = 0x006B)]
        K,

        [Keycode(Platform = "OSX", Keycode = 0x25)]
        [Keycode(Platform = "Windows", Keycode = 0x4C)]
        [Keycode(Platform = "Linux", Keycode = 0x006C)]
        L,

        [Keycode(Platform = "OSX", Keycode = 0x2E)]
        [Keycode(Platform = "Windows", Keycode = 0x4D)]
        [Keycode(Platform = "Linux", Keycode = 0x006D)]
        M,

        [Keycode(Platform = "OSX", Keycode = 0x2D)]
        [Keycode(Platform = "Windows", Keycode = 0x4E)]
        [Keycode(Platform = "Linux", Keycode = 0x006E)]
        N,

        [Keycode(Platform = "OSX", Keycode = 0x1F)]
        [Keycode(Platform = "Windows", Keycode = 0x4F)]
        [Keycode(Platform = "Linux", Keycode = 0x006F)]
        O,

        [Keycode(Platform = "OSX", Keycode = 0x23)]
        [Keycode(Platform = "Windows", Keycode = 0x50)]
        [Keycode(Platform = "Linux", Keycode = 0x0070)]
        P,

        [Keycode(Platform = "OSX", Keycode = 0x0C)]
        [Keycode(Platform = "Windows", Keycode = 0x51)]
        [Keycode(Platform = "Linux", Keycode = 0x0071)]
        Q,

        [Keycode(Platform = "OSX", Keycode = 0x0F)]
        [Keycode(Platform = "Windows", Keycode = 0x52)]
        [Keycode(Platform = "Linux", Keycode = 0x0072)]
        R,

        [Keycode(Platform = "OSX", Keycode = 0x01)]
        [Keycode(Platform = "Windows", Keycode = 0x53)]
        [Keycode(Platform = "Linux", Keycode = 0x0073)]
        S,

        [Keycode(Platform = "OSX", Keycode = 0x11)]
        [Keycode(Platform = "Windows", Keycode = 0x54)]
        [Keycode(Platform = "Linux", Keycode = 0x0074)]
        T,

        [Keycode(Platform = "OSX", Keycode = 0x20)]
        [Keycode(Platform = "Windows", Keycode = 0x55)]
        [Keycode(Platform = "Linux", Keycode = 0x0075)]
        U,

        [Keycode(Platform = "OSX", Keycode = 0x09)]
        [Keycode(Platform = "Windows", Keycode = 0x56)]
        [Keycode(Platform = "Linux", Keycode = 0x0076)]
        V,

        [Keycode(Platform = "OSX", Keycode = 0x0D)]
        [Keycode(Platform = "Windows", Keycode = 0x57)]
        [Keycode(Platform = "Linux", Keycode = 0x0077)]
        W,

        [Keycode(Platform = "OSX", Keycode = 0x07)]
        [Keycode(Platform = "Windows", Keycode = 0x58)]
        [Keycode(Platform = "Linux", Keycode = 0x0078)]
        X,

        [Keycode(Platform = "OSX", Keycode = 0x10)]
        [Keycode(Platform = "Windows", Keycode = 0x59)]
        [Keycode(Platform = "Linux", Keycode = 0x0079)]
        Y,

        [Keycode(Platform = "OSX", Keycode = 0x06)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x007a)]
        Z,

        
        //Numbers
        [Keycode(Platform = "OSX", Keycode = 0x30)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0030)]
        Zero,

        [Keycode(Platform = "OSX", Keycode = 0x31)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0031)]
        One,
        
        [Keycode(Platform = "OSX", Keycode = 0x32)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0032)]
        Two,
        
        [Keycode(Platform = "OSX", Keycode = 0x33)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0033)]
        Three,
        
        [Keycode(Platform = "OSX", Keycode = 0x34)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0034)]
        Four,
        
        [Keycode(Platform = "OSX", Keycode = 0x35)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0035)]
        Five,
        
        [Keycode(Platform = "OSX", Keycode = 0x36)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0036)]
        Six,
        
        [Keycode(Platform = "OSX", Keycode = 0x37)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0037)]
        Seven,
        
        [Keycode(Platform = "OSX", Keycode = 0x38)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0038)]
        Eight,
        
        [Keycode(Platform = "OSX", Keycode = 0x39)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0039)]
        Nine,


        //Symbols
        [Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0xBC)]
        [Keycode(Platform = "Linux", Keycode = 0x002c)]
        Comma,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003a)]
        Colon,

        [Keycode(Platform = "OSX", Keycode = 0x29)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003a)]
        Semicolon,

        [Keycode(Platform = "OSX", Keycode = 0x2F)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x002e)]
        Dot,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0024)]
        Dollar,

        [Keycode(Platform = "OSX", Keycode = 0x2C)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x002f)]
        Slash,

        [Keycode(Platform = "OSX", Keycode = 0x2A)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x005c)]
        Backslash,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0025)]
        Percent,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003c)]
        LessThan,

        [Keycode(Platform = "OSX", Keycode = 0x18)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003d)]
        Equal,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003e)]
        GreaterThan,

        [Keycode(Platform = "OSX", Keycode = 0x27)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0022)]
        QuotationMark,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0028)]
        OpenParenthesis,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x0029)]
        CloseParenthesis,

        [Keycode(Platform = "OSX", Keycode = 0x21)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x005b)]
        OpenBracket,

        [Keycode(Platform = "OSX", Keycode = 0x1E)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x005d)]
        CloseBracket,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x007b)]
        OpenBrace,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x007d)]
        CloseBrace,

        //[Keycode(Platform = "OSX", Keycode = 0x2B)]
        [Keycode(Platform = "Windows", Keycode = 0x5A)]
        [Keycode(Platform = "Linux", Keycode = 0x003f)]
        Interrogation,


        /* Modifiers */
        [Keycode(Platform = "OSX", Keycode = 0x37)]
        [Keycode(Platform = "Windows", Keycode = 0x5b)]
        Command,

        [Keycode(Platform = "OSX", Keycode = 0x38)]
        [Keycode(Platform = "Windows", Keycode = 0xA0, ScanCode = 0xAA)]
        [Keycode(Platform = "Linux", ScanCode = 0xffe1)]
        Shift,

        [Keycode(Platform = "OSX", Keycode = 0x3B)]
        [Keycode(Platform = "Windows", Keycode = 0xA2, ScanCode = 0x9D)]
        [Keycode(Platform = "Linux", Keycode = 0xffe3)]
        Control,

        [Keycode(Platform = "OSX", Keycode = 0x3A)]
        [Keycode(Platform = "Windows", Keycode = 0x12, ScanCode = 0xB8)]
        [Keycode(Platform = "Linux", Keycode = 0xffe9)]
        Option,

        [Keycode(Platform = "Windows", Keycode = 0x12, ScanCode = 0xB8)]
        [Keycode(Platform = "OSX", Keycode = 0x3A)]
        [Keycode(Platform = "Linux", Keycode = 0xffe9)]
        Alt,

        [Keycode(Platform = "OSX", Keycode = 0x39)]
        [Keycode(Platform = "Windows", Keycode = 0x14)]
        [Keycode(Platform = "Linux", Keycode = 0xffe5)]
        CapsLock,


        /* Other keys */

        [Keycode(Platform = "OSX", Keycode = 0x30)]
        [Keycode(Platform = "Windows", Keycode = 0x09, ScanCode = 0x8F)]
        [Keycode(Platform = "Linux", Keycode = 0xff09)]
        Tab,
        
        [Keycode(Platform = "OSX", Keycode = 0x33)]
        [Keycode(Platform = "Windows", Keycode = 0x2E)]
        [Keycode(Platform = "Linux", Keycode = 0xffff)]
        Delete,
        
        [Keycode(Platform = "OSX", Keycode = 0x35)]
        [Keycode(Platform = "Windows", Keycode = 0x1B)]
        [Keycode(Platform = "Linux", Keycode = 0xff1b)]
        Esc,

        //[Keycode(Platform = "OSX", Keycode = 0x35)]
        [Keycode(Platform = "Windows", Keycode = 0x2D)]
        [Keycode(Platform = "Linux", Keycode = 0xff9e)]
        Insert,

        [Keycode(Platform = "OSX", Keycode = 0x73)]
        [Keycode(Platform = "Windows", Keycode = 0xAC)]
        [Keycode(Platform = "Linux", Keycode = 0xff50)]
        Home,

        [Keycode(Platform = "OSX", Keycode = 0x77)]
        [Keycode(Platform = "Windows", Keycode = 0x23)]
        [Keycode(Platform = "Linux", Keycode = 0xff57)]
        End,

        [Keycode(Platform = "OSX", Keycode = 0x74)]
        [Keycode(Platform = "Windows", Keycode = 0x21)]
        [Keycode(Platform = "Linux", Keycode = 0xff55)]
        PageUp,

        [Keycode(Platform = "OSX", Keycode = 0x79)]
        [Keycode(Platform = "Windows", Keycode = 0x22)]
        [Keycode(Platform = "Linux", Keycode = 0xff56)]
        PageDown,

        [Keycode(Platform = "Windows", Keycode = 0x08, ScanCode = 0x8E)]
        [Keycode(Platform = "Linux", Keycode = 0xff08)]
        Backspace,

        [Keycode(Platform = "OSX", Keycode = 0x45)]
        [Keycode(Platform = "Windows", Keycode = 0xBB)]
        [Keycode(Platform = "Linux", Keycode = 0x002b)]
        Plus,

        [Keycode(Platform = "OSX", Keycode = 0x4E)]
        [Keycode(Platform = "Windows", Keycode = 0xBD)]
        [Keycode(Platform = "Linux", Keycode = 0x002d)]
        Minus,

        [Keycode(Platform = "Windows", Keycode = 0x2C)]
        [Keycode(Platform = "Linux", Keycode = 0xfd1d)]
        PrintScreen,

        [Keycode(Platform = "Windows", Keycode = 0x91)]
        [Keycode(Platform = "Linux", Keycode = 0xff14)]
        ScrollLock,

        [Keycode(Platform = "Windows", Keycode = 0x90)]
        [Keycode(Platform = "Linux", Keycode = 0xff14)]
        NumLock,

        [Keycode(Platform = "Windows", Keycode = 0x13)]
        [Keycode(Platform = "Linux", Keycode = 0xff13)]
        Pause,


        /* F keys */

        [Keycode(Platform = "OSX", Keycode = 0x7A)]
        [Keycode(Platform = "Windows", Keycode = 0x70)]
        [Keycode(Platform = "Linux", Keycode = 0xffbe)]
        F1,

        [Keycode(Platform = "OSX", Keycode = 0x78)]
        [Keycode(Platform = "Windows", Keycode = 0x71)]
        [Keycode(Platform = "Linux", Keycode = 0xffbf)]
        F2,

        [Keycode(Platform = "OSX", Keycode = 0x63)]
        [Keycode(Platform = "Windows", Keycode = 0x72)]
        [Keycode(Platform = "Linux", Keycode = 0xffc0)]
        F3,

        [Keycode(Platform = "OSX", Keycode = 0x76)]
        [Keycode(Platform = "Windows", Keycode = 0x73)]
        [Keycode(Platform = "Linux", Keycode = 0xffc1)]
        F4,

        [Keycode(Platform = "OSX", Keycode = 0x60)]
        [Keycode(Platform = "Windows", Keycode = 0x74)]
        [Keycode(Platform = "Linux", Keycode = 0xffc2)]
        F5,

        [Keycode(Platform = "OSX", Keycode = 0x61)]
        [Keycode(Platform = "Windows", Keycode = 0x75)]
        [Keycode(Platform = "Linux", Keycode = 0xffc3)]
        F6,

        [Keycode(Platform = "OSX", Keycode = 0x62)]
        [Keycode(Platform = "Windows", Keycode = 0x76)]
        [Keycode(Platform = "Linux", Keycode = 0xffc4)]
        F7,

        [Keycode(Platform = "OSX", Keycode = 0x64)]
        [Keycode(Platform = "Windows", Keycode = 0x77)]
        [Keycode(Platform = "Linux", Keycode = 0xffc5)]
        F8,

        [Keycode(Platform = "OSX", Keycode = 0x65)]
        [Keycode(Platform = "Windows", Keycode = 0x78)]
        [Keycode(Platform = "Linux", Keycode = 0xffc6)]
        F9,

        [Keycode(Platform = "OSX", Keycode = 0x6D)]
        [Keycode(Platform = "Windows", Keycode = 0x79)]
        [Keycode(Platform = "Linux", Keycode = 0xffc7)]
        F10,
        
        [Keycode(Platform = "OSX", Keycode = 0x67)]
        [Keycode(Platform = "Windows", Keycode = 0x7A)]
        [Keycode(Platform = "Linux", Keycode = 0xffc8)]
        F11,

        [Keycode(Platform = "OSX", Keycode = 0x6F)]
        [Keycode(Platform = "Windows", Keycode = 0x7B)]
        [Keycode(Platform = "Linux", Keycode = 0xffc9)]
        F12,

        [Keycode(Platform = "OSX", Keycode = 0x7e)]
        [Keycode(Platform = "Windows", Keycode = 0x26)]
        Up,

        [Keycode(Platform = "OSX", Keycode = 0x7d)]
        [Keycode(Platform = "Windows", Keycode = 0x28)]
        Down,

        [Keycode(Platform = "OSX", Keycode = 0x7b)]
        [Keycode(Platform = "Windows", Keycode = 0x25)]
        Left,

        [Keycode(Platform = "OSX", Keycode = 0x7c)]
        [Keycode(Platform = "Windows", Keycode = 0x27)]
        Right,
    }

    public static class KeysExtensions 
    {
        public static KeycodeAttribute GetKeycode(this Key key)
        {
            var enumType = typeof(Key);
            var memberInfos = enumType.GetMember(key.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            return enumValueMemberInfo
                .GetCustomAttributes(typeof(KeycodeAttribute), false)
                .Cast<KeycodeAttribute>()
                .First(k => RuntimeInformation.IsOSPlatform(OSPlatform.Create(k.Platform)));
        }
    }
}