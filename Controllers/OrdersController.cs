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
            if (order is SeaTypeOrder)
            {
                dbController.Insert((SeaTypeOrder) order);
            }
            else if (order is LandTypeOrder)
            {
                dbController.Insert((LandTypeOrder) order);
            }
            else
            {
                dbController.Insert(order);
            }
        }

        public void Delete(Order order)
        {
            dbController.Delete(order);
        }

        public List<Order> GetAll()
        {
            List<Order> order = dbController.GetAllOrders();

            return order;
        }

    }
}
