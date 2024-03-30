namespace SomerenUI
{
    partial class AddStudent
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            AddStudentB = new System.Windows.Forms.Button();
            SNumberTB = new System.Windows.Forms.TextBox();
            FirstNameTB = new System.Windows.Forms.TextBox();
            LastNameTB = new System.Windows.Forms.TextBox();
            PhoneNumberTB = new System.Windows.Forms.TextBox();
            ClassTB = new System.Windows.Forms.TextBox();
            RoomCodeTB = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "Student Number: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "First Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 132);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Last Name: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(21, 173);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 15);
            label4.TabIndex = 3;
            label4.Text = "Phone Number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(21, 214);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(40, 15);
            label5.TabIndex = 4;
            label5.Text = "Class: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(21, 247);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(70, 15);
            label6.TabIndex = 5;
            label6.Text = "RoomCode:";
            // 
            // AddStudentB
            // 
            AddStudentB.Location = new System.Drawing.Point(21, 300);
            AddStudentB.Name = "AddStudentB";
            AddStudentB.Size = new System.Drawing.Size(91, 33);
            AddStudentB.TabIndex = 6;
            AddStudentB.Text = "Add Student";
            AddStudentB.UseVisualStyleBackColor = true;
            AddStudentB.Click += AddStudentB_Click;
            // 
            // SNumberTB
            // 
            SNumberTB.Location = new System.Drawing.Point(151, 31);
            SNumberTB.Name = "SNumberTB";
            SNumberTB.Size = new System.Drawing.Size(128, 23);
            SNumberTB.TabIndex = 7;
            // 
            // FirstNameTB
            // 
            FirstNameTB.Location = new System.Drawing.Point(151, 90);
            FirstNameTB.Name = "FirstNameTB";
            FirstNameTB.Size = new System.Drawing.Size(128, 23);
            FirstNameTB.TabIndex = 8;
            // 
            // LastNameTB
            // 
            LastNameTB.Location = new System.Drawing.Point(151, 129);
            LastNameTB.Name = "LastNameTB";
            LastNameTB.Size = new System.Drawing.Size(128, 23);
            LastNameTB.TabIndex = 9;
            // 
            // PhoneNumberTB
            // 
            PhoneNumberTB.Location = new System.Drawing.Point(151, 170);
            PhoneNumberTB.Name = "PhoneNumberTB";
            PhoneNumberTB.Size = new System.Drawing.Size(128, 23);
            PhoneNumberTB.TabIndex = 10;
            // 
            // ClassTB
            // 
            ClassTB.Location = new System.Drawing.Point(151, 211);
            ClassTB.Name = "ClassTB";
            ClassTB.Size = new System.Drawing.Size(128, 23);
            ClassTB.TabIndex = 11;
            // 
            // RoomCodeTB
            // 
            RoomCodeTB.Location = new System.Drawing.Point(151, 244);
            RoomCodeTB.Name = "RoomCodeTB";
            RoomCodeTB.Size = new System.Drawing.Size(128, 23);
            RoomCodeTB.TabIndex = 12;
            // 
            // AddStudent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(310, 365);
            Controls.Add(RoomCodeTB);
            Controls.Add(ClassTB);
            Controls.Add(PhoneNumberTB);
            Controls.Add(LastNameTB);
            Controls.Add(FirstNameTB);
            Controls.Add(SNumberTB);
            Controls.Add(AddStudentB);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddStudent";
            Text = "Add Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddStudentB;
        private System.Windows.Forms.TextBox SNumberTB;
        private System.Windows.Forms.TextBox FirstNameTB;
        private System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.TextBox PhoneNumberTB;
        private System.Windows.Forms.TextBox ClassTB;
        private System.Windows.Forms.TextBox RoomCodeTB;
    }
}