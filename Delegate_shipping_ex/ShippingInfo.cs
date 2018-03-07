using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_shipping_ex
{
    public delegate void ShippingFeesDelegate(decimal price, ref decimal fee);

    public abstract class ShippingDestination
    {
        public bool isHighRisk;

        /// <summary>
        /// Calculated the shipping fee.
        /// </summary>
        /// <param name="price">The item price</param>
        /// <param name="fee">Reference to a fee variable to hold result</param>
        public virtual void calcFees(decimal price, ref decimal fee)
        {
        }

        /// <summary>
        /// Gets the given percentage amount of the given value
        /// </summary>
        /// <returns>Percentage of given value</returns>
        protected decimal PercentageOf(decimal value, decimal percentage) => (value / 100) * percentage;

        /// <summary>
        /// Gets the given destination info
        /// </summary>
        /// <param name="destination"></param>
        /// <returns>A Shipping destination</returns>
        public static ShippingDestination getDestinationInfo(string destination)
        {
            if (destination.Equals("zone1"))
            {
                return new Destination_Zone1();
            }
            if (destination.Equals("zone2"))
            {
                return new Destination_Zone2();
            }
            if (destination.Equals("zone3"))
            {
                return new Destination_Zone3();
            }
            if (destination.Equals("zone4"))
            {
                return new Destination_Zone4();
            }
            return null;
        }
    }

    public class Destination_Zone1 : ShippingDestination
    {
        public Destination_Zone1()
        {
            this.isHighRisk = false;
        }

        public override void calcFees(decimal price, ref decimal fee) => fee = PercentageOf(price, 25);
    }

    public class Destination_Zone2 : ShippingDestination
    {
        public Destination_Zone2()
        {
            this.isHighRisk = true;
        }

        public override void calcFees(decimal price, ref decimal fee) => fee = PercentageOf(price, 12);
    }

    public class Destination_Zone3 : ShippingDestination
    {
        public Destination_Zone3()
        {
            this.isHighRisk = false;
        }

        public override void calcFees(decimal price, ref decimal fee) => fee = PercentageOf(price, 8);
    }

    public class Destination_Zone4 : ShippingDestination
    {
        public Destination_Zone4()
        {
            this.isHighRisk = true;
        }

        public override void calcFees(decimal price, ref decimal fee) => fee = PercentageOf(price, 4);
    }
}