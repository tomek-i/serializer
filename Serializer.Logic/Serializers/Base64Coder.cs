using System;
using System.Text;

namespace TI.Serializer.Logic.Serializers
{
    public class Base64Coder
    {
        public string Decode(string base64text)
        {
            var bytes = Convert.FromBase64String(base64text);
            return new string(Encoding.UTF8.GetChars(bytes));
        }



        public string Encode(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }
    }
}