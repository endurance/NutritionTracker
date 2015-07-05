using Core.Abstracts;
using UnitsNet;

namespace Core.ValueObjects.ServingMeasurements.Imperial
{
    public class MilliGram : WeightMeasure
    {
        public MilliGram(double servingSize)
            : base(servingSize, "mg")
        {
            FriendlyName = "milligram";
            FriendlyNamePlural = "milligrams";
            Unit = Mass.FromMilligrams(servingSize);
        }
    }

    public class MilliLiter: Measure
    {
        public MilliLiter(double servingSize)
            : base(servingSize, "mL")
        {
            FriendlyName = "milliliter";
            FriendlyNamePlural = "milliliters";
        }
    }
}