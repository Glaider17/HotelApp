namespace HotelApp.Forms
{
    partial class RegisterForm
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
            lblFullName = new Label();
            lblLogin = new Label();
            lblPassword = new Label();
            lblConfirm = new Label();
            txtFullName = new TextBox();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(68, 45);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(34, 15);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "ФИО";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(53, 84);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(41, 15);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(53, 127);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(49, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль";
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(34, 173);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(94, 15);
            lblConfirm.TabIndex = 3;
            lblConfirm.Text = "Подтверждение";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(149, 42);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 23);
            txtFullName.TabIndex = 4;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(149, 81);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(100, 23);
            txtLogin.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(149, 124);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(149, 170);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(118, 242);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(131, 23);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(txtFullName);
            Controls.Add(lblConfirm);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(lblFullName);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFullName;
        private Label lblLogin;
        private Label lblPassword;
        private Label lblConfirm;
        private TextBox txtFullName;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
    }
}