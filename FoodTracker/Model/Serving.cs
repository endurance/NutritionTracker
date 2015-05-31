using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
   public enum ImperialUnits : int
   {
      Cups = 0,
      Ounces = 1,
      Inches = 2,
      Feet = 3,
      Invalid = -1
   }

   public enum MetricUnits : int
   {
      Grams = 0,
      Kilograms = 1,
      Milligrams = 2,
      Milliliters = 3,
      Liters = 4,
      Centimeters = 5,
      Meters = 6,
      Invalid = -1
   }

   public abstract class Serving
   {
      protected double servingSize;
      protected Serving()
      { }
      public abstract string GetServing();
   }

   public class ImperialServing : Serving
   {
      private ImperialUnits units;
      public ImperialServing()
      { }
      public ImperialServing(ImperialUnits units,
         double servingSize)
      {
         this.servingSize = servingSize;
         this.units = units;
      }

      #region Properties
      public double ServingSize
      {
         get { return servingSize; }
         set { servingSize = value; }
      }
      public ImperialUnits Units
      {
         get { return units; }
         set { units = value; } 
      }
      #endregion
      public string UnitSuffix()
      {
         switch (units)
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
         switch (units)
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

         Debug.Assert(true, "ImperialUnits have not been set or are otherwise invalid: " + units);
         return null;
      }
   }

   public class MetricServing : Serving
   {
      private MetricUnits units;
      public MetricServing()
      {

      }
      public MetricServing(MetricUnits units, 
         double servingSize)
      {
         this.servingSize = servingSize;
         this.units = units;
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
         switch (units)
         {
            case MetricUnits.Grams:
               {
                  if (servingSize > 1)
                     return " grams";
                  return " gram";
               }
            case MetricUnits.Kilograms:
               {
                  if (servingSize > 1)
                     return " Kilograms";
                  return " Kilogram";
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
         switch (units)
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

         Debug.Assert(true, "mUnits have not been set or are otherwise invalid: " + units);
         return null;
      }
   }

}
