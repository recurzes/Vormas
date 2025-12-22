using System;
using System.Collections.Generic;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class CustomerDbContext : ICustomerManager
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public void CreateCustomer(Customer customer)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcCreateCustomer", cmd =>
            {
                cmd.Parameters.AddWithValue("@pFirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@pLastName", customer.LastName);
                cmd.Parameters.AddWithValue("@pAddress", customer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmail", customer.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pFirstName", customer.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pDateOfBirth", customer.BirthDate);
                cmd.Parameters.AddWithValue("@pCustomerType", customer.CustomerType);
                cmd.Parameters.AddWithValue("@pEmergencyContactName",
                    customer.EmergencyContactName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmergencyContactPhone",
                    customer.EmergencyContactPhone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pIsBlacklisted", customer.IsBlacklisted);
            });

            customer.CustomerId = DbCommandHelper.ExecuteReader(_connStr,
                "SELECT LAST_INSERT_ID() As CustomerId", cmd => { }, reader =>
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("CustomerId");
                    }

                    return 0;
                });
        }

        public List<Customer> GetALlCustomers()
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetAllCustomers",
                cmd => { },
                reader => DataReaderMapper.MapToList<Customer>(reader)
            );
        }

        public Customer GetCustomerById(int customerId)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetCustomerById",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId),
                reader =>
                {
                    if (reader.Read())
                    {
                        return DataReaderMapper.MapToModel<Customer>(reader);
                    }

                    return null;
                }
            );
        }

        public Customer GetCustomerByPhone(string phoneNumber)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetCustomerByPhone",
                cmd => cmd.Parameters.AddWithValue("@pPhoneNumber", phoneNumber),
                reader =>
                {
                    if (reader.Read())
                    {
                        return DataReaderMapper.MapToModel<Customer>(reader);
                    }

                    return null;
                }
            );
        }

        public Customer GetCustomerByEmail(string email)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetCustomerByEmail",
                cmd => cmd.Parameters.AddWithValue("@pEmail", email),
                reader =>
                {
                    if (reader.Read())
                    {
                        return DataReaderMapper.MapToModel<Customer>(reader);
                    }

                    return null;
                }
            );
        }

        public int UpdateCustomer(Customer customer)
        {
            return DbCommandHelper.ExecuteNonQuery(
                _connStr,
                "prcUpdateCustomer",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@pFirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@pLastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@pAddress", customer.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEmail", customer.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pFirstName", customer.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pDateOfBirth", customer.BirthDate);
                    cmd.Parameters.AddWithValue("@pCustomerType", customer.CustomerType);
                    cmd.Parameters.AddWithValue("@pEmergencyContactName",
                        customer.EmergencyContactName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEmergencyContactPhone",
                        customer.EmergencyContactPhone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pIsBlacklisted", customer.IsBlacklisted);
                }
            );
        }

        public int DeleteCustomer(int customerId)
        {
            return DbCommandHelper.ExecuteNonQuery(
                _connStr,
                "prcDeleteCustomer",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId)
            );
        }

        public bool CustomerExists(int customerId)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcCustomerExists",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId),
                reader =>
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("Exists") == 1;
                    }

                    return false;
                }
            );
        }

        public bool IsPhoneNumberTaken(string phoneNumber)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcIsPhoneNumberTaken",
                cmd => cmd.Parameters.AddWithValue("@pPhoneNumber", phoneNumber),
                reader =>
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("IsTaken") == 1;
                    }

                    return false;
                }
            );
        }

        public bool IsEmailTaken(string email)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcIsEmailTaken",
                cmd => cmd.Parameters.AddWithValue("@pEmail", email),
                reader =>
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("IsTaken") == 1;
                    }

                    return false;
                }
            );
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcSearchCustomers",
                cmd => cmd.Parameters.AddWithValue("@pSearchTerm", searchTerm ?? string.Empty),
                reader => DataReaderMapper.MapToList<Customer>(reader)
            );
        }

        public List<Customer> GetCustomerByStatus()
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetCustomerStatus",
                cmd => cmd.Parameters.AddWithValue("@pIsBlacklisted", 1),
                reader => DataReaderMapper.MapToList<Customer>(reader)
            );
        }

        public int DeactivateCustomer(int customerId)
        {
            return DbCommandHelper.ExecuteNonQuery(
                _connStr,
                "prcDeactivateCustomer",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId)
            );
        }

        public int ActivateCustomer(int customerId)
        {
            return DbCommandHelper.ExecuteNonQuery(
                _connStr,
                "prcActivateCustomer",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId)
            );
        }
    }
}