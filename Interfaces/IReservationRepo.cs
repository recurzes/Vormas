using System;
using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IReservationRepository
    {
        bool CheckVehicleAvailability(int vehicleId, DateTime startDate, DateTime endDate);
        void CreateReservation(Reservation reservation);
        // Future extensibility methods (optional)
        // List<Reservation> GetAllReservations();
        // Reservation GetReservationById(int reservationId);
    }
}