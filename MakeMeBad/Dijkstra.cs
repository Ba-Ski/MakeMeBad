using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class Dijkstra : ShortWays
    {
        private Dijkstra_s_Heap<GraphVertex<int, int>> _heap;


        public override void getShortestWays(int sourceIndex, Graph<int, int> adj, int d)
        {
            _heap = new Dijkstra_s_Heap<GraphVertex<int, int>>(adj.vertсiesCount, d);

            adj[0].path = 0;
            _heap.insertNode(adj[0]);
            dijkstraAlgorith(adj);
        }

        private void dijkstraAlgorith(Graph<int, int> adj)
        {

            while (!_heap.empty())
            {
                var minRelaxedNode = _heap.extractMin();

                for (int j = 0; j < adj[minRelaxedNode.key].neighbours.Count; j++)
                {
                    justRelax(adj[minRelaxedNode.key].neighbours[j]);
                }
            }

        }

        protected override void justRelax(GraphEdge<int, int> edge)
        {
            var path = edge.vertex.path + edge.weight;
            if (edge.neighbour.path > path && path >= 0)
            {
                edge.neighbour.path = path;
                edge.neighbour.predcessor = edge.vertex;
                if (_heap.Contains(edge.neighbour)) _heap.decreaseKey(edge.neighbour);
                else
                    _heap.insertNode(edge.neighbour);

            }
        }

    }
}
