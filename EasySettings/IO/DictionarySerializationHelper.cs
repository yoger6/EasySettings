using System.Collections.Generic;
using System.Linq;

namespace EasySettings.IO
{
    public class DictionarySerializationHelper
    {
        public List<Pair> Pairs { get; set; }

        public DictionarySerializationHelper() { }

        public DictionarySerializationHelper(Dictionary<string, object> dictionary)
        {
            Pairs = new List<Pair>();
            foreach (var pair in dictionary)
            {
                Pairs.Add(new Pair(pair.Key, pair.Value));
            }
        }

        public Dictionary<string, object> GetDictionary()
        {
            return Pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
        } 
    }
}