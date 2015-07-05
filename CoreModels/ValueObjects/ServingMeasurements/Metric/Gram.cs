using Core.Abstracts;
using UnitsNet;
using UnitsNet.Units;

namespace Core.ValueObjects.ServingMeasurements.Metric
{
    public class Gram : WeightMeasure
    {
        public Gram(double servingSize)
            : base(servingSize, Mass.GetAbbreviation(MassUnit.Gram))
        {
            FriendlyName = Unit.ToString(MassUnit.Gram);
            FriendlyNamePlural = Unit.ToString(MassUnit.Gram) + "s";
            Unit = Mass.FromGrams(servingSize);
        }
    }
}