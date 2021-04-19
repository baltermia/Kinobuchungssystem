using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kinobuchungssystem
{
    public class SimpleCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Holds all items in the collection
        /// </summary>
        [JsonIgnore]
        public IEnumerable<T> Items => _items.Select(i => i.Value);

        [JsonProperty]
        private readonly Dictionary<int, T> _items;

        /// <summary>
        /// Creates a new SimpleCollection object
        /// </summary>
        /// <param name="items"></param>
        public SimpleCollection(Dictionary<int, T> items = null)
        {
            _items = items ?? new Dictionary<int, T>();
        }

        /// <summary>
        /// Creates a new SimpleCollection object
        /// </summary>
        /// <param name="items"></param>
        public SimpleCollection(IEnumerable<T> items)
        {
            _items = new Dictionary<int, T>();
            items?.ToList().ForEach(Add);
        }

        /// <summary>
        /// Adds the item to the collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            //Gets the fist free key and adds the item to the dictionary
            _items.Add(Enumerable.Range(0, int.MaxValue).Except(_items.Keys).First(), item);
        }

        /// <summary>
        /// Removes the item at the index
        /// </summary>
        /// <param name="key">Index</param>
        public void Remove(int key)
        {
            _items.Remove(key);
        }

        /// <summary>
        /// Removes the matching item from the list if it could be found
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            //Find the entry in the dictionary corresponding the given item
            KeyValuePair<int, T> entry = _items.FirstOrDefault(i => i.Value.Equals(item));

            //If no entry as found (meaning the value is null) return immediately
            if (entry.Value == null)
            {
                return;
            }

            //Remove the entry in the dictionary given the key
            Remove(entry.Key);
        }

        /// <summary>
        /// Serializes the object to json and returns the json as string
        /// </summary>
        /// <returns></returns>
        public string GetSerialized() => JsonConvert.SerializeObject(this, Formatting.Indented);

        /// <summary>
        /// Creates a SimpleCollection object with the given json string
        /// </summary>
        /// <param name="json">Object as json string</param>
        /// <returns></returns>
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
