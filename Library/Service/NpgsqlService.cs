using Npgsql;
using System.Data;
namespace Teacherr.Service;


public static class NpgsqlService
{

    public static bool CreateDatabase(string databaseName)
    {
        try
        {
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(SqlCommands.ConnectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            NpgsqlParameter parameter = new NpgsqlParameter()
            {
                ParameterName = "databaseName",
                Value = databaseName,
                DbType = DbType.String,
                Size = 20,
                IsNullable = false,
            };

            command.Parameters.Add(parameter);
            command.CommandText = SqlCommands.CreateDatabase;
            command.CommandTimeout = 40;
            int res = command.ExecuteNonQuery();
            if (res != 0) return true;
            return false;
        }
        catch (Exception e)
        {
            System.Console.WriteLine("This exeption " + e.Message);
            return false;
        }
    }


    public static bool DropDatabase(string databaseName)
    {
        try
        {
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(SqlCommands.ConnectionString);
            NpgsqlCommand command = connection.CreateCommand();
            NpgsqlParameter parameter = new NpgsqlParameter()
            {
                ParameterName = "databaseName",
                Value = databaseName,
                DbType = DbType.String,
                Size = 30,
                IsNullable = false,
            };
            command.Parameters.Add(parameter);
            command.CommandText = SqlCommands.DropDatabase;
            command.CommandTimeout = 40;
            command.CommandType = CommandType.Text;

            int res = command.ExecuteNonQuery();
            if (res != 0) return true;
            return false;
        }
        catch (Exception e)
        {
            System.Console.WriteLine("This exeption " + e.Message);
            return false;
        }
    }

    public static bool CreateTable(string databaseName, string sqlCommand)
    {
        try
        {
            string connectionString = $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;
            int res = command.ExecuteNonQuery();
            if (res != 0) return true;
            return false;
        }
        catch (Exception e)
        {
            System.Console.WriteLine("This exeption " + e.Message);
            return false;
        }
    }


    public static bool DropTable(string databaseName, string tableName)
    {
        try
        {
            string connectionString =
                $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("tableName", tableName);
            command.CommandText = SqlCommands.DropTable;
            int res = command.ExecuteNonQuery();
            if (res != 0) return true;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("This exception " + e.Message);
            throw;
        }
    }






}



file static class SqlCommands
{
    public const string ConnectionString =
        "Server = localhost; Port = 5432; Database = postgres; username = postgres; password=12345;";

    public const string CreateDatabase = "Create database @databaseName;";
    public const string DropDatabase = "Drop database @databaseName with(force);";
    public const string DropTable = "Drop table @tableName ;";
}
