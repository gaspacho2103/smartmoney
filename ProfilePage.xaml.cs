using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);

        string connectionString;
        SqlDataAdapter adapter;
        DataTable UsersTable;

        public int userId {  get; set; }

        public ProfilePage(int UserId)
        {
            InitializeComponent();

            Cursor = Normal;
            Replenish.Cursor = Link;
            Withdraw.Cursor = Link;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            userId = UserId;

            SelectViews();



        }

        public void SelectViews()
        {
            string sql = $"SELECT * FROM Users WHERE UserId = {userId};";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(UsersTable);

            SurnameProfileBox.Text = UsersTable.Rows[0].ItemArray[2].ToString();
            NameProfileBox.Text = UsersTable.Rows[0].ItemArray[1].ToString();
            TelephoneProfileBox.Text = UsersTable.Rows[0].ItemArray[3].ToString();
            StocksBuyCount.Text = UsersTable.Rows[0].ItemArray[7].ToString();
            BalanceProfileBox.Text = UsersTable.Rows[0].ItemArray[5].ToString() + " Р";
            ReplenishProfileBox.Text = UsersTable.Rows[0].ItemArray[8].ToString() + " Р";
            WithdrawProfileBox.Text = UsersTable.Rows[0].ItemArray[9].ToString() + " Р";

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
