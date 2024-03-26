namespace SomerenUI
{
    partial class OrderForm
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
            listViewDrinks = new System.Windows.Forms.ListView();
            columnHeader23 = new System.Windows.Forms.ColumnHeader();
            columnHeader24 = new System.Windows.Forms.ColumnHeader();
            columnHeader25 = new System.Windows.Forms.ColumnHeader();
            columnHeader26 = new System.Windows.Forms.ColumnHeader();
            columnHeader27 = new System.Windows.Forms.ColumnHeader();
            columnHeader28 = new System.Windows.Forms.ColumnHeader();
            listViewStudents = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            OrderAmountTB = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            OrderB = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            PriceL = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // listViewDrinks
            // 
            listViewDrinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader23, columnHeader24, columnHeader25, columnHeader26, columnHeader27, columnHeader28 });
            listViewDrinks.FullRowSelect = true;
            listViewDrinks.Location = new System.Drawing.Point(15, 49);
            listViewDrinks.Margin = new System.Windows.Forms.Padding(6);
            listViewDrinks.MultiSelect = false;
            listViewDrinks.Name = "listViewDrinks";
            listViewDrinks.Size = new System.Drawing.Size(604, 206);
            listViewDrinks.TabIndex = 2;
            listViewDrinks.UseCompatibleStateImageBehavior = false;
            listViewDrinks.View = System.Windows.Forms.View.Details;
            listViewDrinks.SelectedIndexChanged += listViewDrinks_SelectedIndexChanged;
            // 
            // columnHeader23
            // 
            columnHeader23.Text = "Drink Id";
            columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            columnHeader24.Text = "Drink Name";
            columnHeader24.Width = 100;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "Price";
            columnHeader25.Width = 100;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "Type";
            columnHeader26.Width = 100;
            // 
            // columnHeader27
            // 
            columnHeader27.Text = "Stock status";
            columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "Amount sold";
            columnHeader28.Width = 100;
            // 
            // listViewStudents
            // 
            listViewStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewStudents.FullRowSelect = true;
            listViewStudents.Location = new System.Drawing.Point(15, 296);
            listViewStudents.MultiSelect = false;
            listViewStudents.Name = "listViewStudents";
            listViewStudents.Size = new System.Drawing.Size(604, 206);
            listViewStudents.TabIndex = 3;
            listViewStudents.UseCompatibleStateImageBehavior = false;
            listViewStudents.View = System.Windows.Forms.View.Details;
            listViewStudents.SelectedIndexChanged += this.listViewStudents_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Student Number";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "FirstName";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "LastName";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Phone Number";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Class";
            columnHeader5.Width = 100;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(15, 11);
            label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(81, 32);
            label5.TabIndex = 4;
            label5.Text = "Drinks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(15, 261);
            label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(107, 32);
            label1.TabIndex = 5;
            label1.Text = "Students";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(656, 157);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(141, 32);
            label2.TabIndex = 6;
            label2.Text = "Make Order";
            // 
            // OrderAmountTB
            // 
            OrderAmountTB.Location = new System.Drawing.Point(656, 232);
            OrderAmountTB.Name = "OrderAmountTB";
            OrderAmountTB.Size = new System.Drawing.Size(100, 23);
            OrderAmountTB.TabIndex = 7;
            OrderAmountTB.TextChanged += OrderAmountTB_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(656, 214);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 15);
            label3.TabIndex = 8;
            label3.Text = "Order amount:";
            // 
            // OrderB
            // 
            OrderB.Location = new System.Drawing.Point(656, 317);
            OrderB.Name = "OrderB";
            OrderB.Size = new System.Drawing.Size(115, 34);
            OrderB.TabIndex = 9;
            OrderB.Text = "Order";
            OrderB.UseVisualStyleBackColor = true;
            OrderB.Click += OrderB_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(656, 278);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 15);
            label4.TabIndex = 10;
            label4.Text = "Price : ";
            // 
            // PriceL
            // 
            PriceL.AutoSize = true;
            PriceL.Location = new System.Drawing.Point(703, 278);
            PriceL.Name = "PriceL";
            PriceL.Size = new System.Drawing.Size(0, 15);
            PriceL.TabIndex = 11;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(817, 546);
            Controls.Add(PriceL);
            Controls.Add(label4);
            Controls.Add(OrderB);
            Controls.Add(label3);
            Controls.Add(OrderAmountTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(listViewStudents);
            Controls.Add(listViewDrinks);
            Name = "OrderForm";
            Text = "Order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView listViewDrinks;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OrderAmountTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OrderB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PriceL;
    }
}