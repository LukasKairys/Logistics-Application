using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Logistics.Controllers;

namespace Logistics.GUI
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
            MainController mainController = LogisticsService.GetMainController();
            var clientsWithOrders = mainController.GetClientWithOrders();

            foreach (var client in clientsWithOrders)
            {
                chart1.Series["Orders"].Points.AddXY(client.Key, client.Value);
            }
        }
    }
}
