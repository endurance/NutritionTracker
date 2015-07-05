using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class LiquidTeaspoon : Measure
    {
        public LiquidTeaspoon(double servingSize)
            : base(servingSize, "t")
        {
            FriendlyName = "teaspoon";
            FriendlyNamePlural = "teaspoons";
        }
    }
}