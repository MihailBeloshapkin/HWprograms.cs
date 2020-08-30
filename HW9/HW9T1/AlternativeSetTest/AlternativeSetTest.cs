using HW9T1;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections;
using System.Linq;

namespace AlternativeSetTest
{
    public class Tests
    {
        private IEnumerable collection;
        private AlternativeISet<int> testSet;

        [SetUp]
        public void Setup()
        {
            testSet = new AlternativeISet<int>(new IntegerComparer()) { 15, -7, 19, 25, 128, -72, 54, 1992 };
         //   collection = new IEnumerable<int>();
        }

        [Test]
        public void SimpleAdditionTest()
        {
            testSet.Add(30);
            testSet.Add(239);
            Assert.IsTrue(testSet.Contains(30));
            Assert.IsTrue(testSet.Contains(239));
        }

        [Test]
        public void SimpleRemoveTest()
        {
            testSet.Remove(19);
            Assert.IsFalse(testSet.Contains(19));
        }

        [Test]
        public void ClearTest()
        {
            Assert.AreEqual(8, testSet.Count);
            testSet.Clear();
            Assert.AreEqual(0, testSet.Count);
        }

        [Test]
        public void ContainsTest()
        {
            Assert.IsFalse(testSet.Contains(30));
            testSet.Add(30);
            Assert.IsTrue(testSet.Contains(30));
        }

        [Test]
        public void CopyToTest()
        {
            int[] array = new int[8];
            testSet.CopyTo(array, 0);
            Assert.IsTrue(array.SequenceEqual(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
        }


    }
}