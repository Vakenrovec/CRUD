using CodingPluginInterface;
using System;

namespace Base64Plugin
{
    public class Base64Plugin: ICodingPlugin
    {
        public string Code(byte[] arr)
        {
            return Convert.ToBase64String(arr);
        }
        public byte[] Decode(string s)
        {
            return Convert.FromBase64String(s);
        }
        public override string ToString()
        {
            return "Base64";
        }
        public string Extension { get; } = ".base64";
    }
}
