# 🏥 Egyptian Celiac Association — Management System

A full-stack .NET 8 platform built as a graduation project for the Egyptian Association for Celiac Patients. Consolidates 5+ operational workflows — inventory, medical appointments, patient records, insurance offers, and staff management — into a single system with role-based access control.

> **Graduation Project** · Modern Academy for Engineering · Grade: **Excellent**

[![C#](https://img.shields.io/badge/C%23-.NET%208-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)

---

## 🚀 Features

- **Multi-Module Platform** — A single system replacing multiple disconnected manual processes
- **Role-Based Access Control** — Admin, Doctor, Employee, and Patient roles with scoped permissions via ASP.NET Core Identity
- **Inventory Management** — Track association and pharmacy products, stock levels, and categories
- **Medical Appointments** — Patients book appointments with doctors and labs; staff manage schedules
- **Patient Records** — Full patient profile management including medical history and insurance data
- **Insurance Offers** — Manage and display medical insurance packages available to members
- **MVC Frontend** — Server-rendered UI using ASP.NET Core MVC with Razor Views
- **Authentication** — Cookie-based auth for MVC, with ASP.NET Core Identity managing users and roles

---

## 🏗️ Architecture & Structure

```
├── Controllers/        # MVC Controllers — request routing and response
├── Models/             # Domain entities (Patient, Doctor, Product, Appointment, etc.)
├── ViewModels/         # View-specific models — separation from domain
├── Views/              # Razor Views — server-rendered HTML
├── Repositories/       # Data access layer — abstracts EF Core queries
├── IdentityModels/     # Custom Identity user and role models
├── Areas/
│   └── Identity/       # Scaffolded Identity pages (Login, Register, etc.)
├── Migrations/         # EF Core database migrations
└── wwwroot/            # Static assets (CSS, JS, images)
```

**Pattern:** MVC with Repository pattern. Controllers are kept thin — business logic lives in repositories and service methods, not in action methods.

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| Frontend | Razor Views, Bootstrap, JavaScript |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Auth | ASP.NET Core Identity (cookie-based) |
| Storage | Firebase (media/file storage) |
| Architecture | MVC + Repository Pattern |

---

## 👥 User Roles & Permissions

| Role | Access |
|---|---|
| **Admin** | Full access — manage all modules, users, roles, and content |
| **Doctor** | View and manage appointments and patient records |
| **Employee** | Manage inventory, process orders, handle insurance |
| **Patient** | Book appointments, view own records and insurance offers |

---

## 📋 Modules

### 🏪 Inventory & Store
- Manage association products and pharmacy items
- Track stock levels and product categories
- Process product orders

### 🩺 Medical Appointments
- Patients search and book appointments with available doctors and labs
- Doctors manage their schedules and appointment history
- Staff track upcoming and completed appointments

### 👤 Patient Management
- Full patient profiles with medical history
- Insurance policy assignments
- Document uploads via Firebase storage

### 💊 Insurance Offers
- Admin creates and publishes insurance packages
- Patients browse and apply for coverage
- Staff process applications

---

## 📦 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server
- Firebase project (for file storage — optional for local dev)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/AhmedMTwab/Egyptian-Association-For-Celiac-Management-System.git
   cd Egyptian-Association-For-Celiac-Management-System
   ```

2. **Configure the connection string** in `appsettings.json`
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=CeliacAssociationDb;Trusted_Connection=True;"
     }
   }
   ```

   > **📌 Database Connection Note**: This application is connected to a deployed database, so you don't need to change the connection string. However, if the deployed database fails or you want to use your own database, you can update the connection string above.

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the app** at `https://localhost:5001` — register an account or use the seeded admin credentials (see below)

### Seeded Admin Account
```
Email:    admin@celiac.com
Password: Admin@123
```

---

## 📚 Documentation

### Graduation Book
The complete graduation project documentation is available as a PDF:
- **[Graduation Book.pdf](https://drive.google.com/file/d/1B6xYUrrWza4_Z_OvBsRuGPD2xVPjGefE/view?usp=sharing)** - Full project documentation, analysis, and implementation details

---

## ⚠️ Project Context

This was built as a graduation project in 2024. It represents my earlier work and was designed to solve a real operational problem for the association. The architecture reflects the MVC monolith approach taught at the time — if I were to rebuild it today, I would separate the API layer, apply Clean Architecture, and add proper unit test coverage.

---

## 👤 Author

**Ahmed Mohamed Eltwab**
[![LinkedIn](https://img.shields.io/badge/-LinkedIn-0e76a8?style=flat-square&logo=linkedin&logoColor=white)](https://linkedin.com/in/ahmed-twab)
[![GitHub](https://img.shields.io/badge/-GitHub-181717?style=flat-square&logo=github&logoColor=white)](https://github.com/AhmedMTwab)
