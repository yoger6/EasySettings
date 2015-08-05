using System.IO;
using EasySettings.Exceptions;
using EasySettings.Interfaces;
using Newtonsoft.Json;

namespace EasySettings.IO
{
    public class JsonSettingsWriter : ISettingsWriter
    {
        private readonly JsonSerializer _serializer = new JsonSerializer();
        private readonly SettingsFileHelper _fileHelper = new JsonSettingsFileHelper();

        public JsonSettingsWriter() { }

        public JsonSettingsWriter(string path)
        {
            _fileHelper.Directory = path;
        }

        public void Write(Settings settings)
        {
            if (settings.Collection.Count == 0)
                throw new EmptySettingsException("Cannot write empty settings file.");

            using (var stream = _fileHelper.GetWriteStream())
            using (var writer = new StreamWriter(stream))
            {
                _serializer.Serialize(writer, settings.Collection);
            }
        }
    }
}
