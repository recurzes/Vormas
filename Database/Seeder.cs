using System;
using Vormas.Helpers;

namespace Vormas.Database
{
    public static class Seeder
    {
        public static void Seed()
        {
            try 
            {
                var connStr = MySqlHelper.GetConnectionString();
                
                // Seed Vehicle Categories
                DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                {
                    cmd.CommandText = @"
                        INSERT IGNORE INTO vehiclecategories (CategoryId, Name) VALUES 
                        (1, 'Hatchback'),
                        (2, 'Sedan'),
                        (3, 'SUV'),
                        (4, 'Pickup'),
                        (5, 'Van/Minibus');";
                    cmd.CommandType = System.Data.CommandType.Text;
                });
                
                PatchStoredProcedures(connStr);
            }
            catch (Exception ex)
            {
                // Log or ignore if seed fails (e.g. connectivity)
                System.Diagnostics.Debug.WriteLine($"Seeding failed: {ex.Message}");
            }
        }
        private static void PatchStoredProcedures(string connStr)
        {
             // Ensure IsDeleted column exists
             try 
             {
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = @"
                        ALTER TABLE vehicles ADD COLUMN IF NOT EXISTS IsDeleted BIT DEFAULT 0;";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });
             }
             catch { /* Ignore if IF NOT EXISTS not supported or fails */ }

             // Fix prcGetAllVehicles to include ImagePath and Filter Deleted
             try 
             {
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = "DROP PROCEDURE IF EXISTS `prcGetAllVehicles`;";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });
                 
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = @"
                        CREATE PROCEDURE `prcGetAllVehicles`()
                        BEGIN
                            SELECT 
                                VehicleId,
                                VehicleCode,
                                Make,
                                Model,
                                Year,
                                Color,
                                LicensePlate,
                                VIN,
                                CategoryId, 
                                Transmission,
                                FuelType,
                                SeatingCapacity,
                                Odometer,
                                CargoCapacity,
                                FuelEfficiency,
                                Status,
                                ImagePathMain AS ImagePath
                            FROM vehicles
                            WHERE IsDeleted = 0
                            ORDER BY VehicleId DESC;
                        END";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });

                 // Patch prcGetVehiclesForDateRange
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = "DROP PROCEDURE IF EXISTS `prcGetVehiclesForDateRange`;";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });
                 
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = @"
                        CREATE PROCEDURE `prcGetVehiclesForDateRange`(IN pStartDate DATETIME, IN pEndDate DATETIME)
                        BEGIN
                            SELECT v.*, v.ImagePathMain AS ImagePath
                            FROM vehicles v
                            WHERE v.IsDeleted = 0
                              AND v.Status NOT IN ('Retired', 'OutOfService')
                              AND v.VehicleId NOT IN (
                                  SELECT VehicleId FROM reservations 
                                  WHERE Status NOT IN ('Cancelled')
                                    AND ((pStartDate >= StartDateTime AND pStartDate < EndDateTime)
                                         OR (pEndDate > StartDateTime AND pEndDate <= EndDateTime)
                                         OR (pStartDate <= StartDateTime AND pEndDate >= EndDateTime))
                              )
                              AND v.VehicleId NOT IN (
                                  SELECT VehicleId FROM rentals 
                                  WHERE Status = 'Active'
                                    AND (ReturnDateTime IS NULL OR pStartDate < ReturnDateTime)
                              )
                            ORDER BY v.VehicleCode;
                        END";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });

                 // Patch prcCheckVehicleAvailability (Fixes column names)
                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = "DROP PROCEDURE IF EXISTS `prcCheckVehicleAvailability`;";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });

                 DbCommandHelper.ExecuteNonQuery(connStr, string.Empty, cmd =>
                 {
                     cmd.CommandText = @"
                        CREATE PROCEDURE `prcCheckVehicleAvailability`(
                            IN pVehicleId INT, 
                            IN pStartDate DATETIME, 
                            IN pEndDate DATETIME, 
                            IN pExcludeReservationId INT
                        )
                        BEGIN
                            DECLARE conflictCount INT;
                            SELECT COUNT(*) INTO conflictCount
                            FROM reservations
                            WHERE VehicleId = pVehicleId
                              AND Status NOT IN ('Cancelled')
                              AND (pExcludeReservationId IS NULL OR ReservationId != pExcludeReservationId)
                              AND ((pStartDate >= StartDateTime AND pStartDate < EndDateTime)
                                   OR (pEndDate > StartDateTime AND pEndDate <= EndDateTime)
                                   OR (pStartDate <= StartDateTime AND pEndDate >= EndDateTime));
                            
                            SELECT (conflictCount = 0) AS IsAvailable;
                        END";
                     cmd.CommandType = System.Data.CommandType.Text;
                 });
             }
             catch(Exception ex)
             {
                  System.Diagnostics.Debug.WriteLine($"SP Patch failed: {ex.Message}");
             }
        }
    }
}
