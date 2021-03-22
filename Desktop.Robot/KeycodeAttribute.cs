using System;

namespace Desktop.Robot
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class KeycodeAttribute : Attribute
    {
        public string Platform { get; set; }
        public int Keycode { get; set; }
        public int ScanCode { get; set; }
        public string Char { get; set; }
    }
}