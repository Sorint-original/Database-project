namespace SomerenUI
{
    partial class RevenueReport
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
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            textBox1 = new System.Windows.Forms.TextBox();
            calculateB = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(107, 78);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 32);
            label1.TabIndex = 0;
            label1.Text = "Start :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(107, 175);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 32);
            label2.TabIndex = 1;
            label2.Text = "End :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(260, 292);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 32);
            label3.TabIndex = 2;
            label3.Text = "../../..";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(235, 345);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 32);
            label4.TabIndex = 3;
            label4.Text = "../../..";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(107, 402);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(129, 32);
            label5.TabIndex = 4;
            label5.Text = "Costumer :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(107, 210);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(400, 39);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new System.Drawing.Point(107, 113);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(400, 39);
            dateTimePicker2.TabIndex = 6;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(107, 450);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(648, 323);
            textBox1.TabIndex = 7;
            // 
            // calculateB
            // 
            calculateB.Location = new System.Drawing.Point(605, 808);
            calculateB.Name = "calculateB";
            calculateB.Size = new System.Drawing.Size(150, 52);
            calculateB.TabIndex = 8;
            calculateB.Text = "Calculate";
            calculateB.UseVisualStyleBackColor = true;
            calculateB.Click += calculateB_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(107, 292);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(147, 32);
            label6.TabIndex = 9;
            label6.Text = "Drinks Sold :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(107, 345);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(122, 32);
            label7.TabIndex = 10;
            label7.Text = "Turnover :";
            // 
            // RevenueReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(856, 912);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(calculateB);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RevenueReport";
            Text = "RevenueReport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button calculateB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}