
# VORMAS: Vehicle Rental Management System

A multi-platform vehicle rental management system featuring a C# WinForms desktop application and a modern Vite/React web dashboard. Vormas provides a complete solution for fleet management, customer tracking, reservations, rentals, and automated billing.

## 1. Project Overview

Vormas is designed for efficiency and ease of use in the vehicle rental industry. Key capabilities include:

- **Fleet Management**: Comprehensive tracking of vehicle status, categories, and maintenance.
- **Customer Lifecycle**: Managing records, licenses, and driving history with blacklisting support.
- **Dynamic Reservations**: Real-time availability checking and booking management.
- **Rental Operations**: Streamlined pickup and return workflows with inspection logging.
- **Financial Module**: Automated invoice generation, payment processing, and PDF export.
- **Analytics Dashboard**: High-level metrics for both Admin and Rental Agent roles.

The project utilizes a service-oriented architecture, separating business logic from presentation, and leverages stored procedures for high-performance database operations.

## 2. Technologies Used

- **Desktop**: C# .NET (WinForms)
- **Web**: React, Vite, Vanilla CSS
- **Database**: MariaDB / MySQL (Stored Procedures)
- **State Management**: Context API / Custom Services
- **Version Control**: Git

## 3. Project Structure

```
Vormas/
├── Database/        # Seeders and DB initialization
├── Forms/           # WinForms UI components (Pages, Controls)
├── Helpers/         # Utility classes
├── Interfaces/      # Service and Repository contracts
├── Models/          # Core entity models
├── Navigation/      # Navigation services/logic
├── Services/        # Business logic layer
├── SQL Script/      # Database schema and stored procedures
├── Web/             # Vite/React frontend
│   └── src/         # API, Components, Pages, Styles
├── Vormas.sln       # Visual Studio solution
└── ProjectDocumentation.md  # Comprehensive system documentation
```

## 4. Getting Started

### Prerequisites

- .NET Framework 4.7.2+
- Node.js & npm (for Web Dashboard)
- MariaDB 10.4+ / MySQL 8.0+

### Setup Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/AnexVon/Vormas.git
   cd Vormas
   ```

2. **Database Setup**:
   - Execute the latest SQL dump in `SQL Script/` using your preferred DB manager.
   - Configure the connection string in `App.config`.

3. **Run Desktop App**:
   - Open `Vormas.sln` in Visual Studio / Rider.
   - Build and run the `Vormas` project.

4. **Run Web Dashboard**:
   ```bash
   cd Web
   npm install
   npm run dev
   ```

## 5. Documentation

The system is fully documented in the following files:

- **[ProjectDocumentation.md](ProjectDocumentation.md)**: Full architecture, functional requirements, and technical specs.
- **ERD Diagram**: Available in the brain/artifacts directory (Mermaid format).
- **UML Diagrams**: Class and Use Case diagrams available in the brain/artifacts directory.

## 6. Development Team

- **Lance Sebastian Limbaro**: Lead Developer
- **Anex Von Santarin**: Lead Developer

