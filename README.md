
# LibrarySystem

## Overview
LibrarySystem is a backend application designed to manage a digital library. This project is intended to demonstrate expertise in .NET, Entity Framework Core, SQL Server, and clean coding practices.

The application will include:
- **Book Management**: Adding, updating, and querying books.
- **User Management**: Registering users who can borrow books.
- **Loan Records**: Tracking book loans, including due dates and return statuses.

---

## Technologies Used
- .NET 9
- Entity Framework Core
- SQL Server
- Clean Architecture Principles
- Dependency Injection
- Fluent API for database mappings

---

## Project Structure
The project follows the **Clean Architecture** pattern:

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

---

## Getting Started

### Prerequisites
- .NET 9 SDK installed
- SQL Server installed and running
- Visual Studio, Rider, or another .NET-compatible IDE

### How to Run
1. Clone the repository:
   git clone https://github.com/lucas-slva/LibrarySystem.git

2. Navigate to the project directory:
   cd LibrarySystem

3. Restore dependencies:
   dotnet restore

4. Run the application:
   dotnet run

---

## Commit History
- **Initial Structure**: Set up project folder structure following Clean Architecture principles.

---

## Next Steps
1. Model the database by creating the `Book`, `User`, and `Loan` entities.
2. Configure Fluent API mappings for database constraints, indexes, and relationships.
3. Set up `LibraryDbContext` and prepare for migrations.
