using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using FoodTracker.Model;
using GongSolutions.Wpf.DragDrop;

namespace FoodTracker.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged, IDropTarget
    {
        private readonly Macronutrient _differenceMacros;
        private readonly ObservableCollection<FoodItem> userFoodList;
        private readonly ObservableCollection<FoodItem> windowFoodList;

        public MainViewModel()
        {
            CurrentUser = User.EnduranceUser();
            CurrentUser.FillFoodList("..\\..\\Data\\endurancefood.csv");
            userFoodList = new ObservableCollection<FoodItem>(CurrentUser.Foods);
            windowFoodList = new ObservableCollection<FoodItem>();
            _differenceMacros = CurrentUser.Macros.Clone() as Macronutrient;
        }

        public User CurrentUser { get; }

        public ObservableCollection<FoodItem> UserFoodList
        {
            get { return userFoodList; }
        }

        public ObservableCollection<FoodItem> WindowFoodList
        {
            get { return windowFoodList; }
        }

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
            WindowFoodList.Add(sourceItem);
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