using EasySettings;
using EasySettings.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FileLoadSettingsTests
    {
        private XmlSettingsReader _reader;

        [TestInitialize]
        public void TestSetup()
        {
            var settings = new Settings();
            settings.Add("some string", "string value");
            settings.Add("some int", 1);
            settings.Add("some float", 1.3f);
            var writer = new XmlSettingsWriter();
            writer.Write(settings);
             _reader = new XmlSettingsReader();
        }

        [TestMethod]
        public void LoadSettingsFileHasCorrectAmountOfItems()
        {
            var settings = _reader.Read();

            Assert.AreEqual(3, settings.GetAll().Count);
        }

        [TestMethod]
        public void CanRetrieveLoadedValues()
        {
            var settings = _reader.Read();
            var retrievedString = settings.Get("some string");
            var retrievedInt = settings.Get("some int");
            var retrievedFloat = settings.Get("some float");

            Assert.AreEqual("string value", retrievedString);
            Assert.AreEqual(1, retrievedInt);
            Assert.AreEqual(1.3f, retrievedFloat);
        }
    }
}
