using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DrinkMachin
{
    abstract class Beverage
    {
        private string _name;
        private double _price;
        private string[] _ingredients;
        private bool _stir;
        private double _heatTempOfWater;
        private int _amount;

        public Beverage(string name, double price, string[] ingredients, bool stir, double temp,int amount)
        {
            _name = name;
            _price = price;
            _ingredients = ingredients;
            _stir = stir;
            _heatTempOfWater = temp;
            _amount = amount;
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Name
        {
            get { return _name; }
           
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
           
        }
        public string[] Ingredients
        {
            get { return _ingredients; }
          
        }
        public bool Stir
        {
            get { return _stir; }
          
        }
        public double Temp
        {
            get { return _heatTempOfWater; }
           
        }
        // main function to bev class, bev is abstrct class, we what to make all the class that
        // inheirt from me to make this function the same but with diffrent use.
        public string Prepare()
        {
            StringBuilder result = new StringBuilder();// use builder for performents and save memory
            result.AppendLine("Now we Prepare your : "+Name);
            result.AppendLine(AddingIngredients());
            result.AppendLine(AddingHotWater());
            result.AppendLine(Stiring());
            result.AppendLine(TempOfTheWater());
            Amount--;
            return result.ToString();
        }

        protected abstract string Stiring();
        protected abstract string AddingIngredients();
        protected abstract string AddingHotWater();
        protected abstract string TempOfTheWater();

       

        public override string ToString()
        {
            string ans;
            ans = string.Format("Name Of the Beverage : {0}/n,Price of the Beverage : {1}/n," +
                "Ingredients Of the Beverage : {2}/n,Need to stir?{3}/n, The Temp Of the water :{4}/n" +
                "The Amount Are :{5}"
                , Name, Price, GetIngr(Ingredients), Stir, Temp,Amount);
            return ans;
        }

        public override bool Equals(object obj)
        {
            Beverage other = obj as Beverage;
            if (other != null)
            {
                if (this == other)
                    return true;
                else return false;
            }
            throw new Exception("You Try to compere Two diffrent thing, this methood compere only beverge!");
            
        }
        public string GetIngr(string[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i]+" ");
            }
            return stringBuilder.ToString();


        }


    }
    
}
