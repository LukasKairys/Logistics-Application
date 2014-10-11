using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.DataTypes
{
    class Order
    {

        private int orderId;
        private string cargo;
        private int totalWeight;
        private float price;
        private string from;
        private string to;
        private int clientId;

        public int OrderId { get; set; }
        public string Cargo { get; set; }
        public int TotalWeight { get; set; }
        public float Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int ClientId { get; set; }

        public Order(int orderId, string cargo, int totalWeight, float price, string from, string to, int clientId)
        {
            OrderId = orderId;
            Cargo = cargo;
            TotalWeight = totalWeight;
            Price = price;
            From = from;
            To = to;
            ClientId = clientId;
        }
    }
}
