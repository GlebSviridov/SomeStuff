using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var fib = new FibonacciCount();
            var res = fib.FibFind(10);
            Console.WriteLine(res);
        }
    }
}
