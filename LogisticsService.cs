using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Controllers;
using Logistics.DataTypes;

namespace Logistics
{
    internal delegate void Printer(string name);

    static class LogisticsService
    {

        private static readonly IDbController _dbController = new DbController();

        public static ClientsController GetClientsController()
        {
            return new ClientsController(_dbController);
        }

        public static OrdersController GetOrdersController()
        {
            return new OrdersController(_dbController);
        }

        public static MainController GetMainController()
        {
            return new MainController(GetClientsController(), GetOrdersController());
        }
    }

}
