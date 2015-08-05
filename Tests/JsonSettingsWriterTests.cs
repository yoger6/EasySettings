using System.IO;
using System.Net;
using EasySettings;
using EasySettings.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JsonSettingsWriterTests
    {
        private string _directory;
        private JsonSettingsWriter _writer;
        private Settings _settings;

        [TestInitialize]
        public void TestSetup()
        {
            _directory = "D:\\Settings";
            _settings = new Settings();
            _settings.Add("some string", "example of my poetry");
            _settings.Add("some int", 1);
            _writer = new JsonSettingsWriter(_directory);
            _writer.Write(_settings);
        }

        [TestMethod]
        public void SaveSettingsCreatesActualFile()
        {
            var fileExists = File.Exists(_directory + "\\Settings.json");
            Assert.IsTrue(fileExists);    
        }

        [TestCleanup]
        public void Cleanup()
        {
            var path = _directory + "\\Settings.json";

            if(File.Exists(path))
                File.Delete(path);
            if(Directory.Exists(_directory))
                Directory.Delete(_directory);
        }
    }
}
