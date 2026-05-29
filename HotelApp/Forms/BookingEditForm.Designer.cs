namespace HotelApp.Forms
{
    partial class BookingEditForm
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
            label6 = new Label();
            cmbGuest = new ComboBox();
            cmbRoom = new ComboBox();
            cmbStatus = new ComboBox();
            dtpCheckIn = new DateTimePicker();
            dtpCheckOut = new DateTimePicker();
            nudTotal = new NumericUpDown();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTotal).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Гость:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Номер:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Дата заезда:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 140);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 3;
            label4.Text = "Дата выезда:";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 220);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 5;
            label6.Text = "Сумма (руб):";
            // 
            // cmbGuest
            // 
            cmbGuest.DisplayMember = "FullName";
            cmbGuest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuest.FormattingEnabled = true;
            cmbGuest.Location = new Point(120, 20);
            cmbGuest.Name = "cmbGuest";
            cmbGuest.Size = new Size(121, 23);
            cmbGuest.TabIndex = 6;
            cmbGuest.ValueMember = "Id";
            // 
            // cmbRoom
            // 
            cmbRoom.DisplayMember = "Number";
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(120, 60);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(121, 23);
            cmbRoom.TabIndex = 7;
            cmbRoom.ValueMember = "Id";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Активно, Завершено, Отменено" });
            cmbStatus.Location = new Point(120, 180);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 8;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(120, 100);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(150, 23);
            dtpCheckIn.TabIndex = 9;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(120, 140);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(150, 23);
            dtpCheckOut.TabIndex = 10;
            // 
            // nudTotal
            // 
            nudTotal.DecimalPlaces = 2;
            nudTotal.Location = new Point(120, 220);
            nudTotal.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTotal.Name = "nudTotal";
            nudTotal.Size = new Size(150, 23);
            nudTotal.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 270);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // BookingEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(nudTotal);
            Controls.Add(dtpCheckOut);
            Controls.Add(dtpCheckIn);
            Controls.Add(cmbStatus);
            Controls.Add(cmbRoom);
            Controls.Add(cmbGuest);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BookingEditForm";
            Text = "BookingEditForm";
            Load += BookingEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudTotal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbGuest;
        private ComboBox cmbRoom;
        private ComboBox cmbStatus;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private NumericUpDown nudTotal;
        private Button btnSave;
    }
}