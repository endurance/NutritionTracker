using System;

namespace FoodTracker.Model
{
    public class FoodItem
    {
        public FoodItem()
        {
            Id = Guid.NewGuid();
            Name = "";
            ImperialServing = new ImperialServing();
            MetricServing = new MetricServing();
            FoodMacros = new Macronutrient();
        }

        public override string ToString()
        {
            return Name + " " + ImperialServing + " " + MetricServing + " " + FoodMacros;
        }

        #region Properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ImperialServing ImperialServing { get; set; }

        public MetricServing MetricServing { get; set; }

        public Macronutrient FoodMacros { get; set; }

        #endregion


    }
}