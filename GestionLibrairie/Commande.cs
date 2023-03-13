using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionLibrairie
{
    public partial class Commande : Form
    {
        int currRowIndex;
        int s = 0;
        string idactuelle;
        string idcommande;
        string iditem;
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
                string request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit order by IdCommande";
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
        public Commande()
        {
            InitializeComponent();
            fetchdata();
            guna2ComboBox1.Items.Add("En Cours");
            guna2ComboBox1.Items.Add("En Attente");
            guna2ComboBox1.Items.Add("Terminee");
            products();
            client();
            guna2DataGridView1.ColumnHeadersHeight = 24;
            guna2ComboBox4.Items.Add("Id");

            guna2ComboBox4.Items.Add("Statut Commande");
            guna2ComboBox4.Items.Add("Client");
            guna2ComboBox4.Items.Add("Produit");
        }
        private void products()
        {
            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select IdProduit from produit where CountInStock>0";
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
                      
                        guna2ComboBox2.Items.Add(item.ToString());
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
        private void client()
        {
            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select IdClient from client";
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

                        guna2ComboBox3.Items.Add(item.ToString());
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

        private void Commande_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker1.Text == "" || guna2ComboBox1.Text == "" || guna2ComboBox3.Text == "" )
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {



                try
                {
                    string Query1 = "INSERT INTO `commandeitem`( `Quantite`, `PrixItem`, `IdProduit`,`IdCommande`) VALUES ('" +0+ "','" + 0 + "','1','" + 2 + "')";

                    string Query = "INSERT INTO `commande`( `DateCommande`, `StatutCommande`, `PrixTotal`,`IdClient`) VALUES ('" + guna2DateTimePicker1.Value.ToString("yyy-MM-d ") + "','" + guna2ComboBox1.Text + "','0','"+ guna2ComboBox3.Text + "')";

                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Commande bien ajouter");

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

            guna2DateTimePicker1.Value = (DateTime)row.Cells[1].Value;
            guna2ComboBox1.Text = row.Cells[2].Value.ToString();
            guna2ComboBox3.Text = row.Cells[4].Value.ToString();
            iditem = row.Cells[5].Value.ToString();
            idcommande = row.Cells[3].Value.ToString();
            guna2ComboBox2.Text = row.Cells[6].Value.ToString();
            guna2NumericUpDown2.Text = row.Cells[7].Value.ToString();


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int dispo = 0;
            float prix=0;
            float prixtotal = 0;
            if (s == 0)
            {
                MessageBox.Show("Veuillez Selectionner Un Ligne ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if ( guna2ComboBox2.Text == "" || guna2NumericUpDown2.Text == "")
                {
                    MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                     try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select CountInStock,Prix from produit where IdProduit = " + guna2ComboBox2.Text;
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


                                i++;
                                if (i == 1)
                                {

                                    if (Int32.Parse(item.ToString()) >= Int32.Parse(guna2NumericUpDown2.Value.ToString()))
                                    {
                                        dispo = 1;
                                    }
                                }
                                else
                                {
                                    prix = float.Parse(item.ToString() , CultureInfo.InvariantCulture.NumberFormat);
                                }
                                
                    }
                 
                }
            
                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







                    if(dispo== 1) { 



                    try
                    {

                        string Query = "INSERT INTO `commandeitem`( `Quantite`, `IdProduit`, `PrixItem`,`IdCommande`) VALUES ('" + guna2NumericUpDown2.Value + "','" + guna2ComboBox2.Text + "','"+ prix* int.Parse(guna2NumericUpDown2.Value.ToString()) + "','" + idactuelle + "')";
                        string Query1 = "Update produit set CountInStock =CountInStock- " + Int32.Parse(guna2NumericUpDown2.Value.ToString()) + " where IdProduit = " + guna2ComboBox2.Text;
                            string Query2 = "select sum(PrixItem) from commandeitem where IdCommande = " + idactuelle+"";
                            DataTable dataTable = new DataTable();
                          
                            maconnexion = new MySqlConnection(MyConnection2);
                            maconnexion.Open();
                          
                            MySqlCommand cmd = new MySqlCommand(Query2, maconnexion);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dataTable);


                            int i;
                            String[] myArray = new String[8];
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                i = 0;
                                foreach (var item in dataRow.ItemArray)
                                {


                                 

                                        if (Int32.Parse(item.ToString()) >= Int32.Parse(guna2NumericUpDown2.Value.ToString()))
                                        {
                                        prixtotal = float.Parse(item.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                             
                                    }


                                }

                            }
                          
                            string Query3 = "update commande set PrixTotal="+ (prixtotal +( prix * int.Parse(guna2NumericUpDown2.Value.ToString()))) + " where IdCommande = " + idactuelle;
                            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MyConn2.Open();
                            MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn2);
                            MySqlDataReader MyReader3;

                            MyReader3 = MyCommand3.ExecuteReader();
                            MyConn2.Close();
                            MyConn2.Open();
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                            MyConn2.Close();
                            MyConn2.Open();
                            MySqlCommand MyCommand4 = new MySqlCommand(Query3, MyConn2);
                            MySqlDataReader MyReader4;

                            MyReader4 = MyCommand4.ExecuteReader();
                            MyConn2.Close();

                            MessageBox.Show("Produit bien ajouter");

                        fetchdata();
                            products();
                            client();

                        }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                    else
                    {
                        MessageBox.Show("Stock insuffisance");

                    }
                }
                
            }

            }

        private void guna2Button5_Click(object sender, EventArgs e)
        {


            int dispo = 0;
            float prix = 0;
            float prixtotal = 0;
            if (s == 0)
            {
                MessageBox.Show("Veuillez Selectionner Un Ligne ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (guna2ComboBox2.Text == "" || guna2NumericUpDown2.Text == "")
                {
                    MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        DataTable dataTable = new DataTable();

                        maconnexion = new MySqlConnection(MyConnection2);
                        maconnexion.Open();
                        string request = "select CountInStock,Prix from produit where IdProduit = " + guna2ComboBox2.Text;
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


                                i++;
                                if (i == 1)
                                {

                                    if (Int32.Parse(item.ToString()) >= Int32.Parse(guna2NumericUpDown2.Value.ToString()))
                                    {
                                        dispo = 1;
                                    }
                                }
                                else
                                {
                                    prix = float.Parse(item.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                }

                            }

                        }

                        maconnexion.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }







                    if (dispo == 1)
                    {



                        try
                        {

                            string Query = "Update `commandeitem` set `Quantite`='"+ guna2NumericUpDown2.Value + "', `IdProduit` = '"+ guna2ComboBox2.Text + "', `PrixItem` ='"+ prix * int.Parse(guna2NumericUpDown2.Value.ToString()) + "',`IdCommande`='"+ idactuelle +  "' where IdCommandeItem = " + iditem + "";
                            string Query1 = "Update produit set CountInStock =CountInStock- " + Int32.Parse(guna2NumericUpDown2.Value.ToString()) + " where IdProduit = " + guna2ComboBox2.Text;
                            string Query2 = "select sum(PrixItem) from commandeitem where IdCommande = " + idactuelle + "";
                            DataTable dataTable = new DataTable();

                            maconnexion = new MySqlConnection(MyConnection2);
                            maconnexion.Open();

                            MySqlCommand cmd = new MySqlCommand(Query2, maconnexion);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dataTable);


                            int i;
                            String[] myArray = new String[8];
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                i = 0;
                                foreach (var item in dataRow.ItemArray)
                                {




                                    if (Int32.Parse(item.ToString()) >= Int32.Parse(guna2NumericUpDown2.Value.ToString()))
                                    {
                                        prixtotal = float.Parse(item.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                                    }


                                }

                            }

                            string Query3 = "update commande set PrixTotal=" + (prixtotal + (prix * int.Parse(guna2NumericUpDown2.Value.ToString()))) + " where IdCommande = " + idactuelle;
                            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                            MyConn2.Open();
                            MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn2);
                            MySqlDataReader MyReader3;

                            MyReader3 = MyCommand3.ExecuteReader();
                            MyConn2.Close();
                            MyConn2.Open();
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                            MySqlDataReader MyReader2;

                            MyReader2 = MyCommand2.ExecuteReader();
                            MyConn2.Close();
                            MyConn2.Open();
                            MySqlCommand MyCommand4 = new MySqlCommand(Query3, MyConn2);
                            MySqlDataReader MyReader4;

                            MyReader4 = MyCommand4.ExecuteReader();
                            MyConn2.Close();

                            MessageBox.Show("Bien modifier");

                            fetchdata();
                            products();
                            client();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Stock insuffisance");

                    }
                }

            }













        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "" || guna2ComboBox4.Text == "")
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
                    if (guna2ComboBox4.Text == "Id")
                    {
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commande.IdCommande = '"+guna2TextBox5.Text+ "' order by IdCommande";

                    }
                    else if (guna2ComboBox4.Text == "Statut Commande")
                    {
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commande.StatutCommande = '" + guna2TextBox5.Text + "' order by IdCommande";


                    }
                    else if (guna2ComboBox4.Text == "Client")
                    {
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commande.IdClient = '" + guna2TextBox5.Text + "' order by IdCommande";


                    }
                    else if (guna2ComboBox4.Text == "Produit")
                    {
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commandeitem.IdProduit = '" + guna2TextBox5.Text + "' order by IdCommande";


                    }

                    else
                    {
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit order by IdCommande";


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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker1.Text == "" || guna2ComboBox1.Text == "" || guna2ComboBox3.Text == "")
            {
                MessageBox.Show("Veuillez Remplir tous les champs ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {



                try
                {
                    string Query = "Update `commande` set `DateCommande`='" + guna2DateTimePicker1.Value.ToString("yyy-MM-d ")+"', `StatutCommande` ='"+ guna2ComboBox1.Text + "',`IdClient`='"+ guna2ComboBox3.Text + "' where IdCommande = '"+idactuelle +"'" ;

                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Commande bien modifier");

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

                    string Query = "delete from commandeitem where IdCommande=" + idactuelle + "";
                    string Query1 = "delete from commande where IdCommande=" + idactuelle + "";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MyConn2.Open();
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MyConn2.Close();
                    MyConn2.Open();
                    MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn2);
                    MySqlDataReader MyReader3;

                    MyReader3 = MyCommand3.ExecuteReader();
                    MessageBox.Show("Bien supprimer");
               
                    fetchdata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               



            }
        }
    }
}
