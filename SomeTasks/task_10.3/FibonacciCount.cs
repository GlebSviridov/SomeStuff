using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._3
{
    class FibonacciCount
    {
        public int FibFind(int number)
        {
            if ((number == 1) || (number == 2))
                return 1;
            if (number < 1)
                throw new ArgumentException("The number must be more than 1!");
            var resEnum = FibCount(number);
            return resEnum.Last();
        }


        public static IEnumerable<int> FibCount(int number)
        {
            var firstNum = 0;
            var secondNum = 1;
            var nextNum = firstNum + secondNum;
            while (number> 1)
            {
                nextNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = nextNum;
                yield return nextNum;
                number -= 1;
            }


        }
    }
}
