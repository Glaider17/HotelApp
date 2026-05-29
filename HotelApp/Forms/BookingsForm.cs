using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Forms;

public partial class BookingsForm : Form
{
    private readonly User _currentUser;
    private readonly BookingRepository _repo = new();
    private readonly GuestRepository _guestRepo = new();
    private readonly RoomRepository _roomRepo = new();
    private readonly ActionLogRepository _logRepo = new();
    private readonly PaymentRepository _paymentRepo = new();

    public BookingsForm(User user)
    {
        InitializeComponent();
        _currentUser = user;
        LoadData();
        ApplyPermissions();
    }

    private void LoadData()
    {
        var list = _repo.GetAll(txtSearch.Text);
        dgv.DataSource = null;
        dgv.DataSource = list.Select(b => new { b.Id, Гость = b.GuestName, Номер = b.RoomNumber, Заезд = b.CheckInDate.ToShortDateString(), Выезд = b.CheckOutDate.ToShortDateString(), Статус = b.Status, Сумма = b.TotalAmount }).ToList();
        if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
    }

    private void btnSearch_Click(object sender, EventArgs e) => LoadData();
    private void btnAdd_Click(object sender, EventArgs e) => AddEditBooking(null);
    private void btnEdit_Click(object sender, EventArgs e) => EditBooking();
    private void btnDelete_Click(object sender, EventArgs e) => DeleteBooking();
    private void btnExport_Click(object sender, EventArgs e) => ExportToCsv();

    private void AddEditBooking(Booking booking)
    {
        var form = new Form
        {
            Text = booking == null ? "Добавление бронирования" : "Редактирование",
            Size = new Size(480, 400),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent
        };

        var guests = _guestRepo.GetAll();
        var cmbGuest = new ComboBox { Location = new Point(120, 20), Size = new Size(280, 25), DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "FullName", ValueMember = "Id", DataSource = guests };
        var rooms = _roomRepo.GetAll();
        var cmbRoom = new ComboBox { Location = new Point(120, 60), Size = new Size(280, 25), DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Number", ValueMember = "Id", DataSource = rooms };
        var dtpIn = new DateTimePicker { Location = new Point(120, 100), Size = new Size(150, 25), Format = DateTimePickerFormat.Short };
        var dtpOut = new DateTimePicker { Location = new Point(120, 140), Size = new Size(150, 25), Format = DateTimePickerFormat.Short, Value = DateTime.Now.AddDays(1) };
        var cbStatus = new ComboBox { Location = new Point(120, 180), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList, Items = { "Активно", "Завершено", "Отменено" } };
        cbStatus.SelectedIndex = 0;
        var nudTotal = new NumericUpDown { Location = new Point(120, 220), Size = new Size(150, 25), DecimalPlaces = 2, Minimum = 0, Maximum = 1000000 };

        if (booking != null)
        {
            cmbGuest.SelectedValue = booking.GuestId;
            cmbRoom.SelectedValue = booking.RoomId;
            dtpIn.Value = booking.CheckInDate;
            dtpOut.Value = booking.CheckOutDate;
            cbStatus.SelectedItem = booking.Status;
            nudTotal.Value = booking.TotalAmount;
        }
        else
        {
            void UpdateTotal()
            {
                if (cmbRoom.SelectedItem is Room r)
                {
                    int days = (dtpOut.Value - dtpIn.Value).Days;
                    if (days < 1) days = 1;
                    nudTotal.Value = r.PricePerNight * days;
                }
            }
            dtpIn.ValueChanged += (s, e) => UpdateTotal();
            dtpOut.ValueChanged += (s, e) => UpdateTotal();
            cmbRoom.SelectedIndexChanged += (s, e) => UpdateTotal();
            UpdateTotal();
        }

        var btnSave = new Button { Text = "Сохранить", Location = new Point(120, 270), Size = new Size(100, 35) };
        btnSave.Click += (s, e) =>
        {
            if (cmbGuest.SelectedItem == null || cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Выберите гостя и номер.");
                return;
            }

            int roomId = (int)cmbRoom.SelectedValue;
            DateTime checkIn = dtpIn.Value;
            DateTime checkOut = dtpOut.Value;
            int currentBookingId = booking?.Id ?? 0;

            if (_repo.IsRoomOccupied(roomId, checkIn, checkOut, currentBookingId))
            {
                MessageBox.Show(
                    "Выбранный номер уже забронирован на указанные даты.\n" +
                    "Пожалуйста, выберите другие даты или другой номер.",
                    "Номер занят",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var newBooking = new Booking
            {
                GuestId = (int)cmbGuest.SelectedValue,
                RoomId = (int)cmbRoom.SelectedValue,
                CheckInDate = dtpIn.Value,
                CheckOutDate = dtpOut.Value,
                Status = cbStatus.SelectedItem?.ToString()!,
                TotalAmount = nudTotal.Value
            };

            if (booking == null)
            {
                _repo.Add(newBooking);
                _logRepo.Log(_currentUser.Login, "CREATE", "Booking", newBooking.Id.ToString(), "Добавлено бронирование");
            }
            else
            {
                newBooking.Id = booking.Id;
                _repo.Update(newBooking);
                _logRepo.Log(_currentUser.Login, "UPDATE", "Booking", newBooking.Id.ToString(), "Изменено бронирование");
            }
            LoadData();
            form.Close();
        };

        int y = 20;
        form.Controls.Add(new Label { Text = "Гость:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(cmbGuest);
        y += 40; form.Controls.Add(new Label { Text = "Номер:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(cmbRoom);
        y += 40; form.Controls.Add(new Label { Text = "Заезд:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(dtpIn);
        y += 40; form.Controls.Add(new Label { Text = "Выезд:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(dtpOut);
        y += 40; form.Controls.Add(new Label { Text = "Статус:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(cbStatus);
        y += 40; form.Controls.Add(new Label { Text = "Сумма:", Location = new Point(30, y), Size = new Size(80, 25) }); form.Controls.Add(nudTotal);
        y += 50; form.Controls.Add(btnSave);
        form.ShowDialog();
    }

    private void EditBooking()
    {
        if (dgv.CurrentRow?.DataBoundItem is object item)
        {
            int id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
            var b = _repo.GetById(id);
            if (b != null) AddEditBooking(b);
        }
        else MessageBox.Show("Выберите запись.");
    }

    private void DeleteBooking()
    {
        if (dgv.CurrentRow?.DataBoundItem is object item)
        {
            int id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
            
            if (_paymentRepo.HasPayments(id))
            {
                MessageBox.Show(
                    "Невозможно удалить бронирование, так как по нему есть платежи.\n" +
                    "Сначала удалите связанные платежи.",
                    "Ошибка удаления",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить бронирование?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(id);
                _logRepo.Log(_currentUser.Login, "DELETE", "Booking", id.ToString(), "Удалено бронирование");
                LoadData();
            }
        }
    }

    private void ExportToCsv()
    {
        var data = _repo.GetAll(txtSearch.Text);
        CsvExporter.ExportToCsv(data, $"Bookings_{DateTime.Now:yyyyMMdd_HHmmss}.csv", _currentUser.Login, _logRepo);
    }

    private void ApplyPermissions()
    {
        bool canEdit = _currentUser.RoleName != "user";
        btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = canEdit;
    }
}