using System;
using System.Windows.Forms;
using Vormas.Navigation;

namespace Vormas.Forms.Temp
{
    public partial class Dashboard : PageControl
    {
        private readonly INavigationService _navigation;
        public Dashboard(INavigationService navigation)
        {
            InitializeComponent();

            _navigation = navigation;
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(Routes.Vehicles);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(Routes.UserLogin);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(Routes.Customers);
        }
    }
}