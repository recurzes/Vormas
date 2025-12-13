using System;
using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;
namespace Vormas.Database
{
    public class CustomerDbContext: ICustomerManager
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();
        
        public void CreateCustomer(Customer customer)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcCreateCustomer", cmd =>
            {
                cmd.Parameters.AddWithValue("@pFirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@pLastName", customer.LastName);
                cmd.Parameters.AddWithValue("@pAddress", customer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmail", customer.Email ?? (object) DBNull.Value);
                cmd.Parameters.AddWithValue("@pFirstName", customer.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pDateOfBirth", customer.BirthDate);
                cmd.Parameters.AddWithValue("@pCustomerType", customer.CustomerType);
                cmd.Parameters.AddWithValue("@pEmergencyContactName", customer.EmergencyContactName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pEmergencyContactPhone", customer.EmergencyContactPhone ?? (object)DBNull.Value);
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
                reader =>
                {
                    var customers = new List<Customer>();
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            
                        };
                        
                        customers.Add(customer);
                    }

                    return customers;
                }
            );
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerByPhone(string phoneNumber)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public bool CustomerExists(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPhoneNumberTaken(string phoneNumber)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmailTaken(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomerByStatus()
        {
            throw new System.NotImplementedException();
        }

        public int DeactivateCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public int ActivateCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}