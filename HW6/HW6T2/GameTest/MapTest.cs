using NUnit.Framework;

namespace HW6T2
{
    public class MapTest
    {
        Game testGame;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncorrectGameMapTest()
        {
            Assert.Throws<NoSpaceException>(() => testGame = new Game("../../../testMap.txt"));
        }
    }
}