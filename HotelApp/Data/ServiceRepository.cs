using Microsoft.Data.Sqlite;
using HotelApp.Models;

namespace HotelApp.Data;

public class ServiceRepository
{
    public List<Service> GetAll(string search = "")
    {
        var list = new List<Service>();
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, Name, Price, Category
            FROM Services
            WHERE @search = '' OR Name LIKE '%' || @search || '%' OR Category LIKE '%' || @search || '%'
            ORDER BY Name";
        command.Parameters.AddWithValue("@search", search);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Service
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Category = reader.GetString(3)
            });
        }
        return list;
    }

    public Service GetById(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Price, Category FROM Services WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        return new Service
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Price = reader.GetDecimal(2),
            Category = reader.GetString(3)
        };
    }

    public void Add(Service service)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Services (Name, Price, Category)
            VALUES ($name, $price, $category)";
        FillParameters(command, service);
        command.ExecuteNonQuery();
    }

    public void Update(Service service)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Services SET Name = $name, Price = $price, Category = $category
            WHERE Id = $id";
        command.Parameters.AddWithValue("$id", service.Id);
        FillParameters(command, service);
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = DbConnectionFactory.Create();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Services WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    private void FillParameters(SqliteCommand command, Service service)
    {
        command.Parameters.AddWithValue("$name", service.Name);
        command.Parameters.AddWithValue("$price", service.Price);
        command.Parameters.AddWithValue("$category", service.Category);
    }
}