using System;
using System.Linq;
using System.Threading;

namespace ReactiveExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!", Thread.CurrentThread.ManagedThreadId);
            var query = Enumerable.Range(1, 5).Select(num => num);

            foreach (var number in query)
            {
                Console.WriteLine(number); 
            }

            ImDone();
        }

        private static void ImDone()
        {
            Console.WriteLine("I'm done!");
        }
    }
}
