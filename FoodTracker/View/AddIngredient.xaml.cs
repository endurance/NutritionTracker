using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FoodTracker.Model;
using FoodTracker.Services.Repository;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    /// <summary>
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        private AddIngredientViewModel _viewModel;
        public AddIngredient(IFoodRepository foodRepo)
        {
            InitializeComponent();
            _viewModel = new AddIngredientViewModel(foodRepo);
        }
    }
}
