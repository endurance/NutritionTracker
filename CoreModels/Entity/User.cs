using System;
using System.Collections.Generic;
using Core.Enumerations;
using Core.ValueObjects;

namespace Core.Entity
{
    public class User : Entity<Guid>
    {
        public string Name { get; set; }
        public IEnumerable<Macronutrient> GoalMacroNutrients { get; set; }
        public List<FoodItem> Foods { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}