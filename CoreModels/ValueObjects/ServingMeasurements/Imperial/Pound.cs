using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Pound : Measure
    {
        public Pound(double servingSize)
            : base(servingSize, "lb.")
        {
            FriendlyName = "Pound";
            FriendlyNamePlural = "Pounds";
        }
    }
}