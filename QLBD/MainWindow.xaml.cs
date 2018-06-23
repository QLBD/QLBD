using QLBD.DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account account;

        public MainWindow(Account loginAccount)
        {
            InitializeComponent();

            account = loginAccount;

            Dashboard dboard1 = new Dashboard(account);
            gr_main.Children.Add(dboard1);
        }

        private void bt_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void bt_logout_Click(object sender, RoutedEventArgs e)
        {
            Login lgin = new Login();
            lgin.Show();
            Close();
        }
        private void bt_main_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dboard2 = new Dashboard(account);
            gr_main.Children.Clear();
            gr_main.Children.Add(dboard2);
        }

        private void bt_Setting_Click(object sender, RoutedEventArgs e)
        {
            ThayDoi tdoi = new ThayDoi();
            gr_main.Children.Clear();
            gr_main.Children.Add(tdoi);
        }
    }
}