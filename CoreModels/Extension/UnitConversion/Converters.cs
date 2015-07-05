using Core.Abstracts;
using Core.ValueObjects.ServingMeasurements.Imperial;
using Core.ValueObjects.ServingMeasurements.Metric;

namespace Core.Extension.UnitConversion
{
    public static class Converters
    {
        // Regular Ounces
        public static Ounce ConvertToOunces(this DryVolumeMeasure from)
        {
            return new Ounce(from.Unit.UsOunces);
        }

        public static Ounce ConvertToFluidOunces(this LiquidVolumeMeasure from)
        {
            return new Ounce(from.Unit.ImperialOunces);
        }

        public static MilliGram ConvertToMilligrams(this WeightMeasure from)
        {
            return new MilliGram(from.Unit.Milligrams);
        }

        public static Gram ConvertToGrams(this WeightMeasure from)
        {
            return new Gram(from.Unit.Grams);
        }
    }
}