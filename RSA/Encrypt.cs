using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    public static class Encrypt
    {
        public static RSAParameters publicKey;
        public static RSAParameters privateKey;

        public static void GenerateKeys()
        {
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);

            }
        }

        public static byte[] EncryptMessage(byte[] message)
        {
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(message, false);
            }
        }

        public static byte[] DecryptMessage(byte[] encryptMessage)
        {
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(encryptMessage, false);
            }
        }
    }
}
