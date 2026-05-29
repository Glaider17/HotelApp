namespace HotelApp.Models;

public class Booking
{
    public int Id { get; set; }
    public int GuestId { get; set; }
    public string GuestName { get; set; } = "";
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = "";
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; } = "Активно";
    public decimal TotalAmount { get; set; }
}