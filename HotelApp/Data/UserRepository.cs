using Microsoft.Data.Sqlite;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Data;

public class UserRepository
{
    public User FindByLogin(string login)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT u.Id, u.Login, u.PasswordHash, u.PasswordSalt, u.FullName, u.IsActive, r.Name AS RoleName
            FROM Users u
            JOIN Roles r ON r.Id = u.RoleId
            WHERE u.Login = $login";
        command.Parameters.AddWithValue("$login", login);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        return new User
        {
            Id = reader.GetInt32(0),
            Login = reader.GetString(1),
            PasswordHash = reader.GetString(2),
            PasswordSalt = reader.GetString(3),
            FullName = reader.GetString(4),
            IsActive = reader.GetInt32(5) == 1,
            RoleName = reader.GetString(6)
        };
    }

    public bool LoginExists(string login)
    {
        return FindByLogin(login) != null;
    }

    public void CreateUser(string login, string password, string fullName, int roleId)
    {
        var salt = PasswordHasher.GenerateSalt();
        var hash = PasswordHasher.HashPassword(password, salt);
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Users (Login, PasswordHash, PasswordSalt, FullName, RoleId, IsActive, CreatedAt)
            VALUES ($login, $hash, $salt, $fullName, $roleId, 1, $createdAt)";
        command.Parameters.AddWithValue("$login", login);
        command.Parameters.AddWithValue("$hash", hash);
        command.Parameters.AddWithValue("$salt", salt);
        command.Parameters.AddWithValue("$fullName", fullName);
        command.Parameters.AddWithValue("$roleId", roleId);
        command.Parameters.AddWithValue("$createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        command.ExecuteNonQuery();
    }

    public void AddLoginAttempt(string login, bool success, string message)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO LoginAttempts (UserLogin, IsSuccess, Message, CreatedAt)
            VALUES ($login, $success, $message, $createdAt)";
        command.Parameters.AddWithValue("$login", login);
        command.Parameters.AddWithValue("$success", success ? 1 : 0);
        command.Parameters.AddWithValue("$message", message);
        command.Parameters.AddWithValue("$createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        command.ExecuteNonQuery();
    }

    public List<LoginAttempt> GetAllLoginAttempts()
    {
        var list = new List<LoginAttempt>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, UserLogin, IsSuccess, Message, CreatedAt FROM LoginAttempts ORDER BY CreatedAt DESC";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new LoginAttempt
            {
                Id = reader.GetInt32(0),
                UserLogin = reader.GetString(1),
                IsSuccess = reader.GetInt32(2) == 1,
                Message = reader.GetString(3),
                CreatedAt = reader.GetString(4)
            });
        }
        return list;
    }
}