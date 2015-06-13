using System.Windows;
using FoodTracker.Services.Repository;
using FoodTracker.View;
using FoodTracker.ViewModel;

namespace FoodTracker
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel;

        public MainWindow()
        {
            ViewModel = new MainViewModel();
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void loadFoodData_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void createIngredientCreationWindow_OnClick(object sender, RoutedEventArgs e)
        {
            AddIngredient window = new AddIngredient(new MongoFoodRepository());
            window.Show();

            this.UpdateLayout();
            //ViewModel.UpdateView();
        }
        
    }
}