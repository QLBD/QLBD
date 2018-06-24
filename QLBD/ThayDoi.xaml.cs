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
    }
}
