using Microsoft.Data.Sqlite;

namespace HotelApp.Data;

public static class DbConnectionFactory
{
    private const string ConnectionString = "Data Source=hotel.db";

    public static SqliteConnection Create()
    {
        return new SqliteConnection(ConnectionString);
    }
}