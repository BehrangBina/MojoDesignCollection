using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Helper;
using NUnit.Framework;

namespace MDCTest
{
    class TestConvertor
    {
        [Test]
        [TestCase("tutu")]
        [TestCase("fairy")]
        public void CanConvertStringToEnum(string enumValues)
        {
            var value =Convertor.StringToCategoryEnum(enumValues);
            Assert.AreEqual(value.GetType(),typeof(CategoryEnum));
        }
    }
}
