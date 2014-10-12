using Logistics.Controllers;
using System;
using System.Windows.Forms;

namespace Logistics.GUI
{
    public partial class DeleteForm : Form
    {
        private readonly int _ItemIdToDelete;
        private readonly ClientsController _clientsController;
        private readonly OrdersController _ordersController;
        private readonly string _idOf;
        

        public DeleteForm(int itemId, string idOf)
        {
            InitializeComponent();
            _ItemIdToDelete = itemId;

            _clientsController = LogisticsService.GetClientsController();
            _ordersController = LogisticsService.GetOrdersController();
            _idOf = idOf;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            if (_idOf == "Client")
            {
                _clientsController.Delete(_ItemIdToDelete);
            }
            else
            {
                if (_idOf == "SeaType")
                {
                    _ordersController.Delete(_ItemIdToDelete, "SeaType");
                }
                if (_idOf == "LandType")
                {
                    _ordersController.Delete(_ItemIdToDelete, "LandType");
                }
                if (_idOf == "Standart")
                {
                    _ordersController.Delete(_ItemIdToDelete, "Standart");
                }
            }
            Close();
        }
    }
}
