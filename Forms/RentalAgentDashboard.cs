using System;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Services;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class RentalAgentDashboard : PageControl
    {
        private readonly ISessionService _session;
        public RentalAgentDashboard(ISessionService session)
        {
            _session = session;
            InitializeComponent();
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            // Resolve dependencies manually for now
            var vehicleDbContext = new VehicleDbContext();
            var customerDbContext = new CustomerDbContext();
            var reservationDbContext = new ReservationDbContext();

            IVehicleRepository vehicleRepo = vehicleDbContext;
            ICustomerManager customerManager = new CustomerManager(customerDbContext);
            IReservationRepository reservationRepo = reservationDbContext;
            IReservationService reservationService = new ReservationService(reservationRepo);

            var form = new ReservationForm(reservationService, vehicleRepo, customerManager);
            form.ShowDialog();
        }
    }
}