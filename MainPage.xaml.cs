using MaterialDesignThemes.Wpf;
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
using System.Configuration;
using System.Threading;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);

        BuyWindow buyWindow;
        StocksPage stocksPage;
        string connectionString;
        SqlDataAdapter adapter;
        DataTable UsersTable;
        DataTable StocksTable;

        public int userId { get; set; }

        public int stockIdBuyed { get; set; }


        public MainPage(int UserId, int StockId)
        {
            InitializeComponent();


            //List<DataUserContext> users = new List<DataUserContext>();
            //string str = "";
            //foreach( DataUserContext userContext in users )
            //{
            //    str += "Hello " + userContext.Telephone + "!";
            //}
            //BalanceBlock.Text = str;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            Cursor = Normal;
            Replenish.Cursor = Link;
            Withdraw.Cursor = Link;

            userId = UserId;
            stockIdBuyed = StockId;

            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            //SqlCommand comand = conn.CreateCommand();
            //adapter = new SqlDataAdapter(comand);
            //string sqlUsers = $"SELECT UserId, _Name, Balance FROM Users WHERE UserId = {userId};";
            //UsersTable = new DataTable();
            //comand.CommandText = sqlUsers;
            //adapter = new SqlDataAdapter(comand);
            //adapter.Fill(UsersTable);

            //MainName.Text = UsersTable.Rows[0].ItemArray[1].ToString();
            //BalanceBlock.Text = UsersTable.Rows[0].ItemArray[2].ToString() + " Р";
            //conn.Close();


            SelectViews();
        }

        public void SelectViews()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comand = conn.CreateCommand();
            adapter = new SqlDataAdapter(comand);
            string sqlUsers = $"SELECT UserId, _Name, Balance FROM Users WHERE UserId = {userId};";
            UsersTable = new DataTable();
            comand.CommandText = sqlUsers;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);

            MainName.Text = UsersTable.Rows[0].ItemArray[1].ToString();
            BalanceBlock.Text = UsersTable.Rows[0].ItemArray[2].ToString() + " Р";

            comand = conn.CreateCommand();
            adapter = new SqlDataAdapter(comand);
            string sqlUsersBuy = $"SELECT StockId, StockName FROM StockBuy WHERE UserId = {userId}";
            UsersTable = new DataTable();
            comand.CommandText = sqlUsersBuy;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);

            if (UsersTable.Rows.Count > 0)
            {
                StockBuyed1.Content = UsersTable.Rows[0].ItemArray[1];
            }
            if (UsersTable.Rows.Count > 1)
            {
                StockBuyed2.Content = UsersTable.Rows[1].ItemArray[1];
            }
            if (UsersTable.Rows.Count > 2)
            {
                StockBuyed3.Content = UsersTable.Rows[2].ItemArray[1];
            }
            if (UsersTable.Rows.Count > 3)
            {
                StockBuyed4.Content = UsersTable.Rows[3].ItemArray[1];
            }
            if (UsersTable.Rows.Count > 4)
            {
                StockBuyed5.Content = UsersTable.Rows[4].ItemArray[1];
            }
            if (UsersTable.Rows.Count > 5)
            {
                StockBuyed6.Content = UsersTable.Rows[5].ItemArray[1];
            }

            conn.Close();


        }

        private void Replenish_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.Count < 5)
            {
                ReplenishWindow replenishWindow = new ReplenishWindow();
                replenishWindow.Show();
            }
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.Count < 5)
            {
                WithdrawWindow withdrawWindow = new WithdrawWindow(userId);
                withdrawWindow.Show();
            }
        }
    }
}
