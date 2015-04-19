using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    class GraphVertex<T> : INode<T>
    {
        public int id { get; private set;}
        public List<GraphEdge<T>> neighbours;
        public T key { get; set; }
        public int path { get; set; }
        public GraphVertex<T> parent { get; set; }

        public GraphVertex(int id)
        {
            this.id = id;
            this.parent = this;
            this.path = int.MaxValue;
            neighbours = new List<GraphEdge<T>>();
        }

    }
    class GraphEdge<T>
    {
        public int weight{get;private set;}
        public GraphVertex<T> vertex {get; private set;}
        public GraphVertex<T> neighbour{get; private set;}
        
        public GraphEdge(int weight, GraphVertex<T> vertex, GraphVertex<T> neighbour)
        {
            this.weight = weight;
            this.vertex = vertex;
            this.neighbour = neighbour;
            
        }
    }

    class Graph<T>
    {
        public int vertсiesCount { get; private set; }
        public int edgesCount { get; private set; }
         private GraphVertex<T>[] _verteciesArray;

        public GraphVertex<T> this[int i]
         {
             get
             {
                 if (i < vertсiesCount && i >= 0)
                     return _verteciesArray[i];
                 else return null;
             }
             set
             {
                 if(i<vertсiesCount)
                 {
                     _verteciesArray[i] = value;
                 }
             }
        }

            public Graph(int vertсiesCount, int edgesCount)
            {
                this.vertсiesCount=vertсiesCount;
                this.edgesCount = edgesCount;
                _verteciesArray = new GraphVertex<T>[vertсiesCount];
            }
            
            public GraphVertex<T>[] getVertciesArr()
            {
                return _verteciesArray;
            }
            public void generateGraph(int weightMin, int weightMax)
            {
                _verteciesArray[0] = new GraphVertex<T>(0);
                Random rand = new Random();
                int vertexInd, neighbourInd;

                for (int i = 1; i < vertсiesCount; i++)
                {
                    _verteciesArray[i] = new GraphVertex<T>(i);

                    neighbourInd = rand.Next(0, i);

                    while (i == neighbourInd ||
                        _verteciesArray[i].neighbours.Any(t => t.neighbour == _verteciesArray[neighbourInd]) == true)
                    {
                        neighbourInd = rand.Next(0, vertсiesCount);
                    }
                    GraphEdge<T> edge = new GraphEdge<T>(rand.Next(weightMin, weightMax + 1),
                        _verteciesArray[i], _verteciesArray[neighbourInd]);

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
                    GraphEdge<T> edge = new GraphEdge<T>(rand.Next(weightMin, weightMax + 1), _verteciesArray[vertexInd], _verteciesArray[neighbourInd]);
                    _verteciesArray[vertexInd].neighbours.Add(edge);
                }


            }

         }
    }


