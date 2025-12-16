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
            _repo.CreateCustomer(customer);
        }

        public List<Customer> GetALlCustomers()
        {
            return _repo.GetALlCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _repo.GetCustomerById(customerId);
        }

        public Customer GetCustomerByPhone(string phoneNumber)
        {
            return _repo.GetCustomerByPhone(phoneNumber);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public int UpdateCustomer(Customer customer)
        {
            return _repo.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int customerId)
        {
            return _repo.DeactivateCustomer(customerId);
        }

        public bool CustomerExists(int customerId)
        {
            return _repo.CustomerExists(customerId);
        }

        public bool IsPhoneNumberTaken(string phoneNumber)
        {
            return _repo.IsPhoneNumberTaken(phoneNumber);
        }

        public bool IsEmailTaken(string email)
        {
            return _repo.IsEmailTaken(email);
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            return _repo.SearchCustomers(searchTerm);
        }

        public List<Customer> GetCustomerByStatus()
        {
            return _repo.GetCustomerByStatus();
        }

        public int DeactivateCustomer(int customerId)
        {
            return _repo.DeactivateCustomer(customerId);
        }

        public int ActivateCustomer(int customerId)
        {
            return _repo.ActivateCustomer(customerId);
        }
    }
}