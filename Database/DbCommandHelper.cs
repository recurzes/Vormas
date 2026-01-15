using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Vormas.Database
{
    public static class DbCommandHelper
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
                    object result = command.ExecuteScalar();
                    
                    // Handle null, DBNull, or non-numeric results gracefully
                    if (result == null || result == DBNull.Value)
                        return 0;
                    
                    // Try to convert to int, return 0 if it's not a number (e.g., status strings like "Completed")
                    if (result is int intResult)
                        return intResult;
                    if (result is long longResult)
                        return (int)longResult;
                    if (result is decimal decimalResult)
                        return (int)decimalResult;
                    if (int.TryParse(result.ToString(), out int parsed))
                        return parsed;
                    
                    // For string results like "Completed", return 0 (success indicator)
                    return 0;
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

        public static int ExecuteNonQueryLastIdReturn(string connectionString, string procedureName,
            Action<MySqlCommand> configureCommand)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(procedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    configureCommand(command);
                    
                    conn.Open();
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}