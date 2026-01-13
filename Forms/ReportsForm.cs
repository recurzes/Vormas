using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class ReportsForm : PageControl
    {
        private readonly string _connectionString;

        public ReportsForm()
        {
            InitializeComponent();
             _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"]?.ConnectionString 
                                ?? "Server=localhost;Database=VormasDb;Uid=root;Pwd=password;";
             LoadReports();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void LoadReports()
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    // 1. Stats
                    string statsSql = "SELECT COUNT(*) as Count, SUM(TotalAmount) as Revenue FROM Rentals WHERE Status = 'Completed'";
                    using (var cmd = new MySqlCommand(statsSql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int count = reader["Count"] != DBNull.Value ? Convert.ToInt32(reader["Count"]) : 0;
                                decimal revenue = reader["Revenue"] != DBNull.Value ? Convert.ToDecimal(reader["Revenue"]) : 0;
                                lblTotalRentals.Text = $"Total Rentals: {count}";
                                lblTotalRevenue.Text = $"Total Revenue: {revenue:C2}";
                            }
                        }
                    }

                    // 2. Recent
                    string recentSql = "SELECT RentalId, PickupDate, ReturnDate, TotalAmount FROM Rentals ORDER BY PickupDate DESC LIMIT 10";
                    using (var cmd = new MySqlCommand(recentSql, conn))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvRecentRentals.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error loading reports: " + ex.Message);
            }
        }
    }
}
