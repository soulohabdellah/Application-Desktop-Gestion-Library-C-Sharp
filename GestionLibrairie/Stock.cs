using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class Stock : Form
    {
        int currRowIndex;
        int s = 0;
        string idactuelle;
        string MyConnection2 = "server=localhost;User ID=root;Password=;Database=gestionlibrairie";

        private MySqlConnection maconnexion;
        public void fetchdata()
        {
            guna2DataGridView1.DataSource = null;


            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select IdProduit,NomProduit,Prix,CountInStock,IdCategorie from produit";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    i = 0;
                    foreach (var item in dataRow.ItemArray)
                    {
                        myArray[i] = item.ToString();
                        i++;
                    }
                    //  dataGridView1.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
                }
                guna2DataGridView1.DataSource = dataTable;
                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void categorie()
        {
            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select IdCategorie from categorie";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    i = 0;
                    foreach (var item in dataRow.ItemArray)
                    {

                        guna2ComboBox1.Items.Add(item.ToString());
                        i++;
                    }

                }

                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Stock()
        {
            InitializeComponent();
            fetchdata();
            guna2DataGridView1.ColumnHeadersHeight = 24;
            guna2ComboBox2.Items.Add("Id");

            guna2ComboBox2.Items.Add("Nom");
            guna2ComboBox2.Items.Add("Categorie");
            categorie();
        }

        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2NumericUpDown2.Text == "" )
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {



                try
                {
                    
                    string Query = "INSERT INTO `produit`( `NomProduit`, `Prix`, `CountInStock`,`IdCategorie`) VALUES ('"+guna2TextBox1.Text+"','"+guna2TextBox2.Text+"','"+ guna2NumericUpDown2.Text + "','" + guna2ComboBox1.Text + "')";
              
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Produit bien ajouter");

                    fetchdata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

            private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            s = 1;
            idactuelle = row.Cells[0].Value.ToString();

            guna2TextBox1.Text = row.Cells[1].Value.ToString();
            guna2TextBox2.Text = row.Cells[2].Value.ToString();
            guna2ComboBox1.Text = row.Cells[4].Value.ToString();
            guna2NumericUpDown2.Text = row.Cells[3].Value.ToString();
         
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int rowIndex = guna2DataGridView1.CurrentCell.RowIndex;
            if (s == 0)
            {
                MessageBox.Show("Veuillez Selectionner Un Ligne ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {


                    string Query = "delete from produit where IdProduit=" + idactuelle + "";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Bien supprimer");
                    guna2DataGridView1.Rows.RemoveAt(rowIndex);
                    //fetchdata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2NumericUpDown2.Text = "";
                guna2ComboBox1.Text = "";



            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (s == 0)
            {
                MessageBox.Show("Veuillez Selectionner Un Ligne ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2NumericUpDown2.Text == "")
                {
                    MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {


                    try
                    {

                        string Query = "update produit set NomProduit= '" + guna2TextBox1.Text + "' ,Prix='" + guna2TextBox2.Text + "',CountInStock='" + guna2NumericUpDown2.Text + "',IdCategorie='"+ guna2ComboBox1.Text+"' where IdProduit = " + idactuelle + "";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MyConn2.Open();
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Bien modifier");
                        fetchdata();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";
                    guna2ComboBox1.Text = "";

                    guna2NumericUpDown2.Text = "";


                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "" || guna2ComboBox2.Text == "")
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                guna2DataGridView1.DataSource = null;

                try
                {
                    DataTable dataTable = new DataTable();

                    maconnexion = new MySqlConnection(MyConnection2);
                    maconnexion.Open();
                    string request;
                    if (guna2ComboBox2.Text == "Id")
                    {
                        request = "select IdProduit,NomProduit,Prix,CountInStock from produit where IdProduit=" + guna2TextBox5.Text;

                    }
                    else if (guna2ComboBox2.Text == "Nom")
                    {
                        request = "select IdProduit,NomProduit,Prix,CountInStock from produit where NomProduit='" + guna2TextBox5.Text+"'";

                    }

                    else
                    {
                         request = "select IdProduit,NomProduit,Prix,CountInStock from produit";


                    }
                    MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dataTable);


                    int i;
                    String[] myArray = new String[8];
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        i = 0;
                        foreach (var item in dataRow.ItemArray)
                        {
                            myArray[i] = item.ToString();
                            i++;
                        }
                        //  dataGridView1.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
                    }
                    guna2DataGridView1.DataSource = dataTable;
                    maconnexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
    }

