using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.DataTypes
{
    class Client
    {

        private int clientId;
        private string name;
        private string level;

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public Client(int clientId, string name, string level)
        {
            ClientId = clientId;
            Name = name;
            Level = level;

        }

    }
}
