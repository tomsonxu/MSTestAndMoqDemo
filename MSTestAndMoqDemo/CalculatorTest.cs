using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestAndMoqDemo.TestedClasses;

namespace MSTestAndMoqDemo
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            //arrange
            Calculator calculator = new Calculator();
            int a = 1;
            int b = 2;

            //act
            int result = calculator.add(a, b);

            //assert
            Assert.AreEqual(result, 3);
        }
    }
}
