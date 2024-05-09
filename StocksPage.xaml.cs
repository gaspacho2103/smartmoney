using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для StocksPage.xaml
    /// </summary>
    /// 

    public partial class StocksPage : Page
    {
        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        public BuyWindow buyWindow;
        public AdminPage adminPage;

        public int userId { get; set; }
        public int stockId {get; set;}

        public int rnd {  get; set;}

        public double value1 {  get; set; }
        public double value2 { get; set; }
        public double value3 { get; set; }
        public double value4 { get; set; }

        public double OldPrice { get; set; }
        public double Price { get; set; }


        string connectionString;
        SqlDataAdapter adapter;
        DataTable stocksTable;
        DataTable usersTable;
        public StocksPage(int UserId)
        {
            InitializeComponent();


            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Cursor = Normal;
            B1.Cursor = Link;
            B2.Cursor = Link;
            B3.Cursor = Link;
            B4.Cursor = Link;
            B5.Cursor = Link;

            userId = UserId;

            SelectViews();

            //Graph();
        }

        public void Graph()
        {
            Values = new ChartValues<double> { value1, value2, value3, value4, OldPrice, Price };

            DataContext = this;

        }

        public ChartValues<double> Values { get; set; }

        public void SelectViews()
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            StockAction1.Content = stocksTable.Rows[0].ItemArray[1].ToString();
            StockAction2.Content = stocksTable.Rows[1].ItemArray[1].ToString();
            StockAction3.Content = stocksTable.Rows[2].ItemArray[1].ToString();
            StockAction4.Content = stocksTable.Rows[3].ItemArray[1].ToString();
            StockAction5.Content = stocksTable.Rows[4].ItemArray[1].ToString();
            StockAction6.Content = stocksTable.Rows[5].ItemArray[1].ToString();
            conn.Close();
        }


        //public SeriesCollection SeriesCollection {  get; set; }

        public string[] Labels { get; set; }

        //public Func<double, string> YFormatter { get; set; }

        
        //private void StockGraphic(object sender, RoutedEventArgs e)
        //{
            //Random rand = new Random();

            //SeriesCollection = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Values = new ChartValues<ObservablePoint>
            //        {
            //            new ObservablePoint(x:0, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:07, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:14, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:21, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:28, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:35, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:42, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:49, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:56, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:63, y: rand.Next(1, 15)),
            //            new ObservablePoint(x:70, y: rand.Next(1, 15)),
            //        }
            //    }
            //};

            //YFormatter = value => value.ToString(format: "C");
            //DataContext = this;

            //Values1 = new ChartValues<double> { 3, 4, 6, 3, 2, 6 };
            //Values2 = new ChartValues<double> { 5, 3, 5, 7, 3, 9 };

            

        //public ChartValues<double> Values1 { get; set; }
        //public ChartValues<double> Values2 { get; set; }

        public void StockBuy(int StockId, string Name)
        {

            string stockSql = $"SELECT StockId, _Name, Price, Company FROM Stocks WHERE _Name = '{Name}'";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            string stockName = stocksTable.Rows[0].ItemArray[1].ToString();
            int stockPrice = Convert.ToInt32(stocksTable.Rows[0].ItemArray[2]);
            string companyName = stocksTable.Rows[0].ItemArray[3].ToString();

            StockId = Convert.ToInt32(stocksTable.Rows[0].ItemArray[0]);
            stockId = StockId;

            buyWindow = new BuyWindow(stockName, stockPrice, companyName, StockId, userId);
            buyWindow.Show();
        }


        private void B1_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction1.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction2.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction3.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction4.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction5.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            string Name = StockAction6.Content.ToString();
            int StockId = stockId;
            StockBuy(StockId, Name);
        }

        private void StockAction1_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[0].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;

            
            DataContext = null;

            Graph();
        }

        private void StockAction2_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[1].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;


            DataContext = null;

            Graph();
        }

        private void StockAction3_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[2].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;


            DataContext = null;

            Graph();
        }

        private void StockAction4_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[3].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;


            DataContext = null;

            Graph();
        }

        private void StockAction5_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[4].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;


            DataContext = null;

            Graph();
        }

        private void StockAction6_Click(object sender, RoutedEventArgs e)
        {
            string stockSql = $"SELECT * FROM Stocks ORDER BY Buyers DESC";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            stocksTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = stockSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);

            stockId = Convert.ToInt32(stocksTable.Rows[5].ItemArray[0]);
            conn.Close();

            string stockSqlGetPrice = $"SELECT OldPrice, Price FROM Stocks WHERE StockId = {stockId}";
            conn.Open();
            conn = new SqlConnection(connectionString);
            stocksTable = new DataTable();
            command = conn.CreateCommand();
            command.CommandText = stockSqlGetPrice;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(stocksTable);
            conn.Close();

            double price = Convert.ToDouble(stocksTable.Rows[0].ItemArray[1]);
            double oldPrice = Convert.ToDouble(stocksTable.Rows[0].ItemArray[0]);

            Random rand = new Random();
            value1 = rand.Next(300, 500);
            value2 = rand.Next(300, 500);
            value3 = rand.Next(300, 500);
            value4 = rand.Next(300, 500);
            OldPrice = oldPrice;
            Price = price;


            DataContext = null;

            Graph();
        }
    }
}
