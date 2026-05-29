using HotelApp.Data;

namespace HotelApp.Forms;

public partial class LoginAttemptsForm : Form
{
    private readonly UserRepository _repo = new();

    public LoginAttemptsForm()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        var list = _repo.GetAllLoginAttempts();
        dgv.DataSource = null;
        dgv.DataSource = list.Select(a => new { a.Id, Логин = a.UserLogin, Успех = a.IsSuccess ? "Да" : "Нет", a.Message, ДатаВремя = a.CreatedAt }).ToList();
        if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
    }

    private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
}