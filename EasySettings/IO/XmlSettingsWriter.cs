using System.Xml.Serialization;
using EasySettings.Exceptions;
using EasySettings.Interfaces;

namespace EasySettings.IO
{
    public class XmlSettingsWriter : ISettingsWriter
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(DictionarySerializationHelper));
        private readonly SettingsFileHelper _fileHelper = new XmlSettingsFileHelper();

        public XmlSettingsWriter() { }

        public XmlSettingsWriter(string path)
        {
            _fileHelper.Directory = path;
        }

        public void Write(Settings settings)
        {
            if(settings.Collection.Count == 0)
                throw new EmptySettingsException("Cannot write empty settings file.");

            var dictionaryHelper = new DictionarySerializationHelper(settings.Collection);
            using (var stream = _fileHelper.GetWriteStream())
            {
                _serializer.Serialize(stream, dictionaryHelper);
            }
        }
    }
}