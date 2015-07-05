using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class FluidOunce : Measure
    {
        public FluidOunce(double servingSize)
            : base(servingSize, "fl oz.")
        {
            FriendlyName = "fluid ounce";
            FriendlyNamePlural = "fluid ounces";
        }
    }
}