using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class UserRegisterForm : PageControl
    {
        private readonly IUserManager _userManager;
        private readonly IAuthService _authService;
        private readonly INavigationService _navigation;

        public UserRegisterForm(IUserManager userManager, IAuthService authService, INavigationService navigation)
        {
            InitializeComponent();
            _userManager = userManager;
            _authService = authService;
            _navigation = navigation;
            
            // Populate roles
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Rental Agent");
            cmbRole.SelectedIndex = 1; // Default to Rental Agent
            
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtVerifyPassword.Text))
                {
                    MessageBox.Show(@"Please fill in all fields", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtVerifyPassword.Text)
                {
                    MessageBox.Show(@"Passwords do not match", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show(@"Invalid email format", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DateTime birthDate = dtmBirthDate.Value;

                if (birthDate > DateTime.Now)
                {
                    MessageBox.Show(@"Birth date cannot be in the future", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int roleId = cmbRole.SelectedItem?.ToString() == "Admin" ? 1 : 2;

                var user = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    DateOfBirth = birthDate,
                    UserName = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    RoleId = roleId,
                    IsActive = cmbIsActive.SelectedItem?.ToString() == "Yes" ||
                               cmbIsActive.SelectedItem?.ToString() == "True"
                };
                _authService.RegisterUser(user);

                MessageBox.Show(@"Registration successful!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigation.Navigate(Routes.UserLogin);
        }
    }
}