using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Forms;

public partial class MainForm : Form
{
    private readonly User _currentUser;
    private readonly RoomRepository _roomRepo = new();
    private readonly BookingRepository _bookingRepo = new();

    public MainForm(User user)
    {
        InitializeComponent();
        _currentUser = user;
        this.Text = $"Гостиница Уют - {_currentUser.FullName} ({_currentUser.RoleName})";
        LoadDashboard();
        LoadRecentBookings();
        ApplyRolePermissions();
        this.FormClosed += (s, e) => Application.Exit(); 
    }

    private void LoadDashboard()
    {
        lblFreeRooms.Text = $"Свободных номеров: {_roomRepo.GetAvailableRoomsCount()}";
        lblCheckIns.Text = $"Заездов сегодня: {_bookingRepo.GetCheckInsToday()}";
        lblCheckOuts.Text = $"Выездов сегодня: {_bookingRepo.GetCheckOutsToday()}";
    }

    private void LoadRecentBookings()
    {
        var list = _bookingRepo.GetAll(txtSearchBooking.Text);
        dgvRecentBookings.DataSource = null;
        dgvRecentBookings.DataSource = list.Select(b => new
        {
            b.Id,
            Гость = b.GuestName,
            Номер = b.RoomNumber,
            Заезд = b.CheckInDate.ToShortDateString(),
            Выезд = b.CheckOutDate.ToShortDateString(),
            Статус = b.Status,
            Сумма = b.TotalAmount
        }).ToList();
        if (dgvRecentBookings.Columns.Contains("Id"))
            dgvRecentBookings.Columns["Id"].Visible = false;
    }



    private void ApplyRolePermissions()
    {
        bool isAdmin = _currentUser.RoleName == "admin";
        logsMenuItem.Visible = isAdmin;
        actionLogsMenuItem.Visible = isAdmin;

        bool canEdit = _currentUser.RoleName != "user";
    }

    private void roomsMenuItem_Click(object sender, EventArgs e)
    {
        new RoomsForm(_currentUser).ShowDialog();
        LoadDashboard();
        LoadRecentBookings(); 
    }
    private void guestsMenuItem_Click(object sender, EventArgs e)
    {
        new GuestsForm(_currentUser).ShowDialog();
        LoadRecentBookings(); 
    }
    private void bookingsMenuItem_Click(object sender, EventArgs e)
    {
        new BookingsForm(_currentUser).ShowDialog();
        LoadDashboard();        
        LoadRecentBookings();   
    }

    private void servicesMenuItem_Click(object sender, EventArgs e) => new ServicesForm(_currentUser).ShowDialog();
    private void paymentsMenuItem_Click(object sender, EventArgs e) => new PaymentsForm(_currentUser).ShowDialog();
    private void logsMenuItem_Click(object sender, EventArgs e) => new LoginAttemptsForm().ShowDialog();
    private void actionLogsMenuItem_Click(object sender, EventArgs e) => ShowActionLogs();
    private void btnSearch_Click(object sender, EventArgs e) => LoadRecentBookings();
    private void exitMenuItem_Click(object sender, EventArgs e) => Application.Exit();

    private void ShowActionLogs()
    {
        var repo = new ActionLogRepository();
        var logs = repo.GetAll();
        var frm = new Form { Text = "Журнал действий", Size = new Size(900, 400) };
        var dgv = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true };
        dgv.DataSource = logs.Select(l => new { l.UserLogin, l.ActionType, l.EntityName, l.EntityId, l.Details, l.CreatedAt }).ToList();
        frm.Controls.Add(dgv);
        frm.ShowDialog();
    }
}