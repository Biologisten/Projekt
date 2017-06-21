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
            _title.Content = "Title: " + r.Title;
            _author.Content = "Author:" + r.Author;
            _description.Content = "Description: " + r.Description;
            _ingredient.Content = "Ingredients:";
            foreach (Ingredient ingredient in r.Ingredients)
            {
                _ingredient.Content += Environment.NewLine + ingredient.Name + "    Amount: " + ingredient.Amount + " " + ingredient.Unit;
            }
            _date.Content = "Date: " + r.Date;
            _update.Content = "Latest Update: " + r.Update;
            _category.Content = "Category: " + r.Category;
            _Country.Content = "Country: " + r.Country;
        }
    }
}
