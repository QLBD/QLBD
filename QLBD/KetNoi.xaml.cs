using QLBD.DAO;
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

namespace QLBD
{
    /// <summary>
    /// Interaction logic for KetNoi.xaml
    /// </summary>
    public partial class KetNoi : Window
    {
        public KetNoi()
        {
            InitializeComponent();
            if (Properties.Settings.Default.DataSource != string.Empty && Properties.Settings.Default.InitialCatalog != string.Empty)
            {
                tbServerName.Text = Properties.Settings.Default.DataSource;
                tbDatabaseName.Text = Properties.Settings.Default.InitialCatalog;
                tbUserName.Text = Properties.Settings.Default.UserID;
                tbPassword.Password = Properties.Settings.Default.pwd;
            }
        }
        public static string DataSource;
        public static string InitialCatalog;
        public static string UserID;
        public static string pwd;
        public static string connectionSTR;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.IsEnabled = false;
            btnClose.IsEnabled = false;
            if (tbPassword.Password != "")
            {
                connectionSTR = "Data Source=" + tbServerName.Text
                    + ";Initial Catalog=" + tbDatabaseName.Text
                    + ";User ID=" + tbUserName.Text
                    + ";pwd=" + tbPassword.Password;
            }
            else
            {
                connectionSTR = "Data Source=" + tbServerName.Text
                    + ";Initial Catalog=" + tbDatabaseName.Text
                    + ";Integrated Security=True";
            }

            Properties.Settings.Default.DataSource = tbServerName.Text;
            Properties.Settings.Default.InitialCatalog = tbDatabaseName.Text;
            Properties.Settings.Default.UserID = tbUserName.Text;
            Properties.Settings.Default.pwd = tbPassword.Password;
            Properties.Settings.Default.connectionSTR = connectionSTR;
            Properties.Settings.Default.Save();

            bool result = DataProvider.TestConnectionSQL(connectionSTR);
            if (result)
            {
                MessageBox.Show("KẾT NỐI THÀNH CÔNG", "THÔNG BÁO");
            }
            else
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
            btnConnect.IsEnabled = true;
            btnClose.IsEnabled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
