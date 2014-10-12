using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.DataTypes;

namespace Logistics.Controllers
{
    class OrdersController
    {

        private IDbController dbController;

        public OrdersController(IDbController dbController)
        {
            this.dbController = dbController;
        }

        public void Insert(Order order)
        {
            dbController.Insert(order);
        }

        public void Delete(int orderId, string orderType)
        {
            dbController.Delete(orderId, orderType);
        }

        public List<Order> GetAll()
        {
            List<Order> order = dbController.GetAllOrders();

            return order;
        }

    }
}
