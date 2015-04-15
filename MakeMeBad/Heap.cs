using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{

    class HeapNode
    {
        public int key { get; set; }
        public int name { get; private  set; }
        public int parent { get; set; }

        public HeapNode(int key, int name, int parent)
        {
            this.key = key;
            this.name = name;
            this.parent = parent;
        }
    }

    class Heap
    {
        private HeapNode[] _nodes;
        private int _nodesCount;
        private int[] _graphIndexes;
        private int _d;

        /*public HeapNode this[int i]
        {
            get
            {
                return _nodes[_graphIndexes[i]];
            }
        }*/

        public  int getNodeKey(int index)
        {
            return _nodes[_graphIndexes[index]].key;
        }

        public void setNewKey(int index, int key, int parent)
        {
            _nodes[_graphIndexes[index]].key = key;
            _nodes[_graphIndexes[index]].parent = parent;

            siftUp(_graphIndexes[index]);
        }

        public Heap(int nodesCount, int d)
        {
            _nodesCount = nodesCount;
            _nodes = new HeapNode[_nodesCount];
            _graphIndexes = new int[_nodesCount];
            _d = d;

        }

        public void maekQueue(int startNode)
        {
            for (int i = 0; i < _nodesCount;i++ )
            {
                _nodes[i] = new HeapNode(int.MaxValue, i, 0);
                _graphIndexes[i] = i;
            }

                _nodes[startNode].key = 0;
                siftUp(startNode);
        }

        public void siftDown(int pos)
        {

            HeapNode insertedNode = _nodes[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _nodes[nextChild].key < insertedNode.key)
            {
                _nodes[pos] = _nodes[nextChild];
                _graphIndexes[_nodes[nextChild].name] = pos;
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _nodes[pos] = insertedNode;
            _graphIndexes[insertedNode.name] = pos;

        }

        public void siftUp(int pos)
        {
            HeapNode changedNode = _nodes[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _nodes[parentNodeIndex].key > changedNode.key)
            {
                _nodes[pos] = _nodes[parentNodeIndex];
                _graphIndexes[_nodes[parentNodeIndex].name] = pos;
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _nodes[pos] = changedNode;
            _graphIndexes[changedNode.name] = pos;
        }

        public HeapNode extractMin()
        {
            HeapNode minRealxedNode = _nodes[0];
            _nodes[0] = _nodes[_nodesCount - 1];
            _graphIndexes[_nodes[_nodesCount - 1].name] = 0;
            _nodes[_nodesCount - 1] = minRealxedNode;
            _graphIndexes[minRealxedNode.name] = _nodesCount - 1;
            _nodesCount--;

            siftDown(0);

            return minRealxedNode;
        }

        private int minChild(int pos)
        {
            int fChild, lChild;
            int minKey;
            int minNodeIndex;

            fChild = firstChild(pos);
            if (fChild == 0) return 0;
            lChild = lastChild(pos);
            minKey = _nodes[fChild].key;
            minNodeIndex = fChild;

            for (int chi = fChild + 1; chi <= lChild; chi++)
            {
                if (_nodes[chi].key < minKey)
                {
                    minKey = _nodes[chi].key;
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
