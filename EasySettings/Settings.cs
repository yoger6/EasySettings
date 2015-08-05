using System;
using System.Collections.Generic;

namespace EasySettings
{
    public class Settings
    {
        private Dictionary<string, object> _settings;

        public Settings()
        {
            _settings = new Dictionary<string, object>();
        }

        public Settings(Dictionary<string, object> settings)
        {
            _settings = settings;
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

        public Dictionary<string, object> GetAll()
        {
            return _settings;
        }

    }
}
