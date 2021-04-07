using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kinobuchungssystem
{
    public class SimpleCollection<T> : IEnumerable<T>
    {
        [JsonIgnore]
        public IEnumerable<T> Items => _items.Select(i => i.Value);

        [JsonProperty]
        private readonly Dictionary<int, T> _items;

        public SimpleCollection(Dictionary<int, T> items = null)
        {
            _items = items ?? new Dictionary<int, T>();
        }

        public SimpleCollection(IEnumerable<T> items)
        {
            _items = new Dictionary<int, T>();
            items?.ToList().ForEach(Add);
        }

        public void Add(T item)
        {
            _items.Add(_items.Count, item);
        }

        public string GetSerialized() => JsonConvert.SerializeObject(this);

        public static SimpleCollection<T> GetDeserialized(string json) => JsonConvert.DeserializeObject<SimpleCollection<T>>(json);

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
