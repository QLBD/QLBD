using QLBD.DAO;
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
    /// Interaction logic for CauThu.xaml
    /// </summary>
    public partial class CauThu : UserControl
    {
        public CauThu()
        {
            InitializeComponent();
            LoadListPlayer();
        }

        private void LoadListPlayer()
        {
            dgPlayer.ItemsSource = PlayerDAO.GetAllListPlayer().DefaultView;
            dgPlayer.SelectedIndex = 0;
        }

        private void dgPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgPlayer.SelectedIndex > -1)
            {
                DataRowView dataRow = dgPlayer.SelectedItem as DataRowView;
                if (dataRow == null) return;
                tbPlayerID.Text = dataRow["PLAYERID"].ToString();
                tbClubName.Text = dataRow["CLUBID"].ToString();
                tbPlayerName.Text = dataRow["NAME"].ToString();
                tbPosision.Text = dataRow["POSITION"].ToString();
                tbNationality.Text = dataRow["NATIONALITY"].ToString();
                tbAge.Text = dataRow["AGE"].ToString();
                tbBirthDay.Text = dataRow["BIRTHDAY"].ToString();
                tbHeight.Text = dataRow["HEIGHT"].ToString();
                tbWeight.Text = dataRow["WEIGHT"].ToString();
            }
        }
    }
}
