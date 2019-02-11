using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DrinkMachin
{
    class VendingMachine
    {
        private List<Beverage> beverages;
        private static int _amountOfBeverage;
        private static int _amountOfCups;

        public VendingMachine()//empty machine all the hard work the manger do.
        {
            beverages = new List<Beverage>();
            _amountOfBeverage = 0;
            _amountOfCups = 0;
        }

        public void AddBeverage(Beverage beverage)//simple to add bev to the machine(List)
        {
            beverages.Add(beverage);
            _amountOfBeverage++;
        }

        public int AmoutOfCups // option to fill the cups, the user cant make bev without cups so he can fill them
        {
            get { return _amountOfCups; }
            set { _amountOfCups = value; }
        }
        public int AmountOfBev
        {
            get { return _amountOfBeverage; }
        }

        public void AddAmountToDrink(Beverage beverage)// we can add amount to the bev, if we create the same bev but put anther amount
        {
            for (int i = 0; i < _amountOfBeverage; i++)
            {
                if (beverage.Name == beverages[i].Name)
                {
                    beverages[i].Amount += beverage.Amount;
                    return;
                }
            }
            throw new Exception("Beverage Not found!!");

        }


        public bool IsBeverageInStock(string name)// check the amount of the bev in the machine
        {
            bool flag = false;
            for (int i = 0; i < _amountOfBeverage; i++)
            {
                if (name == beverages[i].Name && beverages[i].Amount > 0)
                {
                    flag =  true;
                }
         
            }
            return flag;
        }
        public double GetbeveagePrice(string name) 
        {
            double priceToReturn = 0;
            for (int i = 0; i < _amountOfBeverage; i++)
            {
                if (name == beverages[i].Name)
                {
                     priceToReturn=beverages[i].Price;
                }

            }
            return priceToReturn;
        }
        public bool CheckIfBevInMach(string name)
        {
            for (int i = 0; i < _amountOfBeverage; i++)
            {
                if (name == beverages[i].Name)
                    return true;
            }
            return false;
        }

        public void RemoveBev(Beverage beverage)// remove bev, first check if he in the machine
        {
            for (int i = 0; i < _amountOfBeverage; i++)
            {
                if (beverage.Name == beverages[i].Name)
                {
                    beverages.RemoveAt(i);
                    return;
                }
                throw new Exception("Bevarge Not found!");
            }
        }
        public Beverage this[string name] // Indexer, very usefull in our project
        {
            get
            {
                for (int i = 0; i < _amountOfBeverage; i++)
                {
                    if (beverages[i].Name == name)
                        return beverages[i];

                }
                throw new Exception("Beverage Not Found");
            }

        }
        public Beverage this[int Index]//Indexer
        {
            get
            {
                for (int i = 0; i < _amountOfBeverage; i++)
                {
                    if (i == Index)
                        return beverages[i];

                }
                throw new Exception("Index Not Fount!");
            }

        }
        
    }
}
