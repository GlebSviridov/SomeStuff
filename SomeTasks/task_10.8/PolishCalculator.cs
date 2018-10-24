using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task_10._8
{
    class PolishCalculator
    {
        public int Calculate(string stringToCalculate)
        {
            if (stringToCalculate == null)
                throw new NullReferenceException("The string is null");
            if (stringToCalculate.Length == 0)
                return 0;
            
            string[] strArray = stringToCalculate.Split(' ');
            var stack = new Stack<int>();

            foreach (var s in strArray)
            {
                if (s == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (s == "-")
                {
                    var tempSecond = stack.Pop();
                    var tempFirst = stack.Pop();
                    stack.Push(tempFirst - tempSecond);
                }
                else if (s == "*")
                {
                    var tempSecond = stack.Pop();
                    var tempFirst = stack.Pop();
                    stack.Push(tempFirst * tempSecond);

                }
                else if (s == "/")
                {
                    var tempSecond = stack.Pop();
                    var tempFirst = stack.Pop();
                    stack.Push(tempFirst / tempSecond);
                }
                else if (s.Length > 1)
                {
                    throw new ArgumentException("You sent wrong parameters");
                }
                else
                {
                    stack.Push(Int32.Parse(s));
                }
            }

            return stack.Pop();
        }
    }
}
