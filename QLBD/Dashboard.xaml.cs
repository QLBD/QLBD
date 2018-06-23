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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private Account LoginAccount;
        public Dashboard(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
            tbNameAccount.Text = account.DisplayName;
        }

        private void bt_doibong_Click(object sender, RoutedEventArgs e)
        {
            DoiBong dbong = new DoiBong();
            gr_main.Children.Clear();
            gr_main.Children.Add(dbong);
        }

        private void bt_cauthu_Click(object sender, RoutedEventArgs e)
        {
            CauThu cauthu = new CauThu();
            gr_main.Children.Clear();
            gr_main.Children.Add(cauthu);
        }

        private void bt_banthang_Click(object sender, RoutedEventArgs e)
        {
            BanThang banthang = new BanThang();
            gr_main.Children.Clear();
            gr_main.Children.Add(banthang);
        }

        private void bt_lichthidau_Click(object sender, RoutedEventArgs e)
        {
            LichThiDau lthidau = new LichThiDau();
            gr_main.Children.Clear();
            gr_main.Children.Add(lthidau);
        }

        private void bt_ghiban_Click(object sender, RoutedEventArgs e)
        {
            GhiBan ghiban = new GhiBan();
            gr_main.Children.Clear();
            gr_main.Children.Add(ghiban);
        }

        private void bt_BXH_Click(object sender, RoutedEventArgs e)
        {
            BXH bxh = new BXH();
            gr_main.Children.Clear();
            gr_main.Children.Add(bxh);
        }
    }
}

