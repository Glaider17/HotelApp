using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class ActionLogRepository
{
    public void Log(string userLogin, string actionType, string entityName, string entityId, string details)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO ActionLogs (UserLogin, ActionType, EntityName, EntityId, Details, CreatedAt)
            VALUES ($userLogin, $actionType, $entityName, $entityId, $details, $createdAt)";
        command.Parameters.AddWithValue("$userLogin", userLogin);
        command.Parameters.AddWithValue("$actionType", actionType);
        command.Parameters.AddWithValue("$entityName", entityName);
        command.Parameters.AddWithValue("$entityId", entityId);
        command.Parameters.AddWithValue("$details", details);
        command.Parameters.AddWithValue("$createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        command.ExecuteNonQuery();
    }

    public List<ActionLog> GetAll()
    {
        var list = new List<ActionLog>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, UserLogin, ActionType, EntityName, EntityId, Details, CreatedAt FROM ActionLogs ORDER BY CreatedAt DESC";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new ActionLog
            {
                Id = reader.GetInt32(0),
                UserLogin = reader.GetString(1),
                ActionType = reader.GetString(2),
                EntityName = reader.GetString(3),
                EntityId = reader.GetString(4),
                Details = reader.GetString(5),
                CreatedAt = reader.GetString(6)
            });
        }
        return list;
    }
}