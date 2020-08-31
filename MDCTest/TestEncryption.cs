using MojoDesignCollection.Models.Security;
using NUnit.Framework;

namespace MDCTest
{
    [TestFixture]
    public class TestEncryption
    {
        [Test]
        public void EncryptDecryptData()
        {
            var password = "Test123!@#";
            Encryption encryption = new Encryption(password);
            var encryptedData = encryption.EncryptedData;
            Assert.AreNotEqual(encryptedData, password);

            var decryptedData = encryption.GetDecryptedData(encryptedData);
            Assert.AreEqual(password, decryptedData);
        }
    }
}
