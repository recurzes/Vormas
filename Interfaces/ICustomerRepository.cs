using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface ICustomerRepository
    {
        int CreateCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByPhone(string phoneNumber);
        Customer GetCustomerByEmail(string email);
        
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(int customerId);
        bool CustomerExists(int customerId);
        bool IsPhoneNumberTaken(string phoneNumber);
        bool IsEmailTaken(string email);
        
        // Search and Filtering
        List<Customer> SearchCustomers(string searchTerm);
        List<Customer> GetCustomerByStatus();

        int DeactivateCustomer(int customerId);
        int ActivateCustomer(int customerId);

        DriverLicense GetLicenseByCustomerId(int customerId);
        int UpsertLicense(DriverLicense license);
    }
}