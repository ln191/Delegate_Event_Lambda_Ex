using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_shipping_ex
{
    internal class Program
    {
        public delegate double shippingTax(int itemPrice);

        private static void Main(string[] args)
        {
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
                Console.WriteLine("Enter the value of the shipment:");
                string valueStr = Console.ReadLine();
                int value = int.Parse(valueStr);

                shippingTax taxZoneCal = ZoneSelection(zone);

                double fee = taxZoneCal(value);

                Console.WriteLine($"The shipping fee for {zone} is {fee}$");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets the right tax calculation function to the given zone
        /// </summary>
        /// <param name="zone"></param>
        /// <returns>Delegate tax function</returns>
        private static shippingTax ZoneSelection(string zone)
        {
            shippingTax selectedZone = null;
            switch (zone)
            {
                case "zone1":
                    selectedZone = ZoneOne;
                    break;

                case "zone2":
                    selectedZone = ZoneTwo;
                    break;

                case "zone3":
                    selectedZone = ZoneThree;
                    break;

                case "zone4":
                    selectedZone = ZoneFour;
                    break;
            }
            return selectedZone;
        }

        /// <summary>
        /// Zone 1 25% fee
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        private static double ZoneOne(int itemPrice) => PercentageOf(itemPrice, 25.00);

        /// <summary>
        /// Zone 2 12% + 25$ fee
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        private static double ZoneTwo(int itemPrice) => PercentageOf(itemPrice, 12.00) + 25;

        /// <summary>
        /// Zone 3 8%
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        private static double ZoneThree(int itemPrice) => PercentageOf(itemPrice, 8.00);

        /// <summary>
        /// Zone 4 4% + 25$
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        private static double ZoneFour(int itemPrice) => PercentageOf(itemPrice, 4.00) + 25;

        /// <summary>
        /// Gets the given percentage amount of the given value
        /// </summary>
        /// <returns>Percentage of given value</returns>
        private static double PercentageOf(int value, double percentage) => (value / 100) * percentage;
    }
}