using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{

    class Heap<T> where T : INode<int>
    {
        private T[] _nodes;
        private T[] _source;
        private int _nodesCount;
        private int[] _conformityArr;
        private int _d;

        public Heap(int nodesCount, T[] source, int d)
        {
            _source = source;
            _nodes = new T[nodesCount];
            _nodesCount = nodesCount;
            _conformityArr = new int[_nodesCount];
            _d = d;

        }

        public void maekQueue(int startNode)
        {
            for (int i = 0; i < _nodesCount; i++)
            {
                _conformityArr[i] = i;
                _nodes[i] = _source[i];
            }

            _nodes[startNode].path = 0;
            interSiftUp(startNode);
        } 

        public void siftDown(int pos)
        {
            interSiftDown(_conformityArr[pos]);
        }

        private void interSiftDown(int pos)
        {

            T insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].path < insertedNode.path)
            {
                _nodes[pos] = _nodes[nextChild];
                _conformityArr[_nodes[nextChild].id] = pos;
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;
            _conformityArr[insertedNode.id] = pos;

        }
        public void siftUp(int pos)
        {
            interSiftUp(_conformityArr[pos]);
        }

        private void interSiftUp(int pos)
        {
            T changedNode = _nodes[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _nodes[parentNodeIndex].path > changedNode.path)
            {
                _nodes[pos] = _nodes[parentNodeIndex];
                _conformityArr[_nodes[parentNodeIndex].id] = pos;
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _nodes[pos] = changedNode;
            _conformityArr[changedNode.id] = pos;
        }

        public T extractMin()
        {
            T minRealxedNode = _nodes[0];
            _nodes[0] = _nodes[_nodesCount - 1];
            _conformityArr[_nodes[_nodesCount - 1].id] = 0;
            _nodes[_nodesCount - 1] = minRealxedNode;
            _conformityArr[minRealxedNode.id] = _nodesCount - 1;
            _nodesCount--;

            interSiftDown(0);

            return minRealxedNode;
        }

        private int minChild(int pos)
        {
            int fChild, lChild;
            int minpath;
            int minNodeIndex;

            fChild = firstChild(pos);
            if (fChild == 0) return 0;
            lChild = lastChild(pos);
            minpath = _nodes[fChild].path;
            minNodeIndex = fChild;

            for (int chi = fChild + 1; chi <= lChild; chi++)
            {
                if (_nodes[chi].path < minpath)
                {
                    minpath = _nodes[chi].path;
                    minNodeIndex = chi;
                }
            }

            return minNodeIndex;
        }

        private int firstChild(int pos)
        {
            int index = pos * _d + 1;
            return index >= _nodesCount ? 0 : index;
        }

        private int lastChild(int pos)
        {
            int fChi = firstChild(pos);
            if (fChi == 0) return 0;
            int lChi = fChi + _d -1;
            return lChi < _nodesCount ? lChi : _nodesCount - 1;
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

