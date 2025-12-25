using System.Collections.Generic;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _repo;

        public CustomerRepository(CustomerDbContext repo)
        {
            _repo = repo;
        }
        
        // Methods
        public int CreateCustomer(Customer customer)
        {
            return _repo.CreateCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
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

        public DriverLicense GetLicenseByCustomerId(int customerId)
        {
            return _repo.GetLicenseByCustomerId(customerId);
        }

        public int UpsertLicense(DriverLicense license)
        {
            return _repo.UpsertLicense(license);
        }
    }
}