using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using FoodTracker.Model;
using GongSolutions.Wpf.DragDrop;

namespace FoodTracker.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged, IDropTarget
    {
        private readonly Macronutrient differenceMacros;
        private readonly User endurance;
        private readonly ObservableCollection<FoodItem> userFoodList;
        private readonly ObservableCollection<FoodItem> windowFoodList;

        public MainViewModel()
        {
            endurance = User.EnduranceUser();
            endurance.FillFoodList("..\\..\\Data\\endurancefood.csv");
            userFoodList = new ObservableCollection<FoodItem>(endurance.Foods);
            windowFoodList = new ObservableCollection<FoodItem>();
            differenceMacros = endurance.Macros.Clone() as Macronutrient;
        }

        public User CurrentUser
        {
            get { return endurance; }
        }

        public ObservableCollection<FoodItem> UserFoodList
        {
            get { return userFoodList; }
            private set { }
        }

        public ObservableCollection<FoodItem> WindowFoodList
        {
            get { return windowFoodList; }
            private set { }
        }

        public double FatDifference
        {
            get { return differenceMacros.Fat; }
            set
            {
                differenceMacros.Fat = value;
                OnPropertyChanged("FatDifference");
            }
        }

        public double CarbDifference
        {
            get { return differenceMacros.Carbohydrate; }
            set
            {
                differenceMacros.Carbohydrate = value;
                OnPropertyChanged("CarbDifference");
            }
        }

        public double ProteinDifference
        {
            get { return differenceMacros.Protein; }
            set
            {
                differenceMacros.Protein = value;
                OnPropertyChanged("ProteinDifference");
            }
        }

        public int SaltDifference
        {
            get { return differenceMacros.Salt; }
            set
            {
                differenceMacros.Salt = value;
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
            FatDifference = differenceMacros.Fat - sourceItem.FoodMacros.Fat;
            CarbDifference = differenceMacros.Carbohydrate - sourceItem.FoodMacros.Carbohydrate;
            ProteinDifference = differenceMacros.Protein - sourceItem.FoodMacros.Protein;
            SaltDifference = differenceMacros.Salt - sourceItem.FoodMacros.Salt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}