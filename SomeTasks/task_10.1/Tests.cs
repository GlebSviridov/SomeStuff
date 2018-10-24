using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._1
{
    [TestFixture]
    class Tests
    {
        BinarySearching binSearch;
        [SetUp]
        public void SetUp()
        {
            binSearch = new BinarySearching();
        }

        [Test]
        public void BinarySearch_intArrayEvenFindNumberIntComparer_ResultIndex()
        {
            var intArray = new[] {1, 2, 3, 4, 5, 6};
            var findNumber = 2;
            Assert.AreEqual(1, binSearch.BinarySearch(intArray,findNumber, Comparer<int>.Default));
        }
        [Test]
        public void BinarySearch_intArrayOddFindNumberIntComparer_ResultIndex()
        {
            var intArray = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var findNumber = 6;
            Assert.AreEqual(5, binSearch.BinarySearch(intArray, findNumber, Comparer<int>.Default));
        }
        [Test]
        public void BinarySearch_intArrayOddFindNumberIntComparer_MinusOne()
        {
            var intArray = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var findNumber = 10;
            Assert.AreEqual(-1, binSearch.BinarySearch(intArray, findNumber, Comparer<int>.Default));
        }
        [Test]
        public void BinarySearch_stringArrayOddFindStrngStrComparer_ResultIndex()
        {
            var strArray = new[] {"abc", "def", "gh", "ijk", "lm"};
            var findString = "abc";
            Assert.AreEqual(0, binSearch.BinarySearch(strArray, findString, Comparer<string>.Default));
        }
        [Test]
        public void BinarySearch_stringArrayEvenFindStrngStrComparer_ResultIndex()
        {
            var strArray = new[] { "abc", "def", "gh", "ijk" };
            var findString = "ijk";
            Assert.AreEqual(3, binSearch.BinarySearch(strArray, findString, Comparer<string>.Default));
        }
        [Test]
        public void BinarySearch_NullArray_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => binSearch.BinarySearch(null, 2, Comparer<int>.Default)));
        }
        [Test]
        public void BinarySearch_NullItem_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => binSearch.BinarySearch(new[] {"One", "two"}, null, Comparer<string>.Default)));
        }
    }
}
