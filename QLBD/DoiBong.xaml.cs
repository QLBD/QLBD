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
            //SqlConnection connect = new SqlConnection(@"Data Source=..\..\Database\QuanLyVDQG.sql; Initial Catalog=Pubs");
            //SqlCommand adapter = new SqlCommand("Select * from CLUB", connect);
            //SqlDataAdapter data = new SqlDataAdapter(adapter);
            //DataTable dt = new DataTable();
            //data.Fill(dt);
            //dg_doibong.ItemsSource = dt.DefaultView;
            

        }
    }

}
