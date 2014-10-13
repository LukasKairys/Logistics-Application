using Logistics.Controllers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Logistics.GUI
{
    public partial class ClientsByPrice : Form
    {
        public ClientsByPrice()
        {
            InitializeComponent();

            MainController mainController = LogisticsService.GetMainController();
            var clientsWithOrdersPrice = mainController.GetClientWithTotalPrice();

            foreach (var client in clientsWithOrdersPrice)
            {
                ChartInEu.Series["OrdersInEu"].Points.AddXY(client.Key, client.Value);
            }

            var clientsWithOrdersPriceInLTL = mainController.GetClientWithTotalPriceInLTL();

            foreach (var client in clientsWithOrdersPriceInLTL)
            {
                ChartInLt.Series["OrdersInLt"].Points.AddXY(client.Key, client.Value);
            }

            Thread rateThread = new Thread(setRate);
            rateThread.Start();

            rateLabel.Text = "Checking....";


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void setRate()
        {
            MainController mainController = LogisticsService.GetMainController();

            string rateString = mainController.getCurrentRate().ToString();

            if (rateLabel.InvokeRequired)
                Invoke(new MethodInvoker(() => rateLabel.Text = rateString));
            else 
                label1.Text = rateString;
        }
    }
}
