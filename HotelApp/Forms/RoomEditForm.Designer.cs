namespace HotelApp.Forms
{
    partial class RoomEditForm
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
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            txtNumber = new TextBox();
            cbType = new ComboBox();
            cbStatus = new ComboBox();
            nudCapacity = new NumericUpDown();
            nudPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Номер:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Тип:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 2;
            label3.Text = "Вместимость:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 140);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 3;
            label4.Text = "Цена за ночь:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 180);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 4;
            label5.Text = "Статус:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(120, 20);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(200, 23);
            txtNumber.TabIndex = 6;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "Стандарт, Люкс, Студия" });
            cbType.Location = new Point(120, 60);
            cbType.Name = "cbType";
            cbType.Size = new Size(200, 23);
            cbType.TabIndex = 7;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Свободен, Занят, Ремонт" });
            cbStatus.Location = new Point(120, 180);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(200, 23);
            cbStatus.TabIndex = 8;
            // 
            // nudCapacity
            // 
            nudCapacity.Location = new Point(120, 100);
            nudCapacity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(100, 23);
            nudCapacity.TabIndex = 9;
            nudCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new Point(120, 140);
            nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(150, 23);
            nudPrice.TabIndex = 10;
            // 
            // RoomEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(nudPrice);
            Controls.Add(nudCapacity);
            Controls.Add(cbStatus);
            Controls.Add(cbType);
            Controls.Add(txtNumber);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RoomEditForm";
            Text = "RoomEditForm";
            Load += RoomEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private TextBox txtNumber;
        private ComboBox cbType;
        private ComboBox cbStatus;
        private NumericUpDown nudCapacity;
        private NumericUpDown nudPrice;
    }
}