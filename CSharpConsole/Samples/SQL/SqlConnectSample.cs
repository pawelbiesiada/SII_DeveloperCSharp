using CSharpConsole.Exercises;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.SQL
{
    public class ConnectionStringProvider
    {
        public string GetConnectionSting()
        {
            var connStr = string.Empty;
            try
            {
                connStr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return connStr;
        }
    }

    public class SqlConnectSample
    {
        private readonly ConnectionStringProvider _connectionStringProvider;

        public SqlConnectSample()
        {
            _connectionStringProvider = new ConnectionStringProvider();
        }

        public static void Main()
        {
            var sqlConnectionSample = new SqlConnectSample();
            sqlConnectionSample.Execute();
        }

        public void Execute()
        {
            GetRecordsWithSelect();
            ExecuteProcedure();
        }

        private void GetRecordsWithSelect()
        {
            var connStr = _connectionStringProvider.GetConnectionSting();
            if (string.IsNullOrEmpty(connStr))
            {
                return;
            }

            //var oracleConn = new OracleConnection();
            try
            {
                using (var connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM  Users";
                    var reader = command.ExecuteReader();
                    //command.ExecuteNonQuery();
                    //command.ExecuteScalar();

                    var users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = (int)reader["Id"]
                        });
                        //var idCol = reader.GetInt32("Id");                       
                        var idCol = (int)reader["Id"];
                        var nameCol = (string)reader["Name"];
                        Console.WriteLine($"{idCol} : {nameCol}");
                    }

                    var usersCount = users.Count;

                    command = connection.CreateCommand();
                    command.CommandText = "SELECT Count(*) FROM  Users";
                    var countUser = (int)command.ExecuteScalar();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private void ExecuteProcedure()
        {
            var connStr = _connectionStringProvider.GetConnectionSting();
            if (string.IsNullOrEmpty(connStr))
            {
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pGetUsers";

                    var isActiveParameter = command.CreateParameter();
                    isActiveParameter.DbType = DbType.Boolean;
                    isActiveParameter.ParameterName = "@IsActive";
                    isActiveParameter.Value = true;

                    command.Parameters.Add(isActiveParameter);

                    var reader = command.ExecuteReader();
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        var idCol = (int)reader["Id"];
                        var nameCol = (string)reader["Name"];
                        Console.WriteLine($"{idCol}\t{nameCol}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private async Task ExecuteNonQueryAsyncProcedure()
        {
            var connStr = _connectionStringProvider.GetConnectionSting();
            if (string.IsNullOrEmpty(connStr))
            {
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pDeleteUser";

                    var idPar = command.CreateParameter();
                    idPar.DbType = DbType.Int32;
                    idPar.ParameterName = "@Id";
                    idPar.Value = 1;

                    command.Parameters.Add(idPar);

                    await command.ExecuteNonQueryAsync();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<int> GetInactiveUsers()
        {
            var connStr = _connectionStringProvider.GetConnectionSting();
            if (string.IsNullOrEmpty(connStr))
            {
                return null;
            }

            try
            {
                using (var connection = new SqlConnection(connStr))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM  Users WHERE IsActive = 0";
                    List<int> inactiveUsers = new List<int>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idCol = (int)reader["Id"];
                        var nameCol = reader.GetString("Name");
                        inactiveUsers.Add(idCol);
                        Console.WriteLine($"{idCol} {nameCol}");
                    }

                    return inactiveUsers;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void RemoveUsers(List<int> users)
        {
            var connStr = _connectionStringProvider.GetConnectionSting();
            if (string.IsNullOrEmpty(connStr))
            {
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connStr))
                {
                    connection.Open();


                    var command = connection.CreateCommand();
                    var ids = string.Join(',', users);

                    command.CommandText = $"DELETE FROM Users WHERE Id IN ({ids}) ";
                    var reader = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
