using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Forms;

public partial class ServicesForm : Form
{
    private readonly User _currentUser;
    private readonly ServiceRepository _repo = new();
    private readonly ActionLogRepository _logRepo = new();

    public ServicesForm(User user)
    {
        InitializeComponent();
        _currentUser = user;
        LoadData();
        ApplyPermissions();
    }

    private void LoadData()
    {
        dgv.DataSource = null;
        dgv.DataSource = _repo.GetAll(txtSearch.Text);
        if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
    }

    private void btnSearch_Click(object sender, EventArgs e) => LoadData();
    private void btnAdd_Click(object sender, EventArgs e) => AddEditService(null);
    private void btnEdit_Click(object sender, EventArgs e) => EditService();
    private void btnDelete_Click(object sender, EventArgs e) => DeleteService();
    private void btnExport_Click(object sender, EventArgs e) => ExportToCsv();

    private void AddEditService(Service service)
    {
        var form = new Form
        {
            Text = service == null ? "Добавление услуги" : "Редактирование",
            Size = new Size(400, 280),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent
        };
        var txtName = new TextBox { Location = new Point(120, 20), Size = new Size(200, 25) };
        var nudPrice = new NumericUpDown { Location = new Point(120, 60), Size = new Size(150, 25), DecimalPlaces = 2, Minimum = 0, Maximum = 100000 };
        var txtCategory = new TextBox { Location = new Point(120, 100), Size = new Size(200, 25) };
        if (service != null)
        {
            txtName.Text = service.Name;
            nudPrice.Value = service.Price;
            txtCategory.Text = service.Category;
        }
        var btnSave = new Button { Text = "Сохранить", Location = new Point(120, 160), Size = new Size(100, 35) };
        btnSave.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Введите название."); return; }
            var newService = new Service
            {
                Name = txtName.Text.Trim(),
                Price = nudPrice.Value,
                Category = txtCategory.Text.Trim()
            };
            if (service == null)
            {
                _repo.Add(newService);
                _logRepo.Log(_currentUser.Login, "CREATE", "Service", newService.Name, $"Добавлена услуга {newService.Name}");
            }
            else
            {
                newService.Id = service.Id;
                _repo.Update(newService);
                _logRepo.Log(_currentUser.Login, "UPDATE", "Service", newService.Name, $"Изменена услуга {newService.Name}");
            }
            LoadData();
            form.Close();
        };
        form.Controls.Add(new Label { Text = "Название:", Location = new Point(30, 20), Size = new Size(80, 25) }); form.Controls.Add(txtName);
        form.Controls.Add(new Label { Text = "Цена:", Location = new Point(30, 60), Size = new Size(80, 25) }); form.Controls.Add(nudPrice);
        form.Controls.Add(new Label { Text = "Категория:", Location = new Point(30, 100), Size = new Size(80, 25) }); form.Controls.Add(txtCategory);
        form.Controls.Add(btnSave);
        form.ShowDialog();
    }

    private void EditService()
    {
        if (dgv.CurrentRow?.DataBoundItem is Service s) AddEditService(s);
        else MessageBox.Show("Выберите запись.");
    }

    private void DeleteService()
    {
        if (dgv.CurrentRow?.DataBoundItem is Service s && MessageBox.Show("Удалить услугу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _repo.Delete(s.Id);
            _logRepo.Log(_currentUser.Login, "DELETE", "Service", s.Name, $"Удалена услуга {s.Name}");
            LoadData();
        }
    }

    private void ExportToCsv()
    {
        var data = _repo.GetAll(txtSearch.Text);
        CsvExporter.ExportToCsv(data, $"Services_{DateTime.Now:yyyyMMdd_HHmmss}.csv", _currentUser.Login, _logRepo);
    }

    private void ApplyPermissions()
    {
        bool canEdit = _currentUser.RoleName != "user";
        btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = canEdit;
    }
}