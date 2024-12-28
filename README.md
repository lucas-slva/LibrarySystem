<a id="readme-top"></a>
# LibrarySystem
![.NET](https://img.shields.io/badge/.NET-9.0-blue?style=flat-square&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-9.0-00599C?style=flat-square&logo=nuget)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Latest-red?style=flat-square&logo=microsoftsqlserver)
![Docker](https://img.shields.io/badge/Docker-Container-blue?style=flat-square&logo=docker)
![Clean Architecture](https://img.shields.io/badge/Clean%20Architecture-Pattern-brightgreen?style=flat-square)
![License](https://img.shields.io/github/license/lucas-slva/LibrarySystem?style=flat-square)

&nbsp;

## 📖 Overview
LibrarySystem is a backend application designed to manage a digital library. This project is intended to demonstrate expertise in .NET, Entity Framework Core, SQL Server, and clean coding practices.

The application will include:
* **Book Management**: Adding, updating, and querying books.
* **User Management**: Registering users who can borrow books.
* **Loan Records**: Tracking book loans, including due dates and return statuses.

&nbsp;

### 🚀 Features

- **Clean Architecture**: Well-structured project organization.
- **Entity Framework Core**: For database access and migrations.
- **Docker**: Simplified SQL Server setup for local development.
- **Validation**: Centralized business logic to ensure database consistency.

&nbsp;

### 🛠️ Technologies

- **.NET 9**
- **Entity Framework Core**
- **SQL Server** (via Docker)
- **Dependency Injection**
- **Fluent API** for database mappings

<br><br>

## 🏁 Getting Started

### Prerequisites
To get started, ensure you have the following installed:

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

&nbsp;

### Installation

Follow these steps to set up the project:

1. Clone the Repository
   ```bash
   git clone https://github.com/lucas-slva/LibrarySystem.git
  
&nbsp;

2. Run SQL Server with Docker Start a SQL Server container using Docker:
   ```bash
   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

&nbsp;

3. Restore Dependencies Restore all required NuGet packages:
   ```bash
   dotnet restore

&nbsp;

4. Create Migration Generate the database schema with the following command:
   ```bash
   dotnet ef migrations add InitialCreate

&nbsp;

5. Apply Migrations Update the database schema:
   ```bash
   dotnet ef database update

&nbsp;

6. Run the Application Start the Console App:
   ```bash
   dotnet run

<br><br>

## 🧪 Unit Tests

This project includes unit tests to validate the core functionalities of the services:
- `LoanService`
- `UserService`

### Running the Tests
To run the tests, use the following command:
```bash
dotnet test
```
<br><br>

## 📜 Commit History

1. **Initial Structure**
   - Set up the project folder structure following Clean Architecture principles.

&nbsp;

2. **Database Models and Configuration**
   - **2.1. Added Domain Models**
     - `Book`
     - `User`
     - `Loan`
   - **2.2. Configured Fluent API Mappings**
     - Mapped constraints, relationships, and indexes for domain models.
   - **2.3. Created and Configured**
     - `LibraryDbContext`
     - Design-time `LibraryDbContextFactory`
   - **2.4. Implemented Dependency Injection**
     - Added DI configuration for the `LibraryDbContext` in a Console App.
   - **2.5. Generated and Applied Migration**
     - Created the `InitialCreate` migration.
     - Applied the migration to create the `LibraryDb` database with tables:
       - `Books`
       - `Users`
       - `Loans`
    
&nbsp;

3. **Services and Interfaces**
   - **3.1. Implemented Services**
     - `BookService`
     - `UserService`
     - `LoanService`
   - **3.2. Created Interfaces**
     - `IBookService`
     - `IUserService`
     - `ILoanService`

&nbsp;

4. **Documentation and README Improvements**
   - **4.1. Updated the README.md**
     - Added clear installation instructions.
     - Highlighted features and technologies used.
     - Included a **C# icon** for a polished presentation.
     - Organized commit history for better readability.

&nbsp;

5. **Unit Testing**
   - **5.1. Added Unit Tests for Services**
     - `LoanServiceTests`:
       - Validates loan creation with valid and invalid data.
       - Ensures proper exception handling when conditions aren't met.
     - `UserServiceTests`:
       - Validates user creation and duplicate email prevention.
       - Tests retrieval of all users.
   - **5.2. Improved Testing Workflow**
     - Mocked dependencies for repositories using Moq.
     - Ensured comprehensive coverage of service methods.
   - **5.3. Updated README**
     - Added instructions to run unit tests using `dotnet test`.
       
<br><br>

## 📜 License
This project is licensed under the `MIT License`. See the LICENSE file for details.
