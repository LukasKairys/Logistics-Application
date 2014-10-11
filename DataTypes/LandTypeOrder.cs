using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.DataTypes
{
    class LandTypeOrder : Order
    {

        private string transportLine;
        private bool isOpenStorage;

        public string TransportLine { get; set; }
        public bool IsOpenStorage { get; set; }

        public LandTypeOrder(int orderId, string cargo, int totalWeight, float price, string from,
                                string to, int clientId, string transportLine, bool isOpenStorage) :
            base(orderId, cargo, totalWeight, price, from, to, clientId)
        {
            TransportLine = transportLine;
            IsOpenStorage = isOpenStorage;
        }

    }
}
