namespace HotelApp.Models;

public class Payment
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string BookingInfo { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string Method { get; set; } = "Наличные";
}