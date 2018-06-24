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
    /// Interaction logic for LichThiDau.xaml
    /// </summary>
    public partial class LichThiDau : UserControl
    {
        public LichThiDau()
        {
            InitializeComponent();
            
            LoadComboBoxClub();
            LoadComboBoxRound();
        }

        private void LoadComboBoxClub()
        {
            List<Club> listClub = new List<Club>();
            DataTable data = ClubDAO.GetAllListClub();
            foreach (DataRow row in data.Rows)
            {
                Club club = new Club(row);
                listClub.Add(club);
            }

            cboHomeClub.ItemsSource = listClub;
            cboHomeClub.DisplayMemberPath = "ClubName";
            cboAwayClub.ItemsSource = listClub;
            cboAwayClub.DisplayMemberPath = "ClubName";
        }


        private void LoadComboBoxRound()
        {
            cboRoundMatch.ItemsSource = RoundDAO.GetAllListRound();
            cboRoundMatch.DisplayMemberPath = "RoundName";
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
                tbMatchID.Text = dataRow["MATCHID"].ToString();
                dpMatchDay.SelectedDate = (DateTime)dataRow["MATCHDAY"];
                tpMathcTime.SelectedTime = DateTime.Parse(dataRow["MATCHTIME"].ToString());

                int roundID = int.Parse(dataRow["ROUNDID"].ToString());

                int k;
                for (k = 0; k < cboHomeClub.Items.Count; k++)
                {
                    Round round = cboRoundMatch.Items[k] as Round;
                    if (roundID == round.RoundID)
                        break;
                }
                cboRoundMatch.SelectedIndex = k;

                int homeClubID = int.Parse(dataRow["HOMECLUB"].ToString());
                int i;
                for (i = 0; i < cboHomeClub.Items.Count; i++)
                {
                    Club club = cboHomeClub.Items[i] as Club;
                    if (homeClubID == club.ClubID)
                        break;
                }
                cboHomeClub.SelectedIndex = i;

                int awayClubID = int.Parse(dataRow["AWAYCLUB"].ToString());
                int j;
                for (j = 0; j < cboHomeClub.Items.Count; j++)
                {
                    Club club = cboHomeClub.Items[j] as Club;
                    if (awayClubID == club.ClubID)
                        break;
                }
                cboAwayClub.SelectedIndex = j;
            }
        }

        private void cboHomeClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboHomeClub.SelectedIndex > -1)
            {
                Club club = cboHomeClub.SelectedItem as Club;
                tbStadium.Text = club.HomeField;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int matchID = int.Parse(tbMatchID.Text);
            int homeClub = (cboHomeClub.SelectedItem as Club).ClubID;
            int awayClub = (cboAwayClub.SelectedItem as Club).ClubID;
            int roundID = (cboRoundMatch.SelectedItem as Round).RoundID;
            DateTime matchDay = dpMatchDay.SelectedDate.Value;
            DateTime matchTime = tpMathcTime.SelectedTime.Value;
            string stadium = tbStadium.Text;

            InsertMatch(matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium);
            LoadListMatchByRound(roundID);
        }

        private void InsertMatch(int matchID, int homeClub, int awayClub,
            int roundID, DateTime matchDay, DateTime matchTime, string stadium)
        {
            if (MatchDAO.AddMatch(matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium))
            {
                MessageBox.Show("THÊM LỊCH THI ĐẤU THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("THÊM LỊCH THI ĐẤU THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int matchID = int.Parse(tbMatchID.Text);
            int homeClub = (cboHomeClub.SelectedItem as Club).ClubID;
            int awayClub = (cboAwayClub.SelectedItem as Club).ClubID;
            int roundID = (cboRoundMatch.SelectedItem as Round).RoundID;
            DateTime matchDay = dpMatchDay.SelectedDate.Value;
            DateTime matchTime = tpMathcTime.SelectedTime.Value;
            string stadium = tbStadium.Text;

            UpdateMatch(matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium);
            LoadListMatchByRound(roundID);
        }

        private void UpdateMatch(int matchID, int homeClub, int awayClub,
            int roundID, DateTime matchDay, DateTime matchTime, string stadium)
        {
            if (MatchDAO.UpdateMatch(matchID, homeClub, awayClub, roundID, matchDay, matchTime, stadium))
            {
                MessageBox.Show("CẬP NHẬT LỊCH THI ĐẤU THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("CẬP NHẬT LỊCH THI ĐẤU THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int matchID = int.Parse(tbMatchID.Text);
            int roundID = (cboRoundMatch.SelectedItem as Round).RoundID;
            string homeClubName = (cboHomeClub.SelectedItem as Club).ClubName;
            string awayClubName = (cboAwayClub.SelectedItem as Club).ClubName;
            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN XÓA TRẬN ĐẤU " + homeClubName + " vs " + awayClubName + " KHÔNG???"
                , "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
            DeleteMatch(matchID);
            LoadListMatchByRound(roundID);
        }

        private void DeleteMatch(int matchID)
        {
            if (MatchDAO.DeleteMatch(matchID))
            {
                MessageBox.Show("XÓA LỊCH THI ĐẤU THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("XÓA LỊCH THI ĐẤU THẤT BẠI", "THÔNG BÁO");
            }
        }
    }
}
