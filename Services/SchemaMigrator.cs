using System;
using System.Configuration;
using Vormas.Database;
using MySql.Data.MySqlClient;

namespace Vormas.Services
{
    public static class SchemaMigrator
    {
        public static void EnsureSchema()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"]?.ConnectionString 
                                ?? "Server=localhost;Database=VormasDb;Uid=root;Pwd=password;";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Check Reservations Table Columns
                    EnsureColumn(conn, "Reservations", "StartDate", "DATETIME NOT NULL");
                    EnsureColumn(conn, "Reservations", "EndDate", "DATETIME NOT NULL");
                    
                    // Check Rentals Table Columns
                    EnsureColumn(conn, "Rentals", "PickupDate", "DATETIME NOT NULL");
                    EnsureColumn(conn, "Rentals", "OdometerStart", "INT NOT NULL");
                    EnsureColumn(conn, "Rentals", "FuelLevelStart", "DECIMAL(5, 2) NOT NULL");
                    EnsureColumn(conn, "Rentals", "ReturnDate", "DATETIME NULL");
                    EnsureColumn(conn, "Rentals", "OdometerEnd", "INT NULL");
                    EnsureColumn(conn, "Rentals", "FuelLevelEnd", "DECIMAL(5, 2) NULL");
                    EnsureColumn(conn, "Rentals", "TotalAmount", "DECIMAL(18, 2) NULL");
                    EnsureColumn(conn, "Rentals", "Status", "ENUM('Active', 'Completed', 'Overdue') NOT NULL DEFAULT 'Active'");
                    
                    // Check Payments Table Columns
                    EnsureColumn(conn, "Payments", "RentalId", "INT NOT NULL");
                    EnsureColumn(conn, "Payments", "Amount", "DECIMAL(18, 2) NOT NULL");
                    EnsureColumn(conn, "Payments", "PaymentDate", "DATETIME DEFAULT CURRENT_TIMESTAMP");
                    EnsureColumn(conn, "Payments", "Method", "ENUM('Cash', 'CreditCard', 'DebitCard', 'BankTransfer') NOT NULL");
                }
            }
            catch (Exception ex)
            {
               System.Windows.Forms.MessageBox.Show("Schema Migration Error: " + ex.Message);
            }
        }

        private static void EnsureColumn(MySqlConnection conn, string tableName, string columnName, string columnDef)
        {
            try 
            {
                bool exists = false;
                string checkSql = $"SELECT count(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = '{tableName}' AND column_name = '{columnName}'";
                using (var cmd = new MySqlCommand(checkSql, conn))
                {
                    exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }

                if (!exists)
                {
                    // If existing data, NOT NULL without default fails. We add defaults.
                    if (columnDef.Contains("NOT NULL") && !columnDef.Contains("DEFAULT"))
                    {
                         if(columnDef.Contains("INT") || columnDef.Contains("DECIMAL"))
                             columnDef += " DEFAULT 0";
                         else if (columnDef.Contains("DATETIME"))
                             columnDef += " DEFAULT '2000-01-01 00:00:00'";
                         else
                             columnDef += " DEFAULT ''";
                    }

                    string alterSql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDef}";
                    using (var cmd = new MySqlCommand(alterSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                 System.Windows.Forms.MessageBox.Show($"Error adding column {columnName} to {tableName}: {ex.Message}");
            }
        }
    }
}
