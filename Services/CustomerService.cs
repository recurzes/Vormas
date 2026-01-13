using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAll() => _repo.GetAllCustomers();

        public Customer GetById(int id) => _repo.GetCustomerById(id);

        public void CreateCustomer(Customer customer, DriverLicense license)
        {
            bool validation = ValidateCustomerAndLicense(customer, license);
            if (!validation) return;
            
            _repo.CreateCustomer(customer);
            if (license != null && !string.IsNullOrWhiteSpace(license.LicenseNumber))
            {
                license.CustomerId = customer.CustomerId;
                _repo.UpsertLicense(license);
            }
        }

        public int UpdateCustomer(Customer customer, DriverLicense license)
        {
            bool validation = ValidateCustomerAndLicense(customer, license);
            if (!validation) return -1;
            
            int result = _repo.UpdateCustomer(customer);
            if (license != null && !string.IsNullOrWhiteSpace(license.LicenseNumber))
            {
                license.CustomerId = customer.CustomerId;
                _repo.UpsertLicense(license);
            }

            return result;
        }

        public int DeleteCustomer(int id)
        {
            if (!_repo.CustomerExists(id))
                return -1;

            return _repo.DeleteCustomer(id);
        }

        public List<CustomerTypeItem> GetCustomerTypes()
        {
            return new List<CustomerTypeItem>
            {
                new CustomerTypeItem { Value = "Individual", Text = "Individual" },
                new CustomerTypeItem { Value = "Corporate", Text = "Corporate" },
                new CustomerTypeItem { Value = "Frequent", Text = "Frequent" },
                new CustomerTypeItem { Value = "Blacklisted", Text = "Blacklisted" },
            };
        }

        public DriverLicense GetDriverLicenseByCustomerId(int customerId)
        {
            return _repo.GetLicenseByCustomerId(customerId);
        }

        private bool ValidateCustomerAndLicense(Customer customer, DriverLicense license)
        {
            // Age verification 21+
            if (customer.DateOfBirth == DateTime.MinValue)
                return false;

            var today = DateTime.Today;
            var age = today.Year - customer.DateOfBirth.Year;
            if (customer.DateOfBirth.Date > today.AddYears(-age)) age--;

            if (age < 21)
                return false;

            if (license != null && !string.IsNullOrWhiteSpace(license.LicenseNumber))
            {
                if (license.ExpiryDate < today)
                    return false;

                if (string.IsNullOrWhiteSpace(license.IssuingCountry))
                    return false;
            }

            return true;
        }

        public CustomerHistory GetCustomerHistory(int customerId)
        {
            var history = _repo.GetCustomerHistory(customerId);
            history.RentalHistory = _repo.GetCustomerRentalHistory(customerId);
            var violations = _repo.GetDrivingRecordCount(customerId);
            history.DrivingViolations = violations.TotalViolations;
            history.MajorViolations = violations.MajorViolations;
            return history;
        }

        public List<DrivingRecord> GetDrivingRecords(int customerId)
        {
            return _repo.GetDrivingRecordsByCustomerId(customerId);
        }

        public int AddDrivingRecord(DrivingRecord record)
        {
            return _repo.AddDrivingRecord(record);
        }

        public bool ValidateAgeForVehicleCategory(DateTime dateOfBirth, int categoryId)
        {
            int minAge = GetMinimumAgeForCategory(categoryId);
            int age = CalculateAge(dateOfBirth);
            return age >= minAge;
        }

        public int GetMinimumAgeForCategory(int categoryId)
        {
            switch (categoryId)
            {
                case 3: return 25; // SUV
                case 4: return 25; // Pickup
                case 5: return 25; // Van/Minibus
                default: return 21; // Hatchback, Sedan
            }
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}