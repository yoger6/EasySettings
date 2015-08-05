using System;
using EasySettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SettingsOperationsTests
    {
        private Settings _settings;

        [TestInitialize]
        public void TestSetup()
        {
            _settings = new Settings();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewSettingWithNullNameThrowsException()
        {
            _settings.Add(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewSettingWithEmptyOrWhiteSpaceNameThrowsException()
        {
            _settings.Add("", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewSettingWithNullValueThrowsException()
        {
            _settings.Add("null setting", null);
        }

        [TestMethod]
        public void AddNewSettingIsPersisted()
        {
            _settings.Add("setting", "value");
            var settingsAmount =_settings.Collection.Count;

            Assert.AreEqual(1, settingsAmount);
        }

        [TestMethod]
        public void RetrieveSetValueSuccess()
        {
            _settings.Add("number", 1);

            var number = _settings.Get("number");

            Assert.AreEqual(1, number);
        }
    }
}
