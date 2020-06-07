using NUnit.Framework;

namespace HW3T1
{
    public class TestEvaluator
    {
        private int answer;
        private bool isCorrect;
        private Calculator testCalculator;
        private IStack testStack;

        [SetUp]
        public void Setup()
        {
            answer = 0;
            testStack = new StackList();
            testCalculator = new Calculator(testStack);
            isCorrect = true;
        }
        

        [Test]
        public void TypicalInputTest1()
        {
            (answer, isCorrect) = testCalculator.Evaluate("2 7 + 3 / 8 *");
            Assert.AreEqual(24, answer);
        }

        [Test]
        public void TypicalInputTest2()
        {
            (answer, isCorrect) = testCalculator.Evaluate("6 9 + 5 - 9 5 * +");
            Assert.AreEqual(55, answer);
        }

        [Test]
        public void IncorrectInputTest()
        {
            (answer, isCorrect) = testCalculator.Evaluate("2 7 + 3 / 8 ");
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void InputContainsIncorrectSymbols()
        {
            (answer, isCorrect) = testCalculator.Evaluate("2 & * ( , m");
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void OnlyOneNumberInput()
        {
            (answer, isCorrect) = testCalculator.Evaluate("30");
            Assert.AreEqual(30, answer);
        }

        [Test]
        public void EmptyInput()
        {
            (answer, isCorrect) = testCalculator.Evaluate("");
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void OnlyIncorrectTrash()
        {
            (answer, isCorrect) = testCalculator.Evaluate("&^%$#VBNM<>?ца1234%$#@#$%^&*(");
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void InputContainsFloatNumbers()
        {
            (answer, isCorrect) = testCalculator.Evaluate("12.7 89.5 +");
            Assert.IsFalse(isCorrect);
        }
        
        [Test]
        public void ZeroDivisionTest()
        {
            (answer, isCorrect) = testCalculator.Evaluate("9 0 /");
            Assert.IsFalse(isCorrect);
        }
        
        [Test]
        public void MultiplyTwoZeros()
        {
            (answer, isCorrect) = testCalculator.Evaluate("0 0 *");
            Assert.AreEqual(0, answer);
        }

        [Test]
        public void AdditionOfTwoZeros()
        {
            (answer, isCorrect) = testCalculator.Evaluate("0 0 +");
            Assert.AreEqual(0, answer);
        }

        [Test]
        public void IncorrectFormOdNegativeValue()
        {
            (answer, isCorrect) = testCalculator.Evaluate("-1 9 *");
            Assert.IsFalse(isCorrect);
        }
        
    }
}