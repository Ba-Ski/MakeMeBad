using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
    interface ShortWays
    {
        Result getShortWays(int startNodeIndex, int heapNodesCount, Graph adj, int d);
        void justRelax(HeapNode parent, GraphEdge edg);
    }
}
