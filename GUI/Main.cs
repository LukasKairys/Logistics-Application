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
            if (menuStrip1.Items.Count == 4)
            {
                menuStrip1.Items.Remove(menuStrip1.Items[3]);
            }
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
            ItemsList.Columns.Add("Transport Line", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Shipping Line", 70, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Is Open Storage", 40, HorizontalAlignment.Left);
            ItemsList.Columns.Add("Is Additional Fastening Needed", 40, HorizontalAlignment.Left);


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

                if (orders[i] is SeaTypeOrder)
                {
                    var seaTypeOrder = (SeaTypeOrder) orders[i];

                    row.Text = "SeaType-" + row.Text;
                    row.SubItems.Add("");
                    row.SubItems.Add(seaTypeOrder.ShippingLine);
                    row.SubItems.Add("");
                    row.SubItems.Add(seaTypeOrder.IsAdditionalFasteningNeeded ? "Yes" : "No");
                }

                else if (orders[i] is LandTypeOrder)
                {
                    var landTypeOrder = (LandTypeOrder) orders[i];

                    row.Text = "LandType-" + row.Text;
                    row.SubItems.Add(landTypeOrder.TransportLine);
                    row.SubItems.Add("");
                    row.SubItems.Add(landTypeOrder.IsOpenStorage ? "Yes" : "No");
                }
                else
                {
                    row.Text = "Standart-" + row.Text;
                }

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

                row.SubItems.Add(clients[i].Name);
                row.SubItems.Add(clients[i].Level);

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

        private void ItemsList_Click(object sender, EventArgs e)
        {
        }

        private void ItemsList_MouseClick(object sender, MouseEventArgs e)
        {
            MenuStrip menuStrip1 = (MenuStrip) Controls["menuStrip1"];

            if (menuStrip1.Items.Count == 4)
            {
                menuStrip1.Items.Remove(menuStrip1.Items[3]);
            }

            ToolStripMenuItem delete = new ToolStripMenuItem("Delete");
            delete.Click += deleteToolStripMenuItem_Click;

            menuStrip1.Items.Add(delete);


        }

        private void ItemsList_Leave(object sender, EventArgs e)
        {
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullId = ItemsList.SelectedItems[0].Text;
            string[] splited = fullId.Split('-');

            if (splited[0] == "Standart")
            {
                new DeleteForm(Convert.ToInt32(splited[1]),"Standart").Show();
            }
            else if (splited[0] == "SeaType")
            {
                new DeleteForm(Convert.ToInt32(splited[1]), "SeaType").Show();
            }
            else if (splited[0] == "LandType")
            {
                new DeleteForm(Convert.ToInt32(splited[1]), "LandType").Show();
            }
            else
            {
                new DeleteForm(Convert.ToInt32(splited[0]), "Client").Show();
            }
            
        }
    }
}
