using System.Collections.Generic;
using System.Xml.Serialization;
using EasySettings.Interfaces;

namespace EasySettings.IO
{
    public class XmlSettingsReader : ISettingsReader
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(DictionarySerializationHelper));
        private readonly SettingsFileHelper _fileHelper = new XmlSettingsFileHelper();

        public XmlSettingsReader() { }

        public XmlSettingsReader(string path)
        {
            _fileHelper.Directory = path;
        }

        public Dictionary<string, object> Read()
        {
            using (var stream = _fileHelper.GetReadStream())
            {
                var dictionaryHelper = (DictionarySerializationHelper)_serializer.Deserialize(stream);
                return dictionaryHelper.GetDictionary();
            }
        }
    }
}
