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

namespace Logistics.GUI
{
    public partial class NewOrder : Form
    {
        private readonly OrdersController _ordersController;

        public NewOrder()
        {
            InitializeComponent();
            ClientsController clientsController = LogisticsService.GetClientsController();
            _ordersController = LogisticsService.GetOrdersController();

            clientComboBox.DisplayMember = "Text";
            clientComboBox.ValueMember = "Value";

            var items = clientsController.GetAll().Select(x => 
                                                new {Text = x.Name, Value = x.ClientId });

            foreach (var item in items)
            {
                clientComboBox.Items.Add(item);
            }
        }

        private void orderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = orderTypeComboBox.Text;

            if (Controls.ContainsKey("fasteningLabel"))
            {
                Controls.RemoveByKey("fasteningLabel");
                Controls.RemoveByKey("fasteningComboBox");
                Controls.RemoveByKey("shippingLineLabel");
                Controls.RemoveByKey("shippingLineComboBox");
            }

            if (Controls.ContainsKey("openStorageLabel"))
            {
                Controls.RemoveByKey("openStorageLabel");
                Controls.RemoveByKey("openStorageComboBox");
                Controls.RemoveByKey("transportLineLabel");
                Controls.RemoveByKey("transportLineComboBox");

            }


            if (type == "Sea Type")
            {
                var isAdditionalFasteningNeededLabel = new Label();
                isAdditionalFasteningNeededLabel.AutoSize = true;
                isAdditionalFasteningNeededLabel.Location = new Point(46, 250);
                isAdditionalFasteningNeededLabel.Name = "fasteningLabel";
                isAdditionalFasteningNeededLabel.Text = "Is additional fastening needed";
                isAdditionalFasteningNeededLabel.TabIndex = 13;

                var fasteningComboBox = new ComboBox();
                fasteningComboBox.FormattingEnabled = true;
                fasteningComboBox.Items.AddRange(new object[] {
                "No",
                "Yes"});
                fasteningComboBox.SelectedIndex = 0;
                fasteningComboBox.Location = new Point(46, 270);
                fasteningComboBox.Name = "fasteningComboBox";
                fasteningComboBox.Size = new Size(60, 13);
                fasteningComboBox.TabIndex = 14;
                fasteningComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                var shippingLineLabel = new Label();
                shippingLineLabel.AutoSize = true;
                shippingLineLabel.Location = new Point(46, 295);
                shippingLineLabel.Name = "shippingLineLabel";
                shippingLineLabel.Text = "Shipping Line";
                shippingLineLabel.TabIndex = 15;

                var shippingLineComboBox = new ComboBox();
                shippingLineComboBox.FormattingEnabled = true;
                shippingLineComboBox.Items.AddRange(new object[] {
                "Limarko",
                "Transeda",
                "DFDS"});
                shippingLineComboBox.SelectedIndex = 0;
                shippingLineComboBox.Location = new Point(46, 310);
                shippingLineComboBox.Name = "shippingLineComboBox";
                shippingLineComboBox.Size = new Size(101, 21);
                shippingLineComboBox.TabIndex = 16;
                shippingLineComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                Controls.Add(isAdditionalFasteningNeededLabel);
                Controls.Add(fasteningComboBox);
                Controls.Add(shippingLineLabel);
                Controls.Add(shippingLineComboBox);
               
            }
            else if (type == "Land Type")
            {
                var isOpenStorageLabel = new Label();
                isOpenStorageLabel.AutoSize = true;
                isOpenStorageLabel.Location = new Point(46, 250);
                isOpenStorageLabel.Name = "openStorageLabel";
                isOpenStorageLabel.Text = "Is open storage";
                isOpenStorageLabel.TabIndex = 13;

                var openStorageComboBox = new ComboBox();

                openStorageComboBox.FormattingEnabled = true;
                openStorageComboBox.Items.AddRange(new object[] {
                "No",
                "Yes"});
                openStorageComboBox.SelectedIndex = 0;
                openStorageComboBox.Location = new Point(46, 270);
                openStorageComboBox.Name = "openStorageComboBox";
                openStorageComboBox.Size = new Size(60, 13);
                openStorageComboBox.TabIndex = 14;
                openStorageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                var transportLineLabel = new Label();
                transportLineLabel.AutoSize = true;
                transportLineLabel.Location = new Point(46, 295);
                transportLineLabel.Name = "transportLineLabel";
                transportLineLabel.Text = "Transport Line";
                transportLineLabel.TabIndex = 15;

                var transportLineComboBox = new ComboBox();
                transportLineComboBox.FormattingEnabled = true;
                transportLineComboBox.Items.AddRange(new object[] {
                "Gitana",
                "Baltkonta",
                "TransportITLines"});
                transportLineComboBox.SelectedIndex = 0;
                transportLineComboBox.Location = new Point(46, 310);
                transportLineComboBox.Name = "transportLineComboBox";
                transportLineComboBox.Size = new Size(101, 21);
                transportLineComboBox.TabIndex = 16;
                transportLineComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                Controls.Add(isOpenStorageLabel);
                Controls.Add(openStorageComboBox);
                Controls.Add(transportLineLabel);
                Controls.Add(transportLineComboBox);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewOrder_Load(object sender, EventArgs e)
        {

        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            removeAllErrors();

            if (checkInputErrors() == 0)
            {
                string orderType = orderTypeComboBox.Text;
                int clientId = Convert.ToInt32(((dynamic) clientComboBox.SelectedItem).Value);
                string cargo = CargoTextBox.Text;
                int totalWeight = Convert.ToInt32(TotalWeightTextBox.Text);
                float price = Convert.ToInt64(priceTextBox.Text);
                string from = fromTextBox.Text;
                string to = toTextBox.Text;



                if (orderType == "Sea Type")
                {
                    bool isAdditionalFasteningNeeded =
                        Controls[Controls.IndexOfKey("fasteningComboBox")].Text == "Yes";
                    string shippingLine = Controls[Controls.IndexOfKey("shippingLineComboBox")].Text;

                    SeaTypeOrder seaTypeOrder = new SeaTypeOrder(0, cargo, totalWeight, price, from, to, clientId,
                        shippingLine, isAdditionalFasteningNeeded);

                    _ordersController.Insert(seaTypeOrder);

                }
                else if (orderType == "Land Type")
                {
                    bool isOpenStorage = Controls[Controls.IndexOfKey("openStorageComboBox")].Text == "Yes";
                    string transportLine = Controls[Controls.IndexOfKey("transportLineComboBox")].Text;

                    LandTypeOrder landTypeOrder = new LandTypeOrder(0, cargo, totalWeight, price, from, to, clientId,
                        transportLine, isOpenStorage);

                    _ordersController.Insert(landTypeOrder);
                }
                else
                {
                    Order order = new Order(0, cargo, totalWeight, price, from, to, clientId);

                    _ordersController.Insert(order);
                }

                Close();

            }
        }

        private void TotalWeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private int checkInputErrors()
        {
            int errorCount = 0;

            if (clientComboBox.SelectedItem == null)
            {
                clientComboBox.BackColor = Color.Red;
                errorCount++;
            }
            if (CargoTextBox.Text.Length < 1)
            {
                CargoTextBox.BackColor = Color.Red;
                errorCount++;
            }
            if (TotalWeightTextBox.Text.Length < 1)
            {
                TotalWeightTextBox.BackColor = Color.Red;
                errorCount++;
            }
            if (priceTextBox.Text.Length < 1)
            {
                priceTextBox.BackColor = Color.Red;
                errorCount++;
            }
            if (fromTextBox.Text.Length < 1)
            {
                fromTextBox.BackColor = Color.Red;
                errorCount++;
            }
            if (toTextBox.Text.Length < 1)
            {
                toTextBox.BackColor = Color.Red;
                errorCount++;
            }

            return errorCount;
        }

        private void removeAllErrors()
        {
            orderTypeComboBox.BackColor = Color.White;
            clientComboBox.BackColor = Color.White;
            CargoTextBox.BackColor = Color.White;
            TotalWeightTextBox.BackColor = Color.White;
            priceTextBox.BackColor = Color.White;
            fromTextBox.BackColor = Color.White;
            toTextBox.BackColor = Color.White;
        }
    }
}
