using System;
using System.IO;
using EasySettings;
using EasySettings.Exceptions;
using EasySettings.Interfaces;
using EasySettings.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FileSaveSettingsTests
    {
        private Settings _settings;
        private ISettingsWriter _writer;
        private const string CustomDirectoryPath = "D:\\Custom";

        [TestInitialize]
        public void TestSetup()
        {
            _settings = new Settings();
            _writer = new XmlSettingsWriter();
        }

        [TestMethod]
        public void FileHelperProvidesNonEmptyPath()
        {
            var helper= new SettingsFileHelper();
            var path = helper.Directory;

            Assert.IsFalse(string.IsNullOrEmpty(path));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptySettingsException))]
        public void SavingEmptySettingsThrowsException()
        {
            _writer.Write(_settings);
        }

        [TestMethod]
        public void SavingSettingsCreatesFileInProgramDirectory()
        {
            var helper = new SettingsFileHelper();
            _settings.Add("number", 1);
        
            _writer.Write(_settings);

            var fileExists = File.Exists(helper.Directory + "Settings.xml");
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void SaveSettingsInSpecificDirectoryCreatesFile()
        {
            _writer = new XmlSettingsWriter(CustomDirectoryPath);
            _settings.Add("number", 1);

            _writer.Write(_settings);

            var fileExists = File.Exists(CustomDirectoryPath + "\\Settings.xml");
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveSettingsInSpecificDirectoryWithInvalidPathFails()
        {
            var customDirectory = "C:\\cant:Create:Me";
            _writer = new XmlSettingsWriter(customDirectory);
            _settings.Add("number", 1);

            _writer.Write(_settings);
        }

        [TestCleanup]
        public void Cleanup()
        {
            var path = Path.Combine(CustomDirectoryPath, "Settings.xml");

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            if (Directory.Exists(CustomDirectoryPath))
            {
                Directory.Delete(CustomDirectoryPath);
            }
        }
    }
}
