using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    public class recipeList
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

        public void Sorterare()
        {
            if (list == list.OrderBy(i => i))
            {
                list = list.OrderByDescending(i => i).ToList();
            }
            else
            {
                list = list.OrderBy(i => i).ToList();
            }
        }
    }
}
