using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._6
{
    class MySet<T>: IEnumerable<T>
    {
        private List<T> setArr;

        public MySet(params T[] parArray)
        {
            if (parArray == null)
                throw new NullReferenceException("the array is null!");
            this.setArr = new List<T>(parArray);
        }
        public MySet()
        {
            this.setArr = new List<T>();
        }


        public void Add(params T[] values)
        {
            if (values == null)
                throw new NullReferenceException("There are must be not null");

            foreach (var value in values)
            {
                if (!setArr.Contains(value))
                {
                    setArr.Add(value);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < setArr.Count; i++)
            {
                yield return setArr[i];
            }
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in setArr)
            {
                sb.AppendFormat("{0}, ", s);
            }

            return sb.Remove(sb.Length - 2, 2).ToString();
        }

        public void Dispose()
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < setArr.Count; i++)
            {
                yield return setArr[i];
            }
        }

        public static MySet<T> Union(MySet<T> fSet, MySet<T> otherSet)
        {
            if ((fSet == null) && (otherSet == null))
                throw new NullReferenceException("Set must be not empty");
            if (fSet == null)
                return otherSet;
            if (otherSet == null)
                return fSet;
            var resSet = new MySet<T>();
            foreach (var s in fSet.setArr)
            {
                resSet.setArr.Add(s);
            }
            foreach (var s in otherSet.setArr)
            {
                if (!resSet.setArr.Contains(s))
                {
                    resSet.setArr.Add(s);
                }
            }

            return resSet;
        }

        public static MySet<T> Intersection(MySet<T> fSet, MySet<T> otherSet)
        {
            if ((fSet == null) && (otherSet == null))
                throw new NullReferenceException("Set must be not empty");
            if (fSet == null)
                return otherSet;
            if (otherSet == null)
                return fSet;
            var resSet = new MySet<T>();
            foreach (var s in fSet.setArr)
            {
                if (fSet.setArr.Contains(s) && otherSet.setArr.Contains(s))
                {
                    resSet.setArr.Add(s);
                }
            }

            return resSet;

        }

        public bool SubSet(MySet<T> otherSet)
        {
            if (otherSet == null)
                return true;
            foreach (var s in otherSet.setArr)
            {
                if (!this.setArr.Contains(s))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
