using QLBD.DAO;
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
    /// Interaction logic for GhiBan.xaml
    /// </summary>
    public partial class GhiBan : UserControl
    {
        public GhiBan()
        {
            InitializeComponent();
            LoadDateTimePickerRevenue();
        }
        void LoadDateTimePickerRevenue()
        {
            dpFromDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dpToDate.SelectedDate = dpFromDate.SelectedDate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromDate = dpFromDate.SelectedDate.Value;
            DateTime toDate = dpToDate.SelectedDate.Value;
            ShowListGoalByPlayer(fromDate, toDate);
        }

        private void ShowListGoalByPlayer(DateTime fromDate, DateTime toDate)
        {
            string query = "DSGHIBAN @START , @END ";
            dgListGoalByPlayer.ItemsSource = DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate }).DefaultView;
        }
    }
}
