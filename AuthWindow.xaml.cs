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

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static AuthWindow authWindow;

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        static Cursor Beam = new Cursor(Application.GetResourceStream(new Uri("beam.cur", UriKind.Relative)).Stream);

        string connectionString;
        SqlDataAdapter adapter;
        DataTable dataTable;

        public AuthWindow()
        {
            InitializeComponent();

            authWindow = this;

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var uriDark = new Uri(@"DarkDictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uriDark) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);


            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            TelephoneTextBox.Cursor = Beam;
            PassBox.Cursor = Beam;
            RegButton.Cursor = Link;
            AuthButton.Cursor = Link;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AuthWindow.authWindow.DragMove();
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

        private void RegWindowButtonClick(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        { 

            string telephone = TelephoneTextBox.Text.ToString();
            string password = PassBox.Password.ToString();


            string sql = $"SELECT * FROM Users WHERE Telephone = '{telephone}' and _Password = '{password}'";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            dataTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MainWindow mainWindow = new MainWindow(Convert.ToInt32(dataTable.Rows[0].ItemArray[0]), 0);
                
                //mainWindow.mainPage.UserId = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                if (Application.Current.Windows.Count < 2)
                {
                    ErrorWindow errorWindow = new ErrorWindow("Неверно введены значения");
                    errorWindow.Show();
                }
            }
            conn.Close();

        }
    }
}
