using QLBD.DAO;
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
    /// Interaction logic for ThayDoi.xaml
    /// </summary>
    public partial class ThayDoi : UserControl
    {
        public ThayDoi()
        {
            InitializeComponent();
            LoadParameterSetting();
            LoadListGoalType();
        }

        private void LoadListGoalType()
        {
            lvGoalType.ItemsSource = GoalTypeDAO.GetAllListGoalType();
            lvGoalType.DisplayMemberPath = "GoalTypeName";
        }

        private void LoadParameterSetting()
        {
            Setting setting = SettingDAO.GetParameterSetting();
            tbMinAge.Text = setting.MinAge + "";
            tbMaxAge.Text = setting.MaxAge + "";
            tbMinPlayer.Text = setting.MinPlayer + "";
            tbMaxPlayer.Text = setting.MaxPlayer + "";
            tbMaxForeignPlayer.Text = setting.MaxForeignPlayer + "";
            tbMaxGoalTime.Text = setting.MaxGoalTime + "";
            tbWinScore.Text = setting.WinScore + "";
            tbDrawScore.Text = setting.DrawScore + "";
            tbLoseScore.Text = setting.LoseScore + "";
        }

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN THAY ĐỔI THAM SỐ VỀ MẶC ĐỊNH KHÔNG???", "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;

            UpdateParameter(16, 40, 15, 22, 3, 3, 90, 0, 1);
            LoadParameterSetting();
            LoadListGoalType();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN THAY ĐỔI THAM SỐ KHÔNG???", "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
            int MinAge = int.Parse(tbMinAge.Text);
            int MaxAge = int.Parse(tbMaxAge.Text);
            int MinPlayer = int.Parse(tbMinPlayer.Text);
            int MaxPlayer = int.Parse(tbMaxPlayer.Text);
            int MaxForeignPlayer = int.Parse(tbMaxForeignPlayer.Text);
            int MaxGoalTime = int.Parse(tbMaxGoalTime.Text);
            int WinScore = int.Parse(tbWinScore.Text);
            int LoseScore = int.Parse(tbDrawScore.Text);
            int DrawScore = int.Parse(tbLoseScore.Text);

            UpdateParameter(MinAge, MaxAge, MinPlayer, MaxPlayer, MaxForeignPlayer, MaxGoalTime, WinScore, LoseScore, DrawScore);
            LoadParameterSetting();
            LoadListGoalType();
        }

        private void UpdateParameter(int MinAge, int MaxAge, int MinPlayer, int MaxPlayer, int MaxForeignPlayer, int MaxGoalTime, int WinScore, int LoseScore, int DrawScore)
        {
            if (SettingDAO.UpdateParameterSetting(MinAge, MaxAge, MinPlayer, MaxPlayer, MaxForeignPlayer, MaxGoalTime, WinScore, LoseScore, DrawScore))
            {
                MessageBox.Show("CẬP NHẬT THAM SỐ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("CẬP NHẬT THAM SỐ THẤT BẠI", "THÔNG BÁO");
            }
        }
    }
}
