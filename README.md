# 🛍️ Egyptian Celiac Association — Store & E-Commerce API

A RESTful Web API built as part of the graduation project for the Egyptian Association for Celiac Patients. This API powers the e-commerce layer of the platform — handling product browsing, cart management, order placement, appointment booking with doctors and labs, and secure JWT-authenticated access for patients.

> **Graduation Project** · Companion API to the [Management System](https://github.com/AhmedMTwab/Egyptian-Association-For-Celiac-Management-System) · Grade: **Excellent**

[![API Docs](https://img.shields.io/badge/API%20Docs-Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)](https://twabprojectapi.runasp.net/swagger/index.html)
[![C#](https://img.shields.io/badge/C%23-.NET%208-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)

---

## 🚀 Features

- **JWT Authentication** — Secure token-based auth; all patient-facing endpoints require a valid Bearer token
- **Product Browsing** — Patients browse association and pharmacy products with category filtering
- **Order Management** — Full order lifecycle: create, view, and track orders
- **Appointment Booking** — Book appointments with doctors and labs directly through the API
- **DTO Pattern** — Clean separation between API contracts and domain models via DTOs
- **Repository Pattern** — Data access abstracted behind interfaces for testability
- **Swagger Documentation** — Full interactive API docs available live

---

## 🏗️ Structure

```
├── Controllers/        # API endpoints — Products, Orders, Appointments, Auth
├── DTO/                # Data Transfer Objects — request/response contracts
├── Models/             # Domain entities — Product, Order, Appointment, Patient
├── Repositories/       # Data access layer — abstracts EF Core queries
├── Migrations/         # EF Core database migrations
├── wwwroot/images/     # Uploaded product images
└── Program.cs          # App bootstrap, DI registration, middleware pipeline
```

This is a single-project Web API — no layered architecture separation. Business logic lives in repositories, controllers handle routing and validation.

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 8) |
| Auth | JWT Bearer Tokens |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Mapping | DTOs (manual mapping) |
| API Docs | Swagger / Swashbuckle |
| Architecture | Repository Pattern |

---

## 🔐 Authentication

All patient-facing endpoints require a JWT Bearer token.

1. **Register** — `POST /api/Auth/register`
2. **Login** — `POST /api/Auth/login` → returns a JWT token
3. **Authorize** — Include the token in every request header:
   ```
   Authorization: Bearer <your-token>
   ```

In Swagger UI, click the **Authorize** button at the top right and paste your token to test protected endpoints interactively.

---

## 📚 API Endpoints

### Authentication
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| `POST` | `/api/Auth/register` | Public | Register a new patient account |
| `POST` | `/api/Auth/login` | Public | Login and receive a JWT token |

### Products
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| `GET` | `/api/Products` | Public | Browse all available products |
| `GET` | `/api/Products/{id}` | Public | Get product details |
| `GET` | `/api/Products/category/{id}` | Public | Filter products by category |

### Orders
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| `POST` | `/api/Orders` | 🔒 Required | Place a new order |
| `GET` | `/api/Orders` | 🔒 Required | Get current patient's orders |
| `GET` | `/api/Orders/{id}` | 🔒 Required | Get order details |

### Appointments
| Method | Endpoint | Auth | Description |
|---|---|---|---|
| `GET` | `/api/Appointments/doctors` | Public | List available doctors |
| `GET` | `/api/Appointments/labs` | Public | List available labs |
| `POST` | `/api/Appointments/book` | 🔒 Required | Book an appointment |
| `GET` | `/api/Appointments/my` | 🔒 Required | View patient's appointments |

---

## 🔗 Relationship to the Management System

This API and the [Management System MVC app](https://github.com/AhmedMTwab/Egyptian-Association-For-Celiac-Management-System) share the same database. They serve different audiences:

| | Management System (MVC) | Store API |
|---|---|---|
| **Users** | Admins, Doctors, Employees | Patients |
| **Interface** | Server-rendered web UI | RESTful API (consumed by clients) |
| **Auth** | Cookie-based (ASP.NET Identity) | JWT Bearer tokens |
| **Purpose** | Manage the platform | Patient-facing e-commerce & bookings |

---

## 📦 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/AhmedMTwab/Egyptian-Association-For-Celiac-Store-API.git
   cd Egyptian-Association-For-Celiac-Store-API
   ```

2. **Configure the connection string** in `appsettings.json`
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=CeliacAssociationDb;Trusted_Connection=True;"
     },
     "Jwt": {
       "Key": "YourSecretKeyHere",
       "Issuer": "CeliacStoreAPI",
       "Audience": "CeliacPatients",
       "DurationInMinutes": 60
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

5. **Open Swagger UI** at `https://localhost:5001` to explore and test all endpoints

---

## 📝 Notes

> **Graduation Project Context:** This API was built in 2024 as part of my graduation project. It uses a flat single-project structure rather than Clean Architecture. If I were to rebuild it today, I would apply layered architecture, add FluentValidation, and write unit tests for the service/repository layer.

---

## 📚 Documentation

Full graduation project documentation:
**[📄 Graduation Book (PDF)](https://drive.google.com/file/d/1B6xYUrrWza4_Z_OvBsRuGPD2xVPjGefE/view?usp=sharing)**

---

## 👤 Author

**Ahmed Mohamed Eltwab**
[![LinkedIn](https://img.shields.io/badge/-LinkedIn-0e76a8?style=flat-square&logo=linkedin&logoColor=white)](https://linkedin.com/in/ahmed-twab)
[![GitHub](https://img.shields.io/badge/-GitHub-181717?style=flat-square&logo=github&logoColor=white)](https://github.com/AhmedMTwab)
