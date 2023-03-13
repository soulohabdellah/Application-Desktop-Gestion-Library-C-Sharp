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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionLibrairie
{
    public partial class Client : Form
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
                string request = "select IdClient,Nom,Prenom,Email,Telephone from client";
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
        public Client()
        {
            InitializeComponent();
            fetchdata();
            guna2DataGridView1.ColumnHeadersHeight = 24;
            guna2ComboBox2.Items.Add("Id");

            guna2ComboBox2.Items.Add("Nom");
            guna2ComboBox2.Items.Add("Prenom");
            guna2ComboBox2.Items.Add("Email");
            guna2ComboBox2.Items.Add("Telephone");
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            s = 1;
            idactuelle = row.Cells[0].Value.ToString();

            guna2TextBox1.Text = row.Cells[1].Value.ToString();
            guna2TextBox2.Text = row.Cells[2].Value.ToString();
            guna2TextBox3.Text = row.Cells[3].Value.ToString();
            guna2TextBox4.Text = row.Cells[4].Value.ToString();

     
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" )
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
              


                    try
                    {


                        string Query = "insert into client(Nom,Prenom,Email,Telephone) values('" + guna2TextBox1.Text + "','" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "','" + guna2TextBox4.Text + "')";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MyConn2.Open();
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Client bien ajouter");
                    fetchdata();

                  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                

            }
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


                    string Query = "delete from client where IdClient=" + idactuelle + "";
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
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";

               

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
              

                    try
                    {

                        string Query = "update client set Nom= '" + guna2TextBox1.Text + "' ,Prenom='" + guna2TextBox2.Text + "',Email='" + guna2TextBox3.Text + "',Telephone='" + guna2TextBox4.Text + "' where IdClient= " + idactuelle + "";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MyConn2.Open();
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Bien modifier");
                    //fetchdata();
                    guna2DataGridView1.CurrentRow.SetValues(idactuelle, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2TextBox4.Text);



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";



            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "" ||guna2ComboBox2.Text == "")
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
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client where IdClient = "+guna2TextBox5.Text;

                    }
                    else if (guna2ComboBox2.Text == "Nom")
                    {
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client where Nom = '" + guna2TextBox5.Text+"'";

                    }
                    else if (guna2ComboBox2.Text == "Prenom")
                    {
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client where Prenom = '" + guna2TextBox5.Text + "'";

                    }
                    else if (guna2ComboBox2.Text == "Email")
                    {
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client where Email = '" + guna2TextBox5.Text + "'";
                    }
                    else if (guna2ComboBox2.Text == "Telephone")
                    {
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client where Telephone = '" + guna2TextBox5.Text + "'";
                    }
                    else
                    {
                        request = "select IdClient,Nom,Prenom,Email,Telephone from client ";


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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
