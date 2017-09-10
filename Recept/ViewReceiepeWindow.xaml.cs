using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for ViewReceiepeWindow.xaml
    /// </summary>
    public partial class ViewReceiepeWindow : Window
    {
        private MainWindow mainwindow = new MainWindow();
        private List<Ingredient> ingredients = new List<Ingredient>();
        private DateTime date = new DateTime();

        public void SetWindow(MainWindow w)
        {
            mainwindow = w;
        }

        public ViewReceiepeWindow()
        {
            InitializeComponent();
        }

        public void Viewer(Recipe r)
        {
            _title.Text = "Title: ";
            _title_input.Text = r.Title;
            _author.Text = "Author: ";
            _author_input.Text = r.Author;
            _description.Text = "Description: ";
            _description_input.Text = r.Description;
            ListView.ItemsSource = r.Ingredients;
            _date.Content = "Created: " + r.Date;
            date = r.Date;
            _update.Content = "Latest Update: " + r.Update;
            _category.Text = "Category:";
            category_box.Text = r.Category;
            _country.Content = "Country:";
            country_box.Text = r.Country;
        }

        private void _save_Click(object sender, RoutedEventArgs e)
        {
            Recipe newrecipe = new Recipe(_title_input.Text, _author_input.Text, _description_input.Text, ingredients, date, DateTime.Now, _category.Text, country_box.Text);
            mainwindow.recipelist.Save(mainwindow.RecipeBox.SelectedIndex, newrecipe, new Exception());
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
                country_box.Items.Add(item);
            }
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

        private void Unitcheck(Ingredient ingredient)
        {
            //flytta till lib?
            //kollar vilken enhet som är ifylld
            if (mgram.IsChecked == true)
            {
                ingredient.Unit = Unit.mg;
            }

            else if (gram.IsChecked == true)
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

            else if (stycke.IsChecked == true)
            {
                ingredient.Unit = Unit.st;
            }

            else
            {
                ingredient.Unit = Unit.None;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ingredients.RemoveAt(ListView.SelectedIndex);
            ListView.Items.Refresh();
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
    }
}
