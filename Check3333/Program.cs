using SplitArray;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Check3333
{
    class XXX
    {
        public static int Sum(int one, int two)
        {
            Thread.Sleep(1);
            return 0;
        }
        public int SumNotStatic(int one, int two)
        {
            Thread.Sleep(1);
            return 0;
        }
    }
   static class InfoStatic
    {

  

        public static void Start()
        {
            var result = Enumerable.Range(0, 500000)
                 .Split(30)
                 .Select(a => Task.Run(() =>
                 {
                     Thread.Sleep(1000);
                     return a.Select(z => XXX.Sum(z, 2)).ToList();
                 }))
                 .ToArray();
            Task.WaitAll(result);
        }
    }
    class Info
    {


        public void Start()
        {
            var result = Enumerable.Range(0, 5000)
                 .Split(30)
                 .Select(a => Task.Run(() =>
                 {
                     Thread.Sleep(1000);
                     var sum = new XXX();
                     return a.Select(z => sum.SumNotStatic(z, 2)).ToList();
                 }))
                 .ToArray();
            Task.WaitAll(result);
        }
        public Info()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Info().Start();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new Info().Start();
            stopwatch.Stop();
            Console.WriteLine("Not Static " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("Static");
            stopwatch.Start();
            InfoStatic.Start();
            stopwatch.Stop();
            Console.WriteLine("Static " + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
