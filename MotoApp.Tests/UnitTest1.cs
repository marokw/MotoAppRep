using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MotoApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var stack = new BasicStack();
            
            //act
            stack.Push(4.5);
            stack.Push(43);
            stack.Push(333.6);

            //assert
            Assert.AreEqual(333.6, stack.Pop());
        }
    }
}
