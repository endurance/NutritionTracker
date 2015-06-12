using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodTracker.Annotations;
using FoodTracker.Model;
using FoodTracker.Services.Repository;

namespace FoodTracker.ViewModel
{
    public class AddIngredientViewModel : IViewModel
    {
        private readonly IFoodRepository _repo = new MongoFoodRepository();
        private FoodItem foodItem;

        public AddIngredientViewModel(IFoodRepository repo)
        {
            _repo = repo;
            foodItem = new FoodItem();
        }

        public long Id { get; set; }

        public string Name
        {
            get { return foodItem.Name; }
            set
            {
                foodItem.Name = value;
                OnPropertyChanged();
            }
        }

        public ImperialServing ImperialServing
        {
            get { return foodItem.ImperialServing; }
            set
            {
                if (Equals(value, foodItem.ImperialServing)) return;
                foodItem.ImperialServing = value;
                OnPropertyChanged();
            }
        }

        public MetricServing MetricServing
        {
            get { return foodItem.MetricServing; }
            set
            {
                if (Equals(value, foodItem.MetricServing)) return;
                foodItem.MetricServing = value;
                OnPropertyChanged();
            }
        }

        public Macronutrient FoodMacros
        {
            get { return foodItem.FoodMacros; }
            set
            {
                if (Equals(value, foodItem.FoodMacros)) return;
                foodItem.FoodMacros = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}