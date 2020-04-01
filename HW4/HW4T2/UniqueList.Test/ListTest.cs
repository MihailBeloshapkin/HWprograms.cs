using NUnit.Framework;

namespace HW4T2
{
    public class Tests
    {
        List testList = null;

        [SetUp]
        public void Setup()
        {
            testList = new List();
        }

        [Test]
        public void AdditionToListFrontTest()
        {
            Assert.AreEqual(testList.Size(), 0);
            testList.AddToListFront(30);
            Assert.IsTrue(testList.Contains(30));
        }

        [Test]
        public void AdditionToListBackTest()
        {
            Assert.AreEqual(testList.Size(), 0);
            testList.AddToListBack(30);
            Assert.IsTrue(testList.Contains(30));
        }

        [Test]
        public void DeleteFromListFrontTest()
        {
            for (int iter = 0; iter < 30; iter++)
            {
                testList.AddToListBack(iter);
            }
            Assert.IsTrue(testList.Contains(0));
            testList.DeleteFromListFront();
            Assert.IsFalse(testList.Contains(0));
        }

        [Test]
        public void DeleteFromListBackTest()
        {
            for (int iter = 0; iter < 30; iter++)
            {
                testList.AddToListBack(iter);
            }
            Assert.IsTrue(testList.Contains(29));
            testList.DeleteFromListBack();
            Assert.IsFalse(testList.Contains(29));
        }

        [Test]
        public void AddHugeCountOfData()
        {
            int size = 10000;
            for (int iter = 0; iter < size; iter++)
            {
                testList.AddToListBack(iter);
            }
            
            for (int iter = 0; iter < size; iter++)
            {
                Assert.IsTrue(testList.Contains(iter));
                testList.DeleteFromListFront();
            }
        }

        [Test]
        public void AddHugeDataTest()
        {
            int hugeValue = 100000000;

            for (int iter = 0; iter < 30; iter++)
            {
                testList.AddToListBack(iter + hugeValue);
            }

            for (int iter = 0; iter < 30; iter++)
            {
                Assert.IsTrue(testList.Contains(iter + hugeValue));
                testList.DeleteFromListFront();
            }
        }

        [Test]
        public void DeleteFromEmptyList()
        {
            Assert.Throws<DeleteFromEmptyListException>(() => testList.DeleteFromListFront());
        }
    }
}