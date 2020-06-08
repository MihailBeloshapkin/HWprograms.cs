using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T1
{
    /// <summary>
    /// This class tests Map, Filter and Fold functions.
    /// </summary>
    public class Tests
    {
        private List<int> testList = null;
        private List<int> rightAnswerList = null;

        [SetUp]
        public void Setup()
        {
            testList = new List<int>() { 4, 2, 1, 8, -5, 7, 15 };
        }

        [Test]
        public void AdditionFunctionMapTest()
        {
            testList = MapFilterAndFold.Map(testList, x => x + 30);
            rightAnswerList = new List<int>() { 34, 32, 31, 38, 25, 37, 45 };

            Assert.AreEqual(rightAnswerList, testList);
        }

        [Test]
        public void MultiplicationFunctionMapTest()
        {
            testList = MapFilterAndFold.Map(testList, x => x * 3);
            rightAnswerList = new List<int>() { 12, 6, 3, 24, -15, 21, 45 };

            Assert.AreEqual(rightAnswerList, testList);
        }

        [Test]
        public void FilterTest()
        {
            testList = MapFilterAndFold.Filter(testList, x => x % 2 == 0);
            rightAnswerList = new List<int>() { 4, 2, 8 };

            Assert.AreEqual(rightAnswerList, testList);
        }

        [Test]
        public void FoldTest()
        {
            int current = MapFilterAndFold.Fold(testList, 30, (x, y) => x + y);
            Assert.AreEqual(current, 62);
        }
    }
}