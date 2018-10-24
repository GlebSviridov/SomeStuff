using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._5
{
    [TestFixture]
    class Tests
    {
        MyStack<int> st1;
        MyStack<string> st2;
        [SetUp]
        public void SetUp()
        {
            st1 = new MyStack<int>();
            st2 = new MyStack<string>();
        }

        [Test]
        public void Push_SomeIntValue_ValueInStack()
        {
            st1.Push(12);
            Assert.AreEqual(12, st1.Peek());
        }
        [Test]
        public void Push_SomeStringValue_ValueInStack()
        {
            st2.Push("Word");
            Assert.AreEqual("Word", st2.Peek());
        }
        [Test]
        public void PeekINt_VoidType_ValueInStack()
        {
            st1.Push(12);
            st1.Push(122);
            Assert.AreEqual(122, st1.Peek());
        }
        [Test]
        public void PeekString_VoidType_ValueInStack()
        {
            st2.Push("Word");
            st2.Push("Hello");
            Assert.AreEqual("Hello", st2.Peek());
        }
        [Test]
        public void PopInt_VoidType_ValueFromStack()
        {
            st1.Push(12);
            st1.Push(122);
            Assert.AreEqual(122, st1.Pop());
        }
        [Test]
        public void PopString_VoidType_ValueFromStack()
        {
            st2.Push("Word");
            st2.Push("Hello");
            Assert.AreEqual("Hello", st2.Pop());
        }
        [Test]
        public void Peek_EmptyStack_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>((() => st1.Peek()));
        }
        [Test]
        public void Pop_EmptyStack_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>((() => st1.Pop()));
        }


    }
}
