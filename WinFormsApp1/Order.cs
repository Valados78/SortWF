using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp1
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
