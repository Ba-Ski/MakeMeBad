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
            IntGraph adj;
            Dijkstra dijk = new Dijkstra();
            Stopwatch watch;
            int cf;

            StreamWriter output = new StreamWriter("out_d+1.txt");
            StreamWriter bitch = new StreamWriter("out_d+2.txt");

            for (int i = Constants.vertexCountMin; i < Constants.vertexCountMax; i += step)
            {
                if (i < 1000) cf = (int)(i * 0.9 * i);
                else cf = i * 790;
                adj = new IntGraph(i, cf);
                adj.generateGraph(Constants.weightMin, Constants.weightMax);
                watch = Stopwatch.StartNew();
                dijk.getShortestWays(0, adj, Constants.d + 1);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("d+1 "+ time);
                output.Write(time + "\t");

                for (int j = 0; j < adj.vertсiesCount; j++)
                {
                    adj[j].path = int.MaxValue;
                    adj[j].predcessor = adj[j];
                }

                watch = Stopwatch.StartNew();
                dijk.getShortestWays(0, adj, Constants.d + 2);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("d+2 " + time);

                //Console.WriteLine("d+1 {0} = {1}", i, time);
                bitch.Write(time + "\t");
            }

            output.Close();
            bitch.Close();
        }

        static void dPlusTwoHeap(int step)
        {

            double time;
            IntGraph adj;
            Dijkstra dijk = new Dijkstra();
            Stopwatch watch;
            int cf;

            StreamWriter output = new StreamWriter("out_d+2.txt");

            for (int i = Constants.vertexCountMin; i < Constants.vertexCountMax; i += step)
            {
                if(i<1000) cf = (int)(i* 0.9 * i);
                else cf = i*890;
                adj = new IntGraph(i,cf );
                adj.generateGraph(Constants.weightMin, Constants.weightMax);

                watch = Stopwatch.StartNew();
                dijk.getShortestWays(0, adj, Constants.d + 2);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("d+2 {0} = {1}", i, time);
                output.Write(time + "\t");

            }

            output.Close();
        }

        static void BellmanFordSoSlow(int step)
        {
            double time;
            IntGraph adj;
            Stopwatch watch;
            BellmanFord BF = new BellmanFord();

            StreamWriter output = new StreamWriter("out_bellmanford.txt");

            for (int i = Constants.vertexCountMin; i < Constants.vertexCountMax; i += step)
            {
                adj = new IntGraph(i, 90 * i);
                adj.generateGraph(Constants.weightMin, Constants.weightMax);

                watch = Stopwatch.StartNew();
                BF.getShortestWays(0, adj);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("bellman-ford {0} = {1}", i, time);
                output.WriteLine(time + "\t");

            }

            output.Close();

        }


        static void Main(string[] args)
        {

            Thread dPlusOne = new Thread(() => dPlusOneHeap(100));
            //Thread dPlusTwo = new Thread(() => dPlusTwoHeap(100));
            //Thread bellmanFord = new Thread(()=>BellmanFordSoSlow(100));

            dPlusOne.Start();
            //dPlusTwo.Start();
            //bellmanFord.Start();

            dPlusOne.Join();
            //dPlusTwo.Join();
            //bellmanFord.Join();

        }
    }
}
