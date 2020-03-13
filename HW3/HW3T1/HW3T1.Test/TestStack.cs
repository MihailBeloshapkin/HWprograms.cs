using System;
using NUnit.Framework;
using System.Collections;

namespace HW3T1
{
    public class StackTest
    {
        private IStack listStack;
        private IStack arrayStack;
        bool isCorrect;

        [SetUp]
        public void Setup()
        {
            listStack = new StackList();
            arrayStack = new StackArray();
            isCorrect = false;
        }

        [Test]
        public void PushTest()
        {
            Assert.IsTrue(listStack.IsEmpty());
            Assert.IsTrue(arrayStack.IsEmpty());
            listStack.Push(7);
            arrayStack.Push(7);
            Assert.IsFalse(listStack.IsEmpty());
            Assert.IsFalse(arrayStack.IsEmpty());
        }

        [Test]
        public void PopTest()
        {
            listStack.Push(7);
            arrayStack.Push(7);
            var result1 = listStack.Pop(ref isCorrect);
            var result2 = arrayStack.Pop(ref isCorrect);
            Assert.AreEqual(7, result1);
            Assert.AreEqual(7, result2);
        }

        [Test]
        public void PopFromEmptyStack()
        {
            var result1 = listStack.Pop(ref isCorrect);
            var result2 = arrayStack.Pop(ref isCorrect);
            Assert.IsFalse(isCorrect);
            Assert.IsFalse(isCorrect);
        }

        [Test]
        public void HugeCountOfInputDataTest()
        {
            for (int iter = 0; iter < 1000000; iter++)
            {
                listStack.Push(iter);
                arrayStack.Push(iter);
            }
            for (int iter = 999999; iter >= 0; iter--)
            {
                var result1 = listStack.Pop(ref isCorrect);
                var result2 = arrayStack.Pop(ref isCorrect);
                Assert.AreEqual(iter, result1);
                Assert.AreEqual(iter, result2);
            }
        }

        [Test]
        public void HugeValueOfInputDataTest()
        {
            for (int iter = 0; iter < 30; iter++)
            {
                listStack.Push(1000000000 + iter);
                arrayStack.Push(1000000000 + iter);
            }

            for (int iter = 0; iter < 30; iter++)
            {
                var result1 = listStack.Pop(ref isCorrect);
                var result2 = arrayStack.Pop(ref isCorrect);
                Assert.AreEqual(1000000029 - iter, result1);
                Assert.AreEqual(1000000029 - iter, result2);
            }
        }
    }
}