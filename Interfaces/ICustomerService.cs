using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void CreateCustomer(Customer customer, DriverLicense license);
        int UpdateCustomer(Customer customer, DriverLicense license);
        int DeleteCustomer(int id);

        List<CustomerTypeItem> GetCustomerTypes();
    }

    public class CustomerTypeItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}