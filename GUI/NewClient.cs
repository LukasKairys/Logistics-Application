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

namespace Logistics.GUI
{
    public partial class NewClient : Form
    {
        private readonly ClientsController _clientsController;

        public NewClient()
        {
            InitializeComponent();
            _clientsController = LogisticsService.GetClientsController();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            RemoveErrors();
            int errorCount = ValidateInfo();

            if (errorCount == 0)
            {
                string name = NameTextBox.Text;
                string level = LevelComboBox.Text;

                _clientsController.Insert(name, level);

                Close();
            }
        }

        private void RemoveErrors()
        {
            NameTextBox.BackColor = Color.White;
        }

        private int ValidateInfo()
        {
            int errorCount = 0;

            if (NameTextBox.Text.Length < 1)
            {
                errorCount++;
                NameTextBox.BackColor = Color.Red;
            }

            return errorCount;
        }
    }
}
