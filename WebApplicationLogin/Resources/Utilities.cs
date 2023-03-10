using System.Security.Cryptography;
using System.Text;

namespace WebApplicationLogin.Resources
{
    public class Utilities
    {
        public static string EncryptKey(string key) {
            StringBuilder sk = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) {  // Create hash to encrypt
                Encoding enc = Encoding.UTF8;   // Enconding UTF8

                byte[] result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                {
                    sk.Append(b.ToString("x2"));    // Concatenate the result -- x2 format in hexadecimal
                }
            }

            return sk.ToString();        
        }
    }
}
