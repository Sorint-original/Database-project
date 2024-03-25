namespace SomerenUI
{
    partial class AddDrinkForm
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
            NameTB = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            PriceTB = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            StockTB = new System.Windows.Forms.TextBox();
            AddButton = new System.Windows.Forms.Button();
            AlcoholCB = new System.Windows.Forms.ComboBox();
            IdLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(45, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Drink Id: ";
            // 
            // NameTB
            // 
            NameTB.Location = new System.Drawing.Point(126, 115);
            NameTB.Name = "NameTB";
            NameTB.Size = new System.Drawing.Size(100, 23);
            NameTB.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(45, 118);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 161);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Price:";
            // 
            // PriceTB
            // 
            PriceTB.Location = new System.Drawing.Point(126, 158);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new System.Drawing.Size(100, 23);
            PriceTB.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(45, 206);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Alcoholic:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(45, 251);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 15);
            label5.TabIndex = 8;
            label5.Text = "Stock Aount:";
            // 
            // StockTB
            // 
            StockTB.Location = new System.Drawing.Point(126, 248);
            StockTB.Name = "StockTB";
            StockTB.Size = new System.Drawing.Size(100, 23);
            StockTB.TabIndex = 7;
            // 
            // AddButton
            // 
            AddButton.Location = new System.Drawing.Point(30, 313);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(75, 23);
            AddButton.TabIndex = 9;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AlcoholCB
            // 
            AlcoholCB.FormattingEnabled = true;
            AlcoholCB.Items.AddRange(new object[] { "True", "False" });
            AlcoholCB.Location = new System.Drawing.Point(126, 203);
            AlcoholCB.Name = "AlcoholCB";
            AlcoholCB.Size = new System.Drawing.Size(100, 23);
            AlcoholCB.TabIndex = 10;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new System.Drawing.Point(126, 46);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new System.Drawing.Size(0, 15);
            IdLabel.TabIndex = 11;
            // 
            // AddDrinkForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(273, 368);
            Controls.Add(IdLabel);
            Controls.Add(AlcoholCB);
            Controls.Add(AddButton);
            Controls.Add(label5);
            Controls.Add(StockTB);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(PriceTB);
            Controls.Add(label2);
            Controls.Add(NameTB);
            Controls.Add(label1);
            Name = "AddDrinkForm";
            Text = "Add Drink";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PriceTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StockTB;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox AlcoholCB;
        private System.Windows.Forms.Label IdLabel;
    }
}