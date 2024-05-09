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
using System.Xml.Linq;

namespace SmartMoney
{ 
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public static RegWindow regWindow;

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        static Cursor Beam = new Cursor(Application.GetResourceStream(new Uri("beam.cur", UriKind.Relative)).Stream);

        string connectionString;
        SqlDataAdapter adapter;
        DataTable UsersTable;
        public RegWindow()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            regWindow = this;

            var uriDark = new Uri(@"DarkDictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uriDark) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            NameTextBox.Cursor = Beam;
            SurnameTextBox.Cursor = Beam;
            TelephoneTextBox.Cursor = Beam;
            PassBox.Cursor = Beam;
            RegButton.Cursor = Link;
            AuthButton.Cursor = Link;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                RegWindow.regWindow.DragMove();
            }
        }

        private void Button_Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Xmark_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AuthWindowButtonClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.ToString();
            string surname = SurnameTextBox.Text.ToString();
            string telephone = TelephoneTextBox.Text.ToString();
            string password = PassBox.Password.ToString();

            if (name.Length < 2)
            {
                NameTextBox.ToolTip = "Имя введено не корректно";
                NameTextBox.BorderBrush = Brushes.Pink;
            }
            else if (surname.Length < 2)
            {
                SurnameTextBox.ToolTip = "Фамилия введена не корректно";
                SurnameTextBox.BorderBrush = Brushes.Pink;
            }
            else if (telephone.Length < 12 || !telephone.Contains("+"))
            {
                TelephoneTextBox.ToolTip = "Номер телефона введен не коректно";
                TelephoneTextBox.BorderBrush = Brushes.Pink;
            }
            else if (password.Length < 8)
            {
                PassBox.ToolTip = "Пароль слишком не надежный";
                PassBox.BorderBrush = Brushes.Pink;
            }
            else
            {
                SuccefulReg(name,surname,telephone,password);
            }

        }

        private void SuccefulReg(string name, string surname, string telephone, string password)
        {
            NameTextBox.ToolTip = "";
            NameTextBox.BorderBrush = Brushes.Pink;
            SurnameTextBox.ToolTip = "";
            SurnameTextBox.BorderBrush = Brushes.Pink;
            TelephoneTextBox.ToolTip = "";
            TelephoneTextBox.BorderBrush = Brushes.Pink;
            PassBox.ToolTip = "";
            PassBox.BorderBrush = Brushes.Transparent;

            string sql = $"INSERT INTO Users (_Name, _Surname, Telephone, _Password, Balance, StockBuy, StocksBuyCount, countReplenish, countWithdraw, _Admin) VALUES('{name}','{surname}','{telephone}','{password}',0,0,0,0,0,0)";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(UsersTable);
            conn.Close();

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            regWindow.Close();
        }

    }
}
