using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace HW3T1
{
    public class StackTest
    {
        private bool isCorrect;

        [SetUp]
        public void Setup()
        {
            isCorrect = false;
        }

        static IEnumerable<IStack> TestStacks()
        {
            yield return new StackArray();
            yield return new StackList();
        }

        [TestCaseSource(nameof(TestStacks))]
        public void SimplePushTest(IStack testStack)
        {
            Assert.IsTrue(testStack.IsEmpty());
            testStack.Push(30);
            Assert.IsFalse(testStack.IsEmpty());
        }

        [TestCaseSource(nameof(TestStacks))]
        public void SimplePopTest(IStack testStack)
        {
            testStack.Push(30);
            var result = testStack.Pop(ref isCorrect);
            Assert.AreEqual(30, result);
        }

        [TestCaseSource(nameof(TestStacks))]
        public void PopFromEmptyStackTest(IStack testStack)
        {
            testStack.Pop(ref isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [TestCaseSource(nameof(TestStacks))]
        public void HugeCountOfInputDataTest(IStack testStack)
        {
            for (int iter = 0; iter < 1000000; iter++)
            {
                testStack.Push(iter);
            }

            for (int iter = 999999; iter >= 0; iter--)
            {
                var result = testStack.Pop(ref isCorrect);
                Assert.AreEqual(iter, result);
            }
        }

        [TestCaseSource(nameof(TestStacks))]
        public void HugeValueOfInputDataTest(IStack testStack)
        {
            for (int iter = 0; iter < 30; iter++)
            {
                testStack.Push(1000000000 + iter);
            }

            for (int iter = 0; iter < 30; iter++)
            {
                var result = testStack.Pop(ref isCorrect);
                Assert.AreEqual(1000000029 - iter, result);
            }
        }
    }
}