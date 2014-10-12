namespace Logistics.GUI
{
    partial class NewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cargo = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            this.totalWeight = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.Label();
            this.CargoTextBox = new System.Windows.Forms.TextBox();
            this.TotalWeightTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.orderType = new System.Windows.Forms.Label();
            this.orderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.clientLabel = new System.Windows.Forms.Label();
            this.addOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cargo
            // 
            this.Cargo.AutoSize = true;
            this.Cargo.Location = new System.Drawing.Point(44, 55);
            this.Cargo.Name = "Cargo";
            this.Cargo.Size = new System.Drawing.Size(35, 13);
            this.Cargo.TabIndex = 0;
            this.Cargo.Text = "Cargo";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(44, 133);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(55, 13);
            this.Price.TabIndex = 1;
            this.Price.Text = "Price (EU)";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Location = new System.Drawing.Point(45, 172);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(30, 13);
            this.From.TabIndex = 2;
            this.From.Text = "From";
            // 
            // totalWeight
            // 
            this.totalWeight.AutoSize = true;
            this.totalWeight.Location = new System.Drawing.Point(44, 94);
            this.totalWeight.Name = "totalWeight";
            this.totalWeight.Size = new System.Drawing.Size(89, 13);
            this.totalWeight.TabIndex = 3;
            this.totalWeight.Text = "Total Weight (kg)";
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Location = new System.Drawing.Point(44, 211);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(20, 13);
            this.To.TabIndex = 4;
            this.To.Text = "To";
            // 
            // CargoTextBox
            // 
            this.CargoTextBox.Location = new System.Drawing.Point(47, 71);
            this.CargoTextBox.MaxLength = 50;
            this.CargoTextBox.Name = "CargoTextBox";
            this.CargoTextBox.Size = new System.Drawing.Size(101, 20);
            this.CargoTextBox.TabIndex = 5;
            // 
            // TotalWeightTextBox
            // 
            this.TotalWeightTextBox.Location = new System.Drawing.Point(47, 110);
            this.TotalWeightTextBox.MaxLength = 100;
            this.TotalWeightTextBox.Name = "TotalWeightTextBox";
            this.TotalWeightTextBox.Size = new System.Drawing.Size(101, 20);
            this.TotalWeightTextBox.TabIndex = 6;
            this.TotalWeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalWeightTextBox_KeyPress);
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(47, 149);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(100, 20);
            this.priceTextBox.TabIndex = 7;
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(47, 188);
            this.fromTextBox.MaxLength = 50;
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(100, 20);
            this.fromTextBox.TabIndex = 8;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(48, 227);
            this.toTextBox.MaxLength = 50;
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(100, 20);
            this.toTextBox.TabIndex = 9;
            // 
            // orderType
            // 
            this.orderType.AutoSize = true;
            this.orderType.Location = new System.Drawing.Point(29, 9);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(60, 13);
            this.orderType.TabIndex = 10;
            this.orderType.Text = "Order Type";
            // 
            // orderTypeComboBox
            // 
            this.orderTypeComboBox.DisplayMember = "Standart";
            this.orderTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderTypeComboBox.FormattingEnabled = true;
            this.orderTypeComboBox.Items.AddRange(new object[] {
            "Standart",
            "Sea Type",
            "Land Type"});
            this.orderTypeComboBox.SelectedIndex = 0;
            this.orderTypeComboBox.Location = new System.Drawing.Point(32, 26);
            this.orderTypeComboBox.Name = "orderTypeComboBox";
            this.orderTypeComboBox.Size = new System.Drawing.Size(101, 21);
            this.orderTypeComboBox.TabIndex = 11;
            this.orderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.orderTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // clientComboBox
            // 
            this.clientComboBox.DisplayMember = "Standart";
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(149, 26);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(101, 21);
            this.clientComboBox.TabIndex = 14;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(146, 9);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(33, 13);
            this.clientLabel.TabIndex = 13;
            this.clientLabel.Text = "Client";
            this.clientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addOrderButton
            // 
            this.addOrderButton.Location = new System.Drawing.Point(161, 341);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(89, 25);
            this.addOrderButton.TabIndex = 15;
            this.addOrderButton.Text = "Add order";
            this.addOrderButton.UseVisualStyleBackColor = true;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 434);
            this.Controls.Add(this.addOrderButton);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderTypeComboBox);
            this.Controls.Add(this.orderType);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.TotalWeightTextBox);
            this.Controls.Add(this.CargoTextBox);
            this.Controls.Add(this.To);
            this.Controls.Add(this.totalWeight);
            this.Controls.Add(this.From);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Cargo);
            this.Name = "NewOrder";
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.NewOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cargo;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.Label totalWeight;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.TextBox CargoTextBox;
        private System.Windows.Forms.TextBox TotalWeightTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label orderType;
        private System.Windows.Forms.ComboBox orderTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Button addOrderButton;
    }
}