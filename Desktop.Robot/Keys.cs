using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Desktop.Robot
{
    public enum Keys
    {
        [Keycode(Platform = "OSX", Value = 0x37)]
        Command,

        [Keycode(Platform = "OSX", Value = 0x30)]
        Tab,
        
        [Keycode(Platform = "OSX", Value = 0x33)]
        Delete,
        
        [Keycode(Platform = "OSX", Value = 0x35)]
        Esc,
        
        [Keycode(Platform = "OSX", Value = 0x38)]
        Shift,
        
        [Keycode(Platform = "OSX", Value = 0x3A)]
        Option,
        
        [Keycode(Platform = "OSX", Value = 0x3B)]
        Control,

        [Keycode(Platform = "OSX", Value = 0x7A)]
        F1,
        
        [Keycode(Platform = "OSX", Value = 0x78)]
        F2,
        
        [Keycode(Platform = "OSX", Value = 0x63)]
        F3,
        
        [Keycode(Platform = "OSX", Value = 0x76)]
        F4,
        
        [Keycode(Platform = "OSX", Value = 0x60)]
        F5,
        
        [Keycode(Platform = "OSX", Value = 0x61)]
        F6,
        
        [Keycode(Platform = "OSX", Value = 0x62)]
        F7,
        
        [Keycode(Platform = "OSX", Value = 0x64)]
        F8,
        
        [Keycode(Platform = "OSX", Value = 0x65)]
        F9,
        
        [Keycode(Platform = "OSX", Value = 0x6D)]
        F10,
        
        [Keycode(Platform = "OSX", Value = 0x67)]
        F11,
                
        [Keycode(Platform = "OSX", Value = 0x6F)]
        F12,
    }

    public static class KeysExtensions 
    {
        private static Dictionary<string, OSPlatform> MapOS = new Dictionary<string, OSPlatform>
        {
            {"OSX", OSPlatform.OSX},
            {"Linux", OSPlatform.Linux},
            {"Windows", OSPlatform.Windows},
        };

        public static int ToChar(this Keys key)
        {
            var enumType = typeof(Keys);
            var memberInfos = enumType.GetMember(key.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo
                .GetCustomAttributes(typeof(KeycodeAttribute), false)
                .Cast<KeycodeAttribute>()
                .ToList();

            var keycode = valueAttributes
                .First(k => RuntimeInformation.IsOSPlatform(MapOS[k.Platform]));

            System.Console.Write(keycode.Value);

            return keycode.Value;
        }
    }
}