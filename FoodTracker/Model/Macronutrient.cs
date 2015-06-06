using System;


namespace FoodTracker
{
   public class Macronutrient : ICloneable
   {
      private double _fatInGrams;
      private double _carbohydratesInGrams;
      private double _proteinInGrams;
      private int _saltInMilligrams;

      public Macronutrient()
      { }
      public Macronutrient(double fatInGrams, double carbohydratesInGrams, double proteinInGrams, int saltInMilligrams)
      {
          _fatInGrams = fatInGrams;
          _carbohydratesInGrams = carbohydratesInGrams;
          _proteinInGrams = proteinInGrams;
          _saltInMilligrams = saltInMilligrams;
      }
      public override string ToString()
      {
         return Fat + " " + Carbohydrate + " " + Protein + " " + Salt;
      }

      #region Properties
      public double Fat
      {
         get { return _fatInGrams; }
         set { _fatInGrams = value; }
      }

      public double Carbohydrate
      {
         get { return _carbohydratesInGrams; }
         set { _carbohydratesInGrams = value; }
      }

      public double Protein
      {
         get { return _proteinInGrams; }
         set { _proteinInGrams = value; }
      }

      public int Salt
      {
         get { return _saltInMilligrams; }
         set { _saltInMilligrams = value; }
      }

      public double Calories
      {
         get { return _proteinInGrams*4 + _carbohydratesInGrams*4 + _fatInGrams*9; }
         private set { }
      }
      #endregion

      public object Clone()
      {
         return this.MemberwiseClone();
      }
   }
}
