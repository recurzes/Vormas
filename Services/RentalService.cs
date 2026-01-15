using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public int StartRental(RentalPickupRequest request)
        {
            return _repository.StartRental(request);
        }

        public void CompleteRental(RentalReturnRequest request)
        {
            _repository.CompleteRental(request);
        }

        public List<Rental> GetActiveRentals()
        {
            return _repository.GetActiveRentals();
        }

        public Rental GetRentalById(int rentalId)
        {
            return _repository.GetRentalById(rentalId);
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return _repository.GetAvailableVehicles();
        }

        public List<Customer> GetEligibleCustomers()
        {
            return _repository.GetEligibleCustomers();
        }
    }
}
