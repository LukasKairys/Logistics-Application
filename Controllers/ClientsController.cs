using Logistics.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logistics.Controllers
{
    class ClientsController
    {
        public delegate void OnSwap<T>(List<T> list, int element1, int element2);

        private IDbController dbController;

        public ClientsController(IDbController dbController)
        {
            this.dbController = dbController;
        }

        public void Insert(string name, string level)
        {
            dbController.Insert(name, level);
        }

        public void Delete(int clientId)
        {
            dbController.Delete(clientId);
        }

        public Client GetById(int clientId)
        {
            return dbController.GetClientById(clientId);
        }

        public List<Client> GetAll(OnSwap<Client> del)
        {

            List<Client> clients = dbController.GetAllClients();

            del(clients, 0, 1);

            return clients;
        }

        public List<Client> GetAll()
        {
            List<Client> clients = dbController.GetAllClients();

            return clients;
        }

        public IEnumerable<Client> GetClients(string level)
        {
            string[] levels = {"VIP", "Standart", "InDebt"};

            Func<Client, bool> p = client => client.Level == level;
            

            Lazy<IEnumerable<Client>> data = new Lazy<IEnumerable<Client>>(delegate
                            {
                                return dbController.GetAllClients().Where(p);
                            });

            if (levels.Contains(level))
            {
                return data.Value;
            }

            return null;

        }

    }
}
