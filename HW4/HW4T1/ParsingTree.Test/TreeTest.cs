using NUnit.Framework;
using System.Diagnostics.Contracts;

namespace HW4T1
{
    public class Test
    {
        Tree testTree;

        [SetUp]
        public void Setup()
        {
            testTree = null;
        }

        [Test]
        public void SimpleTest1()
        {
            testTree = new Tree("* (+ 5 4) 7");
            Assert.AreEqual(63, testTree.Calculate());
        }

        [Test]
        public void SimpleTest2()
        {
            testTree = new Tree("/ (* (+ 5 4) 7) 7");
            Assert.AreEqual(9, testTree.Calculate());
        }

        [Test]
        public void IncorrectInputTest()
        {
            Assert.Throws<UnrecognisedCharException>(() => testTree = new Tree("+ (a , 9) m"));
        }
    }
}