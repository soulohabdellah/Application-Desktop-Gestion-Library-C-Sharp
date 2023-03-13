namespace GestionLibrairie
{
    partial class Dashboard
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
            this.mySqlConnection1 = new MySql.Data.MySqlClient.MySqlConnection();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaAreaDataset1 = new Guna.Charts.WinForms.GunaAreaDataset();
            this.gunaPolarAreaDataset1 = new Guna.Charts.WinForms.GunaPolarAreaDataset();
            this.gunaPolarAreaDataset2 = new Guna.Charts.WinForms.GunaPolarAreaDataset();
            this.gunaPolarAreaDataset3 = new Guna.Charts.WinForms.GunaPolarAreaDataset();
            this.gunaAreaDataset2 = new Guna.Charts.WinForms.GunaAreaDataset();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.gunaAreaDataset3 = new Guna.Charts.WinForms.GunaAreaDataset();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(1, 275);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(414, 252);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            this.pieChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart1_ChildChanged);
            // 
            // pieChart2
            // 
            this.pieChart2.Location = new System.Drawing.Point(472, 12);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(414, 252);
            this.pieChart2.TabIndex = 3;
            this.pieChart2.Text = "pieChart2";
            this.pieChart2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart2_ChildChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel1.IsSelectionEnabled = false;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 163);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(99, 17);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Chiffre d\'affaire :";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel2.IsSelectionEnabled = false;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(12, 57);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(126, 17);
            this.guna2HtmlLabel2.TabIndex = 5;
            this.guna2HtmlLabel2.Text = "Nombre des produits :";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel3.IsSelectionEnabled = false;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(12, 93);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(116, 17);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "Nombre des clients :";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel4.IsSelectionEnabled = false;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(12, 129);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(147, 17);
            this.guna2HtmlLabel4.TabIndex = 7;
            this.guna2HtmlLabel4.Text = "Nombre des commandes :";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel5.IsSelectionEnabled = false;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(194, 57);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel5.TabIndex = 8;
            this.guna2HtmlLabel5.Text = null;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel6.IsSelectionEnabled = false;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(194, 93);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel6.TabIndex = 9;
            this.guna2HtmlLabel6.Text = null;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel7.IsSelectionEnabled = false;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(194, 129);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel7.TabIndex = 10;
            this.guna2HtmlLabel7.Text = null;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel8.IsSelectionEnabled = false;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(194, 163);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel8.TabIndex = 11;
            this.guna2HtmlLabel8.Text = null;
            // 
            // gunaAreaDataset1
            // 
            this.gunaAreaDataset1.BorderColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset1.FillColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset1.Label = "Area1";
            // 
            // gunaPolarAreaDataset1
            // 
            this.gunaPolarAreaDataset1.Label = "PolarArea1";
            // 
            // gunaPolarAreaDataset2
            // 
            this.gunaPolarAreaDataset2.Label = "PolarArea2";
            // 
            // gunaPolarAreaDataset3
            // 
            this.gunaPolarAreaDataset3.Label = "PolarArea3";
            // 
            // gunaAreaDataset2
            // 
            this.gunaAreaDataset2.BorderColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset2.FillColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset2.Label = "Area2";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(472, 275);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(414, 252);
            this.cartesianChart1.TabIndex = 13;
            this.cartesianChart1.Text = "cartesianChart2";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // gunaAreaDataset3
            // 
            this.gunaAreaDataset3.BorderColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset3.FillColor = System.Drawing.Color.Empty;
            this.gunaAreaDataset3.Label = "Area3";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 532);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.pieChart2);
            this.Controls.Add(this.pieChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection1;
        private LiveCharts.WinForms.PieChart pieChart1;
        private LiveCharts.WinForms.PieChart pieChart2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.Charts.WinForms.GunaAreaDataset gunaAreaDataset1;
        private Guna.Charts.WinForms.GunaPolarAreaDataset gunaPolarAreaDataset1;
        private Guna.Charts.WinForms.GunaPolarAreaDataset gunaPolarAreaDataset2;
        private Guna.Charts.WinForms.GunaPolarAreaDataset gunaPolarAreaDataset3;
        private Guna.Charts.WinForms.GunaAreaDataset gunaAreaDataset2;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Guna.Charts.WinForms.GunaAreaDataset gunaAreaDataset3;
    }
}