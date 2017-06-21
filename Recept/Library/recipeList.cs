using System;
using System.Collections.Generic;
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

        public Recipe Load(int i)
        {
            return list[i];
        }
    }
}
