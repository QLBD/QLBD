using QLBD.DAO;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QLBD
{
    /// <summary>
    /// Interaction logic for DoiBong.xaml
    /// </summary>
    public partial class DoiBong : UserControl
    {
        public DoiBong()
        {
            InitializeComponent();
            LoadListClub();
        }

        private void LoadListClub()
        {
            dgClub.ItemsSource = ClubDAO.GetAllListClub().DefaultView;
            dgClub.SelectedIndex = 0;
        }

        private void dgClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClub.SelectedIndex > -1)
            {
                DataRowView dataRow = dgClub.SelectedItem as DataRowView;
                if (dataRow == null) return;
                tbClubID.Text = dataRow["CLUBID"].ToString();
                tbShortName.Text = dataRow["CLUBSHORTNAME"].ToString();
                tbClubName.Text = dataRow["CLUBNAME"].ToString();
                tbEstablishYear.Text = dataRow["ESTABLISHEDYEAR"].ToString();
                tbHomeField.Text = dataRow["HOMEFIELD"].ToString();
                tbTotalPlayer.Text = "" + PlayerDAO.TotalPlayerClub(int.Parse(dataRow["CLUBID"].ToString()));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int clubID = int.Parse(tbClubID.Text);
            string clubName = tbClubName.Text;
            string shortName = tbShortName.Text;
            int establishedYear = int.Parse(tbEstablishYear.Text);
            string homeField = tbHomeField.Text;

            InsertClub(clubID, clubName, shortName, establishedYear, homeField);
            LoadListClub();
        }

        private void InsertClub(int clubID, string clubName, string shortName, int establishedYear, string homeField)
        {
            if (ClubDAO.AddClub(clubID, clubName, shortName, establishedYear, homeField))
            {
                MessageBox.Show("THÊM CÂU LẠC BỘ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("THÊM CÂU LẠC BỘ THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int clubID = int.Parse(tbClubID.Text);
            string clubName = tbClubName.Text;
            string shortName = tbShortName.Text;
            int establishedYear = int.Parse(tbEstablishYear.Text);
            string homeField = tbHomeField.Text;

            UpdateClub(clubID, clubName, shortName, establishedYear, homeField);
            LoadListClub();
        }

        private void UpdateClub(int clubID, string clubName, string shortName, int establishedYear, string homeField)
        {
            if (ClubDAO.UpdateClub(clubID, clubName, shortName, establishedYear, homeField))
            {
                MessageBox.Show("CẬP NHẬT CÂU LẠC BỘ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("CẬP NHẬT CÂU LẠC BỘ THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int clubID = int.Parse(tbClubID.Text);
            if (MessageBox.Show("BẠN CHẮC CHẮC CÓ MUỐN XÓA CLB " + tbClubName.Text + " KHÔNG???", "THÔNG BÁO", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                return;
            DeleteClub(clubID);
            LoadListClub();
        }

        private void DeleteClub(int clubID)
        {
            if (ClubDAO.DeleteClub(clubID))
            {
                MessageBox.Show("XÓA CÂU LẠC BỘ THÀNH CÔNG", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("XÓA CÂU LẠC BỘ THẤT BẠI", "THÔNG BÁO");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string clubName= tbClubNameSearch.Text;
            dgClub.ItemsSource = ClubDAO.SearchClubByName(clubName).DefaultView;
        }
    }

}
