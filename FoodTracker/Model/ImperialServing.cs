using System.Diagnostics;

namespace FoodTracker.Model
{
    public class ImperialServing : Serving
    {
        public ImperialServing()
        {
        }

        public ImperialServing(ImperialUnits units,
            double servingSize)
        {
            this.servingSize = servingSize;
            Units = units;
        }

        public string UnitSuffix()
        {
            switch (Units)
            {
                case ImperialUnits.Cups:
                {
                    if (servingSize > 1)
                        return " cups";
                    return " cup";
                }
                case ImperialUnits.Ounces:
                {
                    if (servingSize > 1)
                        return " ounces";
                    return " ounce";
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
            switch (Units)
            {
                case ImperialUnits.Cups:
                {
                    if (servingSize > 1)
                        return servingSize + " cups";
                    return servingSize + " cup";
                }
                case ImperialUnits.Ounces:
                {
                    if (servingSize > 1)
                        return servingSize + " ounces";
                    return servingSize + " ounce";
                }
            }

            Debug.Assert(true, "ImperialUnits have not been set or are otherwise invalid: " + Units);
            return null;
        }

        #region Properties

        public double ServingSize
        {
            get { return servingSize; }
            set { servingSize = value; }
        }

        public ImperialUnits Units { get; set; }

        #endregion
    }
}