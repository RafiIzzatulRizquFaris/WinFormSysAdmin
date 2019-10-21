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
    public partial class Reservation : UserControl
    {
        public Reservation()
        {
            InitializeComponent();
            GetRoomType();
            GetAvailableRoom();
            GetItem();

            label10.Hide();
            label11.Hide();
            textBox2.Hide();
            textBox3.Hide();
            btnUserAdd.Hide();
            dataGridView2.Hide();
            textBox1.Enabled = false;
        }

        private void AddUserData()
        {
            SqlCommand command = new SqlCommand("INSERT INTO Customer VALUES (@name, @phonenumber)", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@name", textBox2.Text);
            command.Parameters.AddWithValue("@phonenumber", textBox3.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Succes Add User Data", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetItem()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Item", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";
        }

        private void GetAvailableRoom()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Room WHERE roomtypeid LIKE'" + comboBox1.SelectedValue.ToString() + "' AND NOT EXISTS(SELECT * FROM ReservationRoom WHERE ReservationRoom.checkoutdatetime = (SELECT GETDATE()))", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            dgvAvailable.DataSource = dataTable;
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=gihDB;Integrated Security=True");

        private void GetRoomType()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM RoomType", connection);
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            connection.Close();

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            label10.Show();
            label11.Show();
            textBox2.Show();
            textBox3.Show();
            btnUserAdd.Show();
            dataGridView2.Hide();
            textBox1.Enabled = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            textBox2.Hide();
            textBox3.Hide();
            btnUserAdd.Hide();
            dataGridView2.Show();
            textBox1.Enabled = true;

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE name= '" + textBox1.Text + "'", connection);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();

            dataGridView2.DataSource = dataTable;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in dgvAvailable.Rows)
            {
                DataGridViewCheckBoxCell check = item.Cells[0] as DataGridViewCheckBoxCell;
                if(Convert.ToBoolean(check.Value) == true)
                {
                    int n = dgvSelected.Rows.Add();
                    dgvSelected.Rows[n].Cells[1].Value = item.Cells[1].Value.ToString();
                    dgvSelected.Rows[n].Cells[2].Value = item.Cells[2].Value.ToString();
                    dgvSelected.Rows[n].Cells[3].Value = item.Cells[3].Value.ToString();
                    dgvSelected.Rows[n].Cells[4].Value = item.Cells[4].Value.ToString();
                    dgvSelected.Rows[n].Cells[5].Value = item.Cells[5].Value.ToString();

                    dgvAvailable.Rows.Remove(item);
                }
            }
        }

        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            AddUserData();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            
        }

        int price, totalItemPrice, idCustomer;

        private void DgvSelected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomtypeid = Convert.ToInt32(dgvSelected.SelectedRows[0].Cells[2].Value);
            SqlCommand command = new SqlCommand("SELECT roomprice FROM RoomType WHERE id ='" + roomtypeid + "'", connection);
            connection.Open();
            price = Convert.ToInt32(command.ExecuteScalar()) * Convert.ToInt32(tbNights.Text);
            connection.Close();
            MessageBox.Show(price.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            string code = date + id;
            SqlCommand command = new SqlCommand("INSERT INTO Reservation VALUES (@datetime, @customerid, @code)", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@datetime", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@customerid", Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value));
            command.Parameters.AddWithValue("@code", code);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


            SqlCommand command1 = new SqlCommand("SELECT id FROM Reservation WHERE code = '" + code + "'", connection);
            connection.Open();
            int reservationId = Convert.ToInt32(command1.ExecuteScalar());
            connection.Close();


            int roomtypeid = Convert.ToInt32(dgvSelected.SelectedRows[0].Cells[2].Value);
            SqlCommand commandPrice = new SqlCommand("SELECT roomprice FROM RoomType WHERE id ='" + roomtypeid + "'", connection);
            connection.Open();
            int priceroom = Convert.ToInt32(commandPrice.ExecuteScalar());
            connection.Close();
            int roomid = Convert.ToInt32(dgvSelected.SelectedRows[0].Cells[1].Value);
            SqlCommand command2 = new SqlCommand("INSERT INTO ReservationRoom VALUES (@reservationid, @roomid, @startdatetime, @durationnights, @roomprice, @checkindatetime, @checkoutdatetime)", connection);
            command2.CommandType = CommandType.Text;
            command2.Parameters.AddWithValue("@reservationid", reservationId);
            command2.Parameters.AddWithValue("@roomid", roomid);
            command2.Parameters.AddWithValue("@startdatetime", dateTimePicker1.Value.ToString("yyyy-MM-dd H:mm:ss"));
            command2.Parameters.AddWithValue("@durationnights", numericUpDown1.Value.ToString());
            command2.Parameters.AddWithValue("@roomprice", priceroom);

            connection.Open();
            command2.ExecuteNonQuery();
            connection.Close();

            


            MessageBox.Show("Success Input Reservation Data", "SUCCESS");
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCustomer = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            int selectedItem = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            SqlCommand command = new SqlCommand("SELECT requestprice FROM Item WHERE id='"+selectedItem+"'", connection);
            connection.Open();
            int itemPrice = Convert.ToInt32(command.ExecuteScalar());
            int itemQty = Convert.ToInt32(numericUpDown1.Value);
            connection.Close();

            dataGridView1.Rows.Add(comboBox2.SelectedValue, numericUpDown1.Value, itemPrice*itemQty);

            totalItemPrice = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            int totalPrice = totalItemPrice + price;
            label12.Text = totalPrice.ToString();
        }
    }
}
