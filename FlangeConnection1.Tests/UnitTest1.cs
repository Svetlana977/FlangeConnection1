using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlangeConnection1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalcDf_10and20_30returned()
        {
            float db = 10.1F;
            float alfa = 20.8F;
            float expected = 30.9F;

            Calc calc = new Calc();
            float actual = calc.CalcDf(db, alfa);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalcDcp_20and10_10returned()
        {
            float dp = 20.2F;
            float bp = 10.1F;
            float expected = 10.1F;

            Calc calc = new Calc();
            float actual = calc.CalcDcp(dp, bp);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalcZb_10and2_157returned()
        {
            float db = 10.0F;
            float tb = 2.0F;
            float expected = 15.7F;

            Calc calc = new Calc();
            float actual = calc.Calcn(db, tb);

            Assert.AreEqual(expected, actual, 0.01);
        }
    }
   
}
