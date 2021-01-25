using System.Collections.Generic;
using System.Linq;

namespace MarketApp
{
    internal class CalculationBranch
    {
        private readonly bool _endSuccess;
        internal CalculationBranch(CalculationContainer container, int index)
        {
            this.Number = container.Divisors[index];
            var entityNumber = container.NumberOfEntities / this.Number - 1;
            if (entityNumber > 1)
            {
                this.Container = new CalculationContainer(entityNumber);
            }

            this._endSuccess = entityNumber == 0;
        }

        /// <summary>
        /// Gets a value indicating whether this instance finished success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance finished success; otherwise, <c>false</c>.
        /// </value>
        internal bool IsEndSuccess => this.Container != null || this._endSuccess;

        /// <summary>
        /// Gets the number - divisor for target NumberOfEntities.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        internal long Number { get; }

        internal CalculationContainer Container { get; }

        /// <summary>
        /// Build output values for this branch.
        /// </summary>
        /// <param name="currentResult">The current result.</param>
        /// <returns></returns>
        internal List<long> GetNumbers(List<long> currentResult)
        {
            var results = new List<long>();

            if (Container == null)
            {
                if (!this._endSuccess) return results;
                currentResult.Add(Number);
                if (results.Count < currentResult.Count)
                {
                    results = currentResult;
                }
                return results;
            }
            var lookupBranches = this.Container.Branches.ToLookup(p => p);
            foreach (var branch in lookupBranches)
            {
                if (!IsEndSuccess) continue;
                var startResult = new List<long>();
                if (currentResult.Any())
                {
                    startResult.AddRange(currentResult);
                }

                startResult.Add(Number);
                var branchResult = branch.Key.GetNumbers(startResult);
                if (results.Count < branchResult.Count)
                {
                    results = branchResult;
                }
            }

            return results;
        }
    }
}