using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Logistics.DataTypes;
using System.Configuration;

namespace Logistics.Controllers
{
    class DbController : IDbController
    {

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private readonly SqlConnection _connection;


        public DbController()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public void Insert(string name, string level)
        {
            try
            {
                _connection.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO Client(Name, [Level]) VALUES (@Name, @Level)", _connection);
                
                insert.Parameters.AddWithValue("@Name", name);
                insert.Parameters.AddWithValue("@Level", level);
                
                insert.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }

        public void Insert(Order order)
        {
            try
            {
                _connection.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO [Order](Cargo, TotalWeight, Price, [From], [To], ClientId) " +
                                                   "VALUES (@Cargo, @TotalWeight, @Price, @From, @To, @ClientId)", _connection);

                insert.Parameters.AddWithValue("@Cargo", order.Cargo);
                insert.Parameters.AddWithValue("@TotalWeight", order.TotalWeight);
                insert.Parameters.AddWithValue("@Price", order.Price);
                insert.Parameters.AddWithValue("@From", order.From);
                insert.Parameters.AddWithValue("@To", order.To);
                insert.Parameters.AddWithValue("@ClientId", order.ClientId);

                insert.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }

        public void Insert(SeaTypeOrder order)
        {
            try
            {
                _connection.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO SeaTypeOrder(Cargo, TotalWeight, Price, [From], [To], ShippingLine, IsAdditionalFasteningNeeded, ClientId) " +
                                                   "VALUES (@Cargo, @TotalWeight, @Price, @From, @To, @ShippingLine, @IsAdditionalFasteningNeeded, @ClientId)", _connection);

                insert.Parameters.AddWithValue("@Cargo", order.Cargo);
                insert.Parameters.AddWithValue("@TotalWeight", order.TotalWeight);
                insert.Parameters.AddWithValue("@Price", order.Price);
                insert.Parameters.AddWithValue("@From", order.From);
                insert.Parameters.AddWithValue("@To", order.To);
                insert.Parameters.AddWithValue("@ShippingLine", order.ShippingLine);
                insert.Parameters.AddWithValue("@IsAdditionalFasteningNeeded", order.IsAdditionalFasteningNeeded);
                insert.Parameters.AddWithValue("@ClientId", order.ClientId);

                insert.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }

        public void Insert(LandTypeOrder order)
        {
            try
            {
                _connection.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO Order(Cargo, TotalWeight, Price, [From], [To],TransportLine, IsOpenStorage, ClientId) " +
                                                   "VALUES (@Cargo, @TotalWeight, @Price, @From, @To, @TransportLine, @IsOpenStorage, @ClientId)", _connection);

                insert.Parameters.AddWithValue("@Cargo", order.Cargo);
                insert.Parameters.AddWithValue("@TotalWeight", order.TotalWeight);
                insert.Parameters.AddWithValue("@Price", order.Price);
                insert.Parameters.AddWithValue("@From", order.From);
                insert.Parameters.AddWithValue("@To", order.To);
                insert.Parameters.AddWithValue("@TransportLine", order.TransportLine);
                insert.Parameters.AddWithValue("@IsOpenStorage", order.IsOpenStorage);
                insert.Parameters.AddWithValue("@ClientId", order.ClientId);

                insert.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }

        public Client GetClientById(int clientId)
        {
            try
            {
                _connection.Open();

                SqlCommand select = new SqlCommand("SELECT ClientId, Name, [Level] " +
                                                   "FROM Client" +
                                                   "WHERE ClientId = @ClientId", _connection);

                select.Parameters.AddWithValue("@Cargo", clientId);

                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int ClientId = Convert.ToInt32(reader["ClientId"]);
                        string Level = reader["Level"].ToString();
                        string Name = reader["Name"].ToString();

                        return new Client(ClientId, Name, Level);
                    }
                }
                

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }

            return null;
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();

            try
            {
                _connection.Open();

                SqlCommand select = new SqlCommand("SELECT ClientId, Name, Level " +
                                                   "FROM Client", _connection);

                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int ClientId = Convert.ToInt32(reader["ClientId"]);
                        string Level = reader["Level"].ToString();
                        string Name = reader["Name"].ToString();

                        clients.Add(new Client(ClientId, Name, Level));
                    }
                }


                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }

            return clients;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                _connection.Open();

                SqlCommand selectOrders = new SqlCommand("SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId" +
                                                   " FROM [Order]", _connection);

                using (SqlDataReader reader = selectOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight =  Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float) Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new Order(orderId, cargo, totalWeight, price, from, to, clientId));
                    }
                }

                SqlCommand selectSeaTypeOrders = new SqlCommand("SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId,  ShippingLine, IsAdditionalFasteningNeeded" +
                                   " FROM SeaTypeOrder", _connection);

                using (SqlDataReader reader = selectSeaTypeOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight = Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float)Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        string shippingLine = reader["ShippingLine"].ToString();
                        bool isAdditionalFasteningNeeded = (bool) reader["IsAdditionalFasteningNeeded"];
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new SeaTypeOrder(orderId, cargo, totalWeight, price, from, to,
                                                    clientId, shippingLine, isAdditionalFasteningNeeded));
                    }
                }

                SqlCommand selectLandTypeOrders = new SqlCommand("SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId,  TransportLine, IsOpenStorage" +
                   " FROM LandTypeOrder", _connection);

                using (SqlDataReader reader = selectLandTypeOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight = Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float)Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        string transportLine = reader["TransportLine"].ToString();
                        bool isOpenStorage = (bool)reader["IsOpenStorage"];
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new LandTypeOrder(orderId, cargo, totalWeight, price, from, to,
                                                    clientId, transportLine, isOpenStorage));
                    }
                }  

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }

            return orders;
        }

        public void Delete(Client client)
        {
            try
            {
                _connection.Open();

                SqlCommand delete = new SqlCommand("DELETE FROM Client WHERE ClientId = " +
                                                   client.ClientId, _connection);

                delete.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }

        public void Delete(Order order)
        {
            try
            {
                _connection.Open();

                SqlCommand delete;

                if (order is SeaTypeOrder)
                {
                    delete = new SqlCommand("DELETE FROM SeaTypeOrder WHERE OrderId = " +
                                                   order.OrderId, _connection);
                }
                else if (order is LandTypeOrder)
                {
                    delete = new SqlCommand("DELETE FROM LandTypeOrder WHERE OrderId = " +
                                                    order.OrderId, _connection);
                }
                else
                {
                    delete = new SqlCommand("DELETE FROM [Order] WHERE OrderId = " +
                                                    order.OrderId, _connection);
                }

                delete.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
        }



    }
}
