# TatvaCare – Backend (ASP.NET Core Web API)

This is the backend API for the **TatvaCare Appointment Booking System**.  
It provides endpoints to manage appointments for a healthcare clinic.

---

## 🚀 Features
- Create new appointments
- List all appointments
- Update existing appointments
- Delete (cancel) appointments
- Prevent overlapping appointments for the same doctor

---

## 🛠️ Tech Stack
- **ASP.NET Core 6 / 7**
- **C#**
- **Entity Framework Core (InMemory DB for demo)**
- **Swagger** for API documentation

---

## 📂 Project Structure
```
TatvaCare-Backend/
 ├── Controllers/
 │    └── AppointmentsController.cs
 ├── Services/
 │    └── AppointmentService.cs
 ├── Models/
 │    └── Appointment.cs
 ├── Program.cs
 └── TatvaCare.csproj
```

---

## ⚙️ Setup & Run

### 1. Prerequisites
- Install **Visual Studio 2022** (with ASP.NET & web workload)
- Install **.NET 6 or .NET 7 SDK**

### 2. Run the API
- Open the solution in Visual Studio
- Set `TatvaCare-Backend` as the **Startup Project**
- Press **F5** or run:
  ```bash
  dotnet run
  ```

By default, the API will be available at:
- `https://localhost:7080`
- `http://localhost:5080`

---

## 📖 API Endpoints

| Method | Endpoint            | Description                  |
|--------|---------------------|------------------------------|
| GET    | `/appointments`     | Get all appointments         |
| GET    | `/appointments/{id}` | Get appointment by ID        |
| POST   | `/appointments`     | Create new appointment       |
| PUT    | `/appointments/{id}` | Update an appointment        |
| DELETE | `/appointments/{id}` | Cancel an appointment        |

---

## 🔍 Testing
- Swagger UI:  
  Open [https://localhost:7220/swagger/index.html](https://localhost:7220/swagger/index.html) in browser.
- You can also test endpoints using **Postman** or **curl**.
