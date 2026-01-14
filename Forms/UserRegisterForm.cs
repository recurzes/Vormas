using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
        
        // Validation Constants
        private const int MinPasswordLength = 8;
        private readonly Color ErrorColor = Color.FromArgb(239, 68, 68); // Red-500
        private readonly Color SuccessColor = Color.FromArgb(16, 185, 129); // Emerald-500
        private readonly Color NeutralColor = Color.Gray;

        public UserRegisterForm(IUserManager userManager, IAuthService authService, INavigationService navigation)
        {
            InitializeComponent();
            _userManager = userManager;
            _authService = authService;
            _navigation = navigation;
            
            InitializeEvents();
            SetDefaults();
        }

        private void InitializeEvents()
        {
            // Password Show/Hide
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            
            // Real-time Validation
            txtPassword.TextChanged += TxtPassword_TextChanged;
            txtVerifyPassword.TextChanged += Validation_TextChanged;
            txtUsername.TextChanged += Validation_TextChanged;
            txtEmail.TextChanged += Validation_TextChanged;
            txtFirstName.TextChanged += Validation_TextChanged;
            txtLastName.TextChanged += Validation_TextChanged;
            txtPhone.TextChanged += Validation_TextChanged;
            chkTerms.CheckedChanged += Validation_TextChanged;

            // Button Hover Effects
            btnRegister.MouseEnter += (s, e) => btnRegister.BackColor = Color.FromArgb(29, 78, 216); // Measured hover
            btnRegister.MouseLeave += (s, e) => btnRegister.BackColor = Color.FromArgb(37, 99, 235); // Original
        }

        private void SetDefaults()
        {
            // Default role behavior (Hidden controls)
            if (cmbRole.Items.Count == 0) cmbRole.Items.Add("2"); // Default to Customer/User ID if logic parses Int
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            
            cmbIsActive.Items.Add("True");
            cmbIsActive.SelectedIndex = 0;
            
            ValidateForm(); // Initial state check
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
            txtVerifyPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            UpdatePasswordStrength();
            ValidateForm();
        }

        private void Validation_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void UpdatePasswordStrength()
        {
            string password = txtPassword.Text;
            int score = 0;

            // Length Check
            if (password.Length >= MinPasswordLength)
            {
                score++;
                SetLabelStatus(lblLengthCheck, true);
            }
            else
            {
                SetLabelStatus(lblLengthCheck, false);
            }

            // Number Check
            if (Regex.IsMatch(password, @"[0-9]"))
            {
                score++;
                SetLabelStatus(lblNumberCheck, true);
            }
            else
            {
                SetLabelStatus(lblNumberCheck, false);
            }

            // Special Char Check
            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                score++;
                SetLabelStatus(lblSpecialCheck, true);
            }
            else
            {
                SetLabelStatus(lblSpecialCheck, false);
            }

            // Update Progress Bar
            int progress = (score * 33);
            pbPasswordStrength.Value = Math.Min(100, progress);

            // Update Label Logic
            if (score == 3)
            {
                lblPasswordStrength.Text = "Strength: Strong";
                lblPasswordStrength.ForeColor = SuccessColor;
            }
            else if (score == 2)
            {
                lblPasswordStrength.Text = "Strength: Medium";
                lblPasswordStrength.ForeColor = Color.Orange;
            }
            else
            {
                lblPasswordStrength.Text = "Strength: Weak";
                lblPasswordStrength.ForeColor = ErrorColor;
            }
        }

        private void SetLabelStatus(Label label, bool valid)
        {
            label.ForeColor = valid ? SuccessColor : ErrorColor;
            // Could add symbol change here if labels had icons
        }

        private void ValidateForm()
        {
            bool isValid = true;

            // Terms
            if (!chkTerms.Checked) isValid = false;

            // Empty Checks
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                isValid = false;
            }

            // Passwords Match
            if (txtPassword.Text != txtVerifyPassword.Text)
            {
                isValid = false;
                // Optional: Show mismatch error
            }
            
            // Password Requirements (Must meet all 3 for 'Strong' enforcement, or just Length?)
            // Let's enforce Length min and Match.
            if (txtPassword.Text.Length < MinPasswordLength) isValid = false;

            btnRegister.Enabled = isValid;
            btnRegister.BackColor = isValid ? Color.FromArgb(37, 99, 235) : Color.Gray;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Final full validation
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show(@"Invalid email format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtmBirthDate.Value > DateTime.Now.AddYears(-13)) // Basic age check
                {
                    MessageBox.Show(@"You must be at least 13 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    DateOfBirth = dtmBirthDate.Value,
                    UserName = txtUsername.Text,
                    PasswordHash = txtPassword.Text, // Note: In production, hash this! 
                    RoleId = 2, // Default to Customer
                    IsActive = true
                };

                _authService.RegisterUser(user);

                MessageBox.Show(@"Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Reset form or Navigate
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearForm()
        {
             txtFirstName.Clear();
             txtLastName.Clear();
             txtEmail.Clear();
             txtPhone.Clear();
             txtAddress.Clear();
             txtUsername.Clear();
             txtPassword.Clear();
             txtVerifyPassword.Clear();
             chkTerms.Checked = false;
             dtmBirthDate.Value = DateTime.Now;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _navigation.Navigate(Routes.UserLogin);
        }
    }
}