namespace HotelApp.Models;

public class Room
{
    public int Id { get; set; }
    public string Number { get; set; } = "";
    public string Type { get; set; } = ""; 
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public string Status { get; set; } = "Свободен"; 
}