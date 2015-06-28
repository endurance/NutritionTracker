using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodTracker.Annotations;
using FoodTracker.Model;
using FoodTracker.Services.Repository;

namespace FoodTracker.ViewModel
{
    public class AddIngredientViewModel : IViewModel
    {
        private readonly IFoodRepository _repo;
        private FoodItem _food;

        public FoodItem Food
        {
            get { return _food; }
            set
            {
                if (Equals(value, _food)) return;
                _food = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
                OnPropertyChanged("ImperialServing");
                OnPropertyChanged("MetricServing");
                OnPropertyChanged("FoodMacros");
                OnPropertyChanged("Fat");
                OnPropertyChanged("Carbs");
                OnPropertyChanged("Protein");
                OnPropertyChanged("Salt");
            }
        }

        public AddIngredientViewModel(IFoodRepository repo)
        {
            _repo = repo;
            Food = new FoodItem();
            Food.Name = "chicken";
        }

        public long Id { get; set; }
        
        public string Name
        {
            get { return Food.Name; }
            set
            {
                Food.Name = value;
                OnPropertyChanged();
            }
        }

        public ImperialServing ImperialServing
        {
            get { return Food.ImperialServing; }
            set
            {
                if (Equals(value, Food.ImperialServing)) return;
                Food.ImperialServing = value;
                OnPropertyChanged();
            }
        }

        public MetricServing MetricServing
        {
            get { return Food.MetricServing; }
            set
            {
                if (Equals(value, Food.MetricServing)) return;
                Food.MetricServing = value;
                OnPropertyChanged();
            }
        }

        public Macronutrient FoodMacros
        {
            get { return Food.FoodMacros; }
            set
            {
                if (Equals(value, Food.FoodMacros)) return;
                Food.FoodMacros = value;
                OnPropertyChanged();
            }
        }

        public double Fat
        {
            get { return Food.FoodMacros.Fat; }
            set
            {
                if (value.Equals(Food.FoodMacros.Fat)) return;
                Food.FoodMacros.Fat = value;
                OnPropertyChanged();
            }
        }

        public double Carbs
        {
            get { return Food.FoodMacros.Carbohydrate; }
            set
            {
                Food.FoodMacros.Carbohydrate = value;
                OnPropertyChanged();
            }
        }

        public double Protein
        {
            get { return Food.FoodMacros.Protein; }
            set
            {
                Food.FoodMacros.Protein = value;
                OnPropertyChanged();
            }
        }

        public int Salt
        {
            get { return Food.FoodMacros.Salt; }
            set
            {
                Food.FoodMacros.Salt = value;
                OnPropertyChanged();
            }
        }


        public void SaveFoodItemToDb()
        {
            _repo.AddEntity(Food);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}