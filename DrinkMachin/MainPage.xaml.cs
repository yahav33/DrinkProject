using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrinkMachin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Manger manger;
        public MainPage()
        {
            this.InitializeComponent();
            manger = new Manger();
            price2.Visibility = Visibility.Collapsed;
            ingridens.Visibility = Visibility.Collapsed;
            isStirb.Visibility = Visibility.Collapsed;
            amount.Visibility = Visibility.Collapsed;
            temp.Visibility = Visibility.Collapsed;
            name.Visibility = Visibility.Collapsed;
            opt.Visibility = Visibility.Collapsed;
            addbe.Visibility = Visibility.Collapsed;
            coffeeamount.Text = manger.quantity("Coffee");
            teaamount.Text = manger.quantity("Tea");
            tbCoffprice.Text = manger.GetPrice("Coffee");
            tbTeaprice.Text = manger.GetPrice("Tea");
            numofcups.Text = "Cups In Stock : "+manger.GetCups();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            try
            {
                
                var nameofbeverage = (btn.Content).ToString();
                var result = manger.BeverageSelected(nameofbeverage, price.Text);
                var change1 = manger.change(nameofbeverage, price.Text);
                perpare.Text = result;
                change.Text = change1;
                if (nameofbeverage == "Coffee")
                {
                    coffeeamount.Text = manger.quantity(nameofbeverage);
                }
                else if (nameofbeverage == "Tea")
                {
                    teaamount.Text = manger.quantity(nameofbeverage);
                }
                else
                    newbever.Text = manger.quantity(nameofbeverage);
                price.Text = "";
                if (Manger.seccess)
                {
                    pic.Source = manger.GetPicSecces(nameofbeverage);
                }
                else pic.Source = manger.GetPicUnSecces();

                numofcups.Text = "Cups In Stock : " + manger.GetCups();
            }
            catch (ArgumentException)
            {
                perpare.Text = "Beverage Not Found In the Machine!";
            }

        }

        private void Addbe_Click(object sender, RoutedEventArgs e)
        {
            
            var money = price2.Text;
            var ingredients = ingridens.Text;
            var stir1 = isStirb.IsChecked;
            var amount1 = amount.Text;
            var name1 = name.Text;
            var temp1 = temp.Text;
            try
            {
                manger.AddBeveage(name1, money, ingredients, stir1, temp1, amount1);
                price2.Visibility = Visibility.Collapsed;
                ingridens.Visibility = Visibility.Collapsed;
                isStirb.Visibility = Visibility.Collapsed;
                amount.Visibility = Visibility.Collapsed;
                temp.Visibility = Visibility.Collapsed;
                name.Visibility = Visibility.Collapsed;
                opt.Visibility = Visibility.Visible;
                opt.Content = manger.GetName(name1);
                newbever.Text = manger.quantity(name1);
                tboption.Text = manger.GetPrice(name1);
                addbe.Visibility = Visibility.Collapsed;
            }
            catch (ArgumentException)
            {
                perpare.Text = "Pleace Insert Valid Permeters";
            }
             
              


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            price2.Visibility = Visibility.Visible;
            ingridens.Visibility = Visibility.Visible;
            isStirb.Visibility = Visibility.Visible;
            amount.Visibility = Visibility.Visible;
            temp.Visibility = Visibility.Visible;
            name.Visibility = Visibility.Visible;
            addbe.Visibility = Visibility.Visible;
            clickonme.Visibility = Visibility.Collapsed;


        }

        private void CupsAdd_Click(object sender, RoutedEventArgs e)
        {
            var num = textboxcups.Text;
            textboxcups.Text= (manger.AddCups(num));
            numofcups.Text = "Cups In Stock : " + manger.GetCups();
        }
        
        
    }
}
