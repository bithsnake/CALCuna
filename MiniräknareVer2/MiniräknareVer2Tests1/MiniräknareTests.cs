using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniräknareVer2;
using System;

namespace MiniräknareVer2.Tests
{
    [TestClass()]
    public class MiniräknareTests
    {
        readonly double expectedFarenheit = 120.0f;

        [TestMethod()]
        public void ConvertToFarenheitTest()
        {
            float celsius = 48.88889f;
            var test = Miniräknare.ConvertToFarenheit(celsius);
            Assert.AreEqual(expectedFarenheit, test);
        }
        readonly double expectedCelsius = Math.Round(48.88889f, 2);
        [TestMethod()]
        public void ConvertToCelsiusTest()
        {
            float farenheit = 120.0f;
            var test = Miniräknare.ConvertToCelsius(farenheit);
            Assert.AreEqual(expectedCelsius, test);
        }

        readonly float expectedResultCompute = 50f;
        [TestMethod()]
        public void ComputeTest()
        {
            float number1 = 25f;
            float number2 = 2f;
            float number3 = 75f;
            float celsius = 48.88889f;
            float farenheit = 120.0f;

            string testAdd = "+", testSubtraction = "-", testMultiplication = "*", testDivision = "/", testCelsiusTofarenheit = "c", testFarenheitToCelsius = "f";

            //The 4 normal operators  (+, -, *, /)
            var test1 = Convert.ToSingle(Miniräknare.Compute(number1, testAdd, number1));
            var test2 = Convert.ToSingle(Miniräknare.Compute(number3, testSubtraction, number1));
            var test3 = Convert.ToSingle(Miniräknare.Compute(number1, testMultiplication, number2));
            var test4 = Convert.ToSingle(Miniräknare.Compute(number1, testDivision, (number2/4)));
            var test5 = Miniräknare.Compute(number1, testDivision, (number2*0));
            
            //Temperature Conversion tests
            var test6 = Convert.ToDouble(Miniräknare.Compute(celsius, testCelsiusTofarenheit,0f));
            Math.Round(test6, 2);
            var test7 = Convert.ToDouble(Miniräknare.Compute(farenheit, testFarenheitToCelsius,0f));
            Math.Round(test7, 2);

            Assert.AreEqual(expectedResultCompute, test1);
            Assert.AreEqual(expectedResultCompute, test2);
            Assert.AreEqual(expectedResultCompute, test3);

            Assert.AreEqual(expectedResultCompute, test4);
            Assert.AreEqual("faulty", test5);

            Assert.AreEqual(expectedFarenheit, test6);
            Assert.AreEqual(expectedCelsius, test7);

        }

        [TestMethod()]
        public void CheckInputTest()
        {
            string input1    = "QuIT";
            string input2    = "QuaTT";

            /*Är det ok att testa bools såhär?...*/
            Assert.IsTrue(Miniräknare.CheckInput(input1));
            Assert.IsFalse(Miniräknare.CheckInput(input2));
        }
    }
}