using System;
using EasySettings;
using EasySettings.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JsonSettingsReaderTests
    {
        private Settings _settings;

        [TestInitialize]
        public void TestSetup()
        {
            var settings = new Settings();
            settings.Add("some string", "example of my poetry");
            settings.Add("some int", 1);
            var writer = new JsonSettingsWriter();
            writer.Write(settings);
            var reader = new JsonSettingsFileReader();
            _settings = new Settings();
            _settings.Load(reader);
        }

        [TestMethod]
        public void LoadedSettingsHaveCorrectAmoutOfItems()
        {
            Assert.AreEqual(2, _settings.Collection.Count);
        }

        [TestMethod]
        public void LoadedSettingsMatchSavedValues()
        {
            var someString = _settings.Get("some string");
            var someInt = _settings.Get("some int");

            Assert.AreEqual("example of my poetry", someString);
            Assert.AreEqual((long)1, someInt);
        }
    }
}
