using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast_Server
{
    public class Decryption
    {
        /*
        public static string Encrypt(string str_input)
        {
            char[] char_input = str_input.ToCharArray();
            var input_withIndex = char_input.Select((val, index) => new { val, index }).ToArray();
            var char_input_encrypted = input_withIndex.Select(c => c.val + c.index +
                  (input_withIndex.Length > c.index + 1 ? input_withIndex[c.index + 1].val % 2 : 0)).Select(c => (char)c).ToArray();
            string resVal = new string(char_input_encrypted);
            return resVal;
        }
        */
        public static string Decrypt(string str_input)
        {
            char[] char_input = str_input.ToCharArray();
            int length = char_input.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                char_input[i] = (char)(char_input[i] - i - (i == length - 1 ? 0 : char_input[i + 1] % 2));
            }
            string resVal = new string(char_input);
            return resVal;
        }
    }
}
