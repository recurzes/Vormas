using System;
using System.Windows.Forms;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class UserLoginForm : Form
    {
        private readonly IAuthService _authService;
        private readonly ISessionService _session;
        public UserLoginForm(IAuthService authService, ISessionService session)
        {
            InitializeComponent();
            _authService = authService;
            _session = session;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username and password are required", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (_authService.LoginUser(username, password))
                {
                    MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var currentUser = _session.CurrentUser;
                    
                    Form dashboardForm = currentUser.RoleId switch
                    {
                        1 => new AdminDashboard(),
                        2 => new RentalAgentDashboard(),
                        _ => null
                    };
                    
                    if (dashboardForm != null)
                    {
                        this.Hide();
                        dashboardForm.FormClosed += (s, args) => this.Close();
                        dashboardForm.Show();
                    }
                    
                    else
                    {
                        MessageBox.Show("Invalid role assigned to user", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        _session.ClearSession();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRoleToMenu()
        {
            
        }
    }
}