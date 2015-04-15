using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    static class Dijkstra
    {
        private static Heap _heap;

        public static Result getShortestWays(int startNodeIndex, int heapNodesCount, Graph adj, int d)
        {
            _heap = new Heap(heapNodesCount, d);

           _heap.maekQueue(0);

            return dijkstraAlgorith(adj, heapNodesCount);
        }

        private static Result dijkstraAlgorith(Graph adj, int heapNodesCount)
        {
            HeapNode minRelaxedNode;
            Result result = new Result(heapNodesCount);

            for(int i = 0; i<heapNodesCount;i++)
            {
                minRelaxedNode = _heap.extractMin();

                result.pathLength[minRelaxedNode.name] = minRelaxedNode.key;
                result.penultimateNode[minRelaxedNode.name] = minRelaxedNode.parent;
 
                for(int j=0; j<adj[minRelaxedNode.name].neighbours.Count; j++)
                {
                    justRelax(minRelaxedNode, adj[minRelaxedNode.name].neighbours[j]);
                }
            }

            return result;
        }
        
         private static void justRelax(HeapNode parent, GraphEdge edge)
        {
            var path = parent.key + edge.weight;
            if (_heap.getNodeKey(edge.neighbour.name) > path && path >= 0)
            {
                _heap.setNewKey(edge.neighbour.name, path, parent.name);
            }
        }

    }
}
