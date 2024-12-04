using Npgsql;
using System.Data;
namespace Teacherr.Service;

public static class TeacherService
{


    public static bool InsertTeacher(Teacher? teacher, string databaseName)
    {
        try{
        string connectionString = $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
        using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
        NpgsqlCommand command = connection.CreateCommand();
        string insertCommand=$"Insert into {databaseName} (Fullname,Email,Age,Profession) values(@Fullname,@Email,@Age,@Profession;)";
        command.CommandText = insertCommand;

        command.Parameters.AddWithValue("Fullname",teacher.FullName);
        command.Parameters.AddWithValue("Email",teacher.Email);
        command.Parameters.AddWithValue("Age",teacher.Age);
        command.Parameters.AddWithValue("Profession",teacher.Profession);
        int res=command.ExecuteNonQuery();
        if(res!=0)return true;
        return false;

    }
    catch(Exception e)
    {
        System.Console.WriteLine("This exeption "+e.Message);
        return false;
    }
    }


    public static bool UpdateTeacher(Teacher teacher,string databaseName,string tableName)
    {
        try{
        string connectionString = $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
        using NpgsqlConnection connection=NpgsqlHelper.CreateConnection(connectionString);
        NpgsqlCommand command=connection.CreateCommand();
        string UpdateCommand=$"Update {tableName} set fullname=@Fullname,email=@Email,age=@Age,profession=@Profession,id=@Id";
        command.CommandText=UpdateCommand;
        command.Parameters.AddWithValue("Fullname",teacher.FullName);
        command.Parameters.AddWithValue("Email",teacher.Email);
        command.Parameters.AddWithValue("Age",teacher.Age);
        command.Parameters.AddWithValue("Profession",teacher.Profession);
        int res=command.ExecuteNonQuery();
        if(res!=0)return true;
        return false;        
    }
    catch(Exception e)
    {
        System.Console.WriteLine("This exeption "+e.Message);
        return false;
    }
    
}


public static bool DeleteTeacher(int id,string databaseName,string tableName)
{
    try{
        string connectionString = $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
        using NpgsqlConnection connection=NpgsqlHelper.CreateConnection(connectionString);
        NpgsqlCommand command=connection.CreateCommand();    
        string DeleteCommand=$"Delete from {tableName} where id=@Id";
        command.CommandText=DeleteCommand;
        int res=command.ExecuteNonQuery();
        if(res!=0)return true;
        return false;
}
catch(Exception e)
{
    System.Console.WriteLine("This exeption "+e.Message);
    return false;
}

}


public static void DisplayTeachers(string databaseName,string tableName)
{
        string connectionString = $"Server = localhost; Port = 5432; Database = {databaseName}; username = postgres; password=12345;";
      NpgsqlConnection connection=NpgsqlHelper.CreateConnection(connectionString);
      NpgsqlCommand command=connection.CreateCommand();
      string SelectCommand=$"Select * from {tableName}";
      command.CommandText=SelectCommand;
      command.CommandTimeout=40;
      command.ExecuteReader();
}


}