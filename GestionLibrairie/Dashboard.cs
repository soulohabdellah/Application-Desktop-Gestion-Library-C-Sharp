using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MySql.Data.MySqlClient;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;

using Guna.Charts;
using Guna.Charts.WinForms;
using LiveCharts.Dtos;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;

namespace GestionLibrairie
{
    public partial class Dashboard : Form
    {

        public SeriesCollection SeriesCollection { get; set; }
        public DateTime InitialDateTime { get; set; }
        public Func<double, string> Formatter { get; set; }
        private ObservableCollection<double> myChangedData = new();
        int currRowIndex;
        int s = 0;
        string idactuelle;
        string MyConnection2 = "server=localhost;User ID=root;Password=;Database=gestionlibrairie";

        private MySqlConnection maconnexion;
        private void piechart1()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select count(*) as 'Nombre de commande' , commande.StatutCommande from commande group by commande.StatutCommande";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {




                    PieSeries series = new PieSeries();


                    series.Title = dataRow[1].ToString();
                    series.Values = new ChartValues<double> { int.Parse(dataRow[0].ToString()) };
                    series.DataLabels = true;
                    series.LabelPoint = labelPoint;



                    pieChart1.Series.Add(series);

                }

                pieChart1.LegendLocation = LegendLocation.Bottom;
                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void piechart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            try
            {
                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select count(*) as 'Nombre de produits' , categorie.NomCategorie from produit,categorie where categorie.IdCategorie=produit.IdCategorie group by produit.IdCategorie";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {




                    PieSeries series = new PieSeries();


                    series.Title = dataRow[1].ToString();
                    series.Values = new ChartValues<double> { int.Parse(dataRow[0].ToString()) };
                    series.DataLabels = true;
                    series.LabelPoint = labelPoint;



                    pieChart2.Series.Add(series);

                }

                pieChart2.LegendLocation = LegendLocation.Bottom;
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
                string request = "select count(*) from client";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {



                    guna2HtmlLabel6.Text= dataRow[0].ToString();

                }




                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void produit()
        {
            try
            {

                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select count(*) from produit";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {



                    guna2HtmlLabel5.Text = dataRow[0].ToString();

                }




                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void commande()
        {
            try
            {

                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select count(*) from commande";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {



                    guna2HtmlLabel7.Text = dataRow[0].ToString();

                }




                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void chiffre()
        {
            try
            {

                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select sum(PrixTotal) from commande";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                foreach (DataRow dataRow in dataTable.Rows)
                {



                    guna2HtmlLabel8.Text = dataRow[0].ToString();

                }




                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void cartisian()
        {
            try
            {
                cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Year",
                    Labels = new[] { "Jan", "Feb", "Mar" }
                });
                cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Benifice",

                });
                cartesianChart1.LegendLocation = LegendLocation.Right;



                DataTable dataTable = new DataTable();

                maconnexion = new MySqlConnection(MyConnection2);
                maconnexion.Open();
                string request = "select count(*) as 'Nombre de produits' , categorie.NomCategorie from produit,categorie where categorie.IdCategorie=produit.IdCategorie group by produit.IdCategorie";
                MySqlCommand cmd = new MySqlCommand(request, maconnexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);


                int i;
                String[] myArray = new String[8];
                cartesianChart1.Series.Clear();
                SeriesCollection series = new SeriesCollection();
        
                List<double> values = new List<double>();
                LineSeries serie = new LineSeries();
                SeriesCollection serieslist = new SeriesCollection();
                foreach (DataRow dataRow in dataTable.Rows)
                {

                   


                    serie.Title = dataRow[1].ToString();
                    serie.Values = new ChartValues<double> { int.Parse(dataRow[0].ToString()) };
                    serieslist.Add(serie);

                   


                  
                 


                }
                // series.Add((LiveCharts.Definitions.Series.ISeriesView)serieslist);
                cartesianChart1.Series = series;
               
                maconnexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
           
            cartesianChart1.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(55, 32, 49));
          
        


        }
       
    public Dashboard()
        {
            InitializeComponent();

            piechart();
            piechart1();
            cartisian();
            commande();
            client();
            chiffre();
            produit();
        }

    

        private void Dashboard_Load(object sender, EventArgs e)
        {
          


        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void pieChart2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
