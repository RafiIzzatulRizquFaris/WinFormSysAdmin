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
    public partial class SuperVisor : Form
    {
        public SuperVisor()
        {
            InitializeComponent();
            GetData();
            GetEmployee();
            GetRoomNum();
        }

        private void GetRoomNum()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Room", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            cbRoomNum.DataSource = dataTable;
            cbRoomNum.DisplayMember = "roomnumber";
            cbRoomNum.ValueMember = "id";
        }

        private void GetEmployee()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE jobid = 4", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            cbHouseKeep.DataSource = dataTable;
            cbHouseKeep.DisplayMember = "name";
            cbHouseKeep.ValueMember = "id";
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        private void GetData()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CleaningRoom LEFT JOIN CleaningRoomDetail ON CleaningRoom.id = CleaningRoomDetail.cleaningroomid", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
