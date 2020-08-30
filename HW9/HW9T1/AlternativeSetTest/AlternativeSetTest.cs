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
        private AlternativeISet<int> testSet;

        [SetUp]
        public void Setup()
        {
            testSet = new AlternativeISet<int>(new IntegerComparer()) { 15, -7, 19, 25, 128, -72, 54, 1992 };
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

        [Test]
        public void ExceptWithTest()
        {
            testSet.ExceptWith(new int[4] { 15, 128, 54, -72 });
            Assert.IsTrue(testSet.SetEquals(new int[4] { 19, 25, 1992, -7 }));
        }

        [Test]
        public void IntersectWithTest()
        {
            testSet.IntersectWith(new int[4] { 15, 128, 54, -72 });
            Assert.IsTrue(testSet.SetEquals(new int[4] { 15, 128, 54, -72 }));
        }

        [Test]
        public void IsProperSubsetOfTest1()
        {
            Assert.IsTrue(testSet.IsProperSubsetOf(new int[12] { 15, 19, 25, 128, 1992, 54, -7, -72, 45, 89, -801, 90 }));
            Assert.IsTrue(testSet.IsProperSubsetOf(new int[10] { 15, 19, 25, 128, 1992, 54, 75, 12, -7, -72 }));
        }

        [Test]
        public void IsProperSubsetOfTest2()
        {
            Assert.IsFalse(testSet.IsProperSubsetOf(new int[12] { 15, 19, 25, 128, 1992, 51, -7, -72, 45, 89, -801, 90 }));
            Assert.IsFalse(testSet.IsProperSubsetOf(new int[10] { 15, 91, 25, 128, 1992, 54, 75, 12, -7, -72 }));
            Assert.IsFalse(testSet.IsProperSubsetOf(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsTrue(testSet.IsProperSupersetOf(new int[3] { 25, 1992, -72}));
            Assert.IsFalse(testSet.IsProperSupersetOf(new int[4] { 25, 1992, 128, 129 }));
            Assert.IsFalse(testSet.IsProperSupersetOf(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(testSet.IsSubsetOf(new int[12] { 15, 19, 25, 128, 1992, 54, -7, -72, 45, 89, -801, 90 }));
            Assert.IsTrue(testSet.IsSubsetOf(new int[10] { 15, 19, 25, 128, 1992, 54, 75, 12, -7, -72 }));
            Assert.IsTrue(testSet.IsSubsetOf(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsTrue(testSet.IsSupersetOf(new int[3] { 25, 1992, -72 }));
            Assert.IsFalse(testSet.IsSupersetOf(new int[4] { 25, 1992, 128, 129 }));
            Assert.IsTrue(testSet.IsSupersetOf(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
        }

        [Test]
        public void OverlapsTest()
        {
            Assert.IsTrue(testSet.Overlaps(new int[8] { 15, -21, 25, 128, 93, 54, -7, 1 }));
            Assert.IsFalse(testSet.Overlaps(new int[3] { 30, 31, 32}));
        }

        [Test]
        public void SetEqualsTest()
        {
            Assert.IsTrue(testSet.SetEquals(new int[8] { 15, 19, 25, 128, 1992, 54, -7, -72 }));
            Assert.IsFalse(testSet.SetEquals(new int[8] { 15, 19, 25, 129, 1993, 54, -8, -73 }));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            testSet.SymmetricExceptWith(new int[4] { 15, -7, 1992, 30 });
            Assert.IsTrue(testSet.SetEquals(new int[6] {19, 25, 128, 30, 54, -72 }));
        }

        [Test]
        public void UnionWithTest()
        {
            testSet.UnionWith(new int[4] { 30, 31, 90, 100 });
            Assert.IsTrue(testSet.SetEquals(new int[12] { 15, 19, 25, 128, 1992, 54, -7, -72, 30, 31, 90, 100 }));
        }
    }
}