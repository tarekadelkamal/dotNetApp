# GameZone - .NET Core 8 CRUD Application

## What is this App?

**GameZone** is a web application built using **.NET Core 8 MVC**. It demonstrates the implementation of CRUD (Create, Read, Update, Delete) operations using the latest features and best practices introduced in .NET Core 8. 

The application uses **Entity Framework Core** as its ORM (Object-Relational Mapper) to interact with a **SQL Server** database, providing a robust backend for managing game-related data.

## DevOps Tools

This project incorporates modern DevOps practices and tools to ensure seamless development, continuous integration, and deployment:

- **Docker:** Containerizes the application and database for consistent environments across development and production.
- **Docker Compose:** Orchestrates multi-container setups locally (Application + SQL Server).
- **Jenkins:** A fully automated CI/CD pipeline (`Jenkinsfile`) that handles building, pushing Docker images to Docker Hub, and deploying the application.
- **Kubernetes (K8s):** Provides enterprise-grade container orchestration. Manifests for deployments, services, ingress, and secrets are included in the `k8s` directory for deploying the app to a Kubernetes cluster.

## How to Run on a Local Device

You can run this application locally using either Docker (recommended) or the .NET Core SDK.

### Option 1: Using Docker Compose (Recommended)

Quickly spin up the application and database without installing the .NET SDK or SQL Server locally.

**1. Setup Environment Variables:**
Create a `.env` file in the `GameZone` directory (where `docker-compose.yml` resides) and set a strong database password:
```text
db_password=YourStrongPassword123!
```

**2. Build and Run:**
Navigate to the `GameZone` directory and execute:
```bash
cd GameZone
docker-compose up --build
```

**3. Access the App:**
Open your browser and navigate to: [http://localhost:8000](http://localhost:8000)

### Option 2: Using .NET Core SDK

**1. Prerequisites:**
- Install [.NET Core SDK 8.0](https://dotnet.microsoft.com/download)
- Install SQL Server (or SQL Server Express) locally.

**2. Database Configuration:**
Update the `appsettings.json` or `appsettings.Development.json` inside the `GameZone` directory with your local SQL Server connection string.

**3. Apply Migrations:**
Navigate to the `GameZone` directory and run EF Core migrations to create the database:
```bash
cd GameZone
dotnet ef database update
```

**4. Run the Application:**
Start the development server:
```bash
dotnet run
```
The application will usually be accessible at `https://localhost:7111` or `http://localhost:5169` (check terminal output for exact ports).
