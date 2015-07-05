using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Teaspoon : Measure
    {
        public Teaspoon(double servingSize)
            : base(servingSize, "t")
        {
            FriendlyName = "teaspoon";
            FriendlyNamePlural = "teaspoons";
        }
    }
}