using System;
using System.Threading;

namespace Kube.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job started!");

            Thread.Sleep(60000);

            Console.WriteLine("Job ended!");
        }
    }
}
