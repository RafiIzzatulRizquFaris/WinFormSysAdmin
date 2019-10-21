namespace WinFormSysAdmin
{
    partial class FrontOffice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontOffice));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SideActive = new System.Windows.Forms.Panel();
            this.btnMasterItem = new System.Windows.Forms.Button();
            this.btnRoomMaster = new System.Windows.Forms.Button();
            this.btnTypeRoom = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReqItem = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnReservation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.masterItem1 = new WinFormSysAdmin.MasterItem();
            this.roomMaster1 = new WinFormSysAdmin.RoomMaster();
            this.checkOut1 = new WinFormSysAdmin.CheckOut();
            this.masterRoomType1 = new WinFormSysAdmin.MasterRoomType();
            this.requestItem1 = new WinFormSysAdmin.RequestItem();
            this.reservation1 = new WinFormSysAdmin.Reservation();
            this.checkIn1 = new WinFormSysAdmin.CheckIn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.SideActive);
            this.panel1.Controls.Add(this.btnMasterItem);
            this.panel1.Controls.Add(this.btnRoomMaster);
            this.panel1.Controls.Add(this.btnTypeRoom);
            this.panel1.Controls.Add(this.btnCheckOut);
            this.panel1.Controls.Add(this.btnReqItem);
            this.panel1.Controls.Add(this.btnCheckIn);
            this.panel1.Controls.Add(this.btnReservation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 839);
            this.panel1.TabIndex = 14;
            // 
            // SideActive
            // 
            this.SideActive.BackColor = System.Drawing.Color.Red;
            this.SideActive.Location = new System.Drawing.Point(37, 172);
            this.SideActive.Name = "SideActive";
            this.SideActive.Size = new System.Drawing.Size(5, 44);
            this.SideActive.TabIndex = 39;
            // 
            // btnMasterItem
            // 
            this.btnMasterItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMasterItem.FlatAppearance.BorderSize = 0;
            this.btnMasterItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasterItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterItem.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMasterItem.Image = ((System.Drawing.Image)(resources.GetObject("btnMasterItem.Image")));
            this.btnMasterItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterItem.Location = new System.Drawing.Point(48, 567);
            this.btnMasterItem.Name = "btnMasterItem";
            this.btnMasterItem.Size = new System.Drawing.Size(183, 45);
            this.btnMasterItem.TabIndex = 31;
            this.btnMasterItem.Text = "   Master Item";
            this.btnMasterItem.UseVisualStyleBackColor = false;
            this.btnMasterItem.Click += new System.EventHandler(this.BtnMasterItem_Click);
            // 
            // btnRoomMaster
            // 
            this.btnRoomMaster.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRoomMaster.FlatAppearance.BorderSize = 0;
            this.btnRoomMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomMaster.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRoomMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomMaster.Image")));
            this.btnRoomMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomMaster.Location = new System.Drawing.Point(48, 501);
            this.btnRoomMaster.Name = "btnRoomMaster";
            this.btnRoomMaster.Size = new System.Drawing.Size(183, 45);
            this.btnRoomMaster.TabIndex = 30;
            this.btnRoomMaster.Text = "      Room Master";
            this.btnRoomMaster.UseVisualStyleBackColor = false;
            this.btnRoomMaster.Click += new System.EventHandler(this.BtnRoomMaster_Click);
            // 
            // btnTypeRoom
            // 
            this.btnTypeRoom.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTypeRoom.FlatAppearance.BorderSize = 0;
            this.btnTypeRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTypeRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeRoom.ForeColor = System.Drawing.SystemColors.Window;
            this.btnTypeRoom.Image = ((System.Drawing.Image)(resources.GetObject("btnTypeRoom.Image")));
            this.btnTypeRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTypeRoom.Location = new System.Drawing.Point(48, 435);
            this.btnTypeRoom.Name = "btnTypeRoom";
            this.btnTypeRoom.Size = new System.Drawing.Size(183, 45);
            this.btnTypeRoom.TabIndex = 29;
            this.btnTypeRoom.Text = "    Type Room";
            this.btnTypeRoom.UseVisualStyleBackColor = false;
            this.btnTypeRoom.Click += new System.EventHandler(this.BtnTypeRoom_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.Image")));
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Location = new System.Drawing.Point(48, 369);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(183, 45);
            this.btnCheckOut.TabIndex = 28;
            this.btnCheckOut.Text = "  Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.BtnCheckOut_Click);
            // 
            // btnReqItem
            // 
            this.btnReqItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnReqItem.FlatAppearance.BorderSize = 0;
            this.btnReqItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReqItem.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReqItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReqItem.Image")));
            this.btnReqItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReqItem.Location = new System.Drawing.Point(48, 303);
            this.btnReqItem.Name = "btnReqItem";
            this.btnReqItem.Size = new System.Drawing.Size(183, 45);
            this.btnReqItem.TabIndex = 27;
            this.btnReqItem.Text = "Req Item";
            this.btnReqItem.UseVisualStyleBackColor = false;
            this.btnReqItem.Click += new System.EventHandler(this.BtnReqItem_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckIn.Image")));
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckIn.Location = new System.Drawing.Point(48, 239);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(183, 45);
            this.btnCheckIn.TabIndex = 26;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.BtnCheckIn_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnReservation.FlatAppearance.BorderSize = 0;
            this.btnReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservation.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReservation.Image = ((System.Drawing.Image)(resources.GetObject("btnReservation.Image")));
            this.btnReservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservation.Location = new System.Drawing.Point(48, 171);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(183, 45);
            this.btnReservation.TabIndex = 25;
            this.btnReservation.Text = "     Reservation";
            this.btnReservation.UseVisualStyleBackColor = false;
            this.btnReservation.Click += new System.EventHandler(this.BtnReservation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 46);
            this.label2.TabIndex = 25;
            this.label2.Text = "Front Office";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.Window;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(1313, 14);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(42, 42);
            this.btnLogOut.TabIndex = 38;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.masterItem1);
            this.panel2.Controls.Add(this.roomMaster1);
            this.panel2.Controls.Add(this.checkOut1);
            this.panel2.Controls.Add(this.masterRoomType1);
            this.panel2.Controls.Add(this.requestItem1);
            this.panel2.Controls.Add(this.reservation1);
            this.panel2.Controls.Add(this.checkIn1);
            this.panel2.Location = new System.Drawing.Point(280, 133);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 616);
            this.panel2.TabIndex = 39;
            // 
            // masterItem1
            // 
            this.masterItem1.BackColor = System.Drawing.SystemColors.Window;
            this.masterItem1.Location = new System.Drawing.Point(0, 11);
            this.masterItem1.Name = "masterItem1";
            this.masterItem1.Size = new System.Drawing.Size(1069, 616);
            this.masterItem1.TabIndex = 6;
            // 
            // roomMaster1
            // 
            this.roomMaster1.BackColor = System.Drawing.SystemColors.Window;
            this.roomMaster1.Location = new System.Drawing.Point(0, 20);
            this.roomMaster1.Name = "roomMaster1";
            this.roomMaster1.Size = new System.Drawing.Size(1069, 616);
            this.roomMaster1.TabIndex = 5;
            // 
            // checkOut1
            // 
            this.checkOut1.BackColor = System.Drawing.SystemColors.Window;
            this.checkOut1.Location = new System.Drawing.Point(3, 11);
            this.checkOut1.Name = "checkOut1";
            this.checkOut1.Size = new System.Drawing.Size(1069, 616);
            this.checkOut1.TabIndex = 4;
            // 
            // masterRoomType1
            // 
            this.masterRoomType1.BackColor = System.Drawing.SystemColors.Window;
            this.masterRoomType1.Location = new System.Drawing.Point(7, 0);
            this.masterRoomType1.Name = "masterRoomType1";
            this.masterRoomType1.Size = new System.Drawing.Size(1069, 616);
            this.masterRoomType1.TabIndex = 3;
            // 
            // requestItem1
            // 
            this.requestItem1.BackColor = System.Drawing.SystemColors.Window;
            this.requestItem1.Location = new System.Drawing.Point(-3, 0);
            this.requestItem1.Name = "requestItem1";
            this.requestItem1.Size = new System.Drawing.Size(1069, 616);
            this.requestItem1.TabIndex = 2;
            // 
            // reservation1
            // 
            this.reservation1.BackColor = System.Drawing.SystemColors.Window;
            this.reservation1.Location = new System.Drawing.Point(-3, 11);
            this.reservation1.Name = "reservation1";
            this.reservation1.Size = new System.Drawing.Size(1069, 616);
            this.reservation1.TabIndex = 1;
            // 
            // checkIn1
            // 
            this.checkIn1.BackColor = System.Drawing.SystemColors.Window;
            this.checkIn1.Location = new System.Drawing.Point(-3, 11);
            this.checkIn1.Name = "checkIn1";
            this.checkIn1.Size = new System.Drawing.Size(1069, 616);
            this.checkIn1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(292, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(158, 2);
            this.panel3.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 30F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(284, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 46);
            this.label3.TabIndex = 54;
            this.label3.Text = "Input";
            // 
            // FrontOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1368, 768);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrontOffice";
            this.Text = "FrontOffice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMasterItem;
        private System.Windows.Forms.Button btnRoomMaster;
        private System.Windows.Forms.Button btnTypeRoom;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReqItem;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel SideActive;
        private System.Windows.Forms.Panel panel2;
        private CheckIn checkIn1;
        private Reservation reservation1;
        private RequestItem requestItem1;
        private MasterRoomType masterRoomType1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private CheckOut checkOut1;
        private RoomMaster roomMaster1;
        private MasterItem masterItem1;
    }
}