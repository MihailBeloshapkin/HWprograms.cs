using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;

namespace HW6T2
{
    public class MapTest
    {
        private Game testGame;
        private Map testMap;

        [SetUp]
        public void Setup()
        {
            testMap = new Map("../../../testMap2.txt");
        }

        [Test]
        public void IncorrectGameMapTest()
        {
            Assert.Throws<NoSpaceException>(() => testGame = new Game("../../../testMap1.txt"));
        }

        [Test]
        public void IncorrectFilePathTest()
        {
            Assert.Throws<FileNotFoundException>(() => testGame = new Game("../../../test1212.txt")) ;
        }

        [Test]
        public void CharacterPositionSetTest()
        {
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void SimpleMoveRightTest()
        {
            testMap.MoveTheCharacter(1, 0);
            Assert.AreEqual(5, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void SimpleMoveDowmTest()
        {
            testMap.MoveTheCharacter(0, 1);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(2, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void SimpleMoveLeftTest()
        {
            testMap.MoveTheCharacter(1, 0);
            testMap.MoveTheCharacter(-1, 0);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void SimpleMoveUpTest()
        {
            testMap.MoveTheCharacter(0, 1);
            testMap.MoveTheCharacter(0, -1);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void MoveToTheWallTest1()
        {
            testMap.MoveTheCharacter(0, -1);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void MoveToTheWallTest2()
        {
            testMap.MoveTheCharacter(-1, 0);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void MoveToTheWallTest3()
        {
            testMap.MoveTheCharacter(1000, 1000);
            Assert.AreEqual(4, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(1, testMap.GetCharacterCoordinateY());
        }

        [Test]
        public void ComplexTrajectoryTest()
        {
            testMap.MoveTheCharacter(0, 2);
            testMap.MoveTheCharacter(7, 0);
            testMap.MoveTheCharacter(-2, 2);
            testMap.MoveTheCharacter(-2, 2);
            testMap.MoveTheCharacter(-2, 0);
            testMap.MoveTheCharacter(0, 2);
            testMap.MoveTheCharacter(5, 0);
            Assert.AreEqual(10, testMap.GetCharacterCoordinateX());
            Assert.AreEqual(7, testMap.GetCharacterCoordinateY());
        }
    }
}