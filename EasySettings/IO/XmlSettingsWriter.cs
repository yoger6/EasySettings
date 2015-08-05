using System.Xml.Serialization;
using EasySettings.Exceptions;
using EasySettings.Interfaces;

namespace EasySettings.IO
{
    public class XmlSettingsWriter : ISettingsWriter
    {

        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(DictionarySerializationHelper));
        private readonly SettingsFileHelper _fileHelper = new SettingsFileHelper();

        public XmlSettingsWriter() { }

        public XmlSettingsWriter(string path)
        {
            _fileHelper.Directory = path;
        }

        public void Write(Settings settings)
        {
            if(settings.GetAll().Count == 0)
                throw new EmptySettingsException("");

            var dictionaryHelper = new DictionarySerializationHelper(settings.GetAll());
            using (var stream = _fileHelper.GetWriteStream(FileTypes.Xml))
            {
                _serializer.Serialize(stream, dictionaryHelper);
            }
        }
    }
}