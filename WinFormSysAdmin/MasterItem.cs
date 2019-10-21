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
    public partial class MasterItem : UserControl
    {
        public MasterItem()
        {
            InitializeComponent();
            GetData();
            ConfirmDisable();
        }

        int id;

        private void ConfirmDisable()
        {
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = Color.LightSkyBlue;
            btnCancel.Enabled = false;
            btnCancel.BackColor = Color.LightSkyBlue;
            tbName.Enabled = false;
            tbRequestPrice.Enabled = false;
            tbCompensation.Enabled = false;
        }
        
        private void ConfirmEnable()
        {
            btnConfirm.Enabled = true;
            btnConfirm.BackColor = Color.LimeGreen;
            btnCancel.Enabled = true;
            btnCancel.BackColor = Color.Crimson;
            tbName.Enabled = true;
            tbRequestPrice.Enabled = true;
            tbCompensation.Enabled = true;
        }

        private void ControlEnable()
        {
            btnCreate.Enabled = true;
            btnCreate.BackColor = Color.MediumBlue;
            btnDelete.Enabled = true;
            btnDelete.BackColor = Color.Crimson;
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.LimeGreen;
        }

        private void ResetForm()
        {
            tbName.Clear();
            tbRequestPrice.Clear();
            tbCompensation.Clear();
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        private void GetData()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Item", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }

        bool BtnCreateClicked = false;
        bool BtnUpdateClicked = false;
        bool BtnDeleteClicked = false;

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (BtnCreateClicked == true)
            {
                if (tbName.Text.Length > 0 && tbRequestPrice.Text.Length > 0 && tbCompensation.Text.Length > 0)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Item VALUES(@name, @requestprice, @compensationfee)", sqlConnection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@name", tbName.Text);
                    command.Parameters.AddWithValue("@requestprice", tbRequestPrice.Text);
                    command.Parameters.AddWithValue("@compensationfee", tbCompensation.Text);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                    GetData();
                    MessageBox.Show("Input Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill the field", "No Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                BtnCreateClicked = false;
            }
            else if (BtnUpdateClicked == true)
            {
                if (tbName.Text.Length > 0 && tbRequestPrice.Text.Length > 0 && tbCompensation.Text.Length > 0)
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Item SET name=@name, requestprice=@requestprice, compensationfee=@compensationfee WHERE id=@id", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@id", this.id);
                    sqlCommand.Parameters.AddWithValue("@name", tbName.Text);
                    sqlCommand.Parameters.AddWithValue("@requestprice", tbRequestPrice.Text);
                    sqlCommand.Parameters.AddWithValue("@compensationfee", tbCompensation.Text);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    GetData();
                    MessageBox.Show("Update Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill the field", "No Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                BtnUpdateClicked = false;
            }
            else if (BtnDeleteClicked)
            {
                SqlCommand sqlCommand = new SqlCommand("DELETE Item WHERE id=@id", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@id", this.id);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                GetData();
                MessageBox.Show("Delete Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BtnDeleteClicked = false;
            }
            else
            {
                MessageBox.Show("You've Clicked The Wrong Button!!!");
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            BtnCreateClicked = true;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;

            ConfirmEnable();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            BtnUpdateClicked = true;
            btnCreate.Enabled = false;
            btnCreate.BackColor = Color.LightSkyBlue;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;

            ConfirmEnable();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            BtnDeleteClicked = true;
            btnCreate.Enabled = false;
            btnCreate.BackColor = Color.LightSkyBlue;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;

            ConfirmEnable();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ControlEnable();
            ConfirmDisable();
            ResetForm();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tbName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbRequestPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tbCompensation.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ControlEnable();
            ConfirmDisable();
            ResetForm();
        }
    }
}
