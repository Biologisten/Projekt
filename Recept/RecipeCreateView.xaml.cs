using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Recept
{
    /// <summary>
    /// Interaction logic for RecipeCreateView.xaml
    /// </summary>
    public partial class RecipeCreateView : Window
    {
        private MainWindow mainwindow = new MainWindow();
        private Ingredient ingredient = new Ingredient();
        private List<Ingredient> ingredients = new List<Ingredient>();

        public RecipeCreateView()
        {
            InitializeComponent();
            PopulateCountryComboBox();
            CreateDynamicGridView();
        }

        bool Unikingredient(Ingredient ingre)
        {
            if (ingredients.Contains(ingre))
            {
                return false;
            }
            else
            {
                return true;
            }
        
        }

        private void CreateDynamicGridView()
        {
            // Lägga i bibliotek istället?
            // Skapar gridview
            GridView grid = new GridView();
            grid.AllowsColumnReorder = true;

            GridViewColumn nameColumn = new GridViewColumn();
            nameColumn.DisplayMemberBinding = new Binding("Name");
            nameColumn.Header = "Name";
            nameColumn.Width = 37;
            grid.Columns.Add(nameColumn);

            GridViewColumn amountColumn = new GridViewColumn();
            amountColumn.DisplayMemberBinding = new Binding("Amount");
            amountColumn.Header = "Amount";
            amountColumn.Width = 48;
            grid.Columns.Add(amountColumn);

            GridViewColumn unitColumn = new GridViewColumn();
            unitColumn.DisplayMemberBinding = new Binding("Unit");
            unitColumn.Header = "Unit";
            unitColumn.Width = 27;
            grid.Columns.Add(unitColumn);

            ListView.View = grid;
            ListView.ItemsSource = ingredients;
        }

        private void PopulateCountryComboBox() //Lägger till alla länder till komboboxen
        {
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            List<string> countryNames = new List<string>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);

                countryNames.Add(country.DisplayName.ToString());
            }

            IEnumerable<string> nameAdded = countryNames.OrderBy(names => names).Distinct();

            foreach (string item in nameAdded)
            {
                countrybox.Items.Add(item);
            }
        }

        public void SetWindow(MainWindow w)
        {
            mainwindow = w;
        }

        private void Unitcheck(Ingredient ingredient)
        {
            //flytta till lib?
            //kollar vilken enhet som är ifylld
            if (gram.IsChecked == true)
            {
                ingredient.Unit = Unit.g;
            }

            else if (kilogram.IsChecked == true)
            {
                ingredient.Unit = Unit.Kg;
            }
     
            else if (milliliter.IsChecked == true)
            {
                ingredient.Unit = Unit.ml;
            }

            else if (deciliter.IsChecked == true)
            {
                ingredient.Unit = Unit.dl;
            }

            else if (liter.IsChecked == true)
            {
                ingredient.Unit = Unit.L;
            }

            else
            {
                ingredient.Unit = Unit.None;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //sätter alla värden i ingrediensen och kollar så att allt är okej
        {
            Ingredient ingre = new Ingredient();
            Unitcheck(ingre);
            float.TryParse(ingredientamount.Text, out float amount);
            ingre.Name = ingredientname.Text;
            ingre.Amount = amount;
            if (Unikingredient(ingre) == true)
            { 
                ingredients.Add(ingre);
                ListView.Items.Refresh();
            }
            else
            {
                var error = new error();
                error.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Lägger till receptet i receptlistan
        {
            Recipe recipe = new Recipe(titeltxt.Text, authortxt.Text, descriptiontxt.Text, ingredients, DateTime.Now, DateTime.Now, categorytxt.Text, countrybox.Text);
            if (mainwindow.AddRecipe(recipe) == true)
            {
                mainwindow.RecipeBox.Items.Refresh();
                this.Close();
            }
            else
            {
                var error = new error();
                error.ShowDialog();
            }
        }
    }
}