using System;
using System.IO;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordManager.Tools
{
    public static class EncryptionHelper
    {
        private static readonly int _keySize = 256;
        public static byte[] EncryptStringToBytes(byte[] data, string pass, byte[] salt, byte[] iv)
        {
            using var rij = new RijndaelManaged()
            {
                KeySize = _keySize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            using var rfc = new Rfc2898DeriveBytes(pass, salt);
            rij.Key = rfc.GetBytes(_keySize / 8);
            rij.IV = iv;

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, rij.CreateEncryptor(), CryptoStreamMode.Write);

            using (var bw = new BinaryWriter(cs))
            {
                bw.Write(data);
            }

            return ms.ToArray();
        }

        public static byte[] Decrypt(byte[] data, string pass, byte[] salt, byte[] iv)
        {
            using var rij = new RijndaelManaged()
            {
                KeySize = _keySize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            using var rfc = new Rfc2898DeriveBytes(pass, salt);
            rij.Key = rfc.GetBytes(_keySize / 8);
            rij.IV = iv;

            using var ms = new MemoryStream(data);
            using var cs = new CryptoStream(ms, rij.CreateDecryptor(), CryptoStreamMode.Read);

            using var br = new BinaryReader(cs);
            return br.ReadBytes(data.Length);
        }
    }
}