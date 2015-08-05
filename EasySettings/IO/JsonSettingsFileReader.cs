using System.Collections.Generic;
using System.IO;
using EasySettings.Interfaces;
using Newtonsoft.Json;

namespace EasySettings.IO
{
    public class JsonSettingsFileReader : ISettingsReader
    {
        private readonly JsonSerializer _serializer = new JsonSerializer();
        private readonly JsonSettingsFileHelper _fileHelper = new JsonSettingsFileHelper();

        public JsonSettingsFileReader() { }

        public JsonSettingsFileReader(string path)
        {
            _fileHelper.Directory = path;
        }

        public Dictionary<string, object> Read()
        {
            using (var stream = _fileHelper.GetReadStream())
            using (var reader = new StreamReader(stream))
            {
                return (Dictionary < string,object>) _serializer.Deserialize(reader, typeof(Dictionary<string,object>));
            }
        }
    }
}
