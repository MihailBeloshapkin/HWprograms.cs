using NUnit.Framework;

namespace test2
{
    public class Tests
    {
        int[] result;
        int[] rightAnswer;
        MoveToFront testClass;

        [SetUp]
        public void Setup()
        {
            result = null;
            rightAnswer = null;
            testClass = new MoveToFront();
        }

        [Test]
        public void SimpleInputTest1()
        {
            result = testClass.MoveToFrontAlg("banana");
            rightAnswer = new int[] { 1, 1, 13, 1, 1, 1 };

            Assert.AreEqual(result.Length, rightAnswer.Length);

            for (int iter = 0; iter < result.Length; iter++)
            {
                Assert.AreEqual(result[iter], rightAnswer[iter]);
            }
        }

        [Test]
        public void SimpleInputTest2()
        {
            result = testClass.MoveToFrontAlg("algorithm");
            rightAnswer = new int[] { 0, 11, 7, 14, 17, 11, 19, 12, 15 };

            Assert.AreEqual(result.Length, rightAnswer.Length);

            for (int iter = 0; iter < result.Length; iter++)
            {
                Assert.AreEqual(result[iter], rightAnswer[iter]);
            }
        }
    
        [Test]
        public void InputContainsCaptialLettersTest()
        {
            result = testClass.MoveToFrontAlg("BaNaNa");
            rightAnswer = new int[] { 1, 1, 13, 1, 1, 1 };

            Assert.AreEqual(result.Length, rightAnswer.Length);

            for (int iter = 0; iter < result.Length; iter++)
            {
                Assert.AreEqual(result[iter], rightAnswer[iter]);
            }
        }

        [Test]
        public void CapsOnlyTest()
        {
            result = testClass.MoveToFrontAlg("ALGORITHM");
            rightAnswer = new int[] { 0, 11, 7, 14, 17, 11, 19, 12, 15 };

            Assert.AreEqual(result.Length, rightAnswer.Length);

            for (int iter = 0; iter < result.Length; iter++)
            {
                Assert.AreEqual(result[iter], rightAnswer[iter]);
            }
        }

        [Test]
        public void IncorrectInputTest()
        {
            Assert.Throws<InputContainsIncorrectSymbolsException>(() => testClass.MoveToFrontAlg("7*676V6"));
        }
    }
}