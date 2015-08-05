using System;
using System.Collections.Generic;
using EasySettings.Interfaces;
using EasySettings.IO;

namespace EasySettings
{
    public sealed class Settings
    {
        private Dictionary<string, object> _settings;
        public Dictionary<string, object> Collection => _settings;


        public Settings()
        {
            _settings = new Dictionary<string, object>();
        }


        public void Add(string key, object obj)
        {
            if(key == null)
                throw new ArgumentNullException(nameof(key), "Setting key must not be null.");
            if(string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key), "Setting key must not be empty or whitespace.");
            if(obj == null)
                throw new ArgumentNullException(nameof(obj), "Setting object must not be null.");

            _settings.Add(key, obj);
        }

        public object Get(string key)
        {
            return _settings[key];
        }

        public void Save()
        {
            SaveSettings(new XmlSettingsWriter());
        }

        public void Save(ISettingsWriter writer)
        {
            SaveSettings(writer);
        }

        private void SaveSettings(ISettingsWriter writer)
        {
            writer.Write(this);
        }

        public void Load()
        {
            LoadSettings(new XmlSettingsReader());
        }

        public void Load(ISettingsReader reader)
        {
            LoadSettings(reader);
        }

        private void LoadSettings(ISettingsReader reader)
        {
            _settings = reader.Read();
        }
    }
}
