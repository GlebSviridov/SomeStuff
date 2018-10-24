using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new MySet<int>();
            firstSet.Add(10, 12, 32, 10);
            var secondSet = new MySet<int>();
            secondSet.Add(112, 2, 12);
            firstSet.Add(99);
            Console.WriteLine(firstSet.ToString());
            var set1 = new MySet<int>(1, 2, 3, 4, 5);
            Console.WriteLine(set1.ToString());
            var resSetUnion = MySet<int>.Union(firstSet, secondSet);
            
            var resSetIntersection = MySet<int>.Intersection(firstSet, secondSet);

            Console.WriteLine("_________________________________________");
            foreach (var i in firstSet)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(firstSet.SubSet(secondSet));
        }
    }
}
