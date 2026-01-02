# 📇 Contacts Manager

A modern, full-featured web application built with ASP.NET Core MVC for managing contacts and countries with a beautiful, responsive UI.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-purple?style=flat-square&logo=.net)
![C#](https://img.shields.io/badge/C%23-11.0-blue?style=flat-square&logo=c-sharp)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)

---

## 📋 Table of Contents

- [Features](#-features)
- [Architecture](#-architecture)
- [Project Structure](#-project-structure)
- [Technologies Used](#-technologies-used)
- [Getting Started](#-getting-started)
- [Configuration](#-configuration)
- [Usage](#-usage)
- [API Endpoints](#-api-endpoints)
- [Screenshots](#-screenshots)
- [Contributing](#-contributing)
- [License](#-license)

---

## ✨ Features

### 👤 Person Management
- ✅ **Create** new persons with detailed information
- 📝 **Edit** existing person records
- 🗑️ **Delete** persons from the database
- 🔍 **Search** persons by multiple criteria (Name, Email, Country, Age, Gender, Address)
- 🔄 **Sort** persons by any column (ascending/descending)
- 📄 **Export** person list to PDF
- 📧 **Newsletter subscription** tracking

### 🌍 Country Management
- 📤 **Upload countries** from Excel files (XLSX, XLS)
- 🗃️ View and manage country data
- 🔗 Link persons to countries

### 🎨 Modern UI/UX
- 🌈 **Gradient backgrounds** with glassmorphism effects
- 💫 **Smooth animations** and transitions
- 📱 **Responsive design** for all devices
- 🎯 **Intuitive navigation** with visual feedback
- 🎨 **Color-coded actions** (Edit: Green, Delete: Red, Create: Orange, Download: Teal)

### 🔐 Authentication & Authorization
- 👥 **User registration** with validation
- 🔑 **Secure login** system
- 🛡️ **Role-based access control** (ApplicationUser and ApplicationRole)

---

## 🏗️ Architecture

This application follows the **Clean Architecture** principles with clear separation of concerns:

```
┌─────────────────────────────────────────┐
│         Presentation Layer              │
│  (Controllers, Views, ViewModels)       │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Service Layer                   │
│  (Business Logic, DTOs)                 │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Repository Layer                │
│  (Data Access, Repository Pattern)      │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Data Layer                      │
│  (Entity Framework, Database)           │
└─────────────────────────────────────────┘
```

### Key Design Patterns:
- 🏛️ **Repository Pattern** - Abstraction over data access
- 🔄 **Dependency Injection** - Loose coupling and testability
- 📦 **DTO Pattern** - Data transfer objects for clean data flow
- 🎯 **MVC Pattern** - Separation of concerns
- 🔍 **Service Layer** - Business logic encapsulation

---

## 📁 Project Structure

```
ContactsManager/
├── 📂 Controllers/
│   ├── PersonsController.cs      # Handles person CRUD operations
│   ├── CountriesController.cs    # Manages country operations
│   ├── AccountController.cs      # Authentication logic
│   └── ErrorController.cs        # Error handling
│
├── 📂 Views/
│   ├── 📁 Persons/
│   │   ├── Index.cshtml          # Person list view
│   │   ├── Create.cshtml         # Create person form
│   │   ├── Edit.cshtml           # Edit person form
│   │   ├── Delete.cshtml         # Delete confirmation
│   │   └── PersonsPdf.cshtml     # PDF export view
│   ├── 📁 Countries/
│   │   └── UploadCountry.cshtml  # Country upload form
│   ├── 📁 Account/
│   │   ├── Login.cshtml          # Login page
│   │   └── Register.cshtml       # Registration page
│   └── 📁 Shared/
│       ├── _Layout.cshtml        # Main layout
│       └── _GridHeaderColumn.cshtml  # Reusable grid header
│
├── 📂 ServiceContracts/
│   ├── 📁 DTO/
│   │   ├── PersonResponse.cs     # Person data transfer object
│   │   ├── PersonAddRequest.cs   # Add person request
│   │   ├── PersonUpdateRequest.cs # Update person request
│   │   ├── CountryResponse.cs    # Country DTO
│   │   ├── CountryAddRequest.cs  # Add country request
│   │   ├── LoginDTO.cs           # Login data
│   │   └── RegisterDTO.cs        # Registration data
│   ├── IPersonsGetterService.cs  # Person retrieval contract
│   ├── IPersonsAdderService.cs   # Person creation contract
│   ├── IPersonsUpdaterService.cs # Person update contract
│   ├── IPersonsDeleterService.cs # Person deletion contract
│   ├── IPersonsSorterService.cs  # Person sorting contract
│   └── ICountriesService.cs      # Country service contract
│
├── 📂 Services/
│   ├── PersonsGetterService.cs   # Implements person retrieval
│   ├── PersonsAdderService.cs    # Implements person creation
│   ├── PersonsUpdaterService.cs  # Implements person updates
│   ├── PersonsDeleterService.cs  # Implements person deletion
│   ├── PersonsSorterService.cs   # Implements sorting logic
│   ├── CountriesService.cs       # Country operations
│   └── 📁 Helpers/
│       └── ValidationHelper.cs   # Validation utilities
│
├── 📂 Entities/
│   ├── Person.cs                 # Person entity model
│   ├── Country.cs                # Country entity model
│   └── 📁 IdentityEntities/
│       ├── ApplicationUser.cs    # Custom user entity
│       └── ApplicationRole.cs    # Custom role entity
│
├── 📂 Repositories/
│   ├── IPersonsRepository.cs     # Person repository contract
│   ├── ICountriesRepository.cs   # Country repository contract
│   └── ContactsDbContext.cs      # EF Core DbContext
│
├── 📂 RepositoryContracts/
│   ├── IPersonsRepository.cs     # Repository interface
│   └── ICountriesRepository.cs   # Repository interface
│
├── 📂 Filters/
│   └── 📁 ActionFilters/
│       └── PersonsListActionFilter.cs  # Action filter for logging
│
├── 📂 Middlewares/
│   └── ExceptionHandlingMiddleware.cs  # Global exception handler
│
├── 📂 Enums/
│   ├── GenderOptions.cs          # Gender enumeration
│   ├── SortOrderOptions.cs       # Sort order options
│   └── UserTypeOptions.cs        # User type enumeration
│
├── 📂 wwwroot/
│   ├── 📁 Rotativa/               # PDF generation library
│   ├── 14.29 Assignment-StyleSheet.css  # Main stylesheet
│   └── 9276414.jpg               # Assets
│
├── 📄 appsettings.json           # Configuration
├── 📄 Countries.json             # Seed data for countries
├── 📄 Persons.json               # Seed data for persons
└── 📄 Program.cs                 # Application entry point
```

---

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core 9.0** - Web framework
- **C#** - Programming language
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database
- **Identity Framework** - Authentication and authorization

### Frontend
- **Razor Pages** - Server-side rendering
- **HTML5 / CSS3** - Markup and styling
- **Modern CSS** - Gradients, animations, glassmorphism

### Libraries & Tools
- **Rotativa** - PDF generation
- **AutoMapper** (optional) - Object mapping
- **Serilog** (optional) - Logging

---

## 🚀 Getting Started

### Prerequisites

```bash
- .NET 9.0 SDK or later
- SQL Server 2022 or later
- Visual Studio 2022 / VS Code / Rider
- Git
```

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/Ahmed-Hamdi-77/ContactsManager.git
cd ContactsManager
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Update database connection string**

Edit `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=ContactsManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

4. **Apply database migrations**
```bash
dotnet ef database update
```

5. **Run the application**
```bash
dotnet run
```

---

## ⚙️ Configuration

### Database Configuration

The application uses SQL Server by default. You can configure the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ContactsManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Seed Data

Initial data is loaded from:
- `Countries.json` - List of countries
- `Persons.json` - Sample persons

---

## 💡 Usage

### Managing Persons

#### Create a New Person
1. Click **"Create Person"** button
2. Fill in the form with person details:
   - Name
   - Email
   - Date of Birth
   - Gender
   - Country
   - Address
   - Newsletter subscription preference
3. Click **"Submit"**

#### Search Persons
1. Select search criteria from dropdown (Person Name, Email, Country, etc.)
2. Enter search term
3. Click **"Search"**
4. Click **"Clear all"** to reset filters

#### Sort Persons
- Click on any column header to sort
- Click again to toggle between ascending/descending order

#### Edit a Person
1. Click **"Edit"** button next to the person
2. Modify the details
3. Click **"Update"**

#### Delete a Person
1. Click **"Delete"** button next to the person
2. Confirm deletion

#### Export to PDF
- Click **"Download Persons PDF"** to export the current list to PDF

### Managing Countries

#### Upload Countries from Excel
1. Navigate to **"Upload Country"**
2. Select an Excel file (.xlsx or .xls)
3. Click **"Upload"**
4. Countries will be imported automatically

---

## 🔌 API Endpoints

### Persons Controller

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/Persons/Index` | List all persons with search and sort |
| GET | `/Persons/Create` | Show create person form |
| POST | `/Persons/Create` | Create new person |
| GET | `/Persons/Edit/{id}` | Show edit form |
| POST | `/Persons/Edit/{id}` | Update person |
| GET | `/Persons/Delete/{id}` | Show delete confirmation |
| POST | `/Persons/Delete/{id}` | Delete person |
| GET | `/Persons/PersonsPdf` | Export to PDF |

### Countries Controller

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/Countries/UploadCountry` | Show upload form |
| POST | `/Countries/UploadCountry` | Upload Excel file |

### Account Controller

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/Account/Register` | Show registration form |
| POST | `/Account/Register` | Register new user |
| GET | `/Account/Login` | Show login form |
| POST | `/Account/Login` | Authenticate user |
| POST | `/Account/Logout` | Logout user |


---

## 🎨 UI Features

### Color Scheme
- **Primary**: Purple gradient (#667eea → #764ba2)
- **Success**: Green gradient (#48bb78 → #38a169)
- **Danger**: Red gradient (#f56565 → #e53e3e)
- **Warning**: Orange gradient (#f6ad55 → #ed8936)
- **Info**: Teal gradient (#38b2ac → #2c7a7b)

### Animations
- ✨ Fade-in page transitions
- 🎯 Hover effects on buttons and rows
- 📊 Smooth table row scaling
- 🎨 Gradient background animations

### Responsive Design
- 📱 Mobile-friendly navigation
- 💻 Optimized for tablets and desktops
- 🖥️ Horizontal scroll for tables on small screens

---

## 🛡️ Filters & Middleware

### Action Filters

The application uses **Action Filters** for cross-cutting concerns like logging, validation, and performance monitoring.

#### PersonsListActionFilter

Located in: `Filters/ActionFilters/PersonsListActionFilter.cs`

This filter executes before and after the `Index` action in `PersonsController` to:
- ✅ **Log request parameters** (SearchBy, SearchString, SortBy, SortOrder)
- 📊 **Track execution time** for performance monitoring
- 🔍 **Validate search parameters** before processing
- 📝 **Log response data** for debugging

```

**Benefits:**
- 🎯 Separation of concerns
- 📝 Centralized logging
- ✅ Automatic parameter validation
- 🔄 Reusable across multiple actions
- 📊 Performance monitoring

---

### 🚨Exception Handling Middleware

Located in: `Middlewares/ExceptionHandlingMiddleware.cs`

This custom middleware provides **global exception handling** for the entire application.

#### Features:
- 🚨 **Catches all unhandled exceptions**
- 📝 **Logs detailed error information**
- 🎨 **Returns user-friendly error pages**
- 🔒 **Hides sensitive information in production**
- 📊 **Tracks error statistics**

```

#### Exception Types Handled:

| Exception Type | Status Code | Action |
|----------------|-------------|---------|
| `ArgumentNullException` | 400 | Bad Request - Log and return error |
| `InvalidOperationException` | 400 | Bad Request - Log and return error |
| `UnauthorizedAccessException` | 401 | Redirect to Login |
| `KeyNotFoundException` | 404 | Not Found - Show error page |
| `DbUpdateException` | 500 | Database Error - Log and notify admin |
| `All Others` | 500 | Internal Server Error |

---

### Error Controller

Located in: `Controllers/ErrorController.cs`

Handles custom error pages for different HTTP status codes.

---

### Benefits of This Architecture:

✅ **Centralized Error Handling** - All exceptions caught in one place  
✅ **Consistent Error Responses** - Same format for all errors  
✅ **Detailed Logging** - Full context for debugging  
✅ **Security** - Sensitive info hidden in production  
✅ **User Experience** - Friendly error messages  
✅ **Monitoring** - Track error patterns and frequency  
✅ **Maintainability** - Easy to add new error handling logic

---

## 📦 Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="9.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.11" />
<PackageReference Include="Rotativa.AspNetCore" Version="1.4.0" />
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Coding Standards
- Follow C# coding conventions
- Write meaningful commit messages
- Add comments for complex logic
- Update documentation as needed

---


## 📊 Project Statistics

- **Lines of Code**: ~5,000+
- **Controllers**: 4
- **Services**: 7
- **Entities**: 4
- **Views**: 15+

---

<div align="center">

Made with ❤️ using ASP.NET Core

⭐ Star this repo if you find it helpful!

</div>
