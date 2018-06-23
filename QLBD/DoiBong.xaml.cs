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
using System.Data.SqlClient;
using System.Data;
using QLBD.DAO;
using QLBD.DTO;

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
            if(dgClub.SelectedIndex > -1)
            {
                DataRowView dataRow = dgClub.SelectedItem as DataRowView;
                if (dataRow == null) return;
                tbClubID.Text = dataRow[0].ToString();
                tbShortName.Text = dataRow[1].ToString();
                tbClubName.Text = dataRow[2].ToString();
                tbEstablishYear.Text = dataRow[3].ToString();
                tbHomeField.Text = dataRow[4].ToString();
            }
        }
    }

}
