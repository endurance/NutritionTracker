using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class User
   {
      private Macronutrient _userMacros;
      private int _age;
      private Gender _gender;
      // inches or centimeters
      private double _height;
      // in lbs or kgs
      private double _weight;
      List<FoodItem> _userFoodList;
      public string Name
      {
         get { return "Endurance"; }
         private set { }
      }
      
      // Empty Constructor
      public User()
      {
         _userMacros = new Macronutrient();
         _age = 0;
         _gender = Gender.InvalidGender;
         _height = 0;
         _weight = 0;
         _userFoodList = new List<FoodItem>();
      }
      // Test Constructor.
      public User(bool isMe)
      {
         _userMacros = new Macronutrient(fatInGrams: 70, carbohydratesInGrams: 200, proteinInGrams: 200, saltInMilligrams: 3000);
         _age = 26;
         _gender = Gender.Male;
         _height = 180.34;
         _weight = 200;
         _userFoodList = new List<FoodItem>();
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
            _userFoodList.Add(food);
            id++;
         }
      }

      #region Properties
      public Macronutrient Macros
      {
         get { return _userMacros; }
         set { _userMacros = value; }
      }

      public List<FoodItem> Foods
      {
         get { return _userFoodList; }
         set { _userFoodList = value; }
      }

      public int Age
      {
         get { return _age; }
         set { _age = value; }
      }

      public Gender UserGender
      {
         get { return _gender; }
         set { _gender = value; }
      }

      public double Height
      {
         get { return _height; }
         set { _height = value; }
      }

      public double Weight
      {
         get { return _weight; }
         set { _weight = value; }
      }
      #endregion

   }
}
