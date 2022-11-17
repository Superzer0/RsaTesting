using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    internal static class ConvertRsa
    {
        // PKCS#1 format
        public static string FromPemToPkcs1Pem(string key)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportFromPem(key);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN RSA PUBLIC KEY-----");
            buffer.AppendLine(Convert.ToBase64String(
                rsaPublicKey.ExportRSAPublicKey(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END RSA PUBLIC KEY-----");

            return buffer.ToString();
        }

        public static string FromPublicPemToPkcs8Pem(string key)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportFromPem(key);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportSubjectPublicKeyInfo(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END PUBLIC KEY-----");

            return buffer.ToString();
        }


        public static string FromPublicPkcs8ToPkcs1Pem(string key)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportSubjectPublicKeyInfo(System.Convert.FromBase64String(key), out _);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN RSA PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportRSAPublicKey(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END RSA PUBLIC KEY-----");

            return buffer.ToString();
        }


        public static string FromPrivatePkcs8ToPkcs1Pem(string key)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportPkcs8PrivateKey(System.Convert.FromBase64String(key), out _);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN RSA PRIVATE KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportRSAPrivateKey(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END RSA PRIVATE KEY-----");

            return buffer.ToString();
        }

        // PKCS#8 format
        public static string FromPublicPkcs1ToPkcs8Pem(string key)
        {
            var rsaPublicKey = RSA.Create();
            rsaPublicKey.ImportRSAPublicKey(System.Convert.FromBase64String(key), out _);

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                rsaPublicKey.ExportSubjectPublicKeyInfo(),
                Base64FormattingOptions.InsertLineBreaks));
            buffer.AppendLine("-----END PUBLIC KEY-----");

            return buffer.ToString();
        }

        public static string FromCertificatePemToPkcs8Pem(string certificatePemPath)
        {
            var cert = X509Certificate2.CreateFromPem(File.ReadAllText(certificatePemPath));
            var rsaKey = cert.PublicKey.GetRSAPublicKey();

            // X509Certificate2.CreateFromPemFile() use this for loading a private key and certificate info

            var buffer = new StringBuilder();
            buffer.AppendLine("-----BEGIN PUBLIC KEY-----");
            buffer.AppendLine(System.Convert.ToBase64String(
                cert.PublicKey.ExportSubjectPublicKeyInfo(),
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
