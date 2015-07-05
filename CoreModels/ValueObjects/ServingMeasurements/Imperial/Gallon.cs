using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Gallon : Measure
    {
        public Gallon(double servingSize)
            : base(servingSize, "gal")
        {
            FriendlyName = "gallon";
            FriendlyNamePlural = "gallons";
        }
    }
}