using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Logistics.DataTypes;
using System.Net;
using System.IO;

namespace Logistics.Controllers
{
    class MainController
    {
        private readonly ClientsController _clientsController;
        private readonly OrdersController _ordersController;


        public MainController(ClientsController clientsController, OrdersController ordersController)
        {
            _clientsController = clientsController;
            _ordersController = ordersController;
        }

        public Dictionary<string, int> GetClientWithOrders()
        {
            var clients = _clientsController.GetAll();
            var orders = _ordersController.GetAll();

            Dictionary<string, int> clientsWithOrders = new Dictionary<string, int>();

            foreach (var client in clients)
            {
                int clientOrdersCount = orders.Count(order => order.ClientId == client.ClientId);

                if (clientOrdersCount > 0)
                {
                    clientsWithOrders.Add(client.Name, clientOrdersCount);
                }
            }

            return clientsWithOrders;

        }

        public Dictionary<string, float> GetClientWithTotalPrice()
        {
            var clients = _clientsController.GetAll();
            var orders = _ordersController.GetAll();

            Dictionary<string, float> clientsWithOrdersPrice = new Dictionary<string, float>();

            foreach (var client in clients)
            {
                float clientOrdersAmount = orders.Where(order => order.ClientId == client.ClientId).Sum(order => order.Price);

                if (clientOrdersAmount > 0)
                {
                    clientsWithOrdersPrice.Add(client.Name, clientOrdersAmount);
                }
            }

            return clientsWithOrdersPrice;
        }

        public Dictionary<string, float> GetClientWithTotalPriceInLTL()
        {
            var clients = _clientsController.GetAll();
            var orders = _ordersController.GetAll();

            Dictionary<string, float> clientsWithOrdersPrice = GetClientWithTotalPrice();

            float rate = getCurrentRate();


            for(int index = 0; index < clientsWithOrdersPrice.Count; index++)
            {
                clientsWithOrdersPrice[clientsWithOrdersPrice.ElementAt(index).Key] *= rate;
            }

            return clientsWithOrdersPrice;
        }

        public float getCurrentRate()
        {
            string sURL;
            sURL = "http://www.google.com/finance/converter?a=1&from=EUR&to=LTL";
 
            WebRequest request = WebRequest.Create(sURL);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            string pattern = @"<div id=currency_converter_result>1 EUR = <span class=bld>(.*) LTL</span>";

            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(responseFromServer);

            float rate = float.Parse(m.Groups[1].ToString());

            reader.Close();
            response.Close();

            return rate;

        }

        public void Swap<T>(List<T> list, int element1, int element2 )
        {
            T temp = list[element1];
            list[element1] = list[element2];
            list[element1] = temp;
        }

    }
}
