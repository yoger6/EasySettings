using System.Collections.Generic;

namespace EasySettings.Interfaces
{
    public interface ISettingsReader
    {
        Dictionary<string, object> Read();
    }
}
