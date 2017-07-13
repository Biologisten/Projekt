using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    public class RecipeList
    {
        private List<Recipe> list = new List<Recipe>();

        public bool Add(Recipe recipe)
        {
            if (list.Contains(recipe))
            {   
                return false;
            }
            list.Add(recipe);
            return true;
        }

        public Recipe Load(int i, Exception error)
        {
            if (i < 0)
            {
                throw error;
            }
            return list[i];
        }

        public void Sorterare(object sender)
        {
            if (sender == "Title")
            {
                if (list.OrderBy(str => str.Title).SequenceEqual(list))
                {
                    list = list.OrderByDescending(str => str.Title.ToString()).ToList();
                }
                else
                {
                    list = list.OrderBy(str => str.Title.ToString()).ToList();
                }
            }
            else
            {
                if (list.OrderBy(str => str.Author).SequenceEqual(list))
                {
                    list = list.OrderByDescending(str => str.Author.ToString()).ToList();
                }
                else
                {
                    list = list.OrderBy(str => str.Author.ToString()).ToList();
                }
            }
        }

        public void Refresher(MainWindow window)
        {
            foreach (Recipe recipe in list)
            {
                window.RecipeBox.Items.Add(recipe.Title);
            }
        }
    }
}
