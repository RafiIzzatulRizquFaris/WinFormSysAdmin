using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSysAdmin
{
    public partial class FrontOffice : Form
    {
        public FrontOffice()
        {
            InitializeComponent();
            SideActive.Height = btnReservation.Height;
            SideActive.Top = btnReservation.Top;
            reservation1.BringToFront();
            label3.Text = "Reservation";
            panel3.Width = label3.Width;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }

        private void BtnReservation_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnReservation.Height;
            SideActive.Top = btnReservation.Top;
            reservation1.BringToFront();
            label3.Text = "Reservation";
            panel3.Width = label3.Width;
        }

        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnCheckIn.Height;
            SideActive.Top = btnCheckIn.Top;
            checkIn1.BringToFront();
            label3.Text = "Check In";
            panel3.Width = label3.Width;
        }

        private void BtnReqItem_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnReqItem.Height;
            SideActive.Top = btnReqItem.Top;
            requestItem1.BringToFront();
            label3.Text = "Request Item";
            panel3.Width = label3.Width;
        }

        private void BtnTypeRoom_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnTypeRoom.Height;
            SideActive.Top = btnTypeRoom.Top;
            masterRoomType1.BringToFront();
            label3.Text = "Type Room Master";
            panel3.Width = label3.Width;
        }

        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnCheckOut.Height;
            SideActive.Top = btnCheckOut.Top;
            checkOut1.BringToFront();
            label3.Text = "Check Out";
            panel3.Width = label3.Width;
        }

        private void BtnRoomMaster_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnRoomMaster.Height;
            SideActive.Top = btnRoomMaster.Top;
            roomMaster1.BringToFront();
            label3.Text = "Room Master";
            panel3.Width = label3.Width;
        }

        private void BtnMasterItem_Click(object sender, EventArgs e)
        {
            SideActive.Height = btnMasterItem.Height;
            SideActive.Top = btnMasterItem.Top;
            masterItem1.BringToFront();
            label3.Text = "Master Item";
            panel3.Width = label3.Width;
        }
    }
}
