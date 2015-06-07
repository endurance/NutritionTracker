using System.Collections.Generic;
using System.IO;

namespace FoodTracker.Model
{
    public class User
    {
        // Empty Constructor
        public User()
        {
            Macros = new Macronutrient();
            Age = 0;
            UserGender = Gender.InvalidGender;
            Height = 0;
            Weight = 0;
            Foods = new List<FoodItem>();
        }

        // Test Constructor.
        public User(bool isMe)
        {
            Macros = new Macronutrient(70, 200, 200, 3000);
            Age = 26;
            UserGender = Gender.Male;
            Height = 180.34;
            Weight = 200;
            Foods = new List<FoodItem>();
        }

        public string Name => "Endurance";

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
                var food = new FoodItem();
                food.Id = id;
                // Name, Size, Imp, Size, Met, fat, carb, pro, salt 
                var line = reader.ReadLine();
                var splitLine = line.Split(',');
                // Name
                food.Name = splitLine[0];
                // Imperial Units and Serving Size
                var servingSize = double.Parse(splitLine[1]);
                var impUnits = (ImperialUnits) int.Parse(splitLine[2]);
                food.ImperialServing = new ImperialServing(impUnits, servingSize);
                // Metric Units and Serving Size
                servingSize = double.Parse(splitLine[3]);
                var metUnits = (MetricUnits) int.Parse(splitLine[4]);
                food.MetricServing = new MetricServing(metUnits, servingSize);
                // Food Macros
                food.FoodMacros.Fat = double.Parse(splitLine[5]);
                food.FoodMacros.Carbohydrate = double.Parse(splitLine[6]);
                food.FoodMacros.Protein = double.Parse(splitLine[7]);
                food.FoodMacros.Salt = int.Parse(splitLine[8]);
                // Add food to the list.
                Foods.Add(food);
                id++;
            }
        }

        #region Properties

        public Macronutrient Macros { get; set; }

        public List<FoodItem> Foods { get; set; }

        public int Age { get; set; }

        public Gender UserGender { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        #endregion
    }
}