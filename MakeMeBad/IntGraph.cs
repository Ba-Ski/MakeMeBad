using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class IntGraph : Graph<int, int>
    {

        public IntGraph(int verteciesCount, int edgesCount)
            : base(verteciesCount, edgesCount)
        { }

        public void generateGraph(int weightMin, int weightMax)
        {
            _verteciesArray[0] = new GraphVertex<int, int>(0);
            Random rand = new Random();
            int vertexInd, neighbourInd;

            for (int i = 1; i < vertсiesCount; i++)
            {
                _verteciesArray[i] = new GraphVertex<int, int>(i);

                vertexInd = i;
                neighbourInd = rand.Next(0, i-1);

                GraphEdge<int, int> edge = new GraphEdge<int, int>(rand.Next(weightMin, weightMax + 1),
                    _verteciesArray[vertexInd], _verteciesArray[neighbourInd]);

                _verteciesArray[i].neighbours.Add(edge);

            }

            for (int i = 0; i < edgesCount - vertсiesCount + 1; i++)
            {
                vertexInd = rand.Next(0, vertсiesCount);

                vertexInd = rand.Next(0, vertсiesCount);
                neighbourInd = rand.Next(0, vertсiesCount);

                while (vertexInd == neighbourInd ||
                    _verteciesArray[vertexInd].neighbours.Any(t => t.neighbour == _verteciesArray[neighbourInd]) == true)
                {
                    vertexInd = rand.Next(0, vertсiesCount);
                    neighbourInd = rand.Next(0, vertсiesCount);
                }
                GraphEdge<int, int> edge = new GraphEdge<int, int>(rand.Next(weightMin, weightMax + 1), _verteciesArray[vertexInd], _verteciesArray[neighbourInd]);
                _verteciesArray[vertexInd].neighbours.Add(edge);
            }
        }
    }
}
