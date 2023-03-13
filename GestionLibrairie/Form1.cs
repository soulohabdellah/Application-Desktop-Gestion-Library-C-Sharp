using MySql.Data.MySqlClient;
using System.Data;

namespace GestionLibrairie
{
    public partial class Form1 : Form
    {
        string MyConnection2 = "server=localhost;User ID=root;Password=;Database=gestionlibrairie";
        DataTable dataTable = new DataTable();
        private MySqlConnection maconnexion;
        private String[] myArray = new String[8];

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Gestion a = new Gestion();

            this.Hide();
            a.Show();
            /** int i = 0;
             try
             {


                 maconnexion = new MySqlConnection(MyConnection2);
                 maconnexion.Open();
                 string request = "select * from gerant";
                 MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 da.Fill(dataTable);




                 foreach (DataRow dataRow in dataTable.Rows)
                 {

                     if (dataRow[1].ToString() == guna2TextBox1.Text && dataRow[2].ToString() == guna2TextBox2.Text )
                     {
                         i = 1;

                         Gestion a = new Gestion();

                         this.Hide();
                         a.Show();
                     }
                  
                 }
                 if (i == 0)
                 {

                     MessageBox.Show("Veuillez vérifier vos informations de login ! ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     guna2TextBox1.Text = "";
                     guna2TextBox2.Text = "";
                 }
                 maconnexion.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }}*/

        }
    }
}