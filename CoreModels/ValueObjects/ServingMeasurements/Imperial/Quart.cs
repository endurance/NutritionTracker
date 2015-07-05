using Core.Abstracts;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class Quart : Measure
    {
        public Quart(double servingSize)
            : base(servingSize, "qt")
        {
            FriendlyName = "quart";
            FriendlyNamePlural = "quarts";
        }
    }
}