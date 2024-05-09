using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        static Cursor Beam = new Cursor(Application.GetResourceStream(new Uri("beam.cur", UriKind.Relative)).Stream);

        public StocksPage stocksPage;

        string connectionString;
        SqlDataAdapter adapter;
        DataTable StocksTable;
        DataTable UsersTable;
        DataTable WithdrawTable;

        public int StockId {  get; set; }
        public int NewPrice {  get; set; }
        public int OldPrice {  get; set; }

        public AdminPage()
        {
            InitializeComponent();

            Cursor = Normal;
            UserIdSearchTextBox.Cursor = Beam;
            BalanceEditTextBox.Cursor = Beam;
            AdminEditTextBox.Cursor = Beam;
            SaveUserOptions.Cursor = Link;
            DeleteUser.Cursor = Link;
            NameEditTextBox.Cursor = Beam;
            PriceTextBox.Cursor = Beam;
            CompanyNameTextBox.Cursor = Beam;
            StockIdDeleteTextBox.Cursor = Beam;
            AddStockButton.Cursor = Link;
            DeleteStockButton.Cursor = Link;
            StockIdEditTextBox.Cursor = Beam;
            StockOldPriceEditTextBox.Cursor = Beam;
            StockNewPriceTextBox.Cursor = Beam;
            StockEditSaveButton.Cursor = Link;


            SelectViews();

        }

        public void SelectViews()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlStocks = "SELECT * FROM Stocks";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            StocksTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlStocks;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(StocksTable);
            StocksGrid.ItemsSource = StocksTable.DefaultView;

            string sqlUsers = "SELECT UserId, _Surname, Balance, Telephone, StockBuy, _Admin  FROM Users";
            UsersTable = new DataTable();
            comand.CommandText = sqlUsers;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);
            UsersGrid.ItemsSource = UsersTable.DefaultView;

            string sqlWithdraw = "SELECT * FROM Withdraw";
            WithdrawTable = new DataTable();
            comand.CommandText = sqlWithdraw;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(WithdrawTable);
            WithdrawGrid.ItemsSource = WithdrawTable.DefaultView;
            conn.Close();
        }

        private void SaveUserOptions_Click(object sender, RoutedEventArgs e)
        {

            int userId = Convert.ToInt32(UserIdSearchTextBox.Text);
            int balance = Convert.ToInt32(BalanceEditTextBox.Text);
            int admin = Convert.ToInt32(AdminEditTextBox.Text);

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlUsers = $"UPDATE Users SET Balance = {balance}, _Admin = {admin} WHERE UserId = {userId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlUsers;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);
            UsersGrid.ItemsSource = UsersTable.DefaultView;

            SelectViews();

            UserIdSearchTextBox.Text = "";
            BalanceEditTextBox.Text = "";
            AdminEditTextBox.Text = "";

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(UserIdSearchTextBox.Text);

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlUsers = $"DELETE FROM Users WHERE UserId = {userId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlUsers;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);
            UsersGrid.ItemsSource = UsersTable.DefaultView;

            SelectViews();

            UserIdSearchTextBox.Text = "";
        }

        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameEditTextBox.Text.ToString();
            int price = Convert.ToInt32(PriceTextBox.Text);
            string companyName = CompanyNameTextBox.Text.ToString();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlStock = $"INSERT INTO Stocks(_Name, Price, Company, Buyers) VALUES('{name}', {price}, '{companyName}', 0)";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            StocksTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlStock;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(StocksTable);
            StocksGrid.ItemsSource = UsersTable.DefaultView;

            SelectViews();

            NameEditTextBox.Text = "";
            PriceTextBox.Text = "";
            CompanyNameTextBox.Text = "";
        }

        private void DeleteStockButton_Click(object sender, RoutedEventArgs e)
        {
            int stockId = Convert.ToInt32(StockIdDeleteTextBox.Text);

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlStocks = $"DELETE FROM Stocks WHERE StockId = {stockId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            StocksTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlStocks;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(StocksTable);
            StocksGrid.ItemsSource = StocksTable.DefaultView;

            SelectViews();

            StockIdDeleteTextBox.Text = "";
        }

        private void StockEditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            int stockId = Convert.ToInt32(StockIdEditTextBox.Text);
            int newPrice = Convert.ToInt32(StockNewPriceTextBox.Text);
            int oldPrice = Convert.ToInt32(StockOldPriceEditTextBox.Text);

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlStocks = $"UPDATE Stocks SET Price = {newPrice}, OldPrice = {oldPrice} WHERE StockId = {stockId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            StocksTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlStocks;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(StocksTable);
            StocksGrid.ItemsSource = StocksTable.DefaultView;

            StockId = stockId;

            SelectViews();

            StockIdEditTextBox.Text = "";
            StockNewPriceTextBox.Text = "";
            StockOldPriceEditTextBox.Text = "";
        }

        private void SaveStatus_Click(object sender, RoutedEventArgs e)
        {
            int StatusId = Convert.ToInt32(WithdrawId.Text);
            string Status = WithdrawStatus.Text.ToString();

            string sqlWithdraw = $"UPDATE Withdraw SET _Status = '{Status}' WHERE WithdrawId = {StatusId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            WithdrawTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlWithdraw;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(WithdrawTable);
            WithdrawGrid.ItemsSource = WithdrawTable.DefaultView;

            SelectViews();

            WithdrawId.Text = "";
            WithdrawStatus.Text = "";
        }
    }
}
