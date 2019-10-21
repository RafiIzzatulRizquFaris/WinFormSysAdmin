using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormSysAdmin
{
    public partial class RoomMaster : UserControl
    {
        public RoomMaster()
        {
            InitializeComponent();
            ResetForm();
            ControlEnabled();
            ConfirmDisabled();
            InputDisabled();
            GetData();
            GetTypeRoom();
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        bool CreateWasClicked = false;
        bool UpdateWasClicked = false;
        bool DeleteWasClicked = false;


        private void GetData()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Room", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sda = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void GetTypeRoom()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM RoomType", sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            sqlConnection.Close();

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void ConfirmEnabled()
        {
            btnConfirm.BackColor = Color.LimeGreen;
            btnConfirm.Enabled = true;
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Enabled = true;
        }

        private void ConfirmDisabled()
        {
            btnConfirm.BackColor = Color.LightSkyBlue;
            btnConfirm.Enabled = false;
            btnCancel.BackColor = Color.LightSkyBlue;
            btnCancel.Enabled = false;
        }

        private void ControlEnabled()
        {
            btnCreate.BackColor = Color.MediumBlue;
            btnCreate.Enabled = true;
            btnUpdate.BackColor = Color.LimeGreen;
            btnUpdate.Enabled = true;
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Enabled = true;
        }

        private void ControlDisabled()
        {
            btnCreate.BackColor = Color.LightSkyBlue;
            btnCreate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnUpdate.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;
            btnDelete.Enabled = false;
        }

        private void InputEnabled()
        {
            tbRoomFloor.Enabled = true;
            tbRoomNum.Enabled = true;
            comboBox1.Enabled = true;
            rtbDesc.Enabled = true;
        }

        private void InputDisabled()
        {
            tbRoomFloor.Enabled = false;
            tbRoomNum.Enabled = false;
            comboBox1.Enabled = false;
            rtbDesc.Enabled = false;
        }

        private void ResetForm()
        {
            tbRoomNum.Clear();
            tbRoomFloor.Clear();
            rtbDesc.Clear();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateWasClicked = true;
            ControlDisabled();
            ConfirmEnabled();
            InputEnabled();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (CreateWasClicked)
            {
                if (tbRoomFloor.TextLength > 0 && tbRoomNum.TextLength > 0)
                {
                    if (MessageBox.Show("Do you want to insert this?", "INSERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        SqlCommand command = new SqlCommand("INSERT INTO Room VALUES (@roomtypeid, @roomnumber, @roomfloor, @description)", sqlConnection);
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@roomtypeid", comboBox1.SelectedValue.ToString());
                        command.Parameters.AddWithValue("@roomnumber", tbRoomNum.Text);
                        command.Parameters.AddWithValue("@roomfloor", tbRoomFloor.Text);
                        command.Parameters.AddWithValue("@description", rtbDesc.Text);

                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();

                        GetData();
                        MessageBox.Show("Success Input Data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You should've to input all that field", "Input not Filled at all", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                CreateWasClicked = false;
            }
            else if (UpdateWasClicked)
            {
                UpdateWasClicked = false;
            }
            else if (DeleteWasClicked)
            {
                DeleteWasClicked = false;
            }
            else
            {
                MessageBox.Show("You've been clicked the wrong button", "Wrong Button", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            ControlEnabled();
            InputDisabled();
            ConfirmDisabled();
            GetData();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            GetData();
        }
    }
}
