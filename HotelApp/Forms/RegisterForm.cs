using HotelApp.Data;

namespace HotelApp.Forms;

public partial class RegisterForm : Form
{
    private readonly UserRepository _userRepo = new();

    public RegisterForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string login = txtLogin.Text.Trim();
        string password = txtPassword.Text;
        string confirm = txtConfirmPassword.Text;

        if (string.IsNullOrWhiteSpace(fullName))
        {
            MessageBox.Show("Введите ФИО.");
            return;
        }
        if (login.Length < 4)
        {
            MessageBox.Show("Логин не менее 4 символов.");
            return;
        }
        if (password.Length < 6)
        {
            MessageBox.Show("Пароль не менее 6 символов.");
            return;
        }
        if (password != confirm)
        {
            MessageBox.Show("Пароли не совпадают.");
            return;
        }
        if (_userRepo.LoginExists(login))
        {
            MessageBox.Show("Логин уже занят.");
            return;
        }

        _userRepo.CreateUser(login, password, fullName, 3); 
        MessageBox.Show("Регистрация успешна!");
        this.Close();
    }
}