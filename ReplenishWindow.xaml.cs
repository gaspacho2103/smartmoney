using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для ReplenishWindow.xaml
    /// </summary>
    public partial class ReplenishWindow : Window
    {
        public static ReplenishWindow replenishWindow;

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        static Cursor Beam = new Cursor(Application.GetResourceStream(new Uri("beam.cur", UriKind.Relative)).Stream);

        public ReplenishWindow()
        {
            InitializeComponent();
            replenishWindow = this;

            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            TelephoneTextBox.Cursor = Beam;
            MoneyTextBox.Cursor = Beam;
            ReplenishButton.Cursor = Link;

            if (Application.Current.Windows.Count > 2)
            {
                this.Hide();
            }
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ReplenishWindow.replenishWindow.DragMove();
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

        private void ReplenishButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://freekassa.ru/");
        }
    }
}
