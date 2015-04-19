using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class Dijkstra : IShortWays
    {
        private Heap<GraphVertex<int>> _heap;

        public override void getShortestWays(int sourceIndex, Graph<int> adj, int d)
        {
            _heap = new Heap<GraphVertex<int>>(adj.vertсiesCount,adj.getVertciesArr(), d);
           _heap.maekQueue(0);

            dijkstraAlgorith(adj);
        }

        private void dijkstraAlgorith(Graph<int> adj)
        {
            GraphVertex<int> minRelaxedNode;

            for(int i = 0; i<adj.vertсiesCount;i++)
            {
                minRelaxedNode = _heap.extractMin();
 
                for(int j=0; j<minRelaxedNode.neighbours.Count; j++)
                {
                    justRelax(minRelaxedNode.neighbours[j]);
                }
            }

        }
        
         protected override void justRelax(GraphEdge<int> edge)
        {
            var path = edge.vertex.path + edge.weight;
            if (edge.neighbour.path  > path && path >= 0)
            {
                edge.neighbour.path = path;
                edge.neighbour.parent = edge.vertex;
                _heap.siftUp(edge.neighbour.id);
            }
        }

    }
}
