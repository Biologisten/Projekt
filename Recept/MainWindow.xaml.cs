﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private RecipeList recipelist = new RecipeList();

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool AddRecipe(Recipe recipe)
        {
            if (recipelist.Add(recipe) == true)
            {
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

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e) //Title header
        {
            RecipeBox.ItemsSource = recipelist.Sorterare("Title");
            RecipeBox.Items.Refresh();
        }

        private void GridViewColumnHeader_Click_1(object sender, RoutedEventArgs e) //Author header
       {
            RecipeBox.ItemsSource = recipelist.Sorterare("Author");
            RecipeBox.Items.Refresh();
        }
    }
}
