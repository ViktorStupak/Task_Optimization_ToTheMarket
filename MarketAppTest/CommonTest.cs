using MarketApp;
using Xunit;

namespace MarketAppTest
{
    public class CommonTest
    {
        [Fact]
        public void Test1()
        {
            var result = 333566835377.TrialDivision();
            Assert.Equal(2, result.Count);
            Assert.Equal(573197, result[0]);
            Assert.Equal(581941, result[1]);
        }

        [Fact]
        public void Test2()
        {
            var result = 10000L.TrialDivision();
            Assert.Equal(8, result.Count);
            Assert.Equal(5, result[4]);
            Assert.Equal(2, result[1]);
            var unique = 10000L.TrialDivision().GetUniqueDivisors();
            Assert.Equal(3, unique.Count);
            Assert.Equal(2, unique[0]);
            Assert.Equal(4, unique[1]);
            Assert.Equal(5, unique[2]);
        }

        [Fact]
        public void Test3()
        {
            var container = new CalculationContainer(50000000000);
            var branch = container.GetResult();
            Assert.Equal(27, branch.KindsCount);
        }

    }
}
