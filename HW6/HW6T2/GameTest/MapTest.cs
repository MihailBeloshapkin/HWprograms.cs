using NUnit.Framework;
using System;
using System.IO;

namespace HW6T2
{
    public class MapTest
    {
        private Game testGame;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncorrectGameMapTest()
        {
            Assert.Throws<NoSpaceException>(() => testGame = new Game("../../../testMap.txt"));
        }

        [Test]
        public void IncorrectFilePathTest()
        {
            Assert.Throws<FileNotFoundException>(() => testGame = new Game("../../../test1212.txt")) ;
        }
    }
}