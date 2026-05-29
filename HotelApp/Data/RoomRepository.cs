using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class RoomRepository
{
    public List<Room> GetAll(string search = "")
    {
        var list = new List<Room>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, Number, Type, Capacity, PricePerNight, Status
            FROM Rooms
            WHERE @search = '' OR Number LIKE '%' || @search || '%' OR Type LIKE '%' || @search || '%'
            ORDER BY Number";
        command.Parameters.AddWithValue("@search", search);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Room
            {
                Id = reader.GetInt32(0),
                Number = reader.GetString(1),
                Type = reader.GetString(2),
                Capacity = reader.GetInt32(3),
                PricePerNight = reader.GetDecimal(4),
                Status = reader.GetString(5)
            });
        }
        return list;
    }

    public Room GetById(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Number, Type, Capacity, PricePerNight, Status FROM Rooms WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        return new Room
        {
            Id = reader.GetInt32(0),
            Number = reader.GetString(1),
            Type = reader.GetString(2),
            Capacity = reader.GetInt32(3),
            PricePerNight = reader.GetDecimal(4),
            Status = reader.GetString(5)
        };
    }

    public void Add(Room room)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Rooms (Number, Type, Capacity, PricePerNight, Status)
            VALUES ($number, $type, $capacity, $price, $status)";
        FillParameters(command, room);
        command.ExecuteNonQuery();
    }

    public void Update(Room room)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Rooms SET Number = $number, Type = $type, Capacity = $capacity, PricePerNight = $price, Status = $status
            WHERE Id = $id";
        command.Parameters.AddWithValue("$id", room.Id);
        FillParameters(command, room);
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Rooms WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    private void FillParameters(SqliteCommand command, Room room)
    {
        command.Parameters.AddWithValue("$number", room.Number);
        command.Parameters.AddWithValue("$type", room.Type);
        command.Parameters.AddWithValue("$capacity", room.Capacity);
        command.Parameters.AddWithValue("$price", room.PricePerNight);
        command.Parameters.AddWithValue("$status", room.Status);
    }

    public int GetAvailableRoomsCount()
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Rooms WHERE Status = 'Свободен'";
        return Convert.ToInt32(command.ExecuteScalar());
    }
}