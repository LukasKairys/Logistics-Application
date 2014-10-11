using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.DataTypes
{
    class SeaTypeOrder : Order
    {

        private string shippingLine;
        private bool isAdditionalFasteningNeeded;

        public string ShippingLine { get; set; }
        public bool IsAdditionalFasteningNeeded { get; set; }

        public SeaTypeOrder(int orderId, string cargo, int totalWeight, float price, string from,
                                string to, int clientId, string shippingLine, bool isAdditionalFasteningNeeded) :
            base(orderId, cargo, totalWeight, price, from, to, clientId)
        {
            ShippingLine = shippingLine;
            IsAdditionalFasteningNeeded = isAdditionalFasteningNeeded;
        }

    }
}
