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
            LoadComboBoxRound();
        }

        private void LoadGoalsByMatchID(int matchID)
        {
            dgGoalByMatch.ItemsSource = GoalDAO.GetGoalsByMatchID(matchID).DefaultView;
            dgGoalByMatch.SelectedIndex = 0;
        }

        private void dgGoalByMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgGoalByMatch.SelectedIndex > -1)
            {
                DataRowView dataRow = dgGoalByMatch.SelectedItem as DataRowView;
                if (dataRow == null) return;

                tbGoalID.Text = dataRow["GOALID"].ToString();
                tboGoalTime.Text = dataRow["GOALTIME"].ToString();

                int clubID = int.Parse(dataRow["CLUBID"].ToString());
                int i;
                for (i = 0; i < cboClub.Items.Count; i++)
                {
                    Club club = cboClub.Items[i] as Club;
                    if (clubID == club.ClubID)
                        break;
                }
                cboClub.SelectedIndex = i;

                int playerID = int.Parse(dataRow["PLAYERID"].ToString());
                int j;
                for (j = 0; j < cboPlayer.Items.Count; j++)
                {
                    Player player = cboPlayer.Items[j] as Player;
                    if (playerID == player.PlayerID)
                        break;
                }
                cboPlayer.SelectedIndex = j;

                int goalTypeID = int.Parse(dataRow["GOALTYPEID"].ToString());
                int k;
                for (k = 0; k < cboGoalType.Items.Count; k++)
                {
                    GoalType type = cboGoalType.Items[k] as GoalType;
                    if (goalTypeID == type.GoalTypeID)
                        break;
                }
                cboGoalType.SelectedIndex = k;
            }
        }
        private void LoadListGoalType()
        {
            cboGoalType.ItemsSource = GoalTypeDAO.GetAllListGoalType();
            cboGoalType.DisplayMemberPath = "GoalTypeName";
        }
        private void LoadClubByMatch(int matchID)
        {
            cboClub.ItemsSource = ClubDAO.GetPlayerByClubMatchID(matchID);
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
                LoadPlayerByClub(((Club)cboClub.SelectedItem).ClubID);
            }
            
        }
        private void LoadComboBoxRound()
        {
            cboRound.ItemsSource = RoundDAO.GetAllListRound();
            cboRound.DisplayMemberPath = "RoundName";
            cboRound.SelectedIndex = 0;
        }
        private void cboRound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboRound.SelectedIndex > -1)
            {
                Round round = cboRound.SelectedItem as Round;
                LoadListMatchByRound(round.RoundID);
                tbRoundname.Text = round.RoundName;
            }
        }

        private void LoadListMatchByRound(int roundID)
        {
            dgMatch.ItemsSource = MatchDAO.GetAllListMatch(roundID).DefaultView;
            dgMatch.SelectedIndex = 0;
        }

        private void dgMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMatch.SelectedIndex > -1)
            {
                DataRowView dataRow = dgMatch.SelectedItem as DataRowView;
                if (dataRow == null) return;
                Club homeclub = ClubDAO.GetClubByID((int)dataRow["HOMECLUB"]);
                tbHomeclub.Text = homeclub.ClubShortName;
                Club awayclub = ClubDAO.GetClubByID((int)dataRow["AWAYCLUB"]);
                tbAwayclub.Text = awayclub.ClubShortName;
                tboHomescore.Text = dataRow["HOMESCORE"].ToString();
                tboAwayscore.Text = dataRow["AWAYSCORE"].ToString();
                tbMatchID.Text = dataRow["MATCHID"].ToString();
                tbMatchDay.Text = ((DateTime)dataRow["MATCHDAY"]).ToShortDateString();
                tbMatchTime.Text = (dataRow["MATCHTIME"].ToString());
                tbStadium.Text = dataRow["STADIUM"].ToString();

                LoadClubByMatch((int)dataRow["MATCHID"]);
                LoadGoalsByMatchID((int)dataRow["MATCHID"]);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int goalID = int.Parse(tbGoalID.Text);
            int matchID = int.Parse(tbMatchID.Text);
            int clubID = ((Club)(cboClub.SelectedItem)).ClubID;
            int playerID = ((Player)(cboPlayer.SelectedItem)).PlayerID;
            int goalTypeID = ((GoalType)(cboGoalType.SelectedItem)).GoalTypeID;
            int goalTime = int.Parse(tboGoalTime.Text);

            InsertGoal(goalID, matchID, clubID, playerID, goalTypeID, goalTime);
            LoadGoalsByMatchID(matchID);
        }

        private void InsertGoal(int goalID, int matchID, int clubID, int playerID, int goalTypeID, int goalTime)
        {
            if (GoalDAO.AddGoal(goalID, matchID, clubID, playerID, goalTypeID, goalTime))
            {
                MessageBox.Show("THÊM BÀN THẮNG THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("THÊM BÀN THẮNG THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int goalID = int.Parse(tbGoalID.Text);
            int matchID = int.Parse(tbMatchID.Text);
            int clubID = ((Club)(cboClub.SelectedItem)).ClubID;
            int playerID = ((Player)(cboPlayer.SelectedItem)).PlayerID;
            int goalTypeID = ((GoalType)(cboGoalType.SelectedItem)).GoalTypeID;
            int goalTime = int.Parse(tboGoalTime.Text);

            UpdateGoal(goalID, matchID, clubID, playerID, goalTypeID, goalTime);
            LoadGoalsByMatchID(matchID);
        }

        private void UpdateGoal(int goalID, int matchID, int clubID, int playerID, int goalTypeID, int goalTime)
        {
            if (GoalDAO.UpdateGoal(goalID, matchID, clubID, playerID, goalTypeID, goalTime))
            {
                MessageBox.Show("CẬP NHẬT BÀN THẮNG THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("CẬP NHẬT BÀN THẮNG THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int goalID = int.Parse(tbGoalID.Text);
            int matchID = int.Parse(tbMatchID.Text);
            string playerName = ((Player)(cboPlayer.SelectedItem)).Name;
            int goalTime = int.Parse(tboGoalTime.Text);

            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN XÓA BÀN THẮNG CỦA " + playerName + " VÀO PHÚT " + goalTime + " KHÔNG???"
                , "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
            DeleteGoal(goalID);
            LoadGoalsByMatchID(matchID);
        }

        private void DeleteGoal(int goalID)
        {
            if (GoalDAO.DeleteGoal(goalID))
            {
                MessageBox.Show("XÓA BÀN THẮNG THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("XÓA BÀN THẮNG THẤT BẠI", "THÔNG BÁO");
            }
        }
    }
}
