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
using System.Windows.Shapes;
using System.Configuration;
using System.Diagnostics;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public static BuyWindow buyWindow;
        public MainWindow mainWindow;

        string connectionString;
        SqlDataAdapter adapter;
        DataTable UsersTable;
        DataTable StocksTable;
        DataTable StockBuy;
        public int balance {  get; set; }
        public int price { get; set; }

        public int userId {  get; set; }

        public int stockId {  get; set; }

        public string name {  get; set; }

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        public BuyWindow(string Name, int Price, string Company, int StockId, int UserId)
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            buyWindow = this;
            StockName.Text = Name.ToString();
            StockPrice.Text = Price.ToString() + " Р";
            StockCompany.Text = Company;

            name = Name;

            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            ConfirmButton.Cursor = Link;

            string userSql = $"SELECT Balance FROM Users WHERE UserId = {UserId}";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = userSql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(UsersTable);

            balance = Convert.ToInt32(UsersTable.Rows[0].ItemArray[0]);
            price = Convert.ToInt32(Price);
            userId = Convert.ToInt32(UserId);
            stockId = Convert.ToInt32(StockId);


            
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                BuyWindow.buyWindow.DragMove();
            }
        }

        private void Button_Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Xmark_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (balance >= price)
            {
                int money = balance - price;

                string sqlUser = $"UPDATE Users SET Balance = {money} WHERE UserId = {userId}";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                StocksTable = new DataTable();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sqlUser;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(UsersTable);

                

                string sqlCount = $"SELECT Buyers FROM Stocks WHERE StockId = {stockId}";

                StocksTable = new DataTable();
                command = conn.CreateCommand();
                command.CommandText = sqlCount;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(StocksTable);

                int stockBuyers = Convert.ToInt32(StocksTable.Rows[0].ItemArray[0]) + 1;

                string sqlStocks = $"UPDATE Stocks SET Buyers = {stockBuyers} WHERE StockId = {stockId}";

                StocksTable = new DataTable();
                command = conn.CreateCommand();
                command.CommandText = sqlStocks;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(StocksTable);

                string sqlStockBuy = $"INSERT INTO StockBuy(UserId, StockId, StockName) VALUES({userId}, {stockId},'{name}')";

                StockBuy = new DataTable();
                command = conn.CreateCommand();
                command.CommandText = sqlStockBuy;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(StockBuy);

                conn.Close();
                conn.Open();

                string sqlUserBuyGetCount = $"SELECT StocksBuyCount FROM Users WHERE UserId = {userId}";

                UsersTable = new DataTable();
                command = conn.CreateCommand();
                command.CommandText = sqlUserBuyGetCount;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(UsersTable);

                int stocksCount = Convert.ToInt32(UsersTable.Rows[0].ItemArray[0]) + 1;

                string sqlUserBuyCount = $"UPDATE Users SET StocksBuyCount = {stocksCount} WHERE UserId = {userId}";

                UsersTable = new DataTable();
                command = conn.CreateCommand();
                command.CommandText = sqlUserBuyCount;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(UsersTable);

                conn.Close();

                mainWindow = new MainWindow(userId, stockId);

                this.Close();

            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow("Недостаточно средств");
                errorWindow.Show();
            }

        }
    }
}
