using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class BellmanFord : IShortWays
    {

        public override void getShortestWays(int sourceIndex, Graph<int> adj, int d)
        {

            int edgeNumber, vertexNumber;
            adj[sourceIndex].path = 0;

            for(int i = 0; i <adj.vertсiesCount; i++)
            {
                edgeNumber = 0;
                vertexNumber = 0;
                for(int j = 0; j < adj.edgesCount; j++, edgeNumber++)
                {
                    if(edgeNumber>=adj[vertexNumber].neighbours.Count())
                    {
                        vertexNumber++;
                        edgeNumber=0;
                    }

                    justRelax(adj[vertexNumber].neighbours[edgeNumber]);
                }
            }
            vertexNumber =0 ;
            edgeNumber = 0;

            for(int i = 0; i< adj.edgesCount; i++, edgeNumber++)
            {
                if(edgeNumber>=adj[vertexNumber].neighbours.Count)
                {
                    vertexNumber++;
                    edgeNumber = 0;
                }
                var edge = adj[vertexNumber].neighbours[edgeNumber];
                if (edge.neighbour.path > edge.vertex.path + edge.weight)
                    throw new ApplicationException("ooops");
            }
        }

        protected override void justRelax(GraphEdge<int> edge)
        {
            var path = edge.vertex.path + edge.weight;
            if(edge.neighbour.path > path && path >= 0)
            {
                edge.neighbour.path = path;
                edge.neighbour.parent = edge.vertex;
            }
        }
    }
}
