using System;
using System.Collections.Generic;
using System.Drawing;
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
        public ViewReceiepeWindow()
        {
            InitializeComponent();
        }

        public void Viewer(Recipe r)
        {
            _title.Text = "Title: " + r.Title;
            _author.Text = "Author: " + r.Author;
            _description.Text = "Description: " + r.Description;
            _ingredient.Text = "Ingredients:";
            foreach (Ingredient ingredient in r.Ingredients)
            {
                _ingredient.Text += Environment.NewLine + ingredient.ToString();
            }
            _date.Text = "Created: " + r.Date;
            _update.Text = "Latest Update: " + r.Update;
            _category.Text = "Category: " + r.Category;
            _Country.Text = "Country: " + r.Country;
        }

        private void _save_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
