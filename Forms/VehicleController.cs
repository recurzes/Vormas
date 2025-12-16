using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Forms
{
    // This class acts as a connection between the VehicleForm and the VehicleService.
    public class VehicleController
    {
        private readonly IVehicleService _service;
        private readonly VehicleForm _view;

        // BindingSource for managing data in the DataGridView
        private BindingSource _bindingSource;

        public VehicleController(IVehicleService service, VehicleForm view)
        {
            _service = service;
            _view = view;
            _bindingSource = new BindingSource();
            
            InitializeView();
        }

        private void InitializeView()
        {
            // Populate Dropdowns
            _view.SetCategories(_service.GetVehicleCategories());
            _view.SetStatuses(_service.GetVehicleStatuses());

            // Initial Load
            LoadVehicles();
        }

        public void LoadVehicles()
        {
            try
            {
                var vehicles = _service.GetAllVehicles();
                if (vehicles == null || !vehicles.Any())
                {
                    MessageBox.Show("No vehicles found in the database.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    _bindingSource.DataSource = new List<Vehicle>();
                    return;
                }
                _bindingSource.DataSource = vehicles;
                _view.SetVehicleListBinding(_bindingSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchVehicles(string query)
        {
            // Implementing basic filtering on the loaded list for simplicity, 
            // alternatively could call a service method for database-side filtering.
            if (_bindingSource.DataSource is List<Vehicle> allVehicles)
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                     _bindingSource.DataSource = _service.GetAllVehicles(); // Reset
                }
                else
                {
                    var filtered = allVehicles.FindAll(v => 
                        v.Make.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        v.Model.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        v.LicensePlate.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
                     _bindingSource.DataSource = filtered;
                }
                _bindingSource.ResetBindings(false);
            }
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle.VehicleId == 0)
                {
                    _service.AddVehicle(vehicle);
                    MessageBox.Show("Vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _service.UpdateVehicle(vehicle);
                    MessageBox.Show("Vehicle updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadVehicles();
                _view.ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving vehicle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            if (MessageBox.Show("Are you sure you want to delete this vehicle?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _service.DeleteVehicle(vehicleId);
                    LoadVehicles();
                    _view.ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting vehicle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
