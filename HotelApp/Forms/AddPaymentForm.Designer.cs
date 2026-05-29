namespace HotelApp.Forms
{
    partial class AddPaymentForm
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
            cmbBooking = new ComboBox();
            cmbMethod = new ComboBox();
            nudAmount = new NumericUpDown();
            dtpPaymentDate = new DateTimePicker();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Бронирование:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Сумма:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 2;
            label3.Text = "Дата оплаты:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 140);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Способ:";
            // 
            // cmbBooking
            // 
            cmbBooking.FormattingEnabled = true;
            cmbBooking.Location = new Point(140, 20);
            cmbBooking.Name = "cmbBooking";
            cmbBooking.Size = new Size(250, 23);
            cmbBooking.TabIndex = 4;
            // 
            // cmbMethod
            // 
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(140, 140);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(150, 23);
            cmbMethod.TabIndex = 5;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(140, 60);
            nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(150, 23);
            nudAmount.TabIndex = 6;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(140, 100);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(150, 23);
            dtpPaymentDate.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(140, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddPaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(dtpPaymentDate);
            Controls.Add(nudAmount);
            Controls.Add(cmbMethod);
            Controls.Add(cmbBooking);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddPaymentForm";
            Text = "AddPaymentForm";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbBooking;
        private ComboBox cmbMethod;
        private NumericUpDown nudAmount;
        private DateTimePicker dtpPaymentDate;
        private Button btnSave;
    }
}