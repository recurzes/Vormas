using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class UserDbContext : IUserManager
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
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcGetAllUsers", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserId = reader.GetInt32("UserId"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                UserName = reader.GetString("Username"),
                                Email = reader.GetString("Email"),
                                Phone = reader.GetString("Phone"),
                                RoleId = reader.GetInt32("RoleId"),
                                IsActive = reader.GetBoolean("IsActive"),
                                CreatedAt = reader.GetDateTime("CreatedAt")
                            };

                            users.Add(user);
                        }
                    }

                    conn.Close();
                }
            }

            return users;
        }

        public User GetUserById(int userId)
        {
            User user = null;
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcGetUserById", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pUserId", userId);

                    conn.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = reader.GetInt32("UserId"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                UserName = reader.GetString("UserName"),
                                PasswordHash = reader.GetString("PasswordHash"),
                                Email = reader.GetString("Email"),
                                Phone = reader.GetString("Phone"),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address"))
                                    ? null
                                    : reader.GetString("Address"),
                                RoleId = reader.GetInt32("RoleId"),
                                IsActive = reader.GetBoolean("IsActive"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                UpdatedAt = reader.GetDateTime("UpdatedAt")
                            };
                        }
                    }

                    conn.Close();
                }
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcGetUserByUsername", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pUsername", username);
                    
                    conn.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = reader.GetInt32("UserId"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                UserName = reader.GetString("Username"),
                                PasswordHash = reader.GetString("PasswordHash"),
                                Email = reader.GetString("Email"),
                                Phone = reader.GetString("Phone"),
                                RoleId = reader.GetInt32("RoleId"),
                                IsActive = reader.GetBoolean("IsActive")
                            };
                        }
                    }
                }
            }
            
            return user;
        }

        public void UpdateUser(User e)
        {
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcUpdateUser", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("pUserId", e.UserId);
                    command.Parameters.AddWithValue("pFname", e.FirstName);
                    command.Parameters.AddWithValue("pLname", e.LastName);
                    command.Parameters.AddWithValue("pUsername", e.UserName);
                    command.Parameters.AddWithValue("pEmail", e.Email);
                    command.Parameters.AddWithValue("pPhone", e.Phone);
                    command.Parameters.AddWithValue("pAddress", e.Address);
                    command.Parameters.AddWithValue("pRoleId", e.RoleId);
                    command.Parameters.AddWithValue("pIsActive", e.IsActive);
                    
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Updated Successfully.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void UpdatePassword(int userId, string newPasswordHash)
        {
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcUpdateUserPassword", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pUserId", userId);
                    command.Parameters.AddWithValue("pPasswordHash", newPasswordHash);
                    
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    
                    MessageBox.Show("Password Updated.", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                using (MySqlCommand command = new MySqlCommand("prcDeleteUser", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("pUserId", userId);
                    
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Deactivated.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}