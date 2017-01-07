using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyLanguageInterpreterCS.model
{
    public interface MyIDictionary<K, V>
    {
        void put(K key, V value);
        V get(K key);
        List<V> values();
        List<K> keys();
        void remove(K fd);
        MyIDictionary<K, V> clone();
        Dictionary<K, V> toDictionary();
        string ToString();
    }
}
