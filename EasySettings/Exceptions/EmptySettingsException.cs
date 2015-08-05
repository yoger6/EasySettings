using System;

namespace EasySettings.Exceptions
{
    public class EmptySettingsException : Exception
    {
        public EmptySettingsException() {}
        public EmptySettingsException(string message) : base(message){}
    }
}
