using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionLibrairie
{
    public partial class Gestion : Form
    {
        private Form activeForm;
        public Gestion()
        {
            InitializeComponent();
           
            openChildForm(new Dashboard());
            Color myRgbColor = new Color();
            this.guna2Button8.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void Gestion_Load(object sender, EventArgs e)
        {

        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.guna2Panel1.Controls.Add(childForm);
            this.guna2Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            openChildForm(new Client());
            Color myRgbColor = new Color();
            this.guna2Button6.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);


        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Stock());
            Color myRgbColor = new Color();
            this.guna2Button7.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Commande());
            Color myRgbColor = new Color();
            this.guna2Button5.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Facture());
            Color myRgbColor = new Color();
            this.guna2Button3.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
            Color myRgbColor = new Color();
            this.guna2Button8.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Categorie());
            Color myRgbColor = new Color();
            this.guna2Button2.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button4.FillColor = Color.FromArgb(94, 148, 255);

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Parameter());
            Color myRgbColor = new Color();
            this.guna2Button4.FillColor = Color.FromArgb(40, 84, 172);
            this.guna2Button6.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button7.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button5.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button3.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button8.FillColor = Color.FromArgb(94, 148, 255);
            this.guna2Button2.FillColor = Color.FromArgb(94, 148, 255);

        }
    }
}
