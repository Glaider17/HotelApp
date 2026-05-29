using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;


namespace HotelApp.Forms;


public partial class GuestsForm : Form
{
    private readonly User _currentUser;
    private readonly GuestRepository _repo = new();
    private readonly ActionLogRepository _logRepo = new();
    private readonly BookingRepository _bookingRepo = new();

    public GuestsForm(User user)
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
    private void btnAdd_Click(object sender, EventArgs e) => AddEditGuest(null);
    private void btnEdit_Click(object sender, EventArgs e) => EditGuest();
    private void btnDelete_Click(object sender, EventArgs e) => DeleteGuest();
    private void btnExport_Click(object sender, EventArgs e) => ExportToCsv();

    private void AddEditGuest(Guest guest)
    {
        var form = new Form
        {
            Text = guest == null ? "Добавление гостя" : "Редактирование гостя",
            Size = new Size(450, 350),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent
        };
        var txtFullName = new TextBox { Location = new Point(120, 20), Size = new Size(250, 25) };
        var txtPassport = new TextBox { Location = new Point(120, 60), Size = new Size(250, 25) };
        var txtPhone = new TextBox { Location = new Point(120, 100), Size = new Size(250, 25) };
        var txtEmail = new TextBox { Location = new Point(120, 140), Size = new Size(250, 25) };
        var chkActive = new CheckBox { Text = "Активен", Location = new Point(120, 180), Size = new Size(100, 25), Checked = true };

        if (guest != null)
        {
            txtFullName.Text = guest.FullName;
            txtPassport.Text = guest.Passport;
            txtPhone.Text = guest.Phone;
            txtEmail.Text = guest.Email;
            chkActive.Checked = guest.IsActive;
        }

        var btnSave = new Button { Text = "Сохранить", Location = new Point(120, 230), Size = new Size(100, 35) };
        btnSave.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPassport.Text))
            {
                MessageBox.Show("ФИО и паспорт обязательны.");
                return;
            }
            var newGuest = new Guest
            {
                FullName = txtFullName.Text.Trim(),
                Passport = txtPassport.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                IsActive = chkActive.Checked
            };
            if (guest == null)
            {
                _repo.Add(newGuest);
                _logRepo.Log(_currentUser.Login, "CREATE", "Guest", newGuest.FullName, $"Добавлен гость {newGuest.FullName}");
            }
            else
            {
                newGuest.Id = guest.Id;
                _repo.Update(newGuest);
                _logRepo.Log(_currentUser.Login, "UPDATE", "Guest", newGuest.FullName, $"Изменён гость {newGuest.FullName}");
            }
            LoadData();
            form.Close();
        };
        form.Controls.Add(new Label { Text = "ФИО:", Location = new Point(30, 20), Size = new Size(80, 25) }); form.Controls.Add(txtFullName);
        form.Controls.Add(new Label { Text = "Паспорт:", Location = new Point(30, 60), Size = new Size(80, 25) }); form.Controls.Add(txtPassport);
        form.Controls.Add(new Label { Text = "Телефон:", Location = new Point(30, 100), Size = new Size(80, 25) }); form.Controls.Add(txtPhone);
        form.Controls.Add(new Label { Text = "Email:", Location = new Point(30, 140), Size = new Size(80, 25) }); form.Controls.Add(txtEmail);
        form.Controls.Add(chkActive);
        form.Controls.Add(btnSave);
        form.ShowDialog();
    }

    private void EditGuest()
    {
        if (dgv.CurrentRow?.DataBoundItem is Guest g) AddEditGuest(g);
        else MessageBox.Show("Выберите запись.");
    }

    private void DeleteGuest()
    {
        if (dgv.CurrentRow?.DataBoundItem is Guest g)
        {
            
            bool hasBookings = _bookingRepo.HasAnyBookings(g.Id);
            if (hasBookings)
            {
                MessageBox.Show(
                    "Невозможно удалить гостя, так как у него есть связанные бронирования.\n" +
                    "Сначала удалите или завершите бронирования этого гостя.",
                    "Ошибка удаления",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить гостя \"{g.FullName}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(g.Id);
                _logRepo.Log(_currentUser.Login, "DELETE", "Guest", g.FullName, $"Удалён гость {g.FullName}");
                LoadData();
            }
        }
        else
        {
            MessageBox.Show("Выберите запись для удаления.");
        }
    }

    private void ExportToCsv()
    {
        var data = _repo.GetAll(txtSearch.Text);
        CsvExporter.ExportToCsv(data, $"Guests_{DateTime.Now:yyyyMMdd_HHmmss}.csv", _currentUser.Login, _logRepo);
    }

    private void ApplyPermissions()
    {
        bool canEdit = _currentUser.RoleName != "user";
        btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = canEdit;
    }
}