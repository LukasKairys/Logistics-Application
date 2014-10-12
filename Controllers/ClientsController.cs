using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.DataTypes;

namespace Logistics.Controllers
{
    class ClientsController
    {
        public delegate void OnGotResult();
        private IDbController dbController;

        public Lazy<List<Client>> Clients
        {
            get { return new Lazy<List<Client>>(() => GetAll()); }
        }

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

        public List<Client> GetAll()
        {
            return dbController.GetAllClients();
        }

        public IEnumerable<Client> GetClients(string level)
        {
            List<Client> clients = dbController.GetAllClients();

            return clients.Where(client => (client.Level == level));
        } 

    }
}
