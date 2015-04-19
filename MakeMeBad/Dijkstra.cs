using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
	class Dijkstra : IShortWays
	{
		private Heap<MyKeyValuePair<int,int>> _heap;
		private int[] dist;
		public Dijkstra()
		{
		}

		public override void getShortestWays(int sourceIndex, Graph<int> adj, int d)
		{
			_heap = new Heap<MyKeyValuePair<int,int>>(adj.vertсiesCount, d);
			dist = new int[adj.vertсiesCount];
			for (int i = 0; i < dist.Length; i++)
			{
			 dist[i]=int.MaxValue;
			}
			dist[sourceIndex] = 0;
			MyKeyValuePair<int, int> startNode = new MyKeyValuePair<int, int>(sourceIndex,dist[sourceIndex]);
			_heap.insertNode(startNode);
			dijkstraAlgorith(adj);
		}

		private void dijkstraAlgorith(Graph<int> adj)
		{
			MyKeyValuePair<int,int> minRelaxedNode;

			while(!_heap.empty())
			{
				minRelaxedNode = _heap.extractMin();
				if (minRelaxedNode.value > dist[minRelaxedNode.key]) continue;
				adj[minRelaxedNode.key].path = minRelaxedNode.value;

				for(int j=0; j<adj[minRelaxedNode.key].neighbours.Count; j++)
				{
					justRelax(adj[minRelaxedNode.key].neighbours[j]);
				}
			}

		}
		
		 protected override void justRelax(GraphEdge<int> edge)
		{
			var path = edge.vertex.path + edge.weight;
			if (dist[edge.neighbour.key]  > path && path >= 0)
			{
				dist[edge.neighbour.key] = path;
				edge.neighbour.path = path;
				edge.neighbour.parent = edge.vertex;
				_heap.insertNode(new MyKeyValuePair<int,int>(edge.neighbour.key,edge.neighbour.path));
			}
		}

	}
}
