using System.Collections.Generic;
using System.Linq;
using MarketApp.HelpClasses;

namespace MarketApp
{
    internal class CalculationContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationContainer"/> class.
        /// </summary>
        /// <param name="numberOfEntities">The target number of entities.</param>
        internal CalculationContainer(long numberOfEntities)
        {
            this.Divisors = numberOfEntities.TrialDivision().GetUniqueDivisors();
            this.NumberOfEntities = numberOfEntities;
            this.Branches = new HashSet<CalculationBranch>();
            for (var i = 0; i < this.Divisors.Count; i++)
            {
                this.Branches.Add(new CalculationBranch(this,i));
            }
        }

        /// <summary>
        /// Target number (n).
        /// </summary>
        internal long NumberOfEntities { get;  }

        internal CalculationResult GetResult()
        {
            var result = new CalculationResult();
            var results = new List<long>();
            foreach (var branch in this.Branches)
            {
                var branchResult = branch.GetNumbers(new List<long>());
                if (results.Count < branchResult.Count)
                {
                    results = branchResult;
                }
            }
            var recalculate = new List<long>();
            for (var i = 0; i < results.Count; i++)
            {
                if (i == 0)
                {
                    recalculate.Add(results[i]);
                }
                else
                {
                    recalculate.Add(recalculate[^1] * results[i]);
                }
            }

            result.Numbers = recalculate.ToArray();
            result.KindsCount = recalculate.Count;
            return result;
        }



        /// <summary>
        /// Possible divisors.
        /// </summary>
        internal List<long> Divisors { get; }

        /// <summary>
        /// Possible decision branches.
        /// </summary>
        /// <value>
        /// The branches.
        /// </value>
        internal ICollection<CalculationBranch> Branches { get; set; }
    }
}