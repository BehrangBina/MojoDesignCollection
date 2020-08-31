using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MojoDesignCollection.Models.Security
{
    public class Encryption
    {
        private readonly string _privateKey;
        private readonly string _publicKey;
        private readonly UnicodeEncoding _encoder = new UnicodeEncoding();
        private readonly RSACryptoServiceProvider _rsa;

        public Encryption(string data)
        {
            _rsa = new RSACryptoServiceProvider();
            _privateKey = _rsa.ToXmlString(true);
            _publicKey = _rsa.ToXmlString(false);
            EncryptedData = EncryptData(data);
        }
        public string EncryptedData { get; }

        private string EncryptData(string data)
        {
            _rsa.FromXmlString(_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = _rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var b in encryptedByteArray)
            {
                item++;
                sb.Append(b);

                if (item < length)
                    sb.Append(",");
            }
            return sb.ToString();
        }

        public string GetDecryptedData(string data)
        {
            var dataArray = data.Split(new[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            _rsa.FromXmlString(_privateKey);
            var decryptedByte = _rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }
    }
}
