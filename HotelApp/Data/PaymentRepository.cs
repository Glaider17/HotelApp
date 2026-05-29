using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class PaymentRepository
{
    public List<Payment> GetAll(string search = "")
    {
        var list = new List<Payment>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT p.Id, p.BookingId, b.Id || ' - ' || g.FullName, p.Amount, p.PaymentDate, p.Method
            FROM Payments p
            JOIN Bookings b ON b.Id = p.BookingId
            JOIN Guests g ON g.Id = b.GuestId
            WHERE @search = '' OR g.FullName LIKE '%' || @search || '%' OR p.Method LIKE '%' || @search || '%'
            ORDER BY p.PaymentDate DESC";
        command.Parameters.AddWithValue("@search", search);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Payment
            {
                Id = reader.GetInt32(0),
                BookingId = reader.GetInt32(1),
                BookingInfo = reader.GetString(2),
                Amount = reader.GetDecimal(3),
                PaymentDate = reader.GetDateTime(4),
                Method = reader.GetString(5)
            });
        }
        return list;
    }

    public void Add(Payment payment)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Payments (BookingId, Amount, PaymentDate, Method)
            VALUES ($bookingId, $amount, $date, $method)";
        command.Parameters.AddWithValue("$bookingId", payment.BookingId);
        command.Parameters.AddWithValue("$amount", payment.Amount);
        command.Parameters.AddWithValue("$date", payment.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss"));
        command.Parameters.AddWithValue("$method", payment.Method);
        command.ExecuteNonQuery();
    }
    public bool HasPayments(int bookingId)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Payments WHERE BookingId = $bookingId";
        command.Parameters.AddWithValue("$bookingId", bookingId);
        var result = command.ExecuteScalar();
        long count = Convert.ToInt64(result);
        return count > 0;
    }

    public void Delete(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Payments WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    public List<Booking> GetActiveBookings()
    {
        var list = new List<Booking>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT b.Id, g.FullName
            FROM Bookings b
            JOIN Guests g ON g.Id = b.GuestId
            WHERE b.Status = 'Активно'
            ORDER BY b.CheckInDate";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Booking { Id = reader.GetInt32(0), GuestName = reader.GetString(1) });
        }
        return list;
    }
}