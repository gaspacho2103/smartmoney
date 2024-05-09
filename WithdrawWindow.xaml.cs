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
using System.Xml.Linq;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для WithdrawWindow.xaml
    /// </summary>
    public partial class WithdrawWindow : Window
    {
        public static WithdrawWindow withdrawWindow;

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        static Cursor Beam = new Cursor(Application.GetResourceStream(new Uri("beam.cur", UriKind.Relative)).Stream);

        string connectionString;
        SqlDataAdapter adapter;
        DataTable WithdrawTable;
        DataTable UsersTable;
        MainPage mainPage;

        public int userId { get; set; }
        public WithdrawWindow(int UserId)
        {
            InitializeComponent();
            withdrawWindow = this;

            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            CardTextBox.Cursor = Beam;
            MoneyTextBox.Cursor = Beam;
            WithdrawButton.Cursor = Link;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            userId = UserId;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                WithdrawWindow.withdrawWindow.DragMove();
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

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardTextBox.Text.ToString();
            int sum = Convert.ToInt32(MoneyTextBox.Text);

            //string sqlWithdraw = $"INSERT INTO Withdraw(UserId, CardNumber, Summ, _Status) VALUES({userId}, '{cardNumber}', {sum}, 'в ожидании')";
            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            //WithdrawTable = new DataTable();
            //SqlCommand comand = conn.CreateCommand();
            //comand.CommandText = sqlWithdraw;
            //adapter = new SqlDataAdapter(comand);
            //adapter.Fill(WithdrawTable);

            string sqlBalance = $"SELECT Balance FROM Users WHERE UserId = {userId}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand comand = conn.CreateCommand();
            comand.CommandText = sqlBalance;
            adapter = new SqlDataAdapter(comand);
            adapter.Fill(UsersTable);

            int balance = Convert.ToInt32(UsersTable.Rows[0].ItemArray[0]);
            
            if (balance < sum)
            {
                ErrorWindow errorWindow = new ErrorWindow("Сумма вывода больше баланса");
                errorWindow.Show();
            }
            else
            {
                string sqlWithdraw = $"INSERT INTO Withdraw(UserId, CardNumber, Summ, _Status) VALUES({userId}, '{cardNumber}', {sum}, 'в ожидании')";
                WithdrawTable = new DataTable();
                comand.CommandText = sqlWithdraw;
                adapter = new SqlDataAdapter(comand);
                adapter.Fill(WithdrawTable);


                int newBalance = balance - sum;

                string updBalance = $"UPDATE Users SET Balance = {newBalance} WHERE UserId = {userId}";
                UsersTable = new DataTable();
                comand.CommandText = updBalance;
                adapter = new SqlDataAdapter(comand);
                adapter.Fill(UsersTable);

            }

            conn.Close();

            mainPage = new MainPage(userId, 0);
            mainPage.SelectViews();

        }
    }
}
