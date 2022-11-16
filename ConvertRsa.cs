using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal static class ConvertRsa
    {
        // PKCS#1 format
        public static string FromPemToPkcs1Pem(string publicKey)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportFromPem(publicKey);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN RSA PUBLIC KEY-----");
            buffer.AppendLine(Convert.ToBase64String(
                rsaPublicKey.ExportRSAPublicKey(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END RSA PUBLIC KEY-----");

            return buffer.ToString();
        }

        public static string FromPublicPemToPkcs8Pem(string publicKey)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportFromPem(publicKey);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportSubjectPublicKeyInfo(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END PUBLIC KEY-----");

            return buffer.ToString();
        }

        // PKCS#8 format
        public static string FromPublicPkcs1ToPkcs8Pem(string publicKey)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportRSAPublicKey(System.Convert.FromBase64String(publicKey), out _);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportSubjectPublicKeyInfo(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END PUBLIC KEY-----");

            return buffer.ToString();
        }

        public static void WriteToConsole(string input, Func<string, string> convert)
        {
            var output = convert(input);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Output:");
            Console.WriteLine(output);

        }

    }
}
