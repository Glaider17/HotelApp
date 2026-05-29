namespace HotelApp.Models;

public class LoginAttempt
{
    public int Id { get; set; }
    public string UserLogin { get; set; } = "";
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = "";
    public string CreatedAt { get; set; } = "";
}