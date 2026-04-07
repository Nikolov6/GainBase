# 🏋🏽 GainBase

> GainBase is an ASP.NET Core MVC web application for discovering, creating, and managing community-shared fitness exercises, robust custom workouts, and gym sessions.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Architecture & Design Decisions](#architecture--design-decisions)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📖 About the Project

GainBase is a fitness exercise library where users can browse exercise content, filter by muscle group/equipment, and view detailed step-by-step instructions.  
Authenticated users can create, edit, and delete their own exercises, save exercises to personal favorites, build custom multi-exercise routines (**Workouts**), and track their active progress using **Gym Sessions**.  
The project relies heavily on layered ASP.NET Core MVC architecture with Entity Framework Core and implements specialized Role-Based authorization to distinctly separate Administrators from standard Users.

---

## 🏗️ Architecture & Design Decisions

- **Layered MVC Architecture:** The solution strongly follows the Model-View-Controller design pattern, completely separating application entry points (Controllers) from the Views (Razor) and backend logic.
- **Service Layer (Core Services):** All business logic is strictly encapsulated inside `GainBase.Services.Core` (e.g., `ExerciseService`, `WorkoutService`, `GymSessionService`). Controllers are kept lightweight and only handle UI routing, model state interactions, and delegating actual work to abstracted Service Interfaces.
- **Validations:** Uses comprehensive, double-layered validation:
  - Strongly typed Data Annotations over centralized constraints (`GainBase.GCommon.EntityValidation`) on Domain Models and ViewModels.
  - Server-side validation within MVC Controllers (checking `ModelState`) alongside client-side validation scripts.
- **Role Separation Design:** The system distinguishes between "Admin" and "User" functionality securely via ASP.NET Core Identity roles and Areas. **Admin accounts are completely separated from normal user functionality and do not use regular user features**; instead, they operate directly inside a focused, dedicated `Admin` Area for administrative management.

---

## 🛠️ Technologies Used

| Technology            | Version  | Purpose                             |
|-----------------------|----------|-------------------------------------|
| ASP.NET Core MVC      | 8.0      | Web framework (Controllers + Views) |
| Entity Framework Core | 8.x      | ORM / Database access               |
| SQL Server            | -        | Primary relational database         |
| ASP.NET Core Identity | 8.x      | Authentication and user management  |
| Bootstrap             | 5.x      | Frontend styling and responsive UI  |
| Razor Views           | -        | Server-side HTML rendering          |

---

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Git](https://git-scm.com/)

---

## 🚀 Getting Started

Follow these setup instructions to get the project locally running.

### 1. Clone the repository

```bash
git clone https://github.com/Nikolov6/GainBase.git
cd GainBase
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

```bash
dotnet ef database update --project GainBase.Data --startup-project GainBase.Web
```

### 4. Run the application

```bash
dotnet run --project GainBase.Web
```

The app will be available at `https://localhost:7288` or `http://localhost:5192`.

---

## 📁 Project Structure

```
GainBase/
│
├── GainBase.Web/                    # ASP.NET Core MVC application
│   ├── Controllers/                # MVC controllers (Workouts, Exercises, etc.)
│   ├── Views/                      # Razor views
│   ├── Areas/                      # Isolated areas
│   │   ├── Admin/                  # Admin panels & controllers (e.g., ExercisesManagement)
│   │   └── Identity/               # ASP.NET Core Identity pages
│   ├── wwwroot/                    # Static files (CSS, JS, images)
│   └── appsettings.json            # Application configuration
│
├── GainBase.Data/                  # Data access layer
│   ├── ApplicationDbContext        # EF Core DbContext
│   ├── Configurations/             # EF Core entity configurations
│   └── Migrations/                 # Database migrations
│
├── GainBase.Data.Models/           # Domain entities
│   ├── Exercise.cs
│   ├── UserExercise.cs
│   ├── Equipment.cs
│   ├── MuscleGroup.cs
│   ├── Workout.cs
│   └── GymSession.cs               # Tracking models
│
├── GainBase.Services.Core/         # Business logic layer
│   ├── ExerciseService.cs
│   ├── WorkoutService.cs
│   ├── GymSessionService.cs
│   ├── EquipmentService.cs
│   └── MuscleGroupService.cs
│
├── GainBase.Web.ViewModels/        # MVC ViewModels (data mapping layer)
│
├── GainBase.GCommon/               # Shared/common utilities
│   └── EntityValidation.cs         # Validation constants, rules, etc.
│
└── README.md                      # Project documentation
```

---

## ✨ Features

- [x] Authentication and authorization with ASP.NET Core Identity
- [x] CRUD operations for exercises (create, edit, delete by creator)
- [x] Exercise discovery with filtering by muscle group and equipment
- [x] Favorites system (add/remove exercises to personal favorites)
- [x] Workouts system (create/edit/delete multi-exercise routines)
- [x] Gym Sessions tracking (log and monitor exercise sessions)
- [x] Role-based authorization (Admin vs User capabilities)
- [x] Server-side and client-side validation with Data Annotations and validation scripts
- [x] Seeded reference data for muscle groups, equipment, and initial exercises
- [x] Responsive UI with Bootstrap

---

## 💻 Usage

```
1.	Open the home page and go to /Exercises to browse the exercise library.
2.	Use filters (muscle group and equipment) to narrow results.
3.	Register/Login via Identity pages to unlock create/edit/delete and favorites features.
4.	Create exercises from /Exercises/Create.
5.	Manage your own entries in /Exercises/MyExercises and saved ones in /Exercises/MyFavorites.
6.	Open exercise details to view instructions, then add/remove favorites.
7.	Create custom workouts by grouping multiple exercises under /Workouts.
8.	Log gym sessions to track workout progress under /GymSessions.
```

---

## 🗄️ Database Setup

The project uses **Entity Framework Core** with a Code-First approach.

Connection string is configured in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=GainBase;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```

To create and seed the database:

```bash
dotnet ef database update
```

---

## Seeded User
The database seeding includes a pre-created ASP.NET Identity user for testing.
*(Note: Favorite functionalities only apply to exercises you did not author).*

- **Username:** `SeedUser`
- **Email:** `seeduser@gainbase.com`
- **Password:** `SeedUser123!`
- **Email Confirmed:** `true`

### Admin User
- **Username:** `admin`
- **Email:** `admin@gainbase.com`
- **Password:** `Admin123!`
- **Role:** `Admin`

You can use these accounts to sign in immediately after running migrations.

---

## ⚙️ Configuration

Key settings in `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=GainBase;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
},
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore": "Warning"
    }
  }
```

---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add some feature"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📬 Contact

**Nikola** – [@Nikolov6](https://github.com/Nikolov6)

Project Link: [https://github.com/Nikolov6/GainBase](https://github.com/Nikolov6/GainBase)

---

*Built as part of the **ASP.NET Fundamentals** course.*

