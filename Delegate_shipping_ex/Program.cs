using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_shipping_ex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShippingFeesDelegate theDel;
            ShippingDestination theDest;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter the zone you wish to ship to:");
                string zone = Console.ReadLine();
                if (zone.Equals("exit"))
                {
                    exit = true;
                    return;
                }
                //Sets the Shipping destination delegate to the given zone
                theDest = ShippingDestination.getDestinationInfo(zone);

                if (theDest != null)
                {
                    Console.WriteLine("Enter the value of the shipment:");
                    string valueStr = Console.ReadLine();
                    decimal itemPrice = decimal.Parse(valueStr);
                    //Sets the shipping fees delegate to the given destinations calculation method
                    theDel = theDest.calcFees;

                    //if the destination has high risk fee, added to the destination fee
                    if (theDest.isHighRisk)
                    {
                        //Adding Anonymous delegate, to the shipping fee delegate, make it to a composable delegate
                        theDel += delegate (decimal theprice, ref decimal itemFee)
                        {
                            itemFee += 25.0m;
                        };
                    }

                    decimal theFee = 0.0m;

                    //the runs first the clacFee method from given destination then, runs the Anonymous delegate
                    theDel(itemPrice, ref theFee);
                    Console.WriteLine($"The shipping fee for {zone} is {theFee}$");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You have entered an unknown destination, try again");
                    Console.WriteLine();
                }
            }
        }
    }
}