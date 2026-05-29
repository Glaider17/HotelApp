namespace HotelApp.Models;

public class ActionLog
{
    public int Id { get; set; }
    public string UserLogin { get; set; } = "";
    public string ActionType { get; set; } = ""; 
    public string EntityName { get; set; } = "";
    public string EntityId { get; set; } = "";
    public string Details { get; set; } = "";
    public string CreatedAt { get; set; } = "";
}