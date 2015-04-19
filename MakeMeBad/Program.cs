using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace MakeMeBad
{

    class Program
    {
        static void dPlusOneHeap(int step)
        {

            double time;
            Graph<int> adj;
            Dijkstra dijk = new Dijkstra();
            Stopwatch watch;

            StreamWriter output = new StreamWriter("out_d+1.txt");

            for(int i = constants.vertexCountMin; i<constants.vertexCountMax; i+=step)
            {
                adj = new Graph<int>(i, 90*i);
                adj.generateGraph(constants.weightMin, constants.weightMax);

                watch = Stopwatch.StartNew();
                dijk.getShortestWays(0, adj, constants.d + 1);
                watch.Stop();
                time = watch.ElapsedMilliseconds;

                Console.WriteLine("d+1 {0} = {1}", i, time);
                 output.WriteLine("{0} = {1}", i, time);
            }         

            output.Close();
        }

        static void dPlusTwoHeap(int step)
        {
            
            double time;
            Graph<int> adj;
            Dijkstra dijk = new Dijkstra();
            Stopwatch watch;

            StreamWriter output = new StreamWriter("out_d+2.txt");

            for(int i = constants.vertexCountMin; i<constants.vertexCountMax; i+=step)
            {
                adj = new Graph<int>(i, 90*i);
                adj.generateGraph(constants.weightMin, constants.weightMax);

                watch = Stopwatch.StartNew();
                dijk.getShortestWays(0, adj, constants.d + 2);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("d+2 {0} = {1}", i, time);
                output.WriteLine("{0} = {1}", i, time);
                 
            }

            output.Close();
        }

        static void BellmanFordSoSlow(int step)
        {
            double time;
            Graph<int> adj;
            Stopwatch watch;
            BellmanFord BF = new BellmanFord();

            StreamWriter output = new StreamWriter("out_bellmanford.txt");

            for(int i = constants.vertexCountMin; i<constants.vertexCountMax; i+=step)
            {
                adj = new Graph<int>(i, 90*i);
                adj.generateGraph(constants.weightMin, constants.weightMax);

                watch = Stopwatch.StartNew();
                BF.getShortestWays(0, adj, constants.d + 2);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("bellman-ford {0} = {1}", i, time);
                output.WriteLine("{0} = {1}", i, time);
                 
            }

            output.Close();

        }
             

        static void Main(string[] args)
        {

            Thread dPlusOne = new Thread(()=>dPlusOneHeap(100));
            //Thread dPlusTwo = new Thread(()=>dPlusTwoHeap(100));
            Thread bellmanFord = new Thread(()=>BellmanFordSoSlow(100));

            dPlusOne.Start();
            //dPlusTwo.Start();
            bellmanFord.Start();

            dPlusOne.Join();
            //dPlusTwo.Join();
            bellmanFord.Join();

        }
    }
}
