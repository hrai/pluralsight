using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace ReactiveExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! {0}", Thread.CurrentThread.ManagedThreadId);
            var query = Enumerable.Range(1, 5).Select(num => num);

            foreach (var number in query)
            {
                Console.WriteLine(number); 
            }

            ImDone();

            var observableQuery = query.ToObservable(NewThreadScheduler.Default);
            observableQuery.Subscribe(ProcessNumber, ImDone);

            Console.ReadKey();
        }

        static void ProcessNumber(int number)
        {
            Console.WriteLine("{0} Thread {1}", number, Thread.CurrentThread.ManagedThreadId);
        }

        private static void ImDone()
        {
            Console.WriteLine("I'm done!");
        }
    }
}
