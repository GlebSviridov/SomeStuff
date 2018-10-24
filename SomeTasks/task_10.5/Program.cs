using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._5
{
    class Program
    {
        static void Main(string[] args)
        {
            var st2 = new MyStack<string>();
            var st = new MyStack<int>();
            st.Push(12);
            st.Push(10);
            st.Push(12);
            st.Push(10);
            st.Push(12);
            st.Push(7);
            st2.Push("i");
            st2.Push("am");
            st2.Push("The");
            st2.Push("stack");
            Console.WriteLine(st.Peek());
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Peek());
            st.Push(77);
            foreach (var s in st2)
            {
                Console.WriteLine(s);
            }

        }
    }
}
