using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Tablespoon : Measure
    {
        public Tablespoon(double servingSize)
            : base(servingSize, "tbsp")
        {
            FriendlyName = "tablespoon";
            FriendlyNamePlural = "tablespoons";
        }
    }
}