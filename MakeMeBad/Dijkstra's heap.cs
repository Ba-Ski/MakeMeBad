using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class Dijkstra_s_Heap<T> : Heap<T> where T : IComparable
    {
        private Dictionary<T, int> _conformityDickionary;

        public Dijkstra_s_Heap(int nodesCount, int d)
            : base(nodesCount, d)
        {
            _conformityDickionary = new Dictionary<T, int>(nodesCount);
        }

        public bool Contains(T key)
        {
            return _conformityDickionary.ContainsKey(key);
        }

        public override void insertNode(T node)
        {

            if (_heapCurrentSize >= _nodes.Length) throw new ApplicationException("wtf?");
            _nodes[_heapCurrentSize] = node;
            _conformityDickionary.Add(node, _heapCurrentSize);
            _heapCurrentSize++;
            siftUp(_heapCurrentSize - 1);
        }

        public void decreaseKey(T node)
        {
            _nodes[_conformityDickionary[node]] = node;
            siftUp(_conformityDickionary[node]);
        }

        public override T extractMin()
        {
            if (_heapCurrentSize == 0) throw new ApplicationException("heap is empty");
            T minRealxedNode = _nodes[0];
            _conformityDickionary.Remove(_nodes[0]);
            _nodes[0] = _nodes[_heapCurrentSize - 1];
            _nodes[_heapCurrentSize-1] = default(T);
            _heapCurrentSize--;
            if (_heapCurrentSize > 0)
            {
                _conformityDickionary[_nodes[0]] = 0;
                siftDown(0);
            }
            return minRealxedNode;
        }

        protected override void siftDown(int pos)
        {
            T insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].CompareTo(insertedNode) < 0)
            {
                _nodes[pos] = _nodes[nextChild];
                _conformityDickionary[_nodes[pos]] = pos;
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;
            _conformityDickionary[_nodes[pos]] = pos;
        }

        protected override void siftUp(int pos)
        {
            T changedNode = _nodes[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _nodes[parentNodeIndex].CompareTo(changedNode) > 0)
            {
                _nodes[pos] = _nodes[parentNodeIndex];
                _conformityDickionary[_nodes[pos]] = pos;
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _nodes[pos] = changedNode;
            _conformityDickionary[_nodes[pos]] = pos;
        }
    }
}
