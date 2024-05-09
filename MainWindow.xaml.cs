using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using LiveCharts;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);

        public static MainWindow window;
        public MainPage mainPage;
        public ProfilePage profilePage;
        public StocksPage stocksPage;
        public AdminPage adminPage;
        public WithdrawWindow withdrawWindow;

        string connectionString;
        SqlDataAdapter adapter;
        DataTable UsersTable;
        DataTable StocksTable;

        public bool ThemeButtonChecked { get; set; } = false;
        public MainWindow(int UserId, int StockId)
        {
            mainPage = new MainPage(UserId, StockId);
            profilePage = new ProfilePage(UserId);
            stocksPage = new StocksPage(UserId);
            adminPage = new AdminPage();
            withdrawWindow = new WithdrawWindow(UserId);

            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            window = this;

            MainFrame.Content = mainPage;


            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            Main.Cursor = Link;
            Profile.Cursor = Link;
            Stocks.Cursor = Link;
            Chat.Cursor = Link;
            Exit.Cursor = Link;
            Admin.Cursor = Link;

            string sql = $"SELECT _Admin FROM Users WHERE UserId = {UserId}";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            UsersTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(UsersTable);

            int admin = Convert.ToInt32(UsersTable.Rows[0].ItemArray[0]);

            if (admin == 1)
            {
                Admin.Visibility = Visibility.Visible;
            }
            conn.Close();
            
            
            


        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.window.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MainPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
            mainPage.SelectViews();
            
        }

        private void Button_MainPage_MouseEnter(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
            Cursor = Link;
        }

        private void Button_MainPage_MouseLeave(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
            Cursor = Normal;
        }

        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = profilePage;
            profilePage.SelectViews();
            
        }

        private void Button_Stocks(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = stocksPage;
            stocksPage.SelectViews();
            
        }

        private void Button_Chat(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ChatPage();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            this.Close();
            authWindow.Show();
        }
        private void Button_Xmark_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Theme_Button_Click(object sender, RoutedEventArgs e)
        {
            var uriLight = new Uri(@"DarkDictionary.xaml", UriKind.Relative);
            var uriDark = new Uri(@"LightDictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uriDark) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            if ((ThemeButton.IsChecked == true))
            {
                resourceDict = Application.LoadComponent(uriDark) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            else if ((ThemeButton.IsChecked == false))
            {
                resourceDict = Application.LoadComponent(uriLight) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }

        }

        private void Button_Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Admin(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdminPage();
        }
    }
}
