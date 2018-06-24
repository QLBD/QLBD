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
    /// Interaction logic for BXH.xaml
    /// </summary>
    public partial class BXH : UserControl
    {
        public BXH()
        {
            InitializeComponent();
            LoadChart();
        }

        private void LoadChart()
        {
            string query = "select rank() OVER (ORDER BY POINT, (GOALSFOR - GOALSAGAINST),CLUBNAME) as Pos, CLUBNAME as Team, MATCHPLAY as Pld, WIN as W, LOSE as L, DRAW as D, GOALSFOR as GS, GOALSAGAINST as GA, GOALDIFFERENCE as GD, POINT as P "
                + " from CHARTS ch, CLUB cl "
                + " where ch.CLUBID = cl.CLUBID "
                + " ORDER BY Pos ";
            dgCharts.ItemsSource = DataProvider.ExecuteQuery(query).DefaultView;
        }
    }
}
