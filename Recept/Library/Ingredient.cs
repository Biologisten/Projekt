using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    public class Ingredient
    {
        private string name; //failsafe om tom
        private float amount;
        private Unit unit;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public float Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public Unit Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }
    }
}