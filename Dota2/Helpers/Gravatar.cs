using System.Security.Cryptography;
using System.Text;

namespace Dota2.Helpers
{
    public static class Gravatar
    {
        public static string HashEmailForGravatar(string email)
        {
            var md5hash = MD5.Create();

            var data = md5hash.ComputeHash(Encoding.Default.GetBytes(email));

            var sb = new StringBuilder();

            foreach (var t in data)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}