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
            LoadComboBoxRound(); 


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
                tbMatchid.Text = dataRow["MATCHID"].ToString();
                tbMatchday.Text = dataRow["MATCHDAY"].ToString();
                tbMatchtime.Text = (dataRow["MATCHTIME"].ToString());
                tbStadium.Text = dataRow["STADIUM"].ToString();


            }
        }
    }
}
