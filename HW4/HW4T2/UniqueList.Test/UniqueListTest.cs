using NUnit.Framework;

namespace HW4T2
{
    /// <summary>
    /// Tests UniqueList class.
    /// </summary>
    class UniqueListTest
    {
        UniqueList testList = null;

        [SetUp]
        public void SetUp()
        {
            testList = new UniqueList();
        }

        [Test]
        public void AddToListFrontRepetitiveElementsTest()
        {
            testList.AddToListFront(30);
            Assert.Throws<AddDataThatIsAlreadyInTheListException>(() => testList.AddToListFront(30));
        }

        [Test]
        public void AddtolistBackRepetitiveElementsTest()
        {
            testList.AddToListBack(30);
            testList.AddToListBack(31);
            testList.AddToListBack(32);
            Assert.Throws<AddDataThatIsAlreadyInTheListException>(() => testList.AddToListBack(30));
        }

        [Test]
        public void DeleteFromEmptyListFrontTest()
        {
            Assert.Throws<DeleteFromEmptyListException>(() => testList.DeleteFromListFront());
        }

        [Test]
        public void DeleteFromEmptyListBackTest()
        {
            Assert.Throws<DeleteFromEmptyListException>(() => testList.DeleteFromListBack());
        }
    }
}
