using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class GuestRepository
{
    public List<Guest> GetAll(string search = "")
    {
        var list = new List<Guest>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, FullName, Passport, Phone, Email, IsActive
            FROM Guests
            WHERE @search = '' OR FullName LIKE '%' || @search || '%' OR Passport LIKE '%' || @search || '%' OR Phone LIKE '%' || @search || '%'
            ORDER BY FullName";
        command.Parameters.AddWithValue("@search", search);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Guest
            {
                Id = reader.GetInt32(0),
                FullName = reader.GetString(1),
                Passport = reader.GetString(2),
                Phone = reader.GetString(3),
                Email = reader.GetString(4),
                IsActive = reader.GetInt32(5) == 1
            });
        }
        return list;
    }

    public Guest GetById(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, FullName, Passport, Phone, Email, IsActive FROM Guests WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        return new Guest
        {
            Id = reader.GetInt32(0),
            FullName = reader.GetString(1),
            Passport = reader.GetString(2),
            Phone = reader.GetString(3),
            Email = reader.GetString(4),
            IsActive = reader.GetInt32(5) == 1
        };
    }

    public void Add(Guest guest)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Guests (FullName, Passport, Phone, Email, IsActive)
            VALUES ($fullName, $passport, $phone, $email, $isActive)";
        FillParameters(command, guest);
        command.ExecuteNonQuery();
    }

    public void Update(Guest guest)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Guests SET FullName = $fullName, Passport = $passport, Phone = $phone, Email = $email, IsActive = $isActive
            WHERE Id = $id";
        command.Parameters.AddWithValue("$id", guest.Id);
        FillParameters(command, guest);
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Guests WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    private void FillParameters(SqliteCommand command, Guest guest)
    {
        command.Parameters.AddWithValue("$fullName", guest.FullName);
        command.Parameters.AddWithValue("$passport", guest.Passport);
        command.Parameters.AddWithValue("$phone", guest.Phone);
        command.Parameters.AddWithValue("$email", guest.Email);
        command.Parameters.AddWithValue("$isActive", guest.IsActive ? 1 : 0);
    }

    public bool PassportExists(string passport, int excludeId = 0)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Guests WHERE Passport = $passport AND Id != $excludeId";
        command.Parameters.AddWithValue("$passport", passport);
        command.Parameters.AddWithValue("$excludeId", excludeId);
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }
}