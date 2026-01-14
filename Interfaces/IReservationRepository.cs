using System;
using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IReservationRepository
    {
        int CreateReservation(ReservationRequest request);
        void CancelReservation(int reservationId);
        List<Reservation> GetAllReservations(string statusFilter = null);
        Reservation GetReservationById(int reservationId);
        List<Vehicle> GetVehiclesForDateRange(DateTime startDate, DateTime endDate);
        bool CheckVehicleAvailability(int vehicleId, DateTime startDate, DateTime endDate, int? excludeReservationId = null);
        List<Customer> GetEligibleCustomers();
    }
}
