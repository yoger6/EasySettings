namespace EasySettings.IO
{
    public struct Pair
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public Pair(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}