using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSysAdmin
{
    public partial class HouseKeeper : Form
    {
        public HouseKeeper()
        {
            InitializeComponent();
            GetData();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");
        private void GetData()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CleaningRoomDetail", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            dgvFirst.DataSource = dataTable;
        }

        private void BtnReservation_Click(object sender, EventArgs e)
        {

        }
    }
}
