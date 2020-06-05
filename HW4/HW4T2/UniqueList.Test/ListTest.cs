using NUnit.Framework;

namespace HW4T2
{
    public class Tests
    {
        private List testList = null;

        [SetUp]
        public void Setup()
        {
            testList = new List();
        }

        [Test]
        public void AdditionToListFrontTest()
        {
            Assert.AreEqual(0, testList.Size());
            testList.AddToListFront(30);
            Assert.IsTrue(testList.Contains(30));
        }

        [Test]
        public void DeleteFromListFrontTest()
        {
            for (int iter = 0; iter < 30; iter++)
            {
                testList.AddToListFront(iter);
            }
            Assert.IsTrue(testList.Contains(29));
            testList.DeleteFromListFront();
            Assert.IsFalse(testList.Contains(29));
        }

        [Test]
        public void AddHugeCountOfData()
        {
            int size = 10000;
            for (int iter = 0; iter < size; iter++)
            {
                testList.AddToListFront(iter);
            }
            
            for (int iter = size - 1; iter > -1; iter--)
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
                testList.AddToListFront(iter + hugeValue);
            }

            for (int iter = hugeValue + 29; iter > hugeValue - 1; iter--)
            {
                Assert.IsTrue(testList.Contains(iter));
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