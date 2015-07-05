using Core.Abstracts;
using Core.ValueObjects.ServingMeasurements.Imperial;
using Core.ValueObjects.ServingMeasurements.Metric;
using UnitsNet;

namespace Core.ValueObjects
{
    public class Macronutrient
    {
        // Only makes sense within the context of knowing how much of something you have
        private IMeasure size;
        public Gram Fat { get; set; }
        public Gram Carbohydrate { get; set; }
        public Gram Protein { get; set; }
        public MilliGram Sodium { get; set; }

        public Macronutrient(IMeasure size)
        {
            this.size = size;
        }

        public Macronutrient(Gram fat, Gram carbohydrate, Gram protein, MilliGram sodium, IMeasure size)
        {
            Fat = fat;
            Carbohydrate = carbohydrate;
            Protein = protein;
            Sodium = sodium;
            this.size = size;
        }

        public override string ToString()
        {
            return Fat.Amount + " " + Carbohydrate.Amount + " " + Protein.Amount + " " + Sodium.Amount;
        }

        public double CalculateCalories()
        {
            return Protein.Amount*4 + Carbohydrate.Amount*4 + Fat.Amount*9;
        }

        #region Properties

        public double Calories
        {
            get { return CalculateCalories(); }
        }

        #endregion
    }
}