using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordFreq = new WordsFrequency();
            string fromFile = System.IO.File.ReadAllText(@"C:\Users\Gleb\GSviridov\HW_10\task_10.2\FileToReadFrom.txt");
            var resDict = wordFreq.CountWords(fromFile);
            foreach (var i in resDict)
            {
                Console.WriteLine("{0} -- {1}", i.Key, i.Value);
            }
        }
    }
}
