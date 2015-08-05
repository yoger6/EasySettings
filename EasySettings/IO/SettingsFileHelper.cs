using System;
using System.IO;
using System.Reflection;

namespace EasySettings.IO
{
    public abstract class SettingsFileHelper
    {
        protected const string FileName = "Settings";
        public string Directory { get; set; }
        private string DefaultDirectory
        {
            get
            {
                var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
                return TrimAssemblyName(assemblyPath);
            }
        }
        private string CombinedPath {
            get
            {

                var filenameWithExtension = FileName + FileExtension;

                return Path.Combine(Directory, filenameWithExtension);
            }
        }
        protected abstract string FileExtension { get; }

        protected SettingsFileHelper()
        {
            Directory = DefaultDirectory;
        }
        
        private string TrimAssemblyName(string assemblyPath)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name + ".dll";
            return assemblyPath.Remove(assemblyPath.Length - assemblyName.Length, assemblyName.Length);
        }

        public Stream GetWriteStream()
        {
            CreateDirectoryIfNotExists();
            var path = CombinedPath;

            return new FileStream(path, FileMode.Create);
        }

        public Stream GetReadStream()
        {
            var path = CombinedPath;
            return new FileStream(path, FileMode.Open);
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!System.IO.Directory.Exists(Directory))
            {
                System.IO.Directory.CreateDirectory(Directory);
            }
        }
    }
}