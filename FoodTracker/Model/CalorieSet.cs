using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker
{
   public class CalorieSet : ICloneable
   {
      private double m_fat;
      private double m_carbohydrate;
      private double m_protein;
      private int m_salt;

      public CalorieSet()
      {
         m_fat = 0;
         m_carbohydrate = 0;
         m_protein = 0;
         m_salt = 0;
      }
      public CalorieSet(double fat, double carb, double protein, int salt)
      {
         m_fat = fat;
         m_carbohydrate = carb;
         m_protein = protein;
         m_salt = salt;
      }
      public override string ToString()
      {
         return Fat + " " + Carbohydrate + " " + Protein + " " + Salt;
      }
      #region Properties
      public double Fat
      {
         get { return m_fat; }
         set { m_fat = value; }
      }

      public double Carbohydrate
      {
         get { return m_carbohydrate; }
         set { m_carbohydrate = value; }
      }

      public double Protein
      {
         get { return m_protein; }
         set { m_protein = value; }
      }

      public int Salt
      {
         get { return m_salt; }
         set { m_salt = value; }
      }

      public double Calories
      {
         get { return m_protein*4 + m_carbohydrate*4 + m_fat*9; }
         private set { }
      }
      #endregion

      public object Clone()
      {
         return this.MemberwiseClone();
      }
   }
}
