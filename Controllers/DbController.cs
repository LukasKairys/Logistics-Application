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
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void InsertSeaTypeOrder(SeaTypeOrder order)
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
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void InsertLandTypeOrder(LandTypeOrder order)
        {
            try
            {
                _connection.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO LandTypeOrder(Cargo, TotalWeight, Price, [From], [To],TransportLine, IsOpenStorage, ClientId) " +
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
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Insert(Order order)
        {
            if (order is SeaTypeOrder)
            {
                InsertSeaTypeOrder((SeaTypeOrder) order);
            }
            else if (order is LandTypeOrder)
            {
                InsertLandTypeOrder((LandTypeOrder) order);
            }
            else
            {

                try
                {
                    _connection.Open();

                    SqlCommand insert =
                        new SqlCommand("INSERT INTO [Order](Cargo, TotalWeight, Price, [From], [To], ClientId) " +
                                       "VALUES (@Cargo, @TotalWeight, @Price, @From, @To, @ClientId)", _connection);

                    insert.Parameters.AddWithValue("@Cargo", order.Cargo);
                    insert.Parameters.AddWithValue("@TotalWeight", order.TotalWeight);
                    insert.Parameters.AddWithValue("@Price", order.Price);
                    insert.Parameters.AddWithValue("@From", order.From);
                    insert.Parameters.AddWithValue("@To", order.To);
                    insert.Parameters.AddWithValue("@ClientId", order.ClientId);

                    insert.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("There was database error. Message: " + e.Message);
                }
                finally
                {
                    _connection.Close();
                }
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
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
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
                                                   "FROM Client ORDER BY ClientId", _connection);

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
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

            return clients;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                _connection.Open();

                SqlCommand selectOrders =
                    new SqlCommand("SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId" +
                                   " FROM [Order]", _connection);

                using (SqlDataReader reader = selectOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight = Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float) Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new Order(orderId, cargo, totalWeight, price, from, to, clientId));
                    }
                }

                SqlCommand selectSeaTypeOrders =
                    new SqlCommand(
                        "SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId,  ShippingLine, IsAdditionalFasteningNeeded" +
                        " FROM SeaTypeOrder", _connection);

                using (SqlDataReader reader = selectSeaTypeOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight = Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float) Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        string shippingLine = reader["ShippingLine"].ToString();
                        bool isAdditionalFasteningNeeded = (bool) reader["IsAdditionalFasteningNeeded"];
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new SeaTypeOrder(orderId, cargo, totalWeight, price, from, to,
                            clientId, shippingLine, isAdditionalFasteningNeeded));
                    }
                }

                SqlCommand selectLandTypeOrders =
                    new SqlCommand(
                        "SELECT OrderId, Cargo, TotalWeight, Price, [From], [To], ClientId,  TransportLine, IsOpenStorage" +
                        " FROM LandTypeOrder", _connection);

                using (SqlDataReader reader = selectLandTypeOrders.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        string cargo = reader["Cargo"].ToString();
                        int totalWeight = Convert.ToInt32(reader["TotalWeight"]);
                        float price = (float) Convert.ToDouble(reader["Price"]);
                        string from = reader["From"].ToString();
                        string to = reader["To"].ToString();
                        string transportLine = reader["TransportLine"].ToString();
                        bool isOpenStorage = (bool) reader["IsOpenStorage"];
                        int clientId = Convert.ToInt32(reader["ClientId"]);

                        orders.Add(new LandTypeOrder(orderId, cargo, totalWeight, price, from, to,
                            clientId, transportLine, isOpenStorage));
                    }
                }

            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }

            return orders;
        }

        public void Delete(int clientId)
        {
            try
            {
                _connection.Open();

                SqlCommand delete = new SqlCommand("DELETE FROM Client WHERE ClientId = " +
                                                   clientId, _connection);

                delete.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error, which could be caused by trying to delete client, which has some orders");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int orderId, string orderType)
        {
            try
            {
                _connection.Open();

                SqlCommand delete;

                if (orderType == "SeaType")
                {
                    delete = new SqlCommand("DELETE FROM SeaTypeOrder WHERE OrderId = " +
                                                   orderId, _connection);
                }
                else if (orderType == "LandType")
                {
                    delete = new SqlCommand("DELETE FROM LandTypeOrder WHERE OrderId = " +
                                                    orderId, _connection);
                }
                else
                {
                    delete = new SqlCommand("DELETE FROM [Order] WHERE OrderId = " +
                                                    orderId, _connection);
                }

                delete.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("There was database error. Message: " + e.Message);
            }
            finally
            {
                _connection.Close();
            }
        }



    }
}
