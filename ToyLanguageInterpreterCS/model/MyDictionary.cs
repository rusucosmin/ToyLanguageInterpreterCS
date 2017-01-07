using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    class MyDictionary<K, V> : MyIDictionary<K, V>
    {
        Dictionary<K, V> map;
        public MyDictionary(Dictionary<K, V> map)
        {
            this.map = map;
        }
        public MyIDictionary<K, V> clone()
        {
            return new MyDictionary<K, V>(new Dictionary<K, V>(this.map));
        }

        public V get(K key)
        {
            if (this.map.ContainsKey(key))
                return this.map[key];
            else
                throw new Exception("Key not exist in table");
        }

        public List<K> keys()
        {
            return new List<K>(map.Keys);
        }

        public void put(K key, V value)
        {
            this.map[key] = value;
            //this.map.Add(key, value);
        }

        public void remove(K fd)
        {
            this.map.Remove(fd);
        }

        public Dictionary<K, V> toDictionary()
        {
            return this.map;
        }

        public List<V> values()
        {
            return new List<V>(map.Values);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.keys().ForEach(e => sb.Append(e.ToString() + " -> " + this.get(e).ToString() + "\n"));
            return sb.ToString();
        }
    }
}
