using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMachin
{
    class CustBeverage : Beverage
    {
        public CustBeverage(string name, double price, string[] ingredients, bool stir, double temp, int amount)
            : base(name, price, ingredients, stir, temp, amount)
        { }


        protected override string AddingHotWater()
        {
            return "Adding  Cup of Hot Water..";
        }

        protected override string AddingIngredients()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Ingredients.Length; i++)
            {
                stringBuilder.AppendLine(Ingredients[i]);
            }
            return "Adding the ingredients  : " + stringBuilder.ToString();
        }

        protected override string Stiring()
        {
            if (Stir)
                return "Stiring three time to the right";
            else return "No need To Stir..";
        }

        protected override string TempOfTheWater()
        {
            string ans = string.Format(("The Temp Need to be {0} degrees Celsius"), Temp);
            return ans;
        }
    }
}
