using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.DataTypes;

namespace Logistics.Controllers
{
    interface IDbController
    {

        void Insert(string name, string level);

        void Insert(Order order);

        Client GetClientById(int clientId);

        List<Client> GetAllClients();

        List<Order> GetAllOrders();

        void Delete(Client client);

        void Delete(Order order);

    }
}
