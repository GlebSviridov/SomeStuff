using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._3
{
    [TestFixture]
    class Tests
    {
        FibonacciCount fib;
        [SetUp]
        public void SetUp()
        {
            fib = new FibonacciCount();
        }

        [TestCase(5, 5, TestName = "FirstCase")]
        [TestCase(1, 1, TestName = "SecondCase")]
        [TestCase(2, 1, TestName = "ThirdCase")]
        [TestCase(10, 55, TestName = "FourthCase")]
        public void FibFind_FibNumber_ResNumber(int fibNumber, int resNumber)
        {
            Assert.AreEqual(resNumber, fib.FibFind(fibNumber));
        }

        [Test]
        public void FibFind_FibNumberLessThanZero_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => fib.FibFind(0));
        }

    }
}
