using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    interface INode<K, V>
    {
        V value { get; }
        K key { get; }
    }

    class MyKeyValuePair<K,V>:INode<K,V>
    {
        public K key { get; set; }
        public V value { get; set; }

        public MyKeyValuePair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
