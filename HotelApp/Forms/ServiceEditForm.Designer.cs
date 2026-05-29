namespace HotelApp.Forms
{
    partial class ServiceEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtCategory = new TextBox();
            nudPrice = new NumericUpDown();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Цена:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 2;
            label3.Text = "Категория:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 3;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(120, 100);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(200, 23);
            txtCategory.TabIndex = 4;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new Point(120, 60);
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(150, 23);
            nudPrice.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // ServiceEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(nudPrice);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ServiceEditForm";
            Text = "ServiceEditForm";
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtCategory;
        private NumericUpDown nudPrice;
        private Button btnSave;
    }
}