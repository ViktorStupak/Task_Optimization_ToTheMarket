using MarketApp.HelpClasses;
using System;
using System.Diagnostics;
using System.Linq;

namespace MarketApp
{
    class Program
    {
        static void Main()
        {
            // here you can change the tested level 0 - 10:
            for (var i = 0; i <= 10; i++)
                foreach (var testFile in Helpers.ReadFilesForLevel(i))
                {
                    var stopwatch = Stopwatch.StartNew();

                    var calculator = new CalculationToImplement();
                    var result = calculator.Calculate(testFile.Input);

                    ReportResult(testFile, result, stopwatch);
                }

            Console.WriteLine("PROGRAM FINISHED ...");
            Console.ReadLine();
        }

        private static void ReportResult(TestFile testFile, CalculationResult result, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var isCorrect = IsResultCorrect(result, testFile);

            var expectedNumbers = string.Join(" ", testFile.OutputNumbers);
            var calculatedNumbers = string.Join(" ", result.Numbers);

            Console.WriteLine("TEST: " + testFile.NameNoExtension);

            Console.WriteLine($"Elapsed:       {(stopwatch.Elapsed <= TimeSpan.FromSeconds(5) ? "PASSED" : "TOO SLOW")}: "
                              + $"{stopwatch.ElapsedMilliseconds / 1000m:0.000} s ");

            Console.WriteLine($"Kinds count:   {(testFile.OutputKindsCount == result.KindsCount ? "PASSED" : "FAILED")} "
                              + $"- calculated: {result.KindsCount}, expected: {testFile.OutputKindsCount}");

            Console.WriteLine($"Numbers:       {(isCorrect ? "PASSED" : "FAILED")}");
            Console.WriteLine($"   Calculated: {calculatedNumbers.CutIfLong(80)}");
            Console.WriteLine($"   Expected:   {expectedNumbers.CutIfLong(80)}");
            Console.WriteLine($"   Calculated sum: {result.Numbers.Sum()}");
            Console.WriteLine($"   Expected sum:   {testFile.OutputNumbers.Sum()}");
            Console.WriteLine();
        }

        private static bool IsResultCorrect(CalculationResult result, TestFile testFile)
        {
            var numbers = result.Numbers;

            var kindsCount = numbers.Length;

            if (kindsCount != result.KindsCount)
            {
                return false;
            }

            var checkSum = numbers.Sum();

            if (checkSum != testFile.Input)
            {
                return false;
            }

            if (numbers.Any(a => a <= 1))
            {
                return false;
            }

            for (var i = 0; i < kindsCount - 1; i++)
            {
                var current = numbers[i];
                var next = numbers[i + 1];

                if (current >= next
                    || next % current != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}