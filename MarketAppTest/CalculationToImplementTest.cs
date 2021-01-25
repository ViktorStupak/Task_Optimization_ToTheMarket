using System;
using System.Diagnostics;
using System.Linq;
using MarketApp;
using MarketApp.HelpClasses;
using Xunit;

namespace MarketAppTest
{
    public class CalculationToImplementTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void TestLevel(int level)
        {
            foreach (var testFile in Helpers.ReadFilesForLevel(level))
            {
                var stopwatch = Stopwatch.StartNew();

                var calculator = new CalculationToImplement();
                var result = calculator.Calculate(testFile.Input);

                stopwatch.Stop();
                Assert.True(stopwatch.Elapsed <= TimeSpan.FromSeconds(2));
                Assert.NotNull(result.Numbers);
                Assert.DoesNotContain(result.Numbers, a => a <= 1);
                Assert.Equal(testFile.Input, result.Numbers.Sum());
                Assert.Equal(result.KindsCount, result.Numbers.Length);
                for (var i = 0; i < result.KindsCount - 1; i++)
                {
                    var current = result.Numbers[i];
                    var next = result.Numbers[i + 1];
                    Assert.False(current >= next || next % current != 0);
                }
            }
        }
    }
}
