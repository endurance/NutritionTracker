using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
   public enum Gender
   {
      Male = 0,
      Female = 1,
      InvalidGender = 2
   }

   public class User
   {
      private CalorieSet userMacros;
      private int age;
      private Gender gender;
      // inches or centimeters
      private double height;
      // in lbs or kgs
      private double weight;
      List<FoodItem> userFoodList;
      public string Name
      {
         get { return "Endurance"; }
         private set { }
      }
      
      // Empty Constructor
      public User()
      {
         userMacros = new CalorieSet();
         age = 0;
         gender = Gender.InvalidGender;
         height = 0;
         weight = 0;
         userFoodList = new List<FoodItem>();
      }
      // Test Constructor.
      public User(bool isMe)
      {
         userMacros = new CalorieSet(fat: 70, carb: 200, protein: 200, salt: 3000);
         age = 26;
         gender = Gender.Male;
         height = 180.34;
         weight = 200;
         userFoodList = new List<FoodItem>();
      }
      // Static constructor for testing / usage. My own stats
      public static User EnduranceUser()
      {
         return new User(true);
      }

      public void FillFoodList(string filename)
      {
         long id = 0;
         var reader = new StreamReader(File.OpenRead(filename));
         while (!reader.EndOfStream)
         {
            FoodItem food = new FoodItem();
            food.Id = id;
            // Name, Size, Imp, Size, Met, fat, carb, pro, salt 
            var line = reader.ReadLine();
            var splitLine = line.Split(',');
            // Name
            food.Name = splitLine[0];
            // Imperial Units and Serving Size
            double servingSize = Double.Parse(splitLine[1]);
            ImperialUnits impUnits = (ImperialUnits)int.Parse(splitLine[2]);
            food.ImperialServing = new ImperialServing(impUnits, servingSize);
            // Metric Units and Serving Size
            servingSize = Double.Parse(splitLine[3]);
            MetricUnits metUnits = (MetricUnits)int.Parse(splitLine[4]);
            food.MetricServing = new MetricServing(metUnits, servingSize);
            // Food Macros
            food.FoodMacros.Fat = Double.Parse(splitLine[5]);
            food.FoodMacros.Carbohydrate = Double.Parse(splitLine[6]);
            food.FoodMacros.Protein = Double.Parse(splitLine[7]);
            food.FoodMacros.Salt = int.Parse(splitLine[8]);
            // Add food to the list.
            userFoodList.Add(food);
            id++;
         }
      }

      #region Properties
      public CalorieSet Macros
      {
         get { return userMacros; }
         set { userMacros = value; }
      }

      public List<FoodItem> Foods
      {
         get { return userFoodList; }
         set { userFoodList = value; }
      }

      public int Age
      {
         get { return age; }
         set { age = value; }
      }

      public Gender UserGender
      {
         get { return gender; }
         set { gender = value; }
      }

      public double Height
      {
         get { return height; }
         set { height = value; }
      }

      public double Weight
      {
         get { return weight; }
         set { weight = value; }
      }
      #endregion

   }
}
