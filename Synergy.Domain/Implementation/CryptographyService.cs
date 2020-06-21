using Synergy.Domain.Interfaces;
using Synergy.Domain.ServiceModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Synergy.Domain.Implementation
{
   public class CryptographyService : ICryptographyService
    {
        private readonly int _hashSize = 32;
        private readonly int _hashIterations = 128;

        #region synergy Encryption Module
        private byte[] CreateSalt()
        {
            byte[] salt;
            using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rNGCryptoServiceProvider.GetBytes(salt = new byte[_hashSize]);
            }
            return salt;
        }

        private byte[] CreateHash(string input, byte[] salt)
        {
            byte[] hash;
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(input, salt, _hashIterations))
            {
                hash = hashGenerator.GetBytes(_hashSize);
            }
            return hash;
        }
        public HashDetail GenerateHash(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            byte[] salt = CreateSalt();
            byte[] hash = CreateHash(input, salt);

            return new HashDetail { Salt = Convert.ToBase64String(salt), HashedValue = Convert.ToBase64String(hash) };
        }

        public bool ValidateHash(string input, string salt, string hashedValue)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(hashedValue))
                return false;
            byte[] saltByte = Convert.FromBase64String(salt);
            byte[] inputHash = CreateHash(input, saltByte);
            string hashedString = Convert.ToBase64String(inputHash);

            if (hashedString.Equals(hashedValue))
                return true;

            return false;

        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion
        #region flutter wave encryptionModel
        public string GetFlutterwaveEcryptionKey(string secretKey)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);


            byte[] hashedSecret = md5.ComputeHash(secretKeyBytes, 0, secretKeyBytes.Length);
            byte[] hashedSecretLast12Bytes = new byte[12];
            Array.Copy(hashedSecret, hashedSecret.Length - 12, hashedSecretLast12Bytes, 0, 12);
            String hashedSecretLast12HexString = BitConverter.ToString(hashedSecretLast12Bytes);
            hashedSecretLast12HexString = hashedSecretLast12HexString.ToLower().Replace("-", "");
            String secretKeyFirst12 = secretKey.Replace("FLWSECK-", "").Substring(0, 12);
            byte[] hashedSecretLast12HexBytes = Encoding.UTF8.GetBytes(hashedSecretLast12HexString);
            byte[] secretFirst12Bytes = Encoding.UTF8.GetBytes(secretKeyFirst12);
            byte[] combineKey = new byte[24];
            Array.Copy(secretFirst12Bytes, 0, combineKey, 0, secretFirst12Bytes.Length);
            Array.Copy(hashedSecretLast12HexBytes, hashedSecretLast12HexBytes.Length - 12, combineKey, 12, 12);
            return Encoding.UTF8.GetString(combineKey);
        }

        public string FlutterWaveEncryptData(string encryptionKey, string model)
        {
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = ASCIIEncoding.UTF8.GetBytes(encryptionKey);
            ICryptoTransform cryptoTransform = des.CreateEncryptor();
            byte[] dataBytes = ASCIIEncoding.UTF8.GetBytes(model);
            byte[] encryptedDataBytes = cryptoTransform.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
            des.Clear();
            return Convert.ToBase64String(encryptedDataBytes);
        }

        public string FlutterWaveDecryptData(string encryptedData, string encryptionKey)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = ASCIIEncoding.UTF8.GetBytes(encryptionKey);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            ICryptoTransform cryptoTransform = des.CreateDecryptor();
            byte[] EncryptDataBytes = Convert.FromBase64String(encryptedData);
            byte[] plainDataBytes = cryptoTransform.TransformFinalBlock(EncryptDataBytes, 0, EncryptDataBytes.Length);
            des.Clear();
            return ASCIIEncoding.UTF8.GetString(plainDataBytes);
        }

        #endregion

        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private const string BvnSecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVk";
        private string GenerateClientKey(int size, string keyPrefix)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return string.Concat(keyPrefix, result.ToString());
        }

        public ClientApiKey EncryptApiKey(string clientId, string keyPrefix)
        {
            //string EncryptionKey = "Ekoballs";
            byte[] clearBytes = null;
            string apiKey = "";


            apiKey = GenerateClientKey(20, keyPrefix);
            clearBytes = Encoding.UTF8.GetBytes(apiKey);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(clientId, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    return new ClientApiKey { EncryptApiKey = Convert.ToBase64String(ms.ToArray()), ApiKey = apiKey };
                }
            }
            // return clearText;
        }

        public string DecryptApiKey(string clientId, string encryptKey)
        {
            string decryptedValue = string.Empty;
            encryptKey = encryptKey.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(encryptKey);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(clientId, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    decryptedValue = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return decryptedValue;
        }

        public string EncryptBvn(string bvn)
        {


            //var key = Encoding.UTF8.GetBytes(BvnSecretKey).ToString();
            var clearBytes = Encoding.UTF8.GetBytes(bvn);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(BvnSecretKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string DecryptBvn(string encryptBvn)
        {
            string decryptedValue = string.Empty;
            // var key = Encoding.UTF8.(BvnSecretKey);
            byte[] cipherBytes = Convert.FromBase64String(encryptBvn);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(BvnSecretKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    decryptedValue = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return decryptedValue;
        }
    }
}
