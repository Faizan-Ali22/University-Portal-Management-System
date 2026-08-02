# University Portal - Full Stack Management System

Welcome to the **University Portal Management System**. This is an advanced full-stack application designed to manage university operations, including students, courses, faculty, and grading.

## 🚀 Features

- **Modern Web Interface:** A beautifully designed React frontend using Vite, featuring glassmorphism, responsive UI, animations (Framer Motion), and modern data tables.
- **N-Tier Backend Architecture:** Cleanly separated C# .NET 6 Web API with distinct Entity, Data Access (DAL), Business Logic (BLL), and API layers.
- **Dual Support (SPA & SSR):** Integrates alongside the existing ASP.NET Blazor application.
- **In-Memory Prototyping DB:** Easy setup with Entity Framework Core's `InMemoryDatabase` loaded with comprehensive seed data for fast local development.
- **Secure Authentication:** Implements JWT-based authentication and secure password hashing using BCrypt.
- **Dashboard Analytics:** Visual representation of university statistics and enrollment trends using Recharts.

## 🏗️ Project Architecture

This repository contains multiple linked projects under a centralized workspace:

1. **`UniversityApp.Entities`**: Contains all core domain models (Student, Course, Faculty, etc.) and DTOs.
2. **`UniversityApp.DAL`**: The Data Access Layer using EF Core (DbContext, Unit of Work pattern, generic Repositories, and SeedData).
3. **`UniversityApp.BLL`**: The Business Logic Layer containing all services for processing data and handling business rules.
4. **`UniversityApp.API`**: The .NET 6 RESTful Web API containing endpoints and JWT middleware.
5. **`University-Portal`**: The Blazor Server Project.
6. **`University-Portal/university-portal-client`**: The modern React Single Page Application (SPA) providing the polished user interface.

## 🛠️ Technology Stack

- **Backend:** C#, .NET 6, ASP.NET Core Web API, Entity Framework Core, BCrypt, JWT Bearer Auth.
- **Frontend (SPA):** React 18, Vite, CSS (Glassmorphism & CSS Variables), Lucide Icons, Recharts, Framer Motion, React Hot Toast.
- **Frontend (SSR):** Blazor Server, HTML/CSS.

## ⚙️ Getting Started

### 1. Running the .NET 6 Web API
The backend provides all the necessary REST endpoints and serves as the data hub.

1. Open a terminal in the root workspace directory.
2. Navigate to the API project:
   ```bash
   cd UniversityApp.API
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. The API will be available at `http://localhost:5244` and `https://localhost:7244`.
5. You can view the API documentation by visiting the Swagger UI at `https://localhost:7244/swagger`.

### 2. Running the Modern React UI
The React frontend provides a beautiful interface that consumes the API.

1. Open a terminal and navigate to the React client:
   ```bash
   cd University-Portal/university-portal-client
   ```
2. Install the Node dependencies:
   ```bash
   npm install
   ```
3. Start the Vite development server:
   ```bash
   npm run dev
   ```
4. The UI will be available at `http://localhost:5173`. 
5. *(Optional)* The React frontend is currently configured to run seamlessly. You can toggle between Mock Data and the Live API by modifying `src/api/config.js`:
   ```javascript
   export const USE_MOCK_DATA = false; // Set to false to connect to the backend
   ```

## 🔐 Default Login Credentials
For prototype testing and evaluation, you can log in using the following seeded admin account:
- **Email:** admin@university.edu
- **Password:** Admin@123

## 📦 Extensibility
This project is built using a highly decoupled N-tier architecture. To expand upon the current capabilities:
- Add new models in the `Entities` project.
- Register new DbSet properties in the `DAL/UniversityDbContext.cs`.
- Create corresponding Services and Interfaces in the `BLL`.
- Map them to new endpoints in the `API` layer.
- Bind the new data endpoints in the React frontend using the `axiosInstance` configuration in `src/api/`.

---
*Developed as an advanced full-stack demonstration project.*
