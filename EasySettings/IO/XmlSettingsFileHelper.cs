using System.IO;

namespace EasySettings.IO
{
    public class XmlSettingsFileHelper : SettingsFileHelper
    {
        protected override string FileExtension => ".xml";
    }
}