namespace SomerenUI
{
    partial class Participants
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
            ActivityBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            listViewPart = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            listViewNonPart = new System.Windows.Forms.ListView();
            columnHeader7 = new System.Windows.Forms.ColumnHeader();
            columnHeader8 = new System.Windows.Forms.ColumnHeader();
            columnHeader9 = new System.Windows.Forms.ColumnHeader();
            columnHeader10 = new System.Windows.Forms.ColumnHeader();
            columnHeader11 = new System.Windows.Forms.ColumnHeader();
            AddStudB = new System.Windows.Forms.Button();
            RemoveStudB = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ActivityBox
            // 
            ActivityBox.FormattingEnabled = true;
            ActivityBox.Location = new System.Drawing.Point(94, 53);
            ActivityBox.Name = "ActivityBox";
            ActivityBox.Size = new System.Drawing.Size(283, 23);
            ActivityBox.TabIndex = 0;
            ActivityBox.SelectedIndexChanged += ActivityBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(35, 56);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 1;
            label1.Text = "Activity :";
            // 
            // listViewPart
            // 
            listViewPart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewPart.FullRowSelect = true;
            listViewPart.ImeMode = System.Windows.Forms.ImeMode.On;
            listViewPart.Location = new System.Drawing.Point(12, 129);
            listViewPart.MultiSelect = false;
            listViewPart.Name = "listViewPart";
            listViewPart.Size = new System.Drawing.Size(505, 124);
            listViewPart.TabIndex = 2;
            listViewPart.UseCompatibleStateImageBehavior = false;
            listViewPart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Student Number";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "First name";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Last name";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Phone number";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Class";
            columnHeader5.Width = 100;
            // 
            // listViewNonPart
            // 
            listViewNonPart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11 });
            listViewNonPart.FullRowSelect = true;
            listViewNonPart.Location = new System.Drawing.Point(12, 301);
            listViewNonPart.MultiSelect = false;
            listViewNonPart.Name = "listViewNonPart";
            listViewNonPart.Size = new System.Drawing.Size(505, 124);
            listViewNonPart.TabIndex = 3;
            listViewNonPart.UseCompatibleStateImageBehavior = false;
            listViewNonPart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Student number";
            columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "First name";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Last name";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Phone number";
            columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Class";
            columnHeader11.Width = 100;
            // 
            // AddStudB
            // 
            AddStudB.Location = new System.Drawing.Point(35, 471);
            AddStudB.Name = "AddStudB";
            AddStudB.Size = new System.Drawing.Size(109, 32);
            AddStudB.TabIndex = 4;
            AddStudB.Text = "Add student";
            AddStudB.UseVisualStyleBackColor = true;
            AddStudB.Click += AddStudB_Click;
            // 
            // RemoveStudB
            // 
            RemoveStudB.Location = new System.Drawing.Point(377, 471);
            RemoveStudB.Name = "RemoveStudB";
            RemoveStudB.Size = new System.Drawing.Size(109, 32);
            RemoveStudB.TabIndex = 5;
            RemoveStudB.Text = "Remove student";
            RemoveStudB.UseVisualStyleBackColor = true;
            RemoveStudB.Click += RemoveStudB_Click;
            // 
            // Participants
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(532, 539);
            Controls.Add(RemoveStudB);
            Controls.Add(AddStudB);
            Controls.Add(listViewNonPart);
            Controls.Add(listViewPart);
            Controls.Add(label1);
            Controls.Add(ActivityBox);
            Name = "Participants";
            Text = "Manage Participants";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox ActivityBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewPart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listViewNonPart;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button AddStudB;
        private System.Windows.Forms.Button RemoveStudB;
    }
}