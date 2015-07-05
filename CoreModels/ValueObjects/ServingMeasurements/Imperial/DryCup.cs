using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class DryCup : Measure
    {
        public DryCup(double servingSize)
            : base(servingSize, "C")
        {
            FriendlyName = "cup";
            FriendlyNamePlural = "cups";
        }
    }
}