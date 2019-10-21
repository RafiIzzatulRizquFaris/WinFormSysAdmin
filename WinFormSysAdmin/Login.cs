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
    public partial class Login : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
        }

        private void TbUsername_MouseClick(object sender, MouseEventArgs e)
        {
            tbUsername.Clear();
        }

        private void TbPassword_MouseClick(object sender, MouseEventArgs e)
        {
            tbPassword.Clear();
            tbPassword.PasswordChar = '*';
        }

        static string Sha256(string data)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(data));

            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString());
            }
            return stringBuilder.ToString();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length >= 5 && tbPassword.Text.Length >= 5)
            {
                string hashed = Sha256(tbPassword.Text.Trim());
                string query = "SELECT * FROM Employee WHERE username='" + tbUsername.Text.Trim() + "' and password='" + hashed + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlConnection.Open();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                if (dataTable.Rows.Count == 1)
                {
                    int role = Convert.ToInt32(dataTable.Rows[0]["jobid"]);
                    if (role == 1)
                    {
                        this.Hide();
                        Admin admin = new Admin();
                        admin.Show();
                    }
                    else if (role == 2)
                    {
                        this.Hide();
                        FrontOffice frontOffice = new FrontOffice();
                        frontOffice.Show();
                    }
                    else if (role == 3)
                    {
                        this.Hide();
                        SuperVisor superVisor = new SuperVisor();
                        superVisor.Show();
                    }
                    else if (role == 4)
                    {
                        this.Hide();
                        HouseKeeper houseKeeper = new HouseKeeper();
                        houseKeeper.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetForm();
                }
            }
            else
            {
                MessageBox.Show("Username or Password are less than 5 Characters", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetForm();
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
    }
}
