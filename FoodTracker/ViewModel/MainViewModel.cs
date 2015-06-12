using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using FoodTracker.Model;
using FoodTracker.Services.Repository;
using GongSolutions.Wpf.DragDrop;

namespace FoodTracker.ViewModel
{
    public class MainViewModel : IViewModel, IDropTarget
    {
        private readonly Macronutrient _differenceMacros;
        private readonly IFoodRepository _repo = new MongoFoodRepository();
        public MainViewModel()
        {
            CurrentUser = new User()
            {
                GoalMacroNutrients = new List<Macronutrient>()
                {
                  new Macronutrient(70, 200, 200, 3000)
                },
                Age = 26,
                Gender = Gender.Male,
                Height = 180.34,
                Weight = 200,
                Foods = new List<FoodItem>()
            };
            //CurrentUser.FillFoodList("..\\..\\Data\\endurancefood.csv");
            UserFoodList = new ObservableCollection<FoodItem>(CurrentUser.Foods);
            MainWindowFoodList = new ObservableCollection<FoodItem>(_repo.GetAllFoodItems());
            _differenceMacros = CurrentUser.GoalMacroNutrients.First().Clone() as Macronutrient;
        }

        public User CurrentUser { get; }

        public ObservableCollection<FoodItem> UserFoodList { get; }

        public ObservableCollection<FoodItem> MainWindowFoodList { get; }

        public double FatDifference
        {
            get { return _differenceMacros.Fat; }
            set
            {
                _differenceMacros.Fat = value;
                OnPropertyChanged("FatDifference");
            }
        }

        public double CarbDifference
        {
            get { return _differenceMacros.Carbohydrate; }
            set
            {
                _differenceMacros.Carbohydrate = value;
                OnPropertyChanged("CarbDifference");
            }
        }

        public double ProteinDifference
        {
            get { return _differenceMacros.Protein; }
            set
            {
                _differenceMacros.Protein = value;
                OnPropertyChanged("ProteinDifference");
            }
        }

        public int SaltDifference
        {
            get { return _differenceMacros.Salt; }
            set
            {
                _differenceMacros.Salt = value;
                OnPropertyChanged("SaltDifference");
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data as FoodItem;
            if (dropInfo.TargetCollection != null)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Copy;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data as FoodItem;
            MainWindowFoodList.Add(sourceItem);
            FatDifference = _differenceMacros.Fat - sourceItem.FoodMacros.Fat;
            CarbDifference = _differenceMacros.Carbohydrate - sourceItem.FoodMacros.Carbohydrate;
            ProteinDifference = _differenceMacros.Protein - sourceItem.FoodMacros.Protein;
            SaltDifference = _differenceMacros.Salt - sourceItem.FoodMacros.Salt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            // this code is being replaced with "null-propogation".
            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(name));
            //}
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}