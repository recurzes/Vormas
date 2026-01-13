using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IRentalRepository
    {
        int StartRental(RentalPickupRequest request);
        void CompleteRental(RentalReturnRequest request);
        List<Rental> GetActiveRentals();
        Rental GetRentalById(int rentalId);
        List<Vehicle> GetAvailableVehicles();
        List<Customer> GetEligibleCustomers();
    }
}
