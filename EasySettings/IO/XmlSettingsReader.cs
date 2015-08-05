using System.Xml.Serialization;
using EasySettings.Interfaces;

namespace EasySettings.IO
{
    public class XmlSettingsReader : ISettingsReader
    {
        private XmlSerializer _serializer = new XmlSerializer(typeof(DictionarySerializationHelper));
        private SettingsFileHelper _fileHelper = new SettingsFileHelper();

        public Settings Read()
        {
            using (var stream = _fileHelper.GetReadStream(FileTypes.Xml))
            {
                var dictionaryHelper = (DictionarySerializationHelper)_serializer.Deserialize(stream);
                return new Settings(dictionaryHelper.GetDictionary());
            }
        }
    }
}
