using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    internal static class Database
    {
        //internal const string ConnectionString = "Server=.\\SQLEXPRESS;Database=QuanLyBanTraSua;Integrated Security=True;TrustServerCertificate=True;";
        internal const string ConnectionString = @"Server=.\SQLEXPRESS;Database=QuanLyBanTraSua;Integrated Security=True;TrustServerCertificate=True;";

        internal static async Task<SqlConnection> CreateOpenConnectionAsync()
        {
            var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
