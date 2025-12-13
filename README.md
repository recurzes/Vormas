
# VORMAS

A C# WinForms application for managing vehicle rentals, including fleet management, customer management, reservations, rentals/returns, billing, and basic reporting.

## 1. Project Overview

This system allows a rental company to:

- Manage vehicle fleet and categories  
- Register and manage customers and their licenses  
- Create and manage reservations  
- Handle vehicle pickup and return with inspections  
- Generate invoices and record payments  
- View key metrics on a dashboard

The project follows MVC-style separation in WinForms and applies basic SOLID principles.

## 2. Technologies Used

- C# .NET (WinForms)  
- MySQL (or SQL Server, depending on your setup)  
- ADO.NET / MySQL Connector  
- Git and GitHub for version control

## 3. Solution Structure

```
VehicleRental.sln  
├── VehicleRental.UI/ // WinForms (Views + Controllers)  
│ ├── Forms/  
│ ├── Controllers/  
│ └── Program.cs  
├── VehicleRental.Domain/ // Entities + Interfaces + DTOs  
│ ├── Entities/  
│ ├── Interfaces/  
│ └── DTOs/  
└── VehicleRental.Infrastructure/ // Repositories + DB scripts  
├── Repositories/  
└── Database/
```


- UI: Forms and controllers (presentation layer)  
- Domain: Business entities, service and repository interfaces  
- Infrastructure: Data access and database scripts

## 4. Getting Started

### Prerequisites

- .NET SDK (version used in the project)  
- MySQL server (or SQL Server, based on your DB choice)  
- MySQL client or GUI tool (e.g., MySQL Workbench)

### Setup Steps

1. Clone the repository:

`- git clone [https://github.com/your-org/vehicle-rental.git](https://github.com/your-org/vehicle-rental.git)`
`- cd vehicle-rental`

3. Configure connection string: - In `VehicleRental.UI` configuration file (e.g., `App.config`), set the connection string:
```xml
<connectionStrings> 
<add name="MySQL" connectionString="Server=localhost;Database=VehicleRentalDB;Uid=your_user;Pwd=your_password;"/> 
</connectionStrings>
```

4. Build and run:
- Open the solution in Visual Studio. 
- Set `VehicleRental.UI` as startup project. 
- Build and run the application. 
- Log in with the sample admin user defined in the seed data.

## 5. Main Features

- **User Management** 
- Admin and Rental Agent roles 
- Login and basic role-based access 

- **Vehicle Fleet Management** 
- Add, edit, view vehicles 
- Vehicle categories and statuses (available, rented, reserved, under maintenance) 

- **Customer Management** 
- Add and update customers 
- Driver license information and age validation 

- **Reservations** 
- Create reservations for a vehicle and date range 
- Basic availability logic to prevent double booking 

- **Rentals (Pickup and Return)** 
- Start rental from reservation 
- Record pickup and return inspections 
- Update vehicle mileage and status 

- **Billing** 
- Generate invoice for a rental 
- Record payments 

- **Dashboard** 
- Show key summary data (active rentals, today's pickups/returns, etc.)


## 6. Branching and Workflow

- `main`: stable release branch 

- Feature branches: 
- `database-init`: database schema, ERD, and basic seed data 
- `auth`, `vehicles`, `customers`, `reservations`, `rentals`, `billing`, `reports`, `ui-polish` 

- Typical workflow: 
- Create feature branch from `develop` 
- Commit small changes frequently 
- Open pull request to `develop` 
- Merge after review and testing

## 7. Testing

- Manual testing through the UI: 
- Login - Create customer 
- Add vehicle 
- Create reservation 
- Start rental (pickup) 
- Complete rental (return) 
- Generate invoice and record payment


## 8. Documentation

The repository includes:

- ERD diagram (PlantUML and exported image) 
- UML diagrams (Class Diagram and Use Case Diagram)
- Project documentation describing architecture, modules, and key business rules

## 9. Future Improvements

- More advanced reporting and exports 
- Better error handling and logging 
- More granular permissions 
- Improved UI styling and user experience

## 10. Team

- Lance Sebastian Limbaro: Lead developer (auth, rentals, billing) 
- Anex Von Santarin: Lead Developer (vehicles, customers, dashboard)
