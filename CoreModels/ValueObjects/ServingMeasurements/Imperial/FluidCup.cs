using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class FluidCup : Measure
    {
        public FluidCup(double servingSize)
            : base(servingSize, "C")
        {
            FriendlyName = "cup";
            FriendlyNamePlural = "cups";
        }
    }
}