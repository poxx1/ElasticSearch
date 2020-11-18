using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ElasticSearch
{
    class Crypter
    {
        public string MD5Gen(string c)
        {
            var code = new UnicodeEncoding();
            var md5 = new MD5CryptoServiceProvider();
            byte[] ByteS = code.GetBytes(c);
            byte[] Hash = md5.ComputeHash(ByteS);

            return Hash.ToString();
        }

        public string Encriptar(string c)
        {
            //A la key la puedo poner en el .config o usar el crendential manager.
            string key = "asd";
            byte[] keyArray;
            byte[] cifrar = UTF8Encoding.UTF8.GetBytes(c);

            try
            {
                var md5 = new MD5CryptoServiceProvider();
                var t = new TripleDESCryptoServiceProvider();

                keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5.Clear();

                t.Key = keyArray;
                t.Mode = CipherMode.ECB;
                t.Padding = PaddingMode.PKCS7;
                ICryptoTransform e = t.CreateEncryptor();
                byte[] resultado = e.TransformFinalBlock(cifrar, 0, cifrar.Length);
                t.Clear();

                c = Convert.ToBase64String(resultado, 0, resultado.Length);
            }
            catch (Exception e)
            {
                throw e;
            }

            return c;
        }

        public string Desencriptar(string c)
        {
            //A la key la puedo poner en el .config o usar el crendential manager.
            string key = "asd";

            try
            {
                byte[] keyArray;
                byte[] decifrar = Convert.FromBase64String(c);

                var md5 = new MD5CryptoServiceProvider();
                var t = new TripleDESCryptoServiceProvider();

                keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5.Clear();

                t.Key = keyArray;
                t.Mode = CipherMode.ECB;
                t.Padding = PaddingMode.PKCS7;

                ICryptoTransform e = t.CreateDecryptor();
                byte[] resultado = e.TransformFinalBlock(decifrar, 0, decifrar.Length);
                t.Clear();

                c = UTF8Encoding.UTF8.GetString(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }

            return c;
        }
    }
}
