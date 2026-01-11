using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Forms.Pages
{
    public partial class UserManagementControl : UserControl
    {
        private readonly IAuthService _authService;
        private readonly IUserManager _userManager;
        private User _selectedUser;
        private readonly BindingSource _bindingSource;

        public UserManagementControl(IAuthService authService, IUserManager userManager)
        {
            InitializeComponent();
            _bindingSource = new BindingSource();

            _selectedUser = new User();
            _authService = authService ?? throw new ArgumentException(nameof(authService));
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            
            InitializeData();
        }
        
        private void InitializeData()
        {
            if (_userManager == null) return;
    
            ConfigureGrid();
            LoadUsers();
        }

        private void ConfigureGrid()
        {
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AutoGenerateColumns = false;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "UserId", HeaderText = @"User Id", Width = 80 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Username", HeaderText = @"Username", Width = 40 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "FirstName", HeaderText = @"First Name" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LastName", HeaderText = @"Last Name" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = @"Email" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = @"Phone" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DateOfBirth", HeaderText = @"Birth Date" });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RoleId", HeaderText = @"Role Id", Width = 50 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "IsActive", HeaderText = @"Is Active" });
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is User user)
            {
                PopulateFields(user);
            }
        }

        private void PopulateFields(User user)
        {
            _selectedUser = user;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            txtUsername.Text = user.UserName;
            dtmBirthDate.Value = user.DateOfBirth;
            cmbRole.SelectedItem = user.RoleId;
            cmbIsActive.SelectedItem = user.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show(@"Please fill in all fields", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtVerifyPassword.Text)
                {
                    MessageBox.Show(@"Passwords do not match", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show(@"Invalid email format", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DateTime birthDate = dtmBirthDate.Value;

                if (birthDate > DateTime.Now)
                {
                    MessageBox.Show(@"Birth date cannot be in the future", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                
                _selectedUser.FirstName = txtFirstName.Text;
                _selectedUser.LastName = txtLastName.Text;
                _selectedUser.Email = txtEmail.Text;
                _selectedUser.Phone = txtPhone.Text;
                _selectedUser.UserName = txtUsername.Text;
                _selectedUser.DateOfBirth = dtmBirthDate.Value;
                _selectedUser.PasswordHash = txtPassword.Text;
                if (cmbRole.SelectedItem != null && int.TryParse(cmbRole.SelectedItem.ToString(), out int roleId))
                {
                    _selectedUser.RoleId = roleId;
                }
                else
                {
                    MessageBox.Show(@"Please select a valid role", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (cmbIsActive.SelectedItem != null)
                {
                    _selectedUser.IsActive = cmbIsActive.SelectedItem.ToString() == "Yes";
                }
                else
                {
                    MessageBox.Show(@"Please select active status", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (_selectedUser.UserId == 0)
                    {
                        if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            MessageBox.Show(@"Password is required for new users", @"Validation Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        _authService.RegisterUser(_selectedUser);
                        MessageBox.Show(@"User added successfully.", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        var result = _userManager.UpdateUser(_selectedUser);
                        MessageBox.Show($@"User updated successfully. {result}", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    LoadUsers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error saving user: {ex.Message}", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser.UserId <= 0) return;
            if (MessageBox.Show(@"Are you sure you want to delete this user?", @"Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _userManager.DeleteUser(_selectedUser.UserId);
                LoadUsers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error deleting user: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _selectedUser = new User();
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtVerifyPassword.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            dtmBirthDate.Value = DateTime.Now;
            cmbIsActive.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
        }

        private void LoadUsers()
        {
            try
            {
                var users = _userManager.GetAllUsers();
                _bindingSource.DataSource = users;
                dgvUsers.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading users: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers(txtSearch.Text);
        }

        private void SearchUsers(string query)
        {
            var allUsers = _userManager.GetAllUsers();
            if (string.IsNullOrWhiteSpace(query))
            {
                _bindingSource.DataSource = allUsers;
            }
            else
            {
                var filtered = allUsers.FindAll(u =>
                    (u.FirstName != null && u.FirstName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (u.LastName != null && u.LastName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (u.UserName != null && u.UserName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (u.Email != null && u.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (u.Phone != null && u.Phone.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0));
                _bindingSource.DataSource = filtered;
            }

            _bindingSource.ResetBindings(false);
        }
    }
}