using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private recipeList recipelist = new recipeList();
        private SortDescription sort;

        public MainWindow()
        {
            InitializeComponent();
            RecipeGridview();
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
            Recipe r = recipelist.Load(RecipeBox.SelectedIndex, new Exception());
            recipewindow.Viewer(r);
        }

        private void RecipeGridview()
        {
            GridView grid = new GridView();
            grid.AllowsColumnReorder = true;

            GridViewColumn titleColumn = new GridViewColumn();
            titleColumn.DisplayMemberBinding = new Binding("Title");
            titleColumn.Header = "Title";
            titleColumn.Width = 241;
            grid.Columns.Add(titleColumn);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            recipelist.Sorterare();
            //RecipeBox.ItemsSource = recipelist;
        }
    }
}
