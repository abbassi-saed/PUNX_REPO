using System;
using System.Text;

namespace PUNX.API.Helpers
{
    public class CommonMethods
    {
        private static readonly string key = "hY1YOoglO74S7V325EKjv1wkwfLLBJKS";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password+= key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncdeData)
        {
            if (string.IsNullOrEmpty(base64EncdeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncdeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0,result.Length - key.Length);
            return result;
        }
    }
}
