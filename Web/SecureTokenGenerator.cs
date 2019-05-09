using System.Linq;
using System.Security.Cryptography;

namespace WebApplication2
{
    public interface ISecureTokenGenerator
    {
        string Generate(int length);
    }
    public class SecureTokenGenerator : ISecureTokenGenerator
    {
        public string Generate(int length)
        {
            const string availableChars =
                "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_-";
            using (var tokenGenerator = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[256];
                tokenGenerator.GetBytes(bytes);
                var chars = bytes.Select(b => availableChars[b % availableChars.Length]);
                var token = new string(chars.ToArray());
                return token.Substring(0,length);
            }
        }
    }
}