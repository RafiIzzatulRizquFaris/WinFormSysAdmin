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
    public partial class dashboard : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=ToughputTest2;Integrated Security=True");
        int id;

        public dashboard()
        {
            InitializeComponent();
            GetData();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO otobus_tabel VALUES (@busname, @driver)", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@busname", tbBusName.Text);
            sqlCommand.Parameters.AddWithValue("@driver", tbBusdriver.Text);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            GetData();
            ResetForm();
        }

        private void ResetForm()
        {
            GetData();
            tbBusName.Clear();
            tbBusdriver.Clear();
            tbBusName.Focus();
        }

        private void GetData()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM otobus_tabel", sqlConnection);
            DataTable data = new DataTable();
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            data.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = data;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            tbBusName.Focus();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE otobus_tabel SET busname=@busname, driver=@driver WHERE id=@id", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", this.id);
            sqlCommand.Parameters.AddWithValue("@busname", tbBusName.Text);
            sqlCommand.Parameters.AddWithValue("@driver", tbBusdriver.Text);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            GetData();
            MessageBox.Show("Success Update", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }

        private void dataGridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tbBusName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbBusdriver.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE otobus_tabel WHERE id=@id", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", this.id);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            GetData();
            MessageBox.Show("Success Delete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT @busname FROM otobus_tabel WHERE busname=@busname", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@busname", tbBusName.Text);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            sqlConnection.Close();

            dataGridView1.DataSource = dataTable;
        }
    }
}
