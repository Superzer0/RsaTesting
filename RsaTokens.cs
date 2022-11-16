using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal static class RsaTokens
    {
        public static bool ValidateToken(string token, string certificatePath)
        {
            try
            {
                var cert = X509Certificate2.CreateFromPem(File.ReadAllText(certificatePath));
                var rsaKey = cert.PublicKey.GetRSAPublicKey();

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "UsersAPI",
                    ValidateAudience = true,
                    ValidAudience = "UsersAPI",
                    ValidateLifetime = true,
                    IssuerSigningKey = new RsaSecurityKey(rsaKey),
                    RequireExpirationTime = true,
                }, out _);

                return true;
            }
            catch (SecurityTokenValidationException e)
            {
                Console.WriteLine("Token not valid");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static string GenerateAccessToken(IEnumerable<Claim> claims, string pemPrivateKeyPath)
        {
            const string issuer = "UsersAPI";
            const string audience = "UsersAPI";
            var expires = DateTime.Now.AddDays(1);

            var certificate = X509Certificate2.CreateFromPemFile(pemPrivateKeyPath);
            if (!certificate.HasPrivateKey)
            {
                throw new InvalidOperationException("Private key not there");
            }

            var signingCredentials =
                new SigningCredentials(new RsaSecurityKey(certificate.GetRSAPrivateKey()), SecurityAlgorithms.RsaSha256)
                {
                    CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
                };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
