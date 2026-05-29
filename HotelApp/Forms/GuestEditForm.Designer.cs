namespace HotelApp.Forms
{
    partial class GuestEditForm
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
            txtFullName = new TextBox();
            txtPassport = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            chkActive = new CheckBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Паспорт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 2;
            label3.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 140);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(120, 20);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 23);
            txtFullName.TabIndex = 4;
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(120, 60);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(100, 23);
            txtPassport.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(120, 100);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 7;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(120, 180);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(71, 19);
            chkActive.TabIndex = 8;
            chkActive.Text = "Активен";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // GuestEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(chkActive);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtPassport);
            Controls.Add(txtFullName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GuestEditForm";
            Text = "GuestEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtFullName;
        private TextBox txtPassport;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private CheckBox chkActive;
        private Button btnSave;
    }
}