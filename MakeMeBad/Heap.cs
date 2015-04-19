using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{

    class Heap<T> where T : INode<int,int>
    {
        protected T[] _nodes;
        protected int _heapCurrentSize;
        int extracted;
        private int _d;

        public Heap(int nodesCount, int d)
        {
            _nodes = new T[nodesCount];
            _heapCurrentSize = 0;
            _d = d;
            extracted = 0;

        }


        public bool empty()
        {
            if (_heapCurrentSize == 0) return true;
            else return false;
        }

        private void siftDown(int pos)
        {

            T insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].value < insertedNode.value)
            {
                _nodes[pos] = _nodes[nextChild];
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;

        }

        public void insertNode(T node)
        {
            _nodes[_heapCurrentSize] = node;
            _heapCurrentSize++;
            if (_heapCurrentSize > _nodes.Length) throw new ApplicationException("wtf?");
            siftUp(_heapCurrentSize-1);
        }

        private void siftUp(int pos)
        {
            T changedNode = _nodes[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _nodes[parentNodeIndex].value > changedNode.value)
            {
                _nodes[pos] = _nodes[parentNodeIndex];
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _nodes[pos] = changedNode;
        }

        public T extractMin()
        {
            if (_heapCurrentSize == 0) throw new ApplicationException("heap is empty");
            T minRealxedNode = _nodes[0];
            _nodes[0] = _nodes[_heapCurrentSize - 1];
            _heapCurrentSize--;
            extracted++;
            if(_heapCurrentSize>0)
            siftDown(0);

            return minRealxedNode;
        }

        private int minChild(int pos)
        {
            int fChild, lChild;
            int minvalue;
            int minNodeIndex;

            fChild = firstChild(pos);
            if (fChild == 0) return 0;
            lChild = lastChild(pos);
            minvalue = _nodes[fChild].value;
            minNodeIndex = fChild;

            for (int chi = fChild + 1; chi <= lChild; chi++)
            {
                if (_nodes[chi].value < minvalue)
                {
                    minvalue = _nodes[chi].value;
                    minNodeIndex = chi;
                }
            }

            return minNodeIndex;
        }

        private int firstChild(int pos)
        {
            int index = pos * _d + 1;
            return index >= _heapCurrentSize ? 0 : index;
        }

        private int lastChild(int pos)
        {
            int fChi = firstChild(pos);
            if (fChi == 0) return 0;
            int lChi = fChi + _d -1;
            return lChi < _heapCurrentSize ? lChi : _heapCurrentSize - 1;
        }

        private int parent(int pos)
        {
            int index = pos / _d;
            if (pos % _d == 0 && index != 0)
                return index - 1;
            return index;
        }
    }
}

