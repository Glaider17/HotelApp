using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Forms;

public partial class PaymentsForm : Form
{
    private readonly User _currentUser;
    private readonly PaymentRepository _repo = new();
    private readonly ActionLogRepository _logRepo = new();

    public PaymentsForm(User user)
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
        dgv.DataSource = list.Select(p => new { p.Id, Бронирование = p.BookingInfo, Сумма = p.Amount, Дата = p.PaymentDate.ToString("yyyy-MM-dd HH:mm"), Способ = p.Method }).ToList();
        if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
    }

    private void btnSearch_Click(object sender, EventArgs e) => LoadData();
    private void btnAdd_Click(object sender, EventArgs e) => AddPayment();
    private void btnDelete_Click(object sender, EventArgs e) => DeletePayment();
    private void btnExport_Click(object sender, EventArgs e) => ExportToCsv();

    private void AddPayment()
    {
        var bookings = _repo.GetActiveBookings();
        if (bookings.Count == 0) { MessageBox.Show("Нет активных бронирований."); return; }
        var form = new Form { Text = "Добавление оплаты", Size = new Size(450, 300), FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent };
        var cmbBooking = new ComboBox { Location = new Point(140, 20), Size = new Size(250, 25), DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "GuestName", ValueMember = "Id", DataSource = bookings };
        var nudAmount = new NumericUpDown { Location = new Point(140, 60), Size = new Size(150, 25), DecimalPlaces = 2, Minimum = 0, Maximum = 1000000 };
        var dtpDate = new DateTimePicker { Location = new Point(140, 100), Size = new Size(150, 25), Format = DateTimePickerFormat.Custom, CustomFormat = "yyyy-MM-dd HH:mm:ss", Value = DateTime.Now };
        var cmbMethod = new ComboBox { Location = new Point(140, 140), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList, Items = { "Наличные", "Карта" } };
        cmbMethod.SelectedIndex = 0;
        var btnSave = new Button { Text = "Сохранить", Location = new Point(140, 190), Size = new Size(100, 35) };
        btnSave.Click += (s, e) =>
        {
            if (cmbBooking.SelectedItem == null || nudAmount.Value <= 0) { MessageBox.Show("Выберите бронирование и сумму."); return; }
            var pay = new Payment
            {
                BookingId = (int)cmbBooking.SelectedValue,
                Amount = nudAmount.Value,
                PaymentDate = dtpDate.Value,
                Method = cmbMethod.SelectedItem?.ToString()!
            };
            _repo.Add(pay);
            _logRepo.Log(_currentUser.Login, "CREATE", "Payment", pay.Id.ToString(), $"Оплата на сумму {pay.Amount}");
            LoadData();
            form.Close();
        };
        form.Controls.Add(new Label { Text = "Бронирование:", Location = new Point(30, 20), Size = new Size(100, 25) }); form.Controls.Add(cmbBooking);
        form.Controls.Add(new Label { Text = "Сумма:", Location = new Point(30, 60), Size = new Size(100, 25) }); form.Controls.Add(nudAmount);
        form.Controls.Add(new Label { Text = "Дата:", Location = new Point(30, 100), Size = new Size(100, 25) }); form.Controls.Add(dtpDate);
        form.Controls.Add(new Label { Text = "Способ:", Location = new Point(30, 140), Size = new Size(100, 25) }); form.Controls.Add(cmbMethod);
        form.Controls.Add(btnSave);
        form.ShowDialog();
    }

    private void DeletePayment()
    {
        if (dgv.CurrentRow?.DataBoundItem is object item)
        {
            int id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
            if (MessageBox.Show("Удалить оплату?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(id);
                _logRepo.Log(_currentUser.Login, "DELETE", "Payment", id.ToString(), "Удалена оплата");
                LoadData();
            }
        }
        else MessageBox.Show("Выберите запись.");
    }

    private void ExportToCsv()
    {
        var data = _repo.GetAll(txtSearch.Text);
        CsvExporter.ExportToCsv(data, $"Payments_{DateTime.Now:yyyyMMdd_HHmmss}.csv", _currentUser.Login, _logRepo);
    }

    private void ApplyPermissions()
    {
        bool canEdit = _currentUser.RoleName != "user";
        btnAdd.Enabled = btnDelete.Enabled = canEdit;
    }
}