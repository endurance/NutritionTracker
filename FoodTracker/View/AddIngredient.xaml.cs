using System.Windows;
using System.Windows.Controls;
using FoodTracker.Services.Repository;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    /// <summary>
    ///     Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        private AddIngredientViewModel _viewModel;

        public AddIngredient(IFoodRepository foodRepo)
        {
            _viewModel = new AddIngredientViewModel(foodRepo);
            InitializeComponent();
            DataContext = _viewModel;
            
        }

        private void UpdateDb_SubmitClick(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveFoodItemToDb();
            Close();
        }
    }
}