using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DrinkMachin
{
    class Tea : Beverage
    {
       

        public Tea(string name, double price, string[] ingredients, bool stir, double temp,int amount)
             : base(name, price, ingredients, stir, temp,amount)
        {
           
        }

        protected override string AddingHotWater()
        {
            return "Adding Half Cup of Hot Water..";
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
                return "Stiring One time to the right";
            else return "No need To Stir..";
        }

        protected override string TempOfTheWater()
        {
            string ans = string.Format(("The Temp Need to be {0} degrees Celsius"), Temp);
            return ans;
        }

       
    }
}
