using QLBD.DAO;
using QLBD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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

            LoadComboBoxClub();
            LoadListPlayer();
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        private void LoadComboBoxClub()
        {
            List<Club> listClub = new List<Club>();
            DataTable data = ClubDAO.GetAllListClub();
            foreach(DataRow row in data.Rows)
            {
                Club club = new Club(row);
                listClub.Add(club);
            }
            cboClubName.ItemsSource = listClub;
            cboClubName.DisplayMemberPath = "ClubName";
        }

        private void LoadListPlayer()
        {
            dgPlayer.ItemsSource = PlayerDAO.GetAllListPlayer().DefaultView;
            dgPlayer.SelectedIndex = 0;
        }

        private void dgPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPlayer.SelectedIndex > -1)
            {
                DataRowView dataRow = dgPlayer.SelectedItem as DataRowView;
                if (dataRow == null) return;
                tbPlayerID.Text = dataRow["PLAYERID"].ToString();

                int clubID = int.Parse(dataRow["CLUBID"].ToString());
                int i;
                for(i = 0; i < cboClubName.Items.Count; i++)
                {
                    Club club = cboClubName.Items[0] as Club;
                    if (clubID == club.ClubID)
                        break;
                }

                cboClubName.SelectedIndex = i;

                tbPlayerName.Text = dataRow["NAME"].ToString();
                tbPosision.Text = dataRow["POSITION"].ToString();
                tbNationality.Text = dataRow["NATIONALITY"].ToString();
                tbAge.Text = dataRow["AGE"].ToString();
                dpBirthDay.SelectedDate = (DateTime)dataRow["BIRTHDAY"];
                tbHeight.Text = dataRow["HEIGHT"].ToString();
                tbWeight.Text = dataRow["WEIGHT"].ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int playerID = int.Parse(tbPlayerID.Text);
            Club club = cboClubName.SelectedItem as Club;
            int clubID = club.ClubID;
            string playerName = tbPlayerName.Text;
            string position = tbPosision.Text;
            string nationality = tbNationality.Text;
            DateTime birthday = dpBirthDay.DisplayDate;
            int age = int.Parse(tbAge.Text);
            float height = float.Parse(tbHeight.Text);
            float weight = float.Parse(tbWeight.Text);

            InsertPlayer(playerID, clubID, playerName, position, nationality, birthday, age, height, weight);
            LoadComboBoxClub();
            LoadListPlayer();
        }

        private void InsertPlayer(int playerID, int clubID, string playerName, string position, string nationality,
                DateTime birthday, int age, float height, float weight)
        {
            if (PlayerDAO.AddPlayer(playerID, clubID, playerName, position, nationality, birthday, age, height, weight))
            {
                MessageBox.Show("THÊM CẦU THỦ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("THÊM CẦU THỦ THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int playerID = int.Parse(tbPlayerID.Text);
            Club club = cboClubName.SelectedItem as Club;
            int clubID = club.ClubID;
            string playerName = tbPlayerName.Text;
            string position = tbPosision.Text;
            string nationality = tbNationality.Text;
            DateTime birthday = dpBirthDay.DisplayDate;
            int age = int.Parse(tbAge.Text);
            float height = float.Parse(tbHeight.Text) * 1.00f;
            float weight = float.Parse(tbWeight.Text) * 1.00f;

            UpdatePlayer(playerID, clubID, playerName, position, nationality, birthday, age, height, weight);
            LoadComboBoxClub();
            LoadListPlayer();
        }

        private void UpdatePlayer(int playerID, int clubID, string playerName, string position, string nationality,
            DateTime birthday, int age, float height, float weight)
        {
            if (PlayerDAO.UpdatePlayer(playerID, clubID, playerName, position, nationality, birthday, age, height, weight))
            {
                MessageBox.Show("CẬP NHẬT CẦU THỦ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("CẬP NHẬT CẦU THỦ THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int playerID = int.Parse(tbPlayerID.Text);
            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN XÓA CẦU THỦ " + tbPlayerName.Text + " KHÔNG???", "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
            DeletePlayer(playerID);
            LoadComboBoxClub();
            LoadListPlayer();
        }

        private void DeletePlayer(int playerID)
        {
            if (PlayerDAO.DeletePlayer(playerID))
            {
                MessageBox.Show("XÓA CẦU THỦ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("XÓA CẦU THỦ THẤT BẠI", "THÔNG BÁO");
            }
        }
    }
}
