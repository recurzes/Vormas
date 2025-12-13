using System.Collections.Generic;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class CustomerManager: ICustomerManager
    {
        private readonly CustomerDbContext _repo;

        public CustomerManager(CustomerDbContext repo)
        {
            _repo = repo;
        }
        
        // Methods
        public void CreateCustomer(Customer customer)
        {
            
        }

        public List<Customer> GetALlCustomers()
        {
            throw new System.NotImplementedException();
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