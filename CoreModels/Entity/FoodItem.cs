using System;
using System.Collections.Generic;
using Core.ValueObjects;

namespace Core.Entity
{
    public class FoodItem : Entity<Guid>
    {
        private readonly List<Macronutrient> _macroProfiles = new List<Macronutrient>();

        public FoodItem()
        { }

        public FoodItem(List<Macronutrient> macros)
        {
            _macroProfiles = macros;
        }

        public string Name { get; set; }

        public List<Macronutrient> FoodNutritionProfiles
        {
            get { return _macroProfiles; }
        }
    }
}