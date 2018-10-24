using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._6
{
    [TestFixture]
    class Tests
    {
        MySet<int> set1;
        MySet<int> set2;
        MySet<string> set3;
        MySet<string> set4;
        [SetUp]
        public void Setup()
        {
            set1 = new MySet<int>(1, 2, 3, 4, 5);
            set2 = new MySet<int>(4, 5, 6, 7, 8);
            set3 = new MySet<string>("1", "2", "3", "four");
            set4 = new MySet<string>("3", "four", "five");
        }

        [Test]
        public void ToString_SomeIntSet_Result()
        {
            Assert.AreEqual("1, 2, 3, 4, 5", set1.ToString());
        }

        [Test]
        public void ToString_SomeStrSet_Result()
        {
            Assert.AreEqual("3, four, five", set4.ToString());
        }

        [Test]
        public void Add_SomeIntAlreadyInSet_OridinalSet()
        {
            set1.Add(2);
            Assert.AreEqual("1, 2, 3, 4, 5", set1.ToString());
        }

        [Test]
        public void Add_SomeStringAlreadyInSet_OridinalSet()
        {
            set4.Add("five");
            Assert.AreEqual("3, four, five", set4.ToString());
        }

        [Test]
        public void Add_SomeIntNotInSet_OridinalSet()
        {
            set1.Add(7);
            Assert.AreEqual("1, 2, 3, 4, 5, 7", set1.ToString());
        }

        [Test]
        public void Add_SomeStringNotInSet_OridinalSet()
        {
            set4.Add("six");
            Assert.AreEqual("3, four, five, six", set4.ToString());
        }

        [Test]
        public void Add_Null_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => set1.Add(null)));
        }

        [Test]
        public void Union_TwoIntSet_ResultSet()
        {
            Assert.AreEqual("1, 2, 3, 4, 5, 6, 7, 8", MySet<int>.Union(set1, set2).ToString());
        }

        [Test]
        public void Union_TwoStringSet_ResultSet()
        {
            Assert.AreEqual("1, 2, 3, four, five", MySet<string>.Union(set3,set4).ToString());
        }

        [Test]
        public void Union_NullBothSet_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => MySet<int>.Union(null, null)));
        }

        [Test]
        public void Union_OneSetNull_OtherSet()
        {
            Assert.AreEqual("1, 2, 3, 4, 5", MySet<int>.Union(set1, null).ToString());
        }

        [Test]
        public void Intersection_TwoIntSet_ResultSet()
        {
            Assert.AreEqual("4, 5", MySet<int>.Intersection(set1, set2).ToString());
        }

        [Test]
        public void Intersection_TwoStringSet_ResultSet()
        {
            Assert.AreEqual("3, four", MySet<string>.Intersection(set3, set4).ToString());
        }

        [Test]
        public void Intersection_NullBothSet_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => MySet<int>.Intersection(null, null)));
        }

        [Test]
        public void Intersection_OneSetNull_OtherSet()
        {
            Assert.AreEqual("1, 2, 3, 4, 5", MySet<int>.Intersection(set1, null).ToString());
        }

        [Test]
        public void Subset_TwoIntSet_False()
        {
            Assert.AreEqual(false, set1.SubSet(set2));
        }

        [Test]
        public void SubSet_TwoStringSet_True()
        {
            Assert.AreEqual(true, set4.SubSet(new MySet<string>("3", "four")));
        }


        [Test]
        public void Subset_OneSetNull_OtherSet()
        {
            Assert.AreEqual(true, set1.SubSet(null));
        }

    }
}
