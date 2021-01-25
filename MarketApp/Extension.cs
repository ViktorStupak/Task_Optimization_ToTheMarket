using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketApp
{
    internal static class Extension
    {
        /// <summary>
        /// Gets the unique divisors from target list. Also add 4 in case when list contain more that one 2.
        /// </summary>
        /// <param name="divisors">The divisors.</param>
        /// <returns></returns>
        internal static List<long> GetUniqueDivisors(this List<long> divisors)
        {
            var divides = new List<long>();
            foreach (var divisor in divisors.Where(divisor => !divides.Contains(divisor)))
            {
                divides.Add(divisor);
            }

            if (divisors.Count(a=>a==2) > 1 && !divides.Contains(4))
            {
                divides.Add(4);
            }

            divides.Sort();
            return divides;
        }

        /// <summary>
        /// The factorization algorithms. Get each divides from target number (n).
        /// </summary>
        /// <param name="n"></param>
        /// <example>
        /// For example, for the integer n = 12, the only numbers that divide it are 2, 3, 4.
        /// </example>
        /// <returns>each divides from target number. does not include 1 and the number itself</returns>
        internal static List<long> TrialDivision(this long n)
        {
            var divides = new List<long>();
            var div = 2L;
            while (n % div == 0)
            {
                divides.Add(div);
                n /= div;
            }

            div = 3;

            while (Math.Pow(div, 2) <= n)
            {
                if (n % div == 0)
                {
                    divides.Add(div);
                    n /= div;
                }
                else
                {
                    div += 2;
                }
            }

            if (n > 1)
            {
                divides.Add(n);
            }

            return divides;
        }
    }
}