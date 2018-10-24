using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var binSearch = new BinarySearching();
            var res = binSearch.BinarySearch(new[] {"abc", "def", "gh", "ijk"}, "ijk", Comparer<string>.Default);
            Console.WriteLine(res);
        }
    }
}
