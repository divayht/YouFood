using System;
using System.Security.Cryptography;
using System.Text;

namespace YouFood.Services.Security
{
    public class PasswordManager
    {
        private const string key = "9398C7F4B7297B04C8A6227D118D62DB181301ED69C9B81912E0268BE05E7E5F278E4368054BA316C09F75C903B5C204F74B5BA1F51178181FFB5FC925BEE568";

        public string password;
        public string encryptedPassword;

        public PasswordManager(string password)
        {
            this.password = password;
            this.encryptedPassword = EncodePassword(password);
        }

        public bool Validate()
        {
            return true;
        }

        private static string EncodePassword(string password)
        {
            HMACSHA1 hash = new HMACSHA1 {Key = HexToByte(key)};
            string encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));

            return encodedPassword;
        }

        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static PasswordManager Generate()
        {
            const int passwordLength = 7;
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[passwordLength];

            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            PasswordManager newPassword = new PasswordManager(new string(chars));

            return newPassword;
        }
    }
}
