using Caliburn.Micro;
using FoodTracker.Model;
using FoodTracker.Services.Repository;

namespace FoodTracker.ViewModel
{
    public class AddIngredientViewModel : PropertyChangedBase
    {
        private readonly IFoodRepository _repo;
        private FoodItem _food;

        public AddIngredientViewModel(IFoodRepository repo)
        {
            _repo = repo;
            Food = new FoodItem();
            Food.Name = "chicken";
        }

        //public FoodItem Food
        //{
        //    get { return _food; }
        //    set
        //    {
        //        if (Equals(value, _food)) return;
        //        _food = value;
        //        OnPropertyChanged();
        //        OnPropertyChanged("Name");
        //        OnPropertyChanged("ImperialServing");
        //        OnPropertyChanged("MetricServing");
        //        OnPropertyChanged("FoodMacros");
        //        OnPropertyChanged("Fat");
        //        OnPropertyChanged("Carbs");
        //        OnPropertyChanged("Protein");
        //        OnPropertyChanged("Salt");
        //    }
        //}

        public FoodItem Food { get; set; }
        public long Id { get; set; }

        public string Name
        {
            get { return Food.Name; }
            set
            {
                Food.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public ImperialServing ImperialServing
        {
            get { return Food.ImperialServing; }
            set
            {
                if (Equals(value, Food.ImperialServing)) return;
                Food.ImperialServing = value;
                NotifyOfPropertyChange(() => ImperialServing);
            }
        }

        public MetricServing MetricServing
        {
            get { return Food.MetricServing; }
            set
            {
                if (Equals(value, Food.MetricServing)) return;
                Food.MetricServing = value;
                NotifyOfPropertyChange(() => MetricServing);
            }
        }

        public Macronutrient FoodMacros
        {
            get { return Food.FoodMacros; }
            set
            {
                if (Equals(value, Food.FoodMacros)) return;
                Food.FoodMacros = value;
                NotifyOfPropertyChange(() => FoodMacros);
            }
        }

        public double Fat
        {
            get { return Food.FoodMacros.Fat; }
            set
            {
                if (value.Equals(Food.FoodMacros.Fat)) return;
                Food.FoodMacros.Fat = value;
                NotifyOfPropertyChange(() => Fat);
            }
        }

        public double Carbs
        {
            get { return Food.FoodMacros.Carbohydrate; }
            set
            {
                Food.FoodMacros.Carbohydrate = value;
                NotifyOfPropertyChange(() => Carbs);
            }
        }

        public double Protein
        {
            get { return Food.FoodMacros.Protein; }
            set
            {
                Food.FoodMacros.Protein = value;
                NotifyOfPropertyChange(() => Protein);
            }
        }

        public int Salt
        {
            get { return Food.FoodMacros.Salt; }
            set
            {
                Food.FoodMacros.Salt = value;
                NotifyOfPropertyChange(() => Salt);
            }
        }

        public void SaveFoodItemToDb()
        {
            _repo.AddEntity(Food);
        }
    }
}