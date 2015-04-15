using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MakeMeBad
{

    class Result
    {
        public int[] pathLength;
        public int[] penultimateNode;
        public Result(int count)
        {
            pathLength = new int[count];
            penultimateNode = new int[count];
            for (int i = 0; i < count; i++ )
            {
                pathLength[i] = int.MaxValue;
                penultimateNode[i] = -1;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            double time1;
            double time2;
            Graph adj;
            Result result;
            Stopwatch watch;

            StreamWriter output = new StreamWriter("out.txt");
            output.WriteLine("d+1\td+2");

            for(int i = constants.vertexCountMin; i<constants.vertexCountMax; i+=100)
            {
                adj = new Graph(i);
                adj.generateGraph(90*i, constants.weightMin, constants.weightMax);

                watch = Stopwatch.StartNew();
                result = Dijkstra.getShortestWays(0, i, adj, constants.d + 1);
                watch.Stop();
                time1 = watch.ElapsedMilliseconds;
                Console.WriteLine("number of vertices in graph = " + i);
                Console.WriteLine("d+1 = " + time1);

                watch = Stopwatch.StartNew();
                result = Dijkstra.getShortestWays(0, i, adj, constants.d + 2);
                watch.Stop();
                time2 = watch.ElapsedMilliseconds;
                Console.WriteLine("d+2 = " + time2);
                output.WriteLine(time1 + "  " + time2);
            }

            output.Close();

        }
    }
}
