using System.Diagnostics;

namespace FoodTracker.Model
{
    public class MetricServing : Serving
    {
        private readonly MetricUnits _units;

        public MetricServing()
        {
        }

        public MetricServing(MetricUnits units,
            double servingSize)
        {
            this.servingSize = servingSize;
            _units = units;
        }

        #region Properties

        public double ServingSize
        {
            get { return servingSize; }
            set { servingSize = value; }
        }

        #endregion

        public string UnitSuffix()
        {
            switch (_units)
            {
                case MetricUnits.Grams:
                {
                    return servingSize > 1 ? " grams" : " gram";
                }
                case MetricUnits.Kilograms:
                {
                    return servingSize > 1 ? " Kilograms" : " Kilogram";
                }
            }

            return null;
        }

        public override string ToString()
        {
            return servingSize + UnitSuffix();
        }

        public override string GetServing()
        {
            switch (_units)
            {
                case MetricUnits.Grams:
                {
                    return servingSize + " grams";
                }
                case MetricUnits.Kilograms:
                {
                    if (servingSize > 1)
                        return servingSize + " Kilograms";
                    return servingSize + " kilogram";
                }
            }

            Debug.Assert(true, "mUnits have not been set or are otherwise invalid: " + _units);
            return null;
        }
    }
}