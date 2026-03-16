# 🏋🏽 GainBase

> GainBase is an ASP.NET Core MVC web application for discovering, creating, and managing community-shared fitness exercises with favorites support.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
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
Authenticated users can create, edit, and delete their own exercises, and can save exercises from other users to personal favorites.  
The project demonstrates layered ASP.NET Core MVC architecture with Entity Framework Core and ASP.NET Identity authentication/authorization.  

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

Follow these steps to get the project running locally.

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
├── GainBase.Web/                # ASP.NET Core MVC application
│   ├── Controllers/             # MVC controllers
│   ├── Views/                   # Razor views
│   ├── Areas/Identity/          # ASP.NET Core Identity
│   ├── wwwroot/                 # Static files
│   └── appsettings.json         # Application configuration
│
├── GainBase.Data/               # Data access layer
│   ├── ApplicationDbContext
│   ├── EF Core Configurations
│   └── Migrations
│
├── GainBase.Data.Models/        # Domain entities
│   ├── Exercise
│   ├── Equipment
│   ├── MuscleGroup
│   └── UserExercise
│
├── GainBase.Services.Core/      # Business logic / services
│   ├── ExerciseService
│   ├── EquipmentService
│   └── MuscleGroupService
│
├── GainBase.Web.ViewModels/     # MVC view models
│
├── GainBase.GCommon/            # Shared constants and validation rules
│
└── README.md                    # Project documentation
```

---

## ✨ Features

- [x] Authentication and authorization with ASP.NET Core Identity
- [x] CRUD operations for exercises (create, edit, delete by creator)
- [x] Exercise discovery with filtering by muscle group and equipment
- [x] Favorites system (add/remove exercises to personal favorites)
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
The database seeding includes a pre-created ASP.NET Identity user for testing
(have in mind that favorite functionality works only on exercises you are not creator of).

- **Username:** `SeedUser`
- **Email:** `seeduser@gainbase.com`
- **Password:** `SeedUser123!`
- **Email Confirmed:** `true`

You can use this account to sign in immediately after running migrations.

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

