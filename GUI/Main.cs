using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logistics.Controllers;
using Logistics.DataTypes;
using Logistics.GUI;

namespace Logistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ordersToolStripMenuItem_Click(null, null);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsList.Clear();

            ItemsList.View = View.Details;
            ItemsList.LabelEdit = true;
            ItemsList.AllowColumnReorder = true;
            ItemsList.FullRowSelect = true;
            ItemsList.GridLines = true;
            ItemsList.Sorting = SortOrder.Ascending;

            ItemsList.Columns.Add("OrderId", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Cargo", 300, HorizontalAlignment.Left);
            ItemsList.Columns.Add("TotalWeight", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Price", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("From", 150, HorizontalAlignment.Left);
            ItemsList.Columns.Add("To", 150, HorizontalAlignment.Left);
            ItemsList.Columns.Add("ClientId", 70, HorizontalAlignment.Left);

            OrdersController ordersController = LogisticsService.GetOrdersController();
            List<Order> orders = ordersController.GetAll();

            for (int i = 0; i < orders.Count(); i++)
            {
                ListViewItem row = new ListViewItem(orders[i].OrderId.ToString());

                row.SubItems.Add(orders[i].Cargo);
                row.SubItems.Add(orders[i].TotalWeight.ToString());
                row.SubItems.Add(orders[i].Price.ToString());
                row.SubItems.Add(orders[i].From);
                row.SubItems.Add(orders[i].To);
                row.SubItems.Add(orders[i].ClientId.ToString());


                ItemsList.Items.Add(row);
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsList.Clear();

            ItemsList.Columns.Add("ClientId", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Name", 300, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Level", 70, HorizontalAlignment.Left);

            ClientsController clientController = LogisticsService.GetClientsController();
            List<Client> clients = clientController.GetAll();

            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem row = new ListViewItem(clients[i].ClientId.ToString());

                row.SubItems.Add(clients[i].Name.ToString());
                row.SubItems.Add(clients[i].Level.ToString());

                ItemsList.Items.Add(row);
            }
           
        }

        private void ItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewClient().Show();
        }

        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewOrder().Show();
        }
    }
}
