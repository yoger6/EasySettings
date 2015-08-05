using System;
using System.IO;
using System.Reflection;

namespace EasySettings.IO
{
    public class SettingsFileHelper
    {
        private const string FileName = "Settings";
        public string Directory { get; set; }

        public SettingsFileHelper()
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            Directory = TrimAssemblyName(assemblyPath);
        }

        private string TrimAssemblyName(string assemblyPath)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name + ".dll";
            return assemblyPath.Remove(assemblyPath.Length - assemblyName.Length, assemblyName.Length);
        }

        public Stream GetWriteStream(FileTypes fileType)
        {
            CreateDirectoryIfNotExists();
            var path = CombinePath(fileType);

            return new FileStream(path, FileMode.Create);
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!System.IO.Directory.Exists(Directory))
            {
                System.IO.Directory.CreateDirectory(Directory);
            }
        }

        private string CombinePath(FileTypes fileType)
        {
            var extension = string.Empty;
            switch (fileType)
            {
                    case FileTypes.Xml:
                    extension = ".xml";
                    break;

                    case FileTypes.Json:
                    extension = ".json";
                    break;
            }
            var filenameWithExtension = FileName + extension;

            return Path.Combine(Directory, filenameWithExtension);
        }

        public Stream GetReadStream(FileTypes fileType)
        {
            var path = CombinePath(fileType);
            
            return new FileStream(path, FileMode.Open);
        }
    }
}