using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Model;
using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using System.Windows;
namespace FoodTracker.ViewModel
{
   public class MainViewModel : INotifyPropertyChanged, IDropTarget
   {
      CalorieSet differenceMacros;
      private User endurance;
      ObservableCollection<FoodItem> userFoodList;
      ObservableCollection<FoodItem> windowFoodList;
      public MainViewModel()
      {
         endurance = User.EnduranceUser();
         endurance.FillFoodList("..\\..\\Data\\endurancefood.csv");
         userFoodList = new ObservableCollection<FoodItem>(endurance.Foods);
         windowFoodList = new ObservableCollection<FoodItem>();
         differenceMacros = endurance.Macros.Clone() as CalorieSet;
      }

      public User CurrentUser
      {
         get { return endurance; }
         private set { }
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
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged(string name)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(name));
         }
      }

      public void DragOver(IDropInfo dropInfo)
      {
         FoodItem sourceItem = dropInfo.Data as FoodItem;
         if (dropInfo.TargetCollection != null)
         {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Copy;
         }
      }

      public void Drop(IDropInfo dropInfo)
      {
         FoodItem sourceItem = dropInfo.Data as FoodItem;
         WindowFoodList.Add(sourceItem);
         FatDifference = differenceMacros.Fat - sourceItem.FoodMacros.Fat;
         CarbDifference = differenceMacros.Carbohydrate - sourceItem.FoodMacros.Carbohydrate;
         ProteinDifference = differenceMacros.Protein - sourceItem.FoodMacros.Protein;
         SaltDifference = differenceMacros.Salt - sourceItem.FoodMacros.Salt;
      }
   }
}
