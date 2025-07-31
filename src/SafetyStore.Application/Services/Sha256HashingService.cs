using SafetyStore.Domain.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace SafetyStore.Application.Services
{
    public class Sha256HashingService : IHashingService
    {
        public string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256Hash.ComputeHash(buffer);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
