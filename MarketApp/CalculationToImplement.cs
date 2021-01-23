using MarketApp.HelpClasses;
using System;
using System.Collections.Generic;

namespace MarketApp
{
    public class CalculationToImplement
    {
        public CalculationResult Calculate(long numberOfEntities)
        {
            CalculationResult result = new CalculationResult();
            // get first min divisible
            long element = numberOfEntities;
            var resultedCount = new List<long>();
            do
            {
                var divisibleAll = TrialDivision(element, false);
                var divisible = divisibleAll[0];
                if (resultedCount.Count == 0)
                {
                    resultedCount.Add(divisible);
                }
                else
                {
                    resultedCount.Add(resultedCount[^1] * divisible);
                }
                element = element/divisible - 1;
            } while (element  > 1);

            result.Numbers = resultedCount.ToArray();
            result.KindsCount = resultedCount.Count;

            return result;
        }

       public static List<long> TrialDivision(long n, bool returnOnlyFirst = false)
        {
            var divides = new List<long>();
            var div = 2u;
            while (n > 1)
            {
                if (n % div == 0)
                {
                    divides.Add(div);
                    if (returnOnlyFirst)
                    {
                        return divides;
                    }
                    n /= div;
                }
                else
                {
                    div++;
                }
            }

            return divides;
        }
    }
}