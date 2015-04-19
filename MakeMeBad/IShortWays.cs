using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    abstract class IShortWays
    {
        public abstract void getShortestWays(int startNodeIndex, Graph<int> adj, int d);
        protected abstract void justRelax(GraphEdge<int> edge);
    }
}
