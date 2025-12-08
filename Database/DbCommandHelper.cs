using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Vormas.Database
{
    public class DbCommandHelper
    {
        public static int ExecuteNonQuery(string connectionString, string procedureName,
            Action<MySqlCommand> configureCommand)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(procedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    configureCommand(command);
                    
                    conn.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static T ExecuteReader<T>(string connectionString, string procedureName,
            Action<MySqlCommand> configureCommand, Func<MySqlDataReader, T> mapResult)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(procedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    configureCommand(command);
                    
                    conn.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        return mapResult(reader);
                    }
                }
            }
        }
    }
}