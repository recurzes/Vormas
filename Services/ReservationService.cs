using System;
using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public int CreateReservation(ReservationRequest request)
        {
            return _repository.CreateReservation(request);
        }

        public void CancelReservation(int reservationId)
        {
            _repository.CancelReservation(reservationId);
        }

        public List<Reservation> GetAllReservations(string statusFilter = null)
        {
            return _repository.GetAllReservations(statusFilter);
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _repository.GetReservationById(reservationId);
        }

        public List<Vehicle> GetVehiclesForDateRange(DateTime startDate, DateTime endDate)
        {
            return _repository.GetVehiclesForDateRange(startDate, endDate);
        }

        public bool CheckVehicleAvailability(int vehicleId, DateTime startDate, DateTime endDate, int? excludeReservationId = null)
        {
            return _repository.CheckVehicleAvailability(vehicleId, startDate, endDate, excludeReservationId);
        }

        public List<Customer> GetEligibleCustomers()
        {
            return _repository.GetEligibleCustomers();
        }
    }
}
