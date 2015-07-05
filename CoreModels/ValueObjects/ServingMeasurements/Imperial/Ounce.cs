using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Ounce : Measure
    {
        public Ounce(double servingSize)
            : base(servingSize, "oz")
        {
            FriendlyName = "ounce";
            FriendlyNamePlural = "ounces";
        }
    }
}