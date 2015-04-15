using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class GraphVertex
    {
        public int name { get; private set;}
        public List<GraphEdge> neighbours;
        public GraphVertex(int name)
        {
            this.name = name;
            neighbours = new List<GraphEdge>();
        }

    }
    class GraphEdge
    {
        public int weight{get;private set;}
        public GraphVertex vertex {get; private set;}
        public GraphVertex neighbour{get; private set;}
        
        public GraphEdge(int weight, GraphVertex vertex, GraphVertex neighbour)
        {
            this.weight = weight;
            this.vertex = vertex;
            this.neighbour = neighbour;
            
        }
    }

    class Graph
    {
         private GraphVertex[] _verteciesArray;
         private int _vertexCount;

        public GraphVertex this[int i]
         {
             get
             {
                 if (i < _vertexCount && i >= 0)
                     return _verteciesArray[i];
                 else return null;
             }
             set
             {
                 if(i<_vertexCount)
                 {
                     _verteciesArray[i] = value;
                 }
             }
        }

            public Graph(int vertexCount)
            {
                this._vertexCount=vertexCount;
                _verteciesArray = new GraphVertex[_vertexCount];
            }

            public void generateGraph(int edgesCount, int weightMin, int weightMax)
            {
                _verteciesArray[0] = new GraphVertex(0);
                Random rand = new Random();
                int vertexInd;
                for(int i =1; i<_vertexCount; i++)
                {
                    _verteciesArray[i]= new GraphVertex(i);

                    generateEdge(i,i, weightMax, weightMin);                    

                }

                for(int i=0;i<edgesCount - _vertexCount +1;i++)
                {
                    vertexInd = rand.Next(0, _vertexCount);
                    generateEdge(_vertexCount-1, _vertexCount-1, weightMax, weightMin);                    
                }


            }

        private void generateEdge(int vertexInd, int vertexNumMax, int weightMax , int weightMin)
            {
                int neighbourInd;
                Random rand = new Random();
                neighbourInd = rand.Next(0, vertexNumMax+1);

                while (vertexInd == neighbourInd || _verteciesArray[vertexInd].neighbours.Any(t => t.neighbour == _verteciesArray[neighbourInd])==true)
                {
                    neighbourInd = rand.Next(0, vertexNumMax+1);
                }
                    GraphEdge edge = new GraphEdge(rand.Next(weightMin, weightMax+1), _verteciesArray[vertexInd], _verteciesArray[neighbourInd]);
                    _verteciesArray[vertexInd].neighbours.Add(edge);
            }
         }
    }


