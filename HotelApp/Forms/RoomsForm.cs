using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Forms;

public partial class RoomsForm : Form
{
    private readonly User _currentUser;
    private readonly RoomRepository _repo = new();
    private readonly ActionLogRepository _logRepo = new();
    private readonly BookingRepository _bookingRepo = new();

    public RoomsForm(User user)
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
    private void btnAdd_Click(object sender, EventArgs e) => AddEditRoom(null);
    private void btnEdit_Click(object sender, EventArgs e) => EditRoom();
    private void btnDelete_Click(object sender, EventArgs e) => DeleteRoom();
    private void btnExport_Click(object sender, EventArgs e) => ExportToCsv();

    private void AddEditRoom(Room room)
    {
        var form = new Form
        {
            Text = room == null ? "Добавление номера" : "Редактирование номера",
            Size = new Size(400, 300),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent
        };
        var txtNumber = new TextBox { Location = new Point(120, 20), Size = new Size(200, 25) };
        var cbType = new ComboBox { Location = new Point(120, 60), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        cbType.Items.AddRange(new[] { "Стандарт", "Люкс", "Студия" });
        var nudCapacity = new NumericUpDown { Location = new Point(120, 100), Size = new Size(100, 25), Minimum = 1, Maximum = 10 };
        var nudPrice = new NumericUpDown { Location = new Point(120, 140), Size = new Size(150, 25), DecimalPlaces = 2, Minimum = 0, Maximum = 100000 };
        var cbStatus = new ComboBox { Location = new Point(120, 180), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
        cbStatus.Items.AddRange(new[] { "Свободен", "Занят", "Ремонт" });

        if (room != null)
        {
            txtNumber.Text = room.Number;
            cbType.SelectedItem = room.Type;
            nudCapacity.Value = room.Capacity;
            nudPrice.Value = room.PricePerNight;
            cbStatus.SelectedItem = room.Status;
        }
        else cbType.SelectedIndex = 0;

        var btnSave = new Button { Text = "Сохранить", Location = new Point(120, 220), Size = new Size(100, 30) };
        btnSave.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Введите номер.");
                return;
            }
            var newRoom = new Room
            {
                Number = txtNumber.Text,
                Type = cbType.SelectedItem?.ToString()!,
                Capacity = (int)nudCapacity.Value,
                PricePerNight = nudPrice.Value,
                Status = cbStatus.SelectedItem?.ToString()!
            };
            if (room == null)
            {
                _repo.Add(newRoom);
                _logRepo.Log(_currentUser.Login, "CREATE", "Room", newRoom.Number, $"Добавлен номер {newRoom.Number}");
            }
            else
            {
                newRoom.Id = room.Id;
                _repo.Update(newRoom);
                _logRepo.Log(_currentUser.Login, "UPDATE", "Room", newRoom.Number, $"Изменён номер {newRoom.Number}");
            }
            LoadData();
            form.Close();
        };

        form.Controls.Add(new Label { Text = "Номер:", Location = new Point(30, 20), Size = new Size(80, 25) });
        form.Controls.Add(txtNumber);
        form.Controls.Add(new Label { Text = "Тип:", Location = new Point(30, 60), Size = new Size(80, 25) });
        form.Controls.Add(cbType);
        form.Controls.Add(new Label { Text = "Вместимость:", Location = new Point(30, 100), Size = new Size(80, 25) });
        form.Controls.Add(nudCapacity);
        form.Controls.Add(new Label { Text = "Цена за ночь:", Location = new Point(30, 140), Size = new Size(80, 25) });
        form.Controls.Add(nudPrice);
        form.Controls.Add(new Label { Text = "Статус:", Location = new Point(30, 180), Size = new Size(80, 25) });
        form.Controls.Add(cbStatus);
        form.Controls.Add(btnSave);
        form.ShowDialog();
    }

    private void EditRoom()
    {
        if (dgv.CurrentRow?.DataBoundItem is Room r)
            AddEditRoom(r);
        else
            MessageBox.Show("Выберите запись.");
    }

    private void DeleteRoom()
    {
        if (dgv.CurrentRow?.DataBoundItem is Room r)
        {
            if (_bookingRepo.HasAnyBookingsForRoom(r.Id))
            {
                MessageBox.Show(
                    "Невозможно удалить номер, так как на него есть активные или завершённые бронирования.\n" +
                    "Сначала удалите или завершите бронирования, связанные с этим номером.",
                    "Ошибка удаления",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить номер \"{r.Number}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(r.Id);
                _logRepo.Log(_currentUser.Login, "DELETE", "Room", r.Number, $"Удалён номер {r.Number}");
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
        CsvExporter.ExportToCsv(data, $"Rooms_{DateTime.Now:yyyyMMdd_HHmmss}.csv", _currentUser.Login, _logRepo);
    }

    private void ApplyPermissions()
    {
        bool canEdit = _currentUser.RoleName != "user";
        btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = canEdit;
    }
}