using NUnit.Framework;

namespace HW3T1
{
    public class TestEvaluator
    {
        bool isCorrect;

        [SetUp]
        public void Setup()
        {
            isCorrect = true;
        }

        [Test]
        public void TypicalInputTest1()
        {
            int answer1 = Calculation.Evaluator("2 7 + 3 / 8 *", 0, ref isCorrect);
            Assert.AreEqual(answer1, 24);
        }

        [Test]
        public void TypicalInputTest2()
        {
            isCorrect = true;
            int answer3 = Calculation.Evaluator("6 9 + 5 - 9 5 * +", 0, ref isCorrect);
            Assert.AreEqual(answer3, 55);
        }

        [Test]
        public void IncorrectInputTest()
        {
            Calculation.Evaluator("2 7 + 3 / 8 ", 0, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void InputContainsHHugeNumbers()
        {
            Calculation.Evaluator("9999999999 123456789 -", 0, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void InputContainsIncorrectSymbols()
        {
            Calculation.Evaluator("2 & * ( , m", 1, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void OnlyOneNumberInput()
        {
            Assert.AreEqual(30, Calculation.Evaluator("30", 0, ref isCorrect));
        }

        [Test]
        public void EmptyInput()
        {
            Calculation.Evaluator("", 1, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void OnlyIncorrectTrash()
        {
            Calculation.Evaluator("&^%$#VBNM<>?ца1234%$#@#$%^&*(", 1, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void InputContainsFloatNumbers()
        {
            Calculation.Evaluator("12.7 89.5 +", 0, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void ZeroDivisionTest()
        {
            Calculation.Evaluator("9 0 /", 0, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void MultiplyTwoZeros()
        {
            Assert.AreEqual(Calculation.Evaluator("0 0 *", 0, ref isCorrect), 0);
        }

        [Test]
        public void AdditionOfTwoZeros()
        {
            Assert.AreEqual(Calculation.Evaluator("0 0 +", 0, ref isCorrect), 0);
        }

        [Test]
        public void IncorrectFormOdNegativeValue()
        {
            Calculation.Evaluator("-1 9 *", 0, ref isCorrect);
            Assert.IsFalse(isCorrect);
        }
    }
}