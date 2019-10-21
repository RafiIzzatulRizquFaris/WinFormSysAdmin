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
    public partial class MasterRoomType : UserControl
    {
        public MasterRoomType()
        {
            InitializeComponent();
            GetData();
            ControlEnabled();
            ConfirmDisabled();
            InputDisabled();
        }

        private void InputDisabled()
        {
            tbName.Enabled = false;
            tbPrice.Enabled = false;
            numCapacity.Enabled = false;
        }

        private void InputEnabled()
        {
            tbName.Enabled = true;
            tbPrice.Enabled = true;
            numCapacity.Enabled = true;
        }

        private void ConfirmDisabled()
        {
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = Color.LightSkyBlue;
            btnCancel.Enabled = false;
            btnCancel.BackColor = Color.LightSkyBlue;
        }


        private void ConfirmEnabled()
        {
            btnConfirm.Enabled = true;
            btnConfirm.BackColor = Color.LimeGreen;
            btnCancel.Enabled = true;
            btnCancel.BackColor = Color.Crimson;
        }

        private void ControlEnabled()
        {
            btnCreate.Enabled = true;
            btnCreate.BackColor = Color.MediumBlue;
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.LimeGreen;
            btnDelete.Enabled = true;
            btnDelete.BackColor = Color.Crimson;
        }

        private void ResetForm()
        {
            tbName.Clear();
            tbPrice.Clear();
            numCapacity.Value = 0;
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        int id;

        private void GetData()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM RoomType", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }

        bool CreateClicked = false;
        bool UpdateClicked = false;
        bool DeleteClicked = false;

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateClicked = true;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;

            ConfirmEnabled();
            InputEnabled();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateClicked = true;
            btnCreate.Enabled = false;
            btnCreate.BackColor = Color.LightSkyBlue;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;

            ConfirmEnabled();
            InputEnabled();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked = true;
            btnCreate.Enabled = false;
            btnCreate.BackColor = Color.LightSkyBlue;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;

            InputEnabled();
            ConfirmEnabled();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (CreateClicked)
            {
                if(tbName.TextLength > 0 && tbPrice.TextLength > 0 && numCapacity.Value > 0)
                {
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO RoomType VALUES (@name, @capacity, @roomprice)", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@name", tbName.Text);
                    sqlCommand.Parameters.AddWithValue("@capacity", numCapacity.Value.ToString());
                    sqlCommand.Parameters.AddWithValue("@roomprice", tbPrice.Text);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    GetData();
                    MessageBox.Show("Input Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("All input field must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                CreateClicked = false;
            }
            else if (UpdateClicked)
            {
                if (tbName.TextLength > 0 && tbPrice.TextLength > 0 && numCapacity.Value > 0)
                {
                    if (MessageBox.Show("Are you sure to update this data?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand sqlCommand = new SqlCommand("UPDATE RoomType SET name=@name, capacity@capacity, roomprice@roomprice WHERE id=@id", sqlConnection);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@id", this.id);
                        sqlCommand.Parameters.AddWithValue("@name", tbName.Text);
                        sqlCommand.Parameters.AddWithValue("@capacity", numCapacity.Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@roomprice", tbPrice.Text);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        GetData();
                        MessageBox.Show("Update Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("All input field must be filled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                UpdateClicked = false;
            }
            else if (DeleteClicked)
            {
                if (MessageBox.Show("Are you sure to delete this data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand sqlCommand = new SqlCommand("DELETE RoomType WHERE id=@id", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@id", this.id);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    GetData();
                    MessageBox.Show("Delete Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DeleteClicked = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ConfirmDisabled();
            ControlEnabled();
            ResetForm();
            GetData();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tbName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numCapacity.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
        }
    }
}
