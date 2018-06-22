using QLBD.DAO;
using System;
using System.Linq;
using System.Windows;

namespace QLBD
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {


        public Login()
        {
            InitializeComponent();

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            btn_Login.IsEnabled = false;
            string userName = tb_username.Text;
            string passWord = tb_password.ToString();
            int result = LoginAccount(userName, passWord);
            if (result == 1)
            {
                MainWindow mwindow = new MainWindow();
                this.Hide();
                mwindow.ShowDialog();
                this.Show();
            }
            else if (result == 0)
            {
                MessageBox.Show("SAI TÊN TÀI KHOẢN HOẶC MẬT KHẨU!!!!", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
            }
            btn_Login.IsEnabled = true;
        }

        private int LoginAccount(string userName, string passWord)
        {
            return AccountDAO.Login(userName, passWord);
        }
    }
}
