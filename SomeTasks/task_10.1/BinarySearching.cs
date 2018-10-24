using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._1
{
    class BinarySearching
    {
        public int BinarySearch<T>(T[] arr, T item, Comparer<T> comparer)
        {
            if (arr == null)
                throw new NullReferenceException("The array is null");
            if ( item == null)
                throw new NullReferenceException("The item is null");

            var low = 0;
            var high = arr.Length - 1;

            while (high >= low)
            {
                var mid = (high + low) / 2;
                if (comparer.Compare(arr[mid], item) == 0)
                {
                    return mid;
                }

                if (comparer.Compare(arr[mid], item) > 0)
                {
                    high = mid;

                }
                if (comparer.Compare(arr[mid], item) < 0)
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
