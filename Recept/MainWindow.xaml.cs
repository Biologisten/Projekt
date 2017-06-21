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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public recipeList recipelist = new recipeList();

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool AddRecipe(Recipe recipe)
        {
            if (recipelist.Add(recipe) == true)
            {
                RecipeBox.Items.Add(recipe.Title);
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var usrwindow = new RecipeCreateView();
            usrwindow.Owner = this;
            usrwindow.SetWindow(this);
            usrwindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var recipewindow = new ViewReceiepeWindow();
            recipewindow.Owner = this;
            recipewindow.Show();
            Recipe r = recipelist.Load(RecipeBox.SelectedIndex);
            recipewindow.Viewer(r);
        }
    }
}
