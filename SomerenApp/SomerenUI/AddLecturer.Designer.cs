namespace SomerenUI
{
    partial class AddLecturer
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
            components = new System.ComponentModel.Container();
            lecturerCB = new System.Windows.Forms.ComboBox();
            addLecturerB = new System.Windows.Forms.Button();
            UpdateLecturerB = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            FirstNameT = new System.Windows.Forms.TextBox();
            LastNameT = new System.Windows.Forms.TextBox();
            AgeT = new System.Windows.Forms.TextBox();
            NumberT = new System.Windows.Forms.TextBox();
            RoomCodeT = new System.Windows.Forms.TextBox();
            UpdateLpnl = new System.Windows.Forms.Panel();
            LecturerIdTB = new System.Windows.Forms.TextBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            UpdateLpnl.SuspendLayout();
            SuspendLayout();
            // 
            // lecturerCB
            // 
            lecturerCB.FormattingEnabled = true;
            lecturerCB.Location = new System.Drawing.Point(9, 39);
            lecturerCB.Margin = new System.Windows.Forms.Padding(6);
            lecturerCB.Name = "lecturerCB";
            lecturerCB.Size = new System.Drawing.Size(322, 40);
            lecturerCB.TabIndex = 1;
            lecturerCB.SelectedIndexChanged += lectulerCB_SelectedIndexChanged;
            // 
            // addLecturerB
            // 
            addLecturerB.Location = new System.Drawing.Point(60, 494);
            addLecturerB.Name = "addLecturerB";
            addLecturerB.Size = new System.Drawing.Size(174, 46);
            addLecturerB.TabIndex = 2;
            addLecturerB.Text = "Add Lecturer";
            addLecturerB.UseVisualStyleBackColor = true;
            addLecturerB.Click += addLectureB_Click;
            // 
            // UpdateLecturerB
            // 
            UpdateLecturerB.Location = new System.Drawing.Point(524, 494);
            UpdateLecturerB.Name = "UpdateLecturerB";
            UpdateLecturerB.Size = new System.Drawing.Size(198, 46);
            UpdateLecturerB.TabIndex = 3;
            UpdateLecturerB.Text = "Update Lecturer";
            UpdateLecturerB.UseVisualStyleBackColor = true;
            UpdateLecturerB.Click += updateLecturerB_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(60, 72);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(127, 32);
            label1.TabIndex = 4;
            label1.Text = "Lecturer Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(60, 136);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(129, 32);
            label2.TabIndex = 5;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(60, 201);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(126, 32);
            label3.TabIndex = 6;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(60, 270);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 32);
            label4.TabIndex = 7;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(60, 337);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(221, 32);
            label5.TabIndex = 8;
            label5.Text = "Telephone Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(60, 395);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(139, 32);
            label6.TabIndex = 9;
            label6.Text = "Room Code";
            // 
            // FirstNameT
            // 
            FirstNameT.Location = new System.Drawing.Point(400, 129);
            FirstNameT.Name = "FirstNameT";
            FirstNameT.Size = new System.Drawing.Size(322, 39);
            FirstNameT.TabIndex = 10;
            // 
            // LastNameT
            // 
            LastNameT.Location = new System.Drawing.Point(400, 194);
            LastNameT.Name = "LastNameT";
            LastNameT.Size = new System.Drawing.Size(322, 39);
            LastNameT.TabIndex = 11;
            // 
            // AgeT
            // 
            AgeT.Location = new System.Drawing.Point(400, 263);
            AgeT.Name = "AgeT";
            AgeT.Size = new System.Drawing.Size(322, 39);
            AgeT.TabIndex = 12;
            // 
            // NumberT
            // 
            NumberT.Location = new System.Drawing.Point(400, 330);
            NumberT.Name = "NumberT";
            NumberT.Size = new System.Drawing.Size(322, 39);
            NumberT.TabIndex = 13;
            // 
            // RoomCodeT
            // 
            RoomCodeT.Location = new System.Drawing.Point(400, 392);
            RoomCodeT.Name = "RoomCodeT";
            RoomCodeT.Size = new System.Drawing.Size(322, 39);
            RoomCodeT.TabIndex = 14;
            // 
            // UpdateLpnl
            // 
            UpdateLpnl.Controls.Add(lecturerCB);
            UpdateLpnl.Location = new System.Drawing.Point(391, 12);
            UpdateLpnl.Margin = new System.Windows.Forms.Padding(6);
            UpdateLpnl.Name = "UpdateLpnl";
            UpdateLpnl.Size = new System.Drawing.Size(342, 108);
            UpdateLpnl.TabIndex = 15;
            // 
            // LecturerIdTB
            // 
            LecturerIdTB.Location = new System.Drawing.Point(391, 52);
            LecturerIdTB.Name = "LecturerIdTB";
            LecturerIdTB.Size = new System.Drawing.Size(342, 39);
            LecturerIdTB.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AddLecturer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(822, 627);
            Controls.Add(RoomCodeT);
            Controls.Add(NumberT);
            Controls.Add(AgeT);
            Controls.Add(LastNameT);
            Controls.Add(FirstNameT);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(UpdateLecturerB);
            Controls.Add(addLecturerB);
            Controls.Add(UpdateLpnl);
            Controls.Add(LecturerIdTB);
            Name = "AddLecturer";
            Text = "AddLecturer";
            UpdateLpnl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox lecturerCB;
        private System.Windows.Forms.Button addLecturerB;
        private System.Windows.Forms.Button UpdateLecturerB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FirstNameT;
        private System.Windows.Forms.TextBox LastNameT;
        private System.Windows.Forms.TextBox AgeT;
        private System.Windows.Forms.TextBox NumberT;
        private System.Windows.Forms.TextBox RoomCodeT;
        private System.Windows.Forms.Panel UpdateLpnl;
        private System.Windows.Forms.TextBox LecturerIdTB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}