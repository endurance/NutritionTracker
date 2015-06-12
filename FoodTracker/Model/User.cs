using System;
using System.Collections.Generic;
using System.IO;

namespace FoodTracker.Model
{
    public class User
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Macronutrient> GoalMacroNutrients { get; set; }
        public List<FoodItem> Foods { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

    }


    //public class User1
    //{
    //    // Empty Constructor
    //    public User()
    //    {
    //        Macros = new Macronutrient();
    //        Age = 0;
    //        UserGender = Gender.InvalidGender;
    //        Height = 0;
    //        Weight = 0;
    //        Foods = new List<FoodItem>();
    //    }

    //    // Test Constructor.
    //    public User(bool isMe)
    //    {
    //        Macros = new Macronutrient(70, 200, 200, 3000);
    //        Age = 26;
    //        UserGender = Gender.Male;
    //        Height = 180.34;
    //        Weight = 200;
    //        Foods = new List<FoodItem>();
    //    }

    //    public string Name => "Endurance";

    //    // Static constructor for testing / usage. My own stats
    //    public static User EnduranceUser()
    //    {
    //        return new User(true);
    //    }

    //    #region Properties

    //    public Macronutrient Macros { get; set; }

    //    public List<FoodItem> Foods { get; set; }

    //    public int Age { get; set; }

    //    public Gender UserGender { get; set; }

    //    public double Height { get; set; }

    //    public double Weight { get; set; }

    //    #endregion
    //}
}