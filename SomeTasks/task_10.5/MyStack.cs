using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._5
{
    class MyStack<T> : IEnumerable<T>
    {
        private T[] stackArr;
        private int currPos;
        

        public MyStack()
        {
            this.currPos = 0;
            this.stackArr = new T[5];
        }
        public T Peek()
        {
            if (currPos == 0)
                throw new InvalidOperationException("There are nothing in Stack now");
            return stackArr[currPos - 1];
        }

        public void Push(T value)
        {
            if (currPos == stackArr.Length)
            {
                var newStackArr = new T[stackArr.Length * 2];
                Array.Copy(stackArr,newStackArr, stackArr.Length);
                stackArr = newStackArr;
            }
            stackArr[currPos++] = value;
        }

        public T Pop()
        {
            if (currPos == 0)
                throw new  InvalidOperationException("There are nothing in Stack now");
            return stackArr[--currPos];
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyStackEnumerator<T>(stackArr, currPos);
        }

        public IEnumerator GetEnumerator()
        {
            return new MyStackEnumerator<T>(stackArr, currPos);
        }


    }

    class MyStackEnumerator<T> : IEnumerator<T>
    {
        private T[] stackArr;
        private T currentElement;
        private int curIndex;
        private int curPos;

        public MyStackEnumerator(T[] stackArr, int cur)
        {
            this.stackArr = stackArr;
            currentElement = default(T);
            curIndex = -1;
            curPos = cur;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++curIndex >= curPos)
            {
                Reset();
                return false;
            }
            else
            {
                currentElement = stackArr[curIndex];
            }

            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }

        public T Current => currentElement;

        object IEnumerator.Current => Current;
    }
}

