using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.DataTypes;

namespace Logistics.Controllers
{
    internal delegate void Printer(string name);

    class ControllersBuilder
    {

        private readonly IDbController _dbController;

        public ControllersBuilder()
        {
            _dbController = new DbController();
        }

        public ClientsController GetClientsController()
        {
            return new ClientsController(_dbController);
        }

        public OrdersController GetOrdersController()
        {
            return new OrdersController(_dbController);
        }
    }
}
