using System;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void CreateReservation(Reservation reservation)
        {
            // Business Logic Validation rules
            if (reservation.StartDate >= reservation.EndDate)
            {
                throw new ArgumentException("Start date must be before end date.");
            }

            if (reservation.StartDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Reservation start date cannot be in the past.");
            }

            // Check availability
            bool isAvailable = _reservationRepository.CheckVehicleAvailability(reservation.VehicleId, reservation.StartDate, reservation.EndDate);

            if (!isAvailable)
            {
                throw new InvalidOperationException("The selected vehicle is not available for the specified dates.");
            }

            // Proceed to create
            _reservationRepository.CreateReservation(reservation);
        }
    }
}