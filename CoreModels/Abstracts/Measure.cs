using UnitsNet;

namespace Core.Abstracts
{
    public interface IMeasure
    { }

    public abstract class DryVolumeMeasure : IMeasure
    {
        protected DryVolumeMeasure(double servingSize)
        {
            Unit = new Volume(servingSize);
        }

        public Volume Unit { get; set; }
    }

    public abstract class LiquidVolumeMeasure : IMeasure
    {
        protected LiquidVolumeMeasure(double servingSize)
        {
            Unit = new Volume(servingSize);
        }

        public Volume Unit { get; set; }
    }

    public abstract class WeightMeasure : IMeasure
    {
        protected WeightMeasure(double servingSize)
        {
            Unit = new Mass(servingSize);
        }

        public Mass Unit { get; set; }
    }
}