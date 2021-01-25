using MarketApp.HelpClasses;

namespace MarketApp
{
    public class CalculationToImplement
    {
        public CalculationResult Calculate(long numberOfEntities)
        {
            var container = new CalculationContainer(numberOfEntities);
            return container.GetResult();
        }
    }
}