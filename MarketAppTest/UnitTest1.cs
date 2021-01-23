using System;
using MarketApp;
using Xunit;

namespace MarketAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var resul1t = CalculationToImplement.TrialDivision(7785);
            var result = CalculationToImplement.TrialDivision(333566835377);
            Assert.Equal(2, result.Count);
            Assert.Equal(573197, result[0]);
            Assert.Equal(581941, result[1]);
        }
        [Fact]
        public void TestOnlyFirst()
        {
            var result = CalculationToImplement.TrialDivision(333566835377, true);
            Assert.Single(result);
            Assert.Equal(573197, result[0]);
        }
    }
}
