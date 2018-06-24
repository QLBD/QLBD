using QLBD.DAO;
using QLBD.DTO;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBD
{
    /// <summary>
    /// Interaction logic for BanThang.xaml
    /// </summary>
    public partial class BanThang : UserControl
    {
        public BanThang()
        {
            InitializeComponent();
            LoadListGoalType();
        }

        private void LoadGoalsByMatchID(int matchID)
        {
            dgGoalByMatch.ItemsSource = GoalDAO.GetGoalsByMatchID(matchID).DefaultView;
            dgGoalByMatch.SelectedIndex = 0;
        }

        private void dgGoalByMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgGoalByMatch.SelectedIndex > 0)
            {
                DataRowView dataRow = dgGoalByMatch.SelectedItem as DataRowView;
                if (dataRow == null) return;
            }
        }
        private void LoadListGoalType()
        {
            cboGoalType.ItemsSource = GoalTypeDAO.GetAllListGoalType();
            cboGoalType.DisplayMemberPath = "GoalTypeName";
        }
        private void LoadClubByMatch(int matchID)
        {
            cboClub.ItemsSource = ClubDAO;
            cboClub.DisplayMemberPath = "ClubShortName";
        }
        private void LoadPlayerByClub(int clubID)
        {
            cboPlayer.ItemsSource = PlayerDAO.GetPlayerByClubID(clubID);
            cboPlayer.DisplayMemberPath = "Name";
        }

        private void cboClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboClub.SelectedIndex > -1)
            {
                LoadPlayerByClub(((Player)cboClub.SelectedItem).ClubID);
            }
        }
    }
}
