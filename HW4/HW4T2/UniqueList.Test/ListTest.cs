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
        public void AddToListPositionTest()
        {
            for (int iter = 0; iter < 5; iter++)
            {
                testList.AddToListFront(iter);
            }

            testList.AddToListPosition(2, 30);
            Assert.AreEqual(2, testList.GetPositionByData(30));
        }

        [Test]
        public void ChangeElementByPositionTest()
        {
            for (int iter = 0; iter < 5; iter++)
            {
                testList.AddToListFront(iter);
            }

            testList.ChangeElementByPosition(2, 30);
            Assert.AreEqual(30, testList.GetDataByPosition(2));
        }

        [Test]
        public void DeleteByListPositionTest()
        {
            for (int iter = 0; iter < 5; iter++)
            {
                testList.AddToListFront(iter);
            }

            testList.DeleteFromListPosition(2);
            Assert.IsFalse(testList.Contains(2));
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