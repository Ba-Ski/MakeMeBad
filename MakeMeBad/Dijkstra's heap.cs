using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class Dijkstra_s_Heap<T> : Heap<T> where T : IComparable
    {
        private Dictionary<T, int> _conformityDick;

        public Dijkstra_s_Heap(int nodesCount, int d)
            : base(nodesCount, d)
        {
            _conformityDick = new Dictionary<T, int>(nodesCount);
        }

        public bool Contains(T key)
        {
            return _conformityDick.ContainsKey(key);
        }

        public override void insertNode(T node)
        {

            if (_heapCurrentSize >= _nodes.Length) throw new ApplicationException("wtf?");
            _nodes[_heapCurrentSize] = node;
            _conformityDick.Add(node, _heapCurrentSize);
            _heapCurrentSize++;
            siftUp(_heapCurrentSize - 1);
        }

        public void decreaseKey(T node)
        {
            _nodes[_conformityDick[node]] = node;
            siftUp(_conformityDick[node]);
        }

        public override T extractMin()
        {
            if (_heapCurrentSize == 0) throw new ApplicationException("heap is empty");
            T minRealxedNode = _nodes[0];
            _conformityDick.Remove(_nodes[0]);
            _nodes[0] = _nodes[_heapCurrentSize - 1];
            _conformityDick[_nodes[0]] = 0;
            _heapCurrentSize--;
            if (_heapCurrentSize > 0)
                siftDown(0);

            return minRealxedNode;
        }

        protected override void siftDown(int pos)
        {
            T insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].CompareTo(insertedNode) < 0)
            {
                _nodes[pos] = _nodes[nextChild];
                _conformityDick[_nodes[pos]] = pos;
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;
            _conformityDick[_nodes[pos]] = pos;
        }
    }
}
