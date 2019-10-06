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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=ToughputTest2;Integrated Security=True");
        SqlConnection sqlConnection2 = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            tbUsername.Focus();
            tbPassword.PasswordChar = '*';
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Employee WHERE username = '" + tbUsername.Text.Trim()+"'AND password = '"+ tbPassword.Text.Trim()+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection2);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count == 1)
            {
                int role = Convert.ToInt32(dataTable.Rows[0]["jobid"]);
                if(role == 1)
                {
                    MessageBox.Show("You're Admin", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    dashboard dashboard = new dashboard();
                    dashboard.Show();
                }
                else if(role == 2)
                {
                    MessageBox.Show("You're Employee", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    tbUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Your Password or Username is wrong", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetForm()
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length == 0 || tbPassword.Text.Length == 0)
            {
                MessageBox.Show("Your Username and Password Cannot be empty", "Username or Password Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbUsername.Text.Length < 5 || tbPassword.Text.Length < 5)
            {
                MessageBox.Show("Your Username and Password Cannot Less than 5 Characters", "Username or Password is less than 5 characters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tbUsername.Text.Length > 5 && tbPassword.Text.Length > 5) {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Login_Tabel VALUES (@username, @password)", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@username", tbUsername.Text);
                sqlCommand.Parameters.AddWithValue("@password", tbPassword.Text);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}