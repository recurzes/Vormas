using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class CustomerDbContext : ICustomerRepository
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public int CreateCustomer(Customer customer)
        {
            int customerId = DbCommandHelper.ExecuteNonQueryLastIdReturn(_connStr, "prcCreateCustomer", cmd =>
            {
                cmd.Parameters.AddWithValue("@pFirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@pLastName", customer.LastName);
                cmd.Parameters.AddWithValue("@pAddress", customer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmail", customer.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pPhone", customer.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pDateOfBirth", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@pCustomerType", customer.CustomerType.ToString());
                cmd.Parameters.AddWithValue("@pEmergencyContactName",
                    customer.EmergencyContactName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmergencyContactPhone",
                    customer.EmergencyContactPhone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pIsBlacklisted", customer.IsBlacklisted);
            });

            customer.CustomerId = customerId;
            return customerId;
        }

        public List<Customer> GetAllCustomers()
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
                    cmd.Parameters.AddWithValue("@pCustomerId", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@pFirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@pLastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@pAddress", customer.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEmail", customer.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pPhone", customer.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pDateOfBirth", customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@pCustomerType", customer.CustomerType.ToString());
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

        public DriverLicense GetLicenseByCustomerId(int customerId)
        {
            return DbCommandHelper.ExecuteReader(
                _connStr,
                "prcGetDriverLicenseByCustomerId",
                cmd => cmd.Parameters.AddWithValue("@pCustomerId", customerId),
                reader =>
                {
                    if (!reader.Read()) return null;
                    return DataReaderMapper.MapToModel<DriverLicense>(reader);
                }
            );
        }

        public int UpsertLicense(DriverLicense license)
        {
            return DbCommandHelper.ExecuteNonQuery(
                _connStr,
                "prcUpsertDriverLicense",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@pCustomerId", license.CustomerId);
                    cmd.Parameters.AddWithValue("@pLicenseNumber", license.LicenseNumber);
                    cmd.Parameters.AddWithValue("@pIssueDate", license.IssueDate);
                    cmd.Parameters.AddWithValue("@pExpiryDate", license.ExpiryDate);
                    cmd.Parameters.AddWithValue("@pIssuingCountry", license.IssuingCountry);
                    cmd.Parameters.AddWithValue("@pIssuingStateProvince", license.IssuingStateProvince);
                    cmd.Parameters.AddWithValue("@pLicenseImagePath", license.LicenseImagePath);
                    cmd.Parameters.AddWithValue("@pIsInternational", license.IsInternational);
                }
            );
        }
    }
}