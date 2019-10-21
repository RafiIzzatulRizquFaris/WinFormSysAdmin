using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSysAdmin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            GetData();
            GetSelectedItem();
            ControlEnabled();
            InputDisabled();
            ConfirmDisabled();
        }

        bool CreateWasClicked = false;
        bool UpdateWasClicked = false;
        bool DeleteWasClicked = false;

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        private void ConfirmEnabled()
        {
            btnConfirm.Enabled = true;
            btnConfirm.BackColor = Color.LimeGreen;
            btnCancel.Enabled = true;
            btnCancel.BackColor = Color.Crimson;
        }

        private void ConfirmDisabled()
        {
            btnConfirm.Enabled = false;
            btnConfirm.BackColor = Color.LightSkyBlue;
            btnCancel.Enabled = false;
            btnCancel.BackColor = Color.LightSkyBlue;
        }

        private void InputEnabled()
        {
            tbName.Enabled = true;
            tbAddress.Enabled = true;
            tbEmail.Enabled = true;
            tbPassword.Enabled = true;
            tbUsername.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void InputDisabled()
        {
            tbName.Enabled = false;
            tbAddress.Enabled = false;
            tbEmail.Enabled = false;
            tbPassword.Enabled = false;
            tbUsername.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
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

        private void ControlDisabled()
        {
            btnCreate.Enabled = false;
            btnCreate.BackColor = Color.LightSkyBlue;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightSkyBlue;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightSkyBlue;
        }

        private void GetData()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT username, password, Employee.name, email, address, dateofbirth FROM Employee LEFT JOIN Job on Employee.jobid = Job.id", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void GetSelectedItem()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Job", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            SqlDataReader sda = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sda);
            sqlConnection.Close();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            GetData();
            ResetForm();
        }

        private void ResetForm()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbName.Clear();
            tbAddress.Clear();
            tbEmail.Clear();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Employee WHERE name='" + tbSearch.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void TbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        int id, selectedJobId;
        string dtp;

        static string Sha256(string data)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString());
            }

            return builder.ToString();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateWasClicked = true;
            ConfirmEnabled();
            InputEnabled();
            ControlDisabled();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateWasClicked = true;
            ConfirmEnabled();
            InputEnabled();
            ControlDisabled();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteWasClicked = true;
            ConfirmEnabled();
            InputEnabled();
            ControlDisabled();
        }

        private void TbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.Clear();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                tbUsername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbPassword.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tbName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                tbEmail.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                tbAddress.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dtp = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                selectedJobId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Gabole Neken ini Anjir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (CreateWasClicked)
            {
                if (tbUsername.TextLength >= 5 && tbPassword.TextLength >= 5 && tbName.TextLength > 0 && tbEmail.TextLength > 0)
                {
                    if (MessageBox.Show("Do you want to Insert this Data?", "INSERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string hashed = Sha256(tbPassword.Text);
                        try
                        {
                            dtp = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            selectedJobId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Employee VALUES (@username, @password, @name, @email, @address, @dateofbirth, @jobid)", sqlConnection);
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Parameters.AddWithValue("@username", tbUsername.Text);
                            sqlCommand.Parameters.AddWithValue("@password", hashed);
                            sqlCommand.Parameters.AddWithValue("@name", tbName.Text);
                            sqlCommand.Parameters.AddWithValue("@email", tbEmail.Text);
                            sqlCommand.Parameters.AddWithValue("@address", tbAddress.Text);
                            sqlCommand.Parameters.AddWithValue("@dateofbirth", dtp);
                            sqlCommand.Parameters.AddWithValue("@jobid", selectedJobId);

                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();

                            GetData();
                            MessageBox.Show("Input Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Failed Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE FILL THE INPUT", "Fill the input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                CreateWasClicked = false;
            }
            else if (UpdateWasClicked)
            {
                if (tbUsername.TextLength >= 5 && tbPassword.TextLength >= 5 && tbName.TextLength > 0 && tbEmail.TextLength > 0)
                {
                    if (MessageBox.Show("Do you want to Update this Data?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string hashed = Sha256(tbPassword.Text);
                            dtp = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            selectedJobId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                            SqlCommand sqlCom = new SqlCommand("UPDATE Employee SET username=@username, password=@password, name=@name, email=@email, address=@address, dateofbirth=@dateofbirth, jobid=@jobid WHERE id=@id", sqlConnection);
                            sqlCom.CommandType = CommandType.Text;
                            sqlCom.Parameters.AddWithValue("@id", this.id);
                            sqlCom.Parameters.AddWithValue("@username", tbUsername.Text);
                            sqlCom.Parameters.AddWithValue("@password", hashed);
                            sqlCom.Parameters.AddWithValue("@name", tbName.Text);
                            sqlCom.Parameters.AddWithValue("@email", tbEmail.Text);
                            sqlCom.Parameters.AddWithValue("@address", tbAddress.Text);
                            sqlCom.Parameters.AddWithValue("@dateofbirth", dtp);
                            sqlCom.Parameters.AddWithValue("@jobid", selectedJobId);

                            sqlConnection.Open();
                            sqlCom.ExecuteNonQuery();
                            sqlConnection.Close();

                            GetData();
                            MessageBox.Show("Update Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Failed Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                UpdateWasClicked = false;
            }
            else if (DeleteWasClicked)
            {
                if (MessageBox.Show("Do you want to Delete this Data?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand("DELETE Employee WHERE id=@id", sqlConnection);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@id", this.id);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        GetData();
                        MessageBox.Show("Delete Data Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Failed Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                DeleteWasClicked = false;
            }
            else
            {
                MessageBox.Show("You've been clicked the wrong button", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
