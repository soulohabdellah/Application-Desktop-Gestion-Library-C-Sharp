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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Org.BouncyCastle.Asn1.Ocsp;

namespace GestionLibrairie
{
    public partial class Facture : Form
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
        public Facture()
        {
            InitializeComponent();
            fetchdata();
       
            guna2DataGridView1.ColumnHeadersHeight = 24;
            guna2ComboBox4.Items.Add("Id");

            guna2ComboBox4.Items.Add("Statut Commande");
            guna2ComboBox4.Items.Add("Client");
            guna2ComboBox4.Items.Add("Produit");
        }

        private void Facture_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            s = 1;
            idactuelle = row.Cells[0].Value.ToString();
            iditem = row.Cells[5].Value.ToString();
            idcommande = row.Cells[3].Value.ToString();
         

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
                        request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.IdClient as 'Id client ',commandeitem.IdCommandeItem as 'Id Item',produit.IdProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commande.IdCommande = '" + guna2TextBox5.Text + "' order by IdCommande";

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (s == 0)
            {
                MessageBox.Show("Veuillez Selectionner Un Ligne ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Veuillez Remplir le nom de PDF ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {
                        string request = "select commande.IdCommande,commande.DateCommande,commande.StatutCommande,commande.PrixTotal,client.Nom as 'Nom client ',produit.NomProduit,commandeitem.Quantite from commande,client,commandeitem,produit  where commande.IdClient =client.IdClient and commande.IdCommande=commandeitem.IdCommande and commandeitem.IdProduit = produit.IdProduit and commande.IdCommande = '" + idactuelle + "' order by IdCommande";


                        DataTable dataTable = new DataTable();

                        maconnexion = new MySqlConnection(MyConnection2);
                        maconnexion.Open();
                        Document doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream("C:/Users/Souloh/Desktop/"+ guna2TextBox1.Text + ".pdf", FileMode.Create));
                        doc.Open();
                        PdfPTable table = new PdfPTable(7);
                        MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dataTable);

                        table.AddCell("Id Commande");
                        table.AddCell("Date Commande");
                        table.AddCell("Statut Commande");
                        table.AddCell("Prix Total");
                        table.AddCell("Nom Client");
                        table.AddCell("Nom Produit");

                        table.AddCell("Quantite");
                        int i;
                        String[] myArray = new String[8];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            i = 0;
                            foreach (var item in dataRow.ItemArray)
                            {
                                table.AddCell(item.ToString());
                                i++;
                            }
                            //  dataGridView1.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
                        }
                        maconnexion.Close();


                        Paragraph p2 = new Paragraph("\n");
                    
                        doc.Add(p2);
                        doc.Add(table);
                        doc.Close();
                        MessageBox.Show("Bien enregistrée dans : C:/Users/Souloh/Desktop/" + guna2TextBox1.Text + ".pdf");


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
          
        }
    }
}
