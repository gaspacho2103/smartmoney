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

namespace SmartMoney
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public static ErrorWindow errorWindow;

        static Cursor Normal = new Cursor(Application.GetResourceStream(new Uri("Normal Select.cur", UriKind.Relative)).Stream);
        static Cursor Link = new Cursor(Application.GetResourceStream(new Uri("link.cur", UriKind.Relative)).Stream);
        public ErrorWindow(string message)
        {
            InitializeComponent();
            errorWindow = this;

            ErrorText.Text = message;

            Cursor = Normal;
            xMarkButton.Cursor = Link;
            collapseMarkButton.Cursor = Link;
            OkButton.Cursor = Link;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ErrorWindow.errorWindow.DragMove();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Xmark_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Collapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
