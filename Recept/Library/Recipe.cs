using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    public class Recipe
    {
        private string title;
        private string author;
        private string description;
        private List<Ingredient> ingredients;
        private DateTime date;
        private DateTime update;
        private string category;
        private string country;

        public Recipe(string title, string author, string description, List<Ingredient> ingredients, DateTime date, DateTime update, string category, string country)
        {
            this.title = title;
            this.author = author;
            this.description = description;
            this.ingredients = ingredients;
            this.date = date;
            this.update = update;
            this.category = category;
            this.country = country;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public List<Ingredient> Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                this.ingredients = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public DateTime Update
        {
            get
            {
                return this.update;
            }
            set
            {
                this.update = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public override bool Equals(object value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if (ReferenceEquals(this, value))
            {
                return true;
            }

            if (value.GetType() != GetType())
            {
                return false;
            }

            return IsEqual((Recipe)value);
        }

        public bool Equals(Recipe recipe)
        {
            if (ReferenceEquals(null, recipe))
            {
                return false;
            }

            if (ReferenceEquals(this, recipe))
            {
                return true;
            }

            return IsEqual(recipe);
        }

        private bool IsEqual(Recipe recipe)
        {
            return String.Equals(Title.ToLower(), recipe.Title.ToLower()) && String.Equals(Author.ToLower(), recipe.Author.ToLower());
        }
    }
}
