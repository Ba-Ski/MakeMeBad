using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{

    class Heap<T> where T : IComparable
    {
        protected T[] _nodes;
        protected int _heapCurrentSize;
        private int _d;

        public Heap(int nodesCount, int d)
        {
            _nodes = new T[nodesCount];
            _heapCurrentSize = 0;
            _d = d;
        }


        public bool empty()
        {
            return _heapCurrentSize == 0;
        }
            
        protected virtual void siftDown(int pos)
        {

            T insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].CompareTo(insertedNode) < 0)
            {
                _nodes[pos] = _nodes[nextChild];
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;

        }

        public virtual void insertNode(T node)
        {
            if (_heapCurrentSize >= _nodes.Length) throw new ApplicationException("wtf?");
            _nodes[_heapCurrentSize] = node;
            _heapCurrentSize++;
            siftUp(_heapCurrentSize - 1);
        }

        protected virtual void siftUp(int pos)
        {
            T changedNode = _nodes[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _nodes[parentNodeIndex].CompareTo(changedNode) > 0)
            {
                _nodes[pos] = _nodes[parentNodeIndex];
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _nodes[pos] = changedNode;
        }

        public virtual T extractMin()
        {
            if (_heapCurrentSize == 0) throw new ApplicationException("heap is empty");
            T minRealxedNode = _nodes[0];
            _nodes[0] = _nodes[_heapCurrentSize - 1];
            _heapCurrentSize--;
            if (_heapCurrentSize > 0)
                siftDown(0);

            return minRealxedNode;
        }

        protected int minChild(int pos)
        {
            int fChild, lChild;
            T minValueNode;
            int minNodeIndex;

            fChild = firstChild(pos);
            if (fChild == 0) return 0;
            lChild = lastChild(pos);
            minValueNode = _nodes[fChild];
            minNodeIndex = fChild;

            for (int chi = fChild + 1; chi <= lChild; chi++)
            {
                if (_nodes[chi].CompareTo(minValueNode) < 0)
                {
                    minValueNode = _nodes[chi];
                    minNodeIndex = chi;
                }
            }

            return minNodeIndex;
        }

        protected int firstChild(int pos)
        {
            int index = pos * _d + 1;
            return index >= _heapCurrentSize ? 0 : index;
        }

        protected int lastChild(int pos)
        {
            int fChi = firstChild(pos);
            if (fChi == 0) return 0;
            int lChi = fChi + _d - 1;
            return lChi < _heapCurrentSize ? lChi : _heapCurrentSize - 1;
        }

        protected int parent(int pos)
        {
            int index = pos / _d;
            if (pos % _d == 0 && index != 0)
                return index - 1;
            return index;
        }
    }
}

