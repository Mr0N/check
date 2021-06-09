using SplitArray;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Check3333
{
    class Info
    {
        static int Sum(int one,int two)
        {
            Console.Write(Thread.CurrentThread.ManagedThreadId);
            var info = one + two;
            Console.Write(Thread.CurrentThread.ManagedThreadId);
            return info;
        }
        public void Start()
        {
           var result =  Enumerable.Range(0, 5000)
                .Split(30)
                .Select(a => Task.Run(() => a.Select(z => Sum(z, 2)).ToList()))
                .ToArray();
            Task.WaitAll(result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Info().Start();
            Console.ReadKey();  
        }
    }
}
