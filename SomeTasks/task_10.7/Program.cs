using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._7
{
    class Program
    {
        static void Main(string[] args)
        {
            var binTree = new BinarySearchTree<string>(StringComparer.CurrentCulture);
            binTree.Add("c");
            binTree.Add("b");
            binTree.Add("d");
            binTree.Add("a");
            binTree.Add("y");
            binTree.AddRange(new string[]{"I"});
            Console.WriteLine(binTree.Contains("word"));
            Console.WriteLine(binTree.Count());
            Console.WriteLine(binTree.Count());
            var resPre = binTree.PreOrderTraversal();
            foreach (var re in resPre)
            {
                Console.Write("{0}...", re);
            }
            Console.WriteLine();
            var resPost = binTree.PostOrderTraversal();
            foreach (var re in resPost)
            {
                Console.Write("{0}...", re);
            }
            Console.WriteLine();
            var resIn = binTree.InOrderTraversal();
            foreach (var re in resIn)
            {
                Console.Write("{0}...", re);
            }


        }
    }
}
