using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Forms
{
    public partial class UserRegisterForm : Form
    {
        private readonly IUserManager _userManager;
        public UserRegisterForm(IUserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
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
                    MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtVerifyPassword.Text)
                {
                    MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Invalid email format", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DateTime birthDate = dtmBirthDate.Value;

                if (birthDate > DateTime.Now)
                {
                    MessageBox.Show("Birth date cannot be in the future", "Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    BirthDate = birthDate,
                    UserName = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    RoleId = Convert.ToInt32(cmbRole.SelectedItem?.ToString()),
                    IsActive = cmbIsActive.SelectedItem?.ToString() == "Yes" ||
                               cmbIsActive.SelectedItem?.ToString() == "True"
                };
                _userManager.Create(user);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}