using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._8
{
    [TestFixture]
    class Tests
    {
        PolishCalculator polish;

        [SetUp]
        public void Setup()
        {
            polish = new PolishCalculator();
        }

        [TestCase("5 1 2 + 4 * + 3 -", 14, TestName = "FirstCase")]
        [TestCase("8 1 2 + 4 * + 3 -", 17, TestName = "SecondCase")]
        [TestCase("5 1 2 * 4 * + 3 -", 10, TestName = "ThirdCase")]
        public void Calculate_StringExpression_resNumber(string expression, int resNumber)
        {
            Assert.AreEqual(resNumber, polish.Calculate(expression));
        }

        [Test]
        public void Calculate_Null_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => polish.Calculate(null));
        }

        [Test]
        public void Calculate_EmptyString_Zero()
        {
            Assert.AreEqual(0, polish.Calculate(""));
        }

        [Test]
        public void Calculate_WrongString_ArgumentException()
        {
            Assert.Throws<ArgumentException>((() => polish.Calculate("1+ 2 3 2-")));
        }
    }
}
