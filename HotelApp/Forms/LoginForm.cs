using HotelApp.Data;
using HotelApp.Services;
using HotelApp.Models;

namespace HotelApp.Forms;

public partial class LoginForm : Form
{
    private readonly CaptchaService _captcha;
    private readonly AuthService _authService;

    public LoginForm()
    {
        InitializeComponent(); 
        _captcha = new CaptchaService();
        _authService = new AuthService(new UserRepository());
        this.Load += LoginForm_Load;
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        lblCaptcha.Text = _captcha.Generate();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (!_captcha.Validate(txtCaptcha.Text))
            {
                lblCaptcha.Text = _captcha.Generate();
                txtCaptcha.Clear();
                MessageBox.Show("CAPTCHA введена неверно.");
                return;
            }
            var user = _authService.Login(txtLogin.Text.Trim(), txtPassword.Text);
            var mainForm = new MainForm(user);
            mainForm.Show();
            this.Hide();
        }
        catch (Exception ex)
        {
            lblCaptcha.Text = _captcha.Generate();
            txtCaptcha.Clear();
            MessageBox.Show(ex.Message);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        new RegisterForm().ShowDialog();
    }
}