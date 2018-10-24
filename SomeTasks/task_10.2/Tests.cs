using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task_10._2
{
    [TestFixture]
    class Tests
    {
        WordsFrequency freqWords;
        [SetUp]
        public void Setup()
        {
            freqWords = new WordsFrequency();
        }

        [Test]
        public void CountWords_SomeString_ResultDictionary()
        {
            var resDict = new Dictionary<string, int>() {{"this", 1}, {"is", 1}, {"test", 2}};
            Assert.AreEqual(resDict, freqWords.CountWords("test! is this test"));
        }
        [Test]
        public void CountWords_NullString_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>((() => freqWords.CountWords(null)));
        }
    }
}
