using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class LiquidTablespoon : Measure
    {
        public LiquidTablespoon(double servingSize)
            : base(servingSize, "tbsp")
        {
            FriendlyName = "tablespoon";
            FriendlyNamePlural = "tablespoons";
        }
    }
}