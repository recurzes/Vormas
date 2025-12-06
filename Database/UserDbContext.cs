using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Services;

namespace Vormas.Database
{
    public class UserDbContext: IUserManager
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();
        public void Create(User e)
        {
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcAddUser", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("pFname", e.FirstName);
                    command.Parameters.AddWithValue("pLname", e.LastName);
                    command.Parameters.AddWithValue("pUsername", e.UserName);
                    command.Parameters.AddWithValue("pPasswordHash", e.PasswordHash);
                    command.Parameters.AddWithValue("pEmail", e.Email);
                    command.Parameters.AddWithValue("pPhone", e.Phone);
                    command.Parameters.AddWithValue("pRoleId", e.RoleId);
                    command.Parameters.AddWithValue("pIsActive", e.IsActive);
                    
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("User Added.", "New Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(int userId, User e)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}