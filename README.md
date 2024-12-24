
# LibrarySystem
![.NET](https://img.shields.io/badge/.NET-9.0-blue?style=flat-square&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-9.0-00599C?style=flat-square&logo=nuget)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Latest-red?style=flat-square&logo=microsoftsqlserver)
![Docker](https://img.shields.io/badge/Docker-Container-blue?style=flat-square&logo=docker)
![Clean Architecture](https://img.shields.io/badge/Clean%20Architecture-Pattern-brightgreen?style=flat-square)
![License](https://img.shields.io/github/license/lucas-slva/LibrarySystem?style=flat-square)

## Overview
LibrarySystem is a backend application designed to manage a digital library. This project is intended to demonstrate expertise in .NET, Entity Framework Core, SQL Server, and clean coding practices.

The application will include:
- **Book Management**: Adding, updating, and querying books.
- **User Management**: Registering users who can borrow books.
- **Loan Records**: Tracking book loans, including due dates and return statuses.

## Technologies Used
- .NET 9
- Entity Framework Core
- SQL Server
- Docker
- Clean Architecture Principles
- Dependency Injection
- Fluent API for database mappings

## Dependencies

The project uses the following NuGet packages:

### Core Dependencies
- **Microsoft.EntityFrameworkCore**: Provides the core functionality for Entity Framework Core.
- **Microsoft.EntityFrameworkCore.SqlServer**: SQL Server provider for Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Design**: Tools for design-time EF Core operations like migrations.

### Dependency Injection and Configuration
- **Microsoft.Extensions.DependencyInjection**: Provides the built-in DI container for .NET.
- **Microsoft.Extensions.Configuration**: Configuration framework for .NET applications.
- **Microsoft.Extensions.Configuration.Json**: Enables configuration from `appsettings.json`.

### Testing (Future Steps)
- **Moq** *(to be added)*: For mocking dependencies during unit testing.
- **xUnit** *(to be added)*: Test framework for running unit tests.

### How to Restore Dependencies
Run the following command to restore all dependencies:
```bash
dotnet restore
```

## Project Structure
The project follows the **Clean Architecture** pattern:
```
Library/
├── Domain/             # Contains entities and business logic
│   ├── Entities/
├── Application/        # Application-level services and interfaces
├── Infrastructure/     # Handles database and external integrations
│   ├── Context/        # DbContext for EF Core
│   ├── Mappings/       # Fluent API entity configurations
├── Presentation/       # Entry point for the application (Console or API)
├── appsettings.json    # Configuration for database and app settings
├── Program.cs          # Main entry point of the application
```

## Getting Started

### Prerequisites
- .NET 9 SDK installed
- Docker Desktop installed
- Visual Studio, Rider, or another .NET-compatible IDE

### Setting Up SQL Server with Docker
This project requires a SQL Server instance to run. You can use Docker to create a local SQL Server instance:

1. Run the following command to start a SQL Server container:
   ```
      docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
   ```

3. Verify that the container is running:
   ```
   docker ps
   ```

5. Use the following connection string in the `appsettings.json` file:
   ```
   {
     "ConnectionStrings":
     {
       "DefaultConnection": "Server=localhost,1433;Database=LibraryDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True"
     }
   }
   ```

6. Apply migrations to create the database:
   ```
   dotnet ef database update
   ```

And now your database should be ready for use 🚀🚀

## Running the Application
1. Clone the repository:
   git clone https://github.com/lucas-slva/LibrarySystem.git

2. Navigate to the project directory:
   cd LibrarySystem

3. Restore dependencies:
   dotnet restore

4. Run the application:
   dotnet run

## Commit History

- **Initial Structure**
  - Set up the project folder structure following Clean Architecture principles.

- **Database Models and Configuration**
  - Added domain models:
    - `Book`
    - `User`
    - `Loan`
      
  - Configured Fluent API mappings for the domain models.
    
  - Created and configured:
    - `LibraryDbContext`
    - Design-time `LibraryDbContextFactory`
  - Implemented Dependency Injection for a Console App.
    
  - Generated the `InitialCreate` migration.
    
  - Applied the migration to create the `LibraryDb` database with the following tables:
    - `Books`
    - `Users`
    - `Loans`
      
## Next Steps
1. Create basic services for domain operations:
   - `BookService`: To manage books (add, update, query).
   - `UserService`: To manage users.
   - `LoanService`: To handle book loans.
     
2. Implement repository patterns for better data access abstraction.
3. Add unit tests for services and repository methods to ensure robustness.
4. Populate the database with seed data for testing purposes.
5. Enhance the documentation by adding examples of queries and operations.
