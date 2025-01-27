# ACME Office Visits Management

This repository contains a **.NET 6** solution that manages office product visits for **ACME**. The goal is to provide a simple yet well-structured application demonstrating a multi-layer architecture, including repositories, services, and MVC controllers.

## Overview

ACME is a company selling office products. The marketing department’s sales representatives record their client visits in a shared Excel file. This solution aims to replace that file with a web application where users can **view, add, edit, and delete**:

- **Client** (the visited customer)
- **Date of the visit**
- **Commercial** (the responsible salesperson)
- Any other relevant details

## Requirements and Purpose

- **Platform**: .NET 6 (Core)
- **Architecture**: Clean separation of responsibilities using repositories, services, and controllers.
- **Objective**: Evaluate technical skills, simplicity of code, and ability to implement design patterns.

### Instructions

1. **Create a new repository** and make an initial commit to track the start of the process.
2. **Deliver a solution** with a clear architecture and well-documented reasoning.
3. **Send the repository URL by email** once the project is completed.

## Architecture

### 1. Core/Domain

- **Entities**: `Client`, `Commercial`, `Visit`.
- **Interfaces**: Repository contracts (e.g., `IClientRepository`, `IVisitRepository`, `ICommercialRepository`).
- **Domain Services**: Optional services for additional business logic.

### 2. Infrastructure

- **Entity Framework Core**: Persists data in a SQL Server or LocalDB database.
- **DbContext**: `VisitsDbContext` with `DbSet<Client>`, `DbSet<Commercial>`, and `DbSet<Visit>`.
- **Repositories**: `ClientRepository`, `CommercialRepository`, `VisitRepository` using EF Core methods (`AddAsync`, `FindAsync`, `Update`, etc.).
- **Repository Pattern**: Separates data access concerns from the core domain.

### 3. Web (MVC)

- **Controllers**: `ClientsController`, `CommercialsController`, and `VisitsController`.
- **Service Layer**: Interfaces like `IClientService` and implementations like `ClientService` to encapsulate business logic and validations.
- **Views**: Razor files offering CRUD functionalities:
  - **Index**: List of entities
  - **Create**: New record creation form
  - **Edit**: Update existing record
  - **Delete**: Remove record (often via a POST form)
  - **Details**: Optional page showing entity details

### 4. Recent Changes

- **The following changes have been implemented to improve the functionality of the **Visits** module:

- **Creation of a ViewModel `VisitsCreateEditViewModel`**:
  - Facilitates data transfer between the controller and views.
  - Includes selection lists for clients and commercials (`ClientsSelectList`, `CommercialsSelectList`).
  - Hosts the `Visit` entity for creation and editing forms.

- **Integration of the Service Layer Pattern**:
  - The `VisitsController` uses services (`IVisitService`, `IClientService`, `ICommercialService`) to interact with the lower layers.
  - Direct access to the `DbContext` was removed from controllers, ensuring cleaner and more consistent code.

- **Improvements in `Create.cshtml` and `Edit.cshtml` Views**:
  - Dropdown lists (`<select>`) were added to select the client and the commercial when creating or editing a visit.
  - The lists are dynamically generated from the data retrieved by the services.

- **Modifications in the `Visit` Repository**:
  - The `GetAllAsync` method includes relationships with `Client` and `Commercial` using `Include`, enabling the display of client and commercial names in the list view (`Index`).

- **Validation in Forms**:
  - Validation error handling in the `Create` and `Edit` methods. If the model is invalid, the dropdown lists are reloaded, and the corresponding error messages are displayed.


## Design Decisions

### Multi-Layer Architecture

- **Separation of Concerns**:
  - **Repositories**: Handle database operations with EF Core.
  - **Services**: Hold business logic or validations.
  - **Controllers**: Manage HTTP requests and map them to the service layer.
- **Benefits**: Easier maintenance, testability, and a cleaner codebase.

### Repository Pattern

- **Per Entity Repositories**: Each entity has its own repository interface and implementation.
- **Advantages**: Isolates database queries from other parts of the system, enhancing flexibility.

### Service Layer

- **Abstraction**: Places business logic between controllers and repositories.
- **Simplification**: Moves data manipulation, validations, or advanced checks into services.

### Entity Framework Core

- **Data Persistence**: Utilized for persisting data to a SQL database.
- **Migrations**: `Add-Migration`, `Update-Database` enable incremental schema changes.

### ASP.NET Core MVC

- **Framework Features**: Model-binding, validations, tag helpers, etc.
- **ViewModels**: Used for complex forms, e.g., `VisitsCreateEditViewModel` to store entity data plus lists for dropdowns.

### Scaffolding

- **Initial Generation**: Used to generate basic Razor views.
- **Customization**: Adapted to integrate with services and repositories.
- **Cleanup**: Unused scaffolded controllers were discarded to maintain a consistent architecture.

## Getting Started

### Prerequisites

- **.NET 6 SDK**
- **SQL Server** or **LocalDB** instance (configured in `appsettings.json`)

### Setup Steps

1. **Clone the repository**:

    ```bash
    git clone https://github.com/eduardomarraz/Prueba-Especialista-.NET.git
    cd Prueba Especialista .NET
    ```

2. **Configure database connection** in `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=VisitsDb;Trusted_Connection=True;"
      }
    }
    ```

3. **Apply EF Core migrations**:

    ```powershell
    dotnet ef database update
    ```

    This creates the required tables in the database specified in `DefaultConnection`.

4. **Run the application**:

    ```powershell
    dotnet run --project Acme.Visits.Web
    ```

    Or simply press **F5** in Visual Studio if preferred.

5. **Navigate to** `https://localhost:{port}`:

    - **Home Page**: Links to Clients, Commercials, Visits.
    - **Clients**: CRUD for customers.
    - **Commercials**: CRUD for sales representatives.
    - **Visits**: CRUD linking Client, Commercial, and Date/Notes.

## Future Enhancements

- **Authentication & Authorization**: Restrict who can manage visits data.
- **Additional Fields**: e.g., phone numbers, addresses, emails for both Clients and Commercials.
- **Validation**: Improved data annotations and custom validations.
- **Advanced Queries**: Searching, filtering, or pagination in the Index pages.
- **Unit Tests**: Testing repository methods, services, and controllers.

## Conclusion

This solution demonstrates a clean architecture in .NET 6, respecting the Repository Pattern, a Service Layer, and MVC with Razor views. It meets the requirement of **“view, add, edit, and delete”** for Clients, Commercials, and Visits, fulfilling the specification provided by ACME’s problem statement.

