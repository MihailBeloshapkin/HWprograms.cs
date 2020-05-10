using NUnit.Framework;

namespace HW3T2
{
    /// <summary>
    /// Tests list methods.
    /// </summary>
    class ListTest
    {
        private List list;

        [SetUp]
        public void Setup()
        {
            list = new List();
        }

        [Test]
        public void AdditionTest()
        {
            list.Addition("word");
            Assert.IsTrue(list.Contains("word"));
        }

        [Test]
        public void DeletionTest()
        {
            list.Addition("word");
            list.DeleteElement("word");
            Assert.IsFalse(list.Contains("word"));
        }

        [Test]
        public void DeleteFromEmptyListTest()
        {
            list.DeleteElement("word");
            Assert.AreEqual(0, list.Size());
        }

        [Test]
        public void SizeCounterTest()
        {
            for (int iter = 0; iter < 1000; iter++)
            {
                list.Addition("word");
            }
            Assert.AreEqual(1000, list.Size());
        }

        [Test]
        public void HugeCountOfInputData()
        {
            for (int iter = 0; iter < 1000; iter++)
            {
                list.Addition("word");
            }
            Assert.IsTrue(list.Contains("word"));
            Assert.AreEqual(1000, list.Size());
        }
    }
}