using System;
using System.Collections.Generic;
using System.Linq;
using WordCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingWordCount
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {                        
            var result = Program.GetWordFrequency("Test1.txt");

            var expected = new Dictionary<string, int>()
            {
                { "k", 6 },
                {"l", 1},
                {"hej", 1},
                {"med", 1},
                {"jer", 1},
                {"allesammen", 1},
                {"i", 1},
                {"nordea", 1}
            };

            Assert.IsTrue(!result.Except(expected).Any());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = Program.GetWordFrequency("Test2.txt");

            var expected = new Dictionary<string, int>()
            {
                {"a", 3},
                {"b", 2},
                {"c", 1},
                {"d", 1},
                {"e", 1},
            };

            Assert.IsTrue(!result.Except(expected).Any());
        }
    }
}
