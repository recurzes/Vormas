using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class UserLoginForm : PageControl
    {
        private readonly IAuthService _authService;
        private readonly ISessionService _session;
        private readonly INavigationService _navigation;
        public UserLoginForm(IAuthService authService, ISessionService session, INavigationService navigation)
        {
            InitializeComponent();
            _authService = authService;
            _session = session;
            _navigation = navigation;
            
            this.Resize += (s, e) => CenterPanel();
            this.Load += (s, e) => CenterPanel();
        }

        private void CenterPanel()
        {
            if (pnlCard != null)
            {
                pnlCard.Left = (this.ClientSize.Width - pnlCard.Width) / 2;
                pnlCard.Top = (this.ClientSize.Height - pnlCard.Height) / 2;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show(@"Username and password are required", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (_authService.LoginUser(username, password))
                {
                    MessageBox.Show(@"Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var currentUser = _session.CurrentUser;

                    // Navigate to dashboards using the navigation service
                    switch (currentUser.RoleId)
                    {
                        case 1:
                            _navigation.Navigate(Routes.AdminDashboard);
                            break;
                        case 2:
                            _navigation.Navigate(Routes.RentalAgentDashboard);
                            break;
                        default:
                            MessageBox.Show(@"Invalid role assigned to user", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            _session.ClearSession();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(@"Invalid username or password", "Login Failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _navigation.Navigate(Routes.UserRegister);
        }

    }
}