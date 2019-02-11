using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DrinkMachin
{
    class Manger
    {
        //create the bev and the machine
        VendingMachine vendingMachine = new VendingMachine();
        Tea tea = new Tea("Tea", 3, new string[] { "tea leaves", "suger" }, true, 90, 50);
        Coffee coffee = new Coffee("Coffee", 4, new string[] { "coffee beans", "milk" }, true, 100, 50);
        public static bool seccess = false;
        public Manger()
        {
            FillMachine();
        }

        private void FillMachine()// start point
        {
            vendingMachine.AddBeverage(tea);
            vendingMachine.AddBeverage(coffee);
            vendingMachine.AmoutOfCups = 100;
        }

        // the main func, the user select bev from the machine and we check all the things
        // and if all o.k we prepare the bev according to the prepare system
        // every step we check something else, becouse we what to return the right message to the user
        // and to give him the option to change the uncurrect filleds.
        public string BeverageSelected(string name, string price)
        {
            seccess = false;
            if (vendingMachine.CheckIfBevInMach(name))
            {
                if (vendingMachine[name].Amount > 0)
                {
                    if (ISValidDouble(price) && vendingMachine[name].Price <= double.Parse(price))
                    {
                        if (vendingMachine.AmoutOfCups != 0)
                        {
                            vendingMachine.AmoutOfCups = vendingMachine.AmoutOfCups - 1;
                            seccess = true;
                            return vendingMachine[name].Prepare();

                        }
                        return "Not enough cups In the machine, Pleace Insert cups..";

                    }
                    return "you didnt insert enough money, the money need to be : " + vendingMachine[name].Price + " $";
                }
                return "No " + vendingMachine[name].Name + " In Stock!";
            }
            throw new ArgumentException();
           
        } 

        private bool ISValidDouble(string price)// using for all the string that i get from the GUI and check if thay numbers
        {
            bool flag = true;
            if(!double.TryParse(price, out double result) || result<0)
            {
                flag = false;
            }
            return flag;
  
        }

        public BitmapSource GetPicSecces(string name)// uploded the pic to the machine according to the bev
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(@"ms-appx:///Assets/" + name + ".jpg");
            return bitmap;
        }

        public BitmapImage GetPicUnSecces()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(@"ms-appx:///Assets/not.jpg");
            return bitmap;
        }

        public string AddCups(string num)// mang the cups, alowed to add until 100 cups, no place to store over 100 cups
        {
            if (ISValidDouble(num))
            {
                if (vendingMachine.AmoutOfCups < 100 && 100> vendingMachine.AmoutOfCups+int.Parse(num))
                {
                    vendingMachine.AmoutOfCups += int.Parse(num);
                    return "Adding Cups success";
                }
                return "Adding cups Falied, The Machine can hold only 100 Cups ";
            }
            return "Adding cups Falied, Pleace Insert a Valid Number";
                
        }

        public string change(string name,string price)// make the calulate of the change and return the amoount
        {
            
                string result;
                if (ISValidDouble(price) && vendingMachine[name].Price < double.Parse(price))
                {
                    result = (double.Parse(price) - vendingMachine[name].Price).ToString();
                    return result;
                }
                else return "";
               
        }

        // option : add one bev to the machine , the machine can hold only 3 bev(small machine)
        public bool AddBeveage(string name, string price, string ingredients, bool? stir, string temp, string amount)
        {
            
            var ingredientsArray = ingredients.Split(' ');
            if (ISValidDouble(price) && ISValidDouble(temp))
            {
                CustBeverage custBeverage = new CustBeverage(name, double.Parse(price)
                    , ingredientsArray, true, double.Parse(temp), int.Parse(amount));
                vendingMachine.AddBeverage(custBeverage);
                return true;
            }
            throw new ArgumentException();

        }

        //usefull functions that help me to resive the parmeters from the vendingmachine
        public string GetName(string name)
        {
            return vendingMachine[name].Name;
        }
        
        public string quantity(string name)
        {
            return vendingMachine[name].Amount.ToString();
        }
        public string GetPrice(string name)
        {
            return vendingMachine[name].Price.ToString()+"$";
        }
        public string GetCups()
        {
            return vendingMachine.AmoutOfCups.ToString();
        }
        




    }
}