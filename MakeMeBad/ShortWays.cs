using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    abstract class ShortWays
    {
        public abstract void getShortestWays(int startNodeIndex, Graph<int, int> adj, int d);
        protected abstract void justRelax(GraphEdge<int, int> edge);
    }
}
