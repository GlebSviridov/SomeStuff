using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._8
{
    class Program
    {
        static void Main(string[] args)
        {
            var polish = new PolishCalculator();
            Console.WriteLine(polish.Calculate(""));
        }
    }
}
