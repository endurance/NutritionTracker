using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Caliburn.Micro;
using FoodTracker.Annotations;
using FoodTracker.Model;
using FoodTracker.Services.Repository;
using GongSolutions.Wpf.DragDrop;

namespace FoodTracker.ViewModel
{
    public class MainViewModel : PropertyChangedBase, IDropTarget
    {
        private readonly Macronutrient _differenceMacros;
        private readonly IFoodRepository _repo = new MongoFoodRepository();
        private readonly ObservableCollection<FoodItem> _repoFoodList = new ObservableCollection<FoodItem>();
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
            MainWindowFoodList = new ObservableCollection<FoodItem>(CurrentUser.Foods);
            _differenceMacros = CurrentUser.GoalMacroNutrients.First().Clone() as Macronutrient;
        }

        public User CurrentUser { get; set; }

        public ObservableCollection<FoodItem> UserFoodList
        {
            get
            {
                _repoFoodList.Clear();
                foreach (var i in _repo.GetAllFoodItems()) _repoFoodList.Add(i);
                return _repoFoodList;
            }
        }

        public ObservableCollection<FoodItem> MainWindowFoodList { get; set;  }

        public double FatDifference
        {
            get { return _differenceMacros.Fat; }
            set
            {
                _differenceMacros.Fat = value;
                NotifyOfPropertyChange(() => FatDifference);
            }
        }

        public double CarbDifference
        {
            get { return _differenceMacros.Carbohydrate; }
            set
            {
                _differenceMacros.Carbohydrate = value;
                NotifyOfPropertyChange(() => CarbDifference);
            }
        }

        public double ProteinDifference
        {
            get { return _differenceMacros.Protein; }
            set
            {
                _differenceMacros.Protein = value;
                NotifyOfPropertyChange(() => ProteinDifference);
            }
        }

        public int SaltDifference
        {
            get { return _differenceMacros.Salt; }
            set
            {
                _differenceMacros.Salt = value;
                NotifyOfPropertyChange(() => SaltDifference);
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data as FoodItem;
            if (dropInfo.TargetCollection == null) return;
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Copy;
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
    }
}