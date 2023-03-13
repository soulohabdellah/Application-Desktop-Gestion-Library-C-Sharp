using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class Parameter : Form
    {
        string MyConnection2 = "server=localhost;User ID=root;Password=;Database=gestionlibrairie";
        DataTable dataTable = new DataTable();
        private MySqlConnection maconnexion;
        private String[] myArray = new String[8];
        public Parameter()
        {
            InitializeComponent();
        }

        private void Parameter_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {
                try
                {


                    string Query = "update gerant set Email= '" + guna2TextBox1.Text + "' ,Password='" + guna2TextBox2.Text +  "'";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Bien modifier");
                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";





                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
    }
}
