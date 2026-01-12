-- Create Database (if not exists)
CREATE DATABASE IF NOT EXISTS VormasDb;
USE VormasDb;

-- Users Table (Admin, RentalAgent)
CREATE TABLE IF NOT EXISTS Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Role ENUM('Admin', 'RentalAgent') NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Customers Table
CREATE TABLE IF NOT EXISTS Customers (
    CustomerId INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DriverLicenseNumber VARCHAR(50) NOT NULL UNIQUE,
    DateOfBirth DATE NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Vehicles Table
CREATE TABLE IF NOT EXISTS Vehicles (
    VehicleId INT AUTO_INCREMENT PRIMARY KEY,
    VehicleCode VARCHAR(50), 
    Make VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Color VARCHAR(30),
    LicensePlate VARCHAR(20) NOT NULL UNIQUE,
    VIN VARCHAR(50),
    VehicleType VARCHAR(50), -- Mapped to CategoryId in code
    Transmission VARCHAR(20),
    FuelType VARCHAR(20),
    SeatingCapacity INT,
    Status VARCHAR(20) NOT NULL DEFAULT 'Available',
    Mileage INT NOT NULL DEFAULT 0, -- Mapped to Odometer in code
    CurrentRate DECIMAL(18, 2) NOT NULL DEFAULT 0,
    ImagePath VARCHAR(255),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Schema Migration for Vehicles (Idempotent-ish using Procedure)
DELIMITER //

DROP PROCEDURE IF EXISTS UpgradeDatabaseSchema //
CREATE PROCEDURE UpgradeDatabaseSchema()
BEGIN
    -- Add ImagePath
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'ImagePath' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN ImagePath VARCHAR(255);
    END IF;

    -- Add VehicleCode
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'VehicleCode' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN VehicleCode VARCHAR(50);
    END IF;

    -- Add Color
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'Color' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN Color VARCHAR(30);
    END IF;

    -- Add VIN
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'VIN' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN VIN VARCHAR(50);
    END IF;

    -- Add Transmission
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'Transmission' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN Transmission VARCHAR(20);
    END IF;

    -- Add FuelType
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'FuelType' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN FuelType VARCHAR(20);
    END IF;

    -- Add SeatingCapacity
    IF NOT EXISTS (
        SELECT * FROM information_schema.columns 
        WHERE table_name = 'Vehicles' AND column_name = 'SeatingCapacity' AND table_schema = DATABASE()
    ) THEN
        ALTER TABLE Vehicles ADD COLUMN SeatingCapacity INT;
    END IF;
END //

DELIMITER ;

CALL UpgradeDatabaseSchema();
DROP PROCEDURE UpgradeDatabaseSchema;


-- Reservations Table
CREATE TABLE IF NOT EXISTS Reservations (
    ReservationId INT AUTO_INCREMENT PRIMARY KEY,
    VehicleId INT NOT NULL,
    CustomerId INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Status ENUM('Pending', 'Confirmed', 'Cancelled', 'Completed', 'NoShow') NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- Rentals Table
CREATE TABLE IF NOT EXISTS Rentals (
    RentalId INT AUTO_INCREMENT PRIMARY KEY,
    ReservationId INT,
    VehicleId INT NOT NULL,
    CustomerId INT NOT NULL,
    PickupDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    OdometerStart INT NOT NULL,
    OdometerEnd INT,
    FuelLevelStart DECIMAL(5, 2) NOT NULL, -- Percentage or Liters
    FuelLevelEnd DECIMAL(5, 2),
    TotalAmount DECIMAL(18, 2),
    Status ENUM('Active', 'Completed', 'Overdue') NOT NULL DEFAULT 'Active',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ReservationId) REFERENCES Reservations(ReservationId),
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- Payments Table
CREATE TABLE IF NOT EXISTS Payments (
    PaymentId INT AUTO_INCREMENT PRIMARY KEY,
    RentalId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Method ENUM('Cash', 'CreditCard', 'DebitCard', 'BankTransfer') NOT NULL,
    FOREIGN KEY (RentalId) REFERENCES Rentals(RentalId)
);

-- Maintenance Table
CREATE TABLE IF NOT EXISTS Maintenance (
    MaintenanceId INT AUTO_INCREMENT PRIMARY KEY,
    VehicleId INT NOT NULL,
    Description TEXT NOT NULL,
    DatePerformed DATETIME NOT NULL,
    Cost DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId)
);

-- DamageReports Table
CREATE TABLE IF NOT EXISTS DamageReports (
    DamageReportId INT AUTO_INCREMENT PRIMARY KEY,
    VehicleId INT NOT NULL,
    RentalId INT,
    Description TEXT NOT NULL,
    EstimatedCost DECIMAL(18, 2) NOT NULL,
    DateReported DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('Pending', 'Repaired', 'WrittenOff') DEFAULT 'Pending',
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId),
    FOREIGN KEY (RentalId) REFERENCES Rentals(RentalId)
);

-- Seed Initial Data (Admin User)
-- Password is 'admin123' (Example hash)
INSERT IGNORE INTO Users (Username, PasswordHash, FullName, Role)
VALUES ('admin', '1000:c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23:123456', 'System Administrator', 'Admin');

---------------------------------------------------------
-- Stored Procedures
---------------------------------------------------------

DELIMITER //

DROP PROCEDURE IF EXISTS prcAddVehicle //
CREATE PROCEDURE prcAddVehicle(
    IN pVehicleCode VARCHAR(50),
    IN pMake VARCHAR(50),
    IN pModel VARCHAR(50),
    IN pYear INT,
    IN pColor VARCHAR(30),
    IN pLicensePlate VARCHAR(20),
    IN pVin VARCHAR(50),
    IN pCategory VARCHAR(50),
    IN pTransmission VARCHAR(20),
    IN pFuelType VARCHAR(20),
    IN pSeatingCapacity INT,
    IN pOdometer INT,
    IN pStatus VARCHAR(20),
    IN pImagePath VARCHAR(255)
)
BEGIN
    INSERT INTO Vehicles (
        VehicleCode, Make, Model, Year, Color, LicensePlate, VIN, 
        VehicleType, Transmission, FuelType, SeatingCapacity, Mileage, Status, ImagePath, CreatedAt, UpdatedAt
    )
    VALUES (
        pVehicleCode, pMake, pModel, pYear, pColor, pLicensePlate, pVin, 
        pCategory, pTransmission, pFuelType, pSeatingCapacity, pOdometer, pStatus, pImagePath, NOW(), NOW()
    );
END //

DROP PROCEDURE IF EXISTS prcUpdateVehicle //
CREATE PROCEDURE prcUpdateVehicle(
    IN pVehicleCode VARCHAR(50),
    IN pMake VARCHAR(50),
    IN pModel VARCHAR(50),
    IN pYear INT,
    IN pColor VARCHAR(30),
    IN pLicensePlate VARCHAR(20),
    IN pVin VARCHAR(50),
    IN pCategory VARCHAR(50),
    IN pTransmission VARCHAR(20),
    IN pFuelType VARCHAR(20),
    IN pSeatingCapacity INT,
    IN pOdometer INT,
    IN pStatus VARCHAR(20),
    IN pImagePath VARCHAR(255)
)
BEGIN
    UPDATE Vehicles
    SET 
        Make = pMake,
        Model = pModel,
        Year = pYear,
        Color = pColor,
        VIN = pVin,
        VehicleType = pCategory,
        Transmission = pTransmission,
        FuelType = pFuelType,
        SeatingCapacity = pSeatingCapacity,
        Mileage = pOdometer,
        Status = pStatus,
        ImagePath = pImagePath,
        UpdatedAt = NOW()
    WHERE VehicleCode = pVehicleCode OR LicensePlate = pLicensePlate;
END //

DROP PROCEDURE IF EXISTS prcDeleteVehicle //
CREATE PROCEDURE prcDeleteVehicle(
    IN pVehicleId INT
)
BEGIN
    DELETE FROM Vehicles WHERE VehicleId = pVehicleId;
END //

DROP PROCEDURE IF EXISTS prcGetAllVehicles //
CREATE PROCEDURE prcGetAllVehicles()
BEGIN
    SELECT 
        VehicleId, VehicleCode, Make, Model, Year, Color, LicensePlate, VIN, 
        VehicleType AS CategoryId, 
        Transmission, FuelType, SeatingCapacity, 
        Mileage AS Odometer, 
        Status, ImagePath, CreatedAt, UpdatedAt
    FROM Vehicles;
END //

DROP PROCEDURE IF EXISTS prcGetVehicleById //
CREATE PROCEDURE prcGetVehicleById(
    IN pVehicleId INT
)
BEGIN
    SELECT 
        VehicleId, VehicleCode, Make, Model, Year, Color, LicensePlate, VIN, 
        VehicleType AS CategoryId, 
        Transmission, FuelType, SeatingCapacity, 
        Mileage AS Odometer, 
        Status, ImagePath, CreatedAt, UpdatedAt
    FROM Vehicles
    WHERE VehicleId = pVehicleId;
END //

DELIMITER ;
