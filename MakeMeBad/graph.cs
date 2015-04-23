using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class GraphVertex<K, V> : IComparable
    {
        public K key { get; private set; }
        public List<GraphEdge<K, V>> neighbours { get; set; }
        public V value { get; set; }
        public int path { get; set; }
        public GraphVertex<K, V> predcessor { get; set; }

        public GraphVertex(K id)
        {
            this.key = id;
            this.predcessor = this;
            this.path = int.MaxValue;
            neighbours = new List<GraphEdge<K, V>>();
        }

        int IComparable.CompareTo(object other)
        {
            return CompareTo(other as GraphVertex<K, V>);
        }

        int CompareTo(GraphVertex<K, V> vertex)
        {
            if (vertex != null)
            {
                if (this.path == vertex.path) return 0;
                else if (this.path > vertex.path) return 1;
            }
            return -1;
        }



    }
    class GraphEdge<K, V>
    {
        public int weight { get; private set; }
        public GraphVertex<K, V> vertex { get; private set; }
        public GraphVertex<K, V> neighbour { get; private set; }

        public GraphEdge(int weight, GraphVertex<K, V> vertex, GraphVertex<K, V> neighbour)
        {
            this.weight = weight;
            this.vertex = vertex;
            this.neighbour = neighbour;

        }
    }

    class Graph<K, V>
    {
        public int vertсiesCount { get; private set; }
        public int edgesCount { get; private set; }
        protected GraphVertex<K, V>[] _verteciesArray;

        public GraphVertex<K, V> this[int i]
        {
            get
            {
                if (i < vertсiesCount && i >= 0)
                    return _verteciesArray[i];
                else return null;
            }
            set
            {
                if (i < vertсiesCount)
                {
                    _verteciesArray[i] = value;
                }
            }
        }

        public Graph(int vertсiesCount, int edgesCount)
        {
            this.vertсiesCount = vertсiesCount;
            this.edgesCount = edgesCount;
            _verteciesArray = new GraphVertex<K, V>[vertсiesCount];
        }

    }
}


