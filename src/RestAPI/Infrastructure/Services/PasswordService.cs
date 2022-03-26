using Domain.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions options;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            this.options = options.Value;
        }

        public string HashingPass(string pass)
        {
            // Create salt
            using var rng = new RNGCryptoServiceProvider();
            byte[] salt;
            rng.GetBytes(salt = new byte[options.SaltSize]);
            using var encrypt = new Rfc2898DeriveBytes(pass, salt, options.Iterations);
            var hash = encrypt.GetBytes(options.KeySize);

            // Combine salt and hash
            var hashBytes = new byte[options.SaltSize + options.KeySize];
            Array.Copy(salt, 0, hashBytes, 0, options.SaltSize);
            Array.Copy(hash, 0, hashBytes, options.SaltSize, options.KeySize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return $"${options.Version}{options.Iterations}${base64Hash}";
        }

        public bool CheckPass(string saved, string validate)
        {
            if (!saved.Contains(options.Version))
                throw new NotSupportedException("Tipo de hash No soportado.");

            // Extract iteration and Base64 string
            var splittedHashString = saved.Replace(options.Version, "").Split('$');
            var iterations = int.Parse(splittedHashString[1]);
            var base64Hash = splittedHashString[2];

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[options.SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, options.SaltSize);

            // Create hash with given salt
            using var encrypt = new Rfc2898DeriveBytes(validate, salt, iterations);
            var hash = encrypt.GetBytes(options.KeySize);
            for (var i = 0; i < options.KeySize; i++)
            {
                if (hashBytes[i + options.SaltSize] != hash[i]) return false;
            }
            return true;
        }
    }
}
