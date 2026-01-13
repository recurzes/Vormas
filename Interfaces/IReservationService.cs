using System;
using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetReservations();
        void CreateReservation(Reservation reservation);
        void UpdateReservationStatus(int reservationId, string status);
        bool IsVehicleAvailable(int vehicleId, DateTime start, DateTime end);
    }
}
