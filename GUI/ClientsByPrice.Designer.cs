namespace Logistics.GUI
{
    partial class ClientsByPrice
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartInEu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartInLt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInEu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInLt)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartInEu
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartInEu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartInEu.Legends.Add(legend1);
            this.ChartInEu.Location = new System.Drawing.Point(123, 29);
            this.ChartInEu.Name = "ChartInEu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "OrdersInEu";
            this.ChartInEu.Series.Add(series1);
            this.ChartInEu.Size = new System.Drawing.Size(651, 275);
            this.ChartInEu.TabIndex = 0;
            this.ChartInEu.Text = "ChartInEu";
            // 
            // ChartInLt
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartInLt.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartInLt.Legends.Add(legend2);
            this.ChartInLt.Location = new System.Drawing.Point(123, 333);
            this.ChartInLt.Name = "ChartInLt";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "OrdersInLt";
            this.ChartInLt.Series.Add(series2);
            this.ChartInLt.Size = new System.Drawing.Size(651, 275);
            this.ChartInLt.TabIndex = 1;
            this.ChartInLt.Text = "Chart in LT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current EUR To LTL rate";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Location = new System.Drawing.Point(0, 333);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(0, 13);
            this.rateLabel.TabIndex = 4;
            this.rateLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // ClientsByPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 645);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChartInLt);
            this.Controls.Add(this.ChartInEu);
            this.Name = "ClientsByPrice";
            this.Text = "ClientsByPrice";
            ((System.ComponentModel.ISupportInitialize)(this.ChartInEu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInLt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartInEu;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartInLt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rateLabel;
    }
}