using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class BookingRepository
{
    public List<Booking> GetAll(string search = "")
    {
        var list = new List<Booking>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT b.Id, b.GuestId, g.FullName, b.RoomId, r.Number, b.CheckInDate, b.CheckOutDate, b.Status, b.TotalAmount
            FROM Bookings b
            JOIN Guests g ON g.Id = b.GuestId
            JOIN Rooms r ON r.Id = b.RoomId
            WHERE @search = '' OR g.FullName LIKE '%' || @search || '%' OR r.Number LIKE '%' || @search || '%'
            ORDER BY b.CheckInDate DESC";
        command.Parameters.AddWithValue("@search", search);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Booking
            {
                Id = reader.GetInt32(0),
                GuestId = reader.GetInt32(1),
                GuestName = reader.GetString(2),
                RoomId = reader.GetInt32(3),
                RoomNumber = reader.GetString(4),
                CheckInDate = reader.GetDateTime(5),
                CheckOutDate = reader.GetDateTime(6),
                Status = reader.GetString(7),
                TotalAmount = reader.GetDecimal(8)
            });
        }
        return list;
    }

    public Booking GetById(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT b.Id, b.GuestId, g.FullName, b.RoomId, r.Number, b.CheckInDate, b.CheckOutDate, b.Status, b.TotalAmount
            FROM Bookings b
            JOIN Guests g ON g.Id = b.GuestId
            JOIN Rooms r ON r.Id = b.RoomId
            WHERE b.Id = $id";
        command.Parameters.AddWithValue("$id", id);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        return new Booking
        {
            Id = reader.GetInt32(0),
            GuestId = reader.GetInt32(1),
            GuestName = reader.GetString(2),
            RoomId = reader.GetInt32(3),
            RoomNumber = reader.GetString(4),
            CheckInDate = reader.GetDateTime(5),
            CheckOutDate = reader.GetDateTime(6),
            Status = reader.GetString(7),
            TotalAmount = reader.GetDecimal(8)
        };
    }

    public bool HasAnyBookings(int guestId)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Bookings WHERE GuestId = $guestId";
        command.Parameters.AddWithValue("$guestId", guestId);

        var result = command.ExecuteScalar();
        long count = Convert.ToInt64(result);  
        return count > 0;
    }

    public bool HasAnyBookingsForRoom(int roomId)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Bookings WHERE RoomId = $roomId";
        command.Parameters.AddWithValue("$roomId", roomId);   

        var result = command.ExecuteScalar();
        long count = Convert.ToInt64(result);
        return count > 0;
    }

    public void Add(Booking booking)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Bookings (GuestId, RoomId, CheckInDate, CheckOutDate, Status, TotalAmount)
            VALUES ($guestId, $roomId, $checkIn, $checkOut, $status, $total)";
        FillParameters(command, booking);
        command.ExecuteNonQuery();
    }

    public void Update(Booking booking)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Bookings SET GuestId = $guestId, RoomId = $roomId, CheckInDate = $checkIn, CheckOutDate = $checkOut, Status = $status, TotalAmount = $total
            WHERE Id = $id";
        command.Parameters.AddWithValue("$id", booking.Id);
        FillParameters(command, booking);
        command.ExecuteNonQuery();
    }

    public bool IsRoomOccupied(int roomId, DateTime checkIn, DateTime checkOut, int excludeBookingId = 0)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
        SELECT COUNT(*) FROM Bookings 
        WHERE RoomId = $roomId 
        AND Id != $excludeBookingId
        AND (
            (CheckInDate <= $checkOut AND CheckOutDate >= $checkIn)
        )";
        command.Parameters.AddWithValue("$roomId", roomId);
        command.Parameters.AddWithValue("$checkIn", checkIn.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$checkOut", checkOut.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$excludeBookingId", excludeBookingId);
        var result = command.ExecuteScalar();
        long count = Convert.ToInt64(result);
        return count > 0;
    }

    public void Delete(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Bookings WHERE Id = @id";
        command.Parameters.AddWithValue("@id", id);  
        command.ExecuteNonQuery();
    }

    private void FillParameters(SqliteCommand command, Booking booking)
    {
        command.Parameters.AddWithValue("$guestId", booking.GuestId);
        command.Parameters.AddWithValue("$roomId", booking.RoomId);
        command.Parameters.AddWithValue("$checkIn", booking.CheckInDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$checkOut", booking.CheckOutDate.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$status", booking.Status);
        command.Parameters.AddWithValue("$total", booking.TotalAmount);
    }

    public List<Booking> GetRecentBookings(int count = 5)
    {
        var list = new List<Booking>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT b.Id, b.GuestId, g.FullName, b.RoomId, r.Number, b.CheckInDate, b.CheckOutDate, b.Status, b.TotalAmount
            FROM Bookings b
            JOIN Guests g ON g.Id = b.GuestId
            JOIN Rooms r ON r.Id = b.RoomId
            ORDER BY b.CheckInDate DESC
            LIMIT $count";
        command.Parameters.AddWithValue("$count", count);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Booking
            {
                Id = reader.GetInt32(0),
                GuestId = reader.GetInt32(1),
                GuestName = reader.GetString(2),
                RoomId = reader.GetInt32(3),
                RoomNumber = reader.GetString(4),
                CheckInDate = reader.GetDateTime(5),
                CheckOutDate = reader.GetDateTime(6),
                Status = reader.GetString(7),
                TotalAmount = reader.GetDecimal(8)
            });
        }
        return list;
    }

    public int GetCheckInsToday()
    {
        var today = DateTime.Now.ToString("yyyy-MM-dd");
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Bookings WHERE CheckInDate = $today";
        command.Parameters.AddWithValue("$today", today);
        return Convert.ToInt32(command.ExecuteScalar());
    }

    public int GetCheckOutsToday()
    {
        var today = DateTime.Now.ToString("yyyy-MM-dd");
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Bookings WHERE CheckOutDate = $today";
        command.Parameters.AddWithValue("$today", today);
        return Convert.ToInt32(command.ExecuteScalar());
    }
}