using System;
using System.Text;

namespace RSA
{
    class Program
    {
        public static void Main(string[] args)
        {
            string msg = "Hello world";
            Encrypt.GenerateKeys();

            //Convierte el mensaje de tipo string a una cadena de bytes utilizando la codificacion UTF_8
            var encoded = Encoding.Unicode.GetBytes(msg);
            var encrypted = Encrypt.EncryptMessage(encoded);
            var decrypted = Encrypt.DecryptMessage(encrypted);

            Console.WriteLine("Original: " + msg);
            Console.WriteLine("Encriptado " + BitConverter.ToString(encrypted));
            Console.WriteLine("Desencriptado " + Encoding.Unicode.GetString(decrypted));
        }
    }
}
