# Project Documentation: Vormas Vehicle Rental Management System

## 1. Executive Summary
Vormas is a comprehensive Vehicle Rental Management System designed to streamline the operations of a vehicle rental business. It provides tools for managing vehicle fleets, customer records, reservations, rentals (pickups and returns), billing, and maintenance. The system supports multiple user roles (Admin and Rental Agent) to ensure secure and efficient task allocation.

## 2. System Architecture
Vormas is built using a hybrid architecture:
- **Desktop Application (WinForms)**: Used for core management tasks like vehicle inventory, user management, and detailed reporting.
- **Web Frontend (Vite/React)**: Provides a modern interface for dashboards and potentially customer-facing features.
- **Database (MariaDB/MySQL)**: Centralized storage for all system data.

## 3. Functional Requirements

### 3.1 Vehicle Management
- Add, update, and remove vehicles.
- Categorize vehicles (Sedan, SUV, etc.).
- Track vehicle status (Available, Rented, Maintenance).
- Manage vehicle features and images.

### 3.2 Customer Management
- Maintain detailed customer profiles.
- Track driving records and license information.
- Blacklist customers based on history.

### 3.3 Reservation and Rental Flow
- Check vehicle availability for specific date ranges.
- Create and manage reservations.
- Process vehicle pickups (start rental) and returns (complete rental).
- Recording odometer readings and fuel levels.

### 3.4 Billing and Payments
- Generate invoices automatically upon rental completion.
- Support for multiple payment methods (Cash, Card, etc.).
- PDF export for invoices.

### 3.5 Damage and Maintenance
- Record vehicle damage during return inspections.
- Create damage reports and assign repair costs.
- Track routine and emergency maintenance records.

## 4. Technical Specifications
- **Language**: C# (.NET Framework) for Desktop, JavaScript/CSS/HTML for Web.
- **Tools**: SQL (Stored Procedures used for complex logic), Git for Version Control.
- **Design Patterns**: Service Layer pattern for business logic, Repository pattern (implied via stored procedures).

## 5. Database Schema (ERD)
The system uses a relational database with 20 tables. Key entities include Users, Customers, Vehicles, Rentals, and Invoices.

```mermaid
erDiagram
    USERS ||--o{ RENTALS : "Pickup/Return Agent"
    USERS ||--o{ RESERVATIONS : "Created By"
    USERS ||--o{ PAYMENTS : "Processed By"
    USERS ||--o{ DAMAGE_REPORTS : "Reported/Approved By"
    ROLES ||--o{ USERS : "assigned to"
    
    CUSTOMERS ||--o{ RENTALS : "makes"
    CUSTOMERS ||--o{ RESERVATIONS : "makes"
    CUSTOMERS ||--o{ DRIVER_LICENSES : "has"
    CUSTOMERS ||--o{ DRIVING_RECORDS : "has"
    
    VEHICLES ||--o{ RENTALS : "is rented"
    VEHICLES ||--o{ RESERVATIONS : "is reserved"
    VEHICLES ||--o{ DAMAGES : "has"
    VEHICLES ||--o{ MAINTENANCE_RECORDS : "undergoes"
    VEHICLES ||--o{ VEHICLE_IMAGES : "has"
    VEHICLES ||--o{ VEHICLE_FEATURE_ASSIGNMENTS : "has features"
    
    VEHICLE_CATEGORIES ||--o{ VEHICLES : "categorizes"
    VEHICLE_CATEGORIES ||--o{ RATE_CONFIGURATIONS : "has rates"
    
    VEHICLE_FEATURES ||--o{ VEHICLE_FEATURE_ASSIGNMENTS : "assigned to"
    
    RENTALS ||--o| RESERVATIONS : "from"
    RENTALS ||--o{ DAMAGE_REPORTS : "generates"
    RENTALS ||--o{ INVOICES : "billed by"
    RENTALS ||--o{ VEHICLE_INSPECTIONS : "includes"
    
    INVOICES ||--o{ INVOICE_LINE_ITEMS : "contains"
    INVOICES ||--o{ PAYMENTS : "paid by"
    
    DAMAGES ||--o{ DAMAGE_REPORTS : "reported in"
```

## 6. UML Diagrams

### 6.1 Class Diagram
Visualizes the core models and services within the system.

```mermaid
classDiagram
    class Person {
        +int Id
        +string FirstName
        +string LastName
        +string Email
        +string Phone
    }

    class User {
        +string Username
        +string PasswordHash
        +int RoleId
        +bool IsActive
    }

    class Customer {
        +string Address
        +DateTime DateOfBirth
        +string CustomerType
        +bool IsBlacklisted
    }

    Person <|-- User
    Person <|-- Customer

    class Vehicle {
        +int VehicleId
        +string VehicleCode
        +string Make
        +string Model
        +int CategoryId
        +string Status
    }

    class Rental {
        +int RentalId
        +int CustomerId
        +int VehicleId
        +DateTime PickupDateTime
        +DateTime ReturnDateTime
    }
```

### 6.2 Use Case Diagram
Describes the interactions between users and the system's features.

```mermaid
graph LR
    subgraph Vormas System
        UC1(Manage Vehicles)
        UC2(Manage Users)
        UC3(View Reports)
        UC4(Process Reservations)
        UC5(Process Rentals)
        UC6(Manage Customers)
        UC7(Billing & Payments)
        UC8(Damage Reports)
        UC9(Configure Rates)
    end

    Admin((Admin))
    Agent((Rental Agent))
    Customer((Customer))

    Admin --> UC1
    Admin --> UC2
    Admin --> UC3
    Admin --> UC9
    Admin --> UC8

    Agent --> UC4
    Agent --> UC5
    Agent --> UC6
    Agent --> UC7
    Agent --> UC8

    Customer --- UC4
```
