using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void Save(int i, Recipe recipe, Exception error)
        {
            if (i < 0)
            {
                throw error;
            }

            list[i] = recipe;
        }

        public Recipe Load(int i, Exception error)
        {
            if (i < 0)
            {
                throw error;
            }
            return list[i];
        }

        public List<Recipe> Sorterare(string sender)
        {
            if (sender == "Title")
            {
                var sortedlist = list.OrderBy(str => str.Title);
                if (sortedlist.SequenceEqual(list))
                {
                    list = list.OrderByDescending(str => str.Title.ToString()).ToList();
                    return list;
                }
                else
                {
                    list = list.OrderBy(str => str.Title.ToString()).ToList();
                    return list;
                }
            }
            else if (sender == "Source")
            {
                return list;
            }
            else
            {
                var sortedlist = list.OrderBy(str => str.Author);
                if (sortedlist.SequenceEqual(list))
                {
                    list = list.OrderByDescending(str => str.Author.ToString()).ToList();
                    return list;
                }
                else
                {
                    list = list.OrderBy(str => str.Author.ToString()).ToList();
                    return list;
                }
            }
        }
    }
}
