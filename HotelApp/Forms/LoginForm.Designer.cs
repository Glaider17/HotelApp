namespace HotelApp.Forms
{
    partial class LoginForm
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
            lblLogin = new Label();
            lblPassword = new Label();
            lblCaptcha = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtCaptcha = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(30, 30);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(41, 15);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(49, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль";
            // 
            // lblCaptcha
            // 
            lblCaptcha.AutoSize = true;
            lblCaptcha.Location = new Point(30, 110);
            lblCaptcha.Name = "lblCaptcha";
            lblCaptcha.Size = new Size(60, 15);
            lblCaptcha.TabIndex = 2;
            lblCaptcha.Text = "CAPTCHA";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(120, 30);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(180, 23);
            txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(230, 110);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.Size = new Size(70, 23);
            txtCaptcha.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(120, 160);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(230, 160);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 30);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtCaptcha);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(lblCaptcha);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private Label lblPassword;
        private Label lblCaptcha;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtCaptcha;
        private Button btnLogin;
        private Button btnRegister;
    }
}