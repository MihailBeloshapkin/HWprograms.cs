using NUnit.Framework;

namespace HW3T2
{

    /// <summary>
    /// Tests hash table
    /// </summary>
    public class HashTest
    {
        Hash table;
        [SetUp]
        public void Setup()
        {
            table = new Hash(2, 0);
        }

        [Test]
        public void AdditionToHashTableTest()
        {
            table.AddToHashTable("word");
            Assert.IsTrue(table.Contains("word"));
        }

        [Test]
        public void DeletionFromHashTableTest()
        {
            table.AddToHashTable("word");
            table.DeleteDataFromHashTable("word");
            Assert.IsFalse(table.Contains("word"));
        }

        [Test]
        public void DeleteFromEmptyHashTableTest()
        {
            Assert.IsFalse(table.DeleteDataFromHashTable("abc"));
        }

        [Test]
        public void HugeCountOfDataTest()
        {
            for (int iter = 0; iter < 1000; iter++)
            {
                table.AddToHashTable("abc");
            }

            Assert.IsTrue(table.Contains("abc"));
        }
    }
}