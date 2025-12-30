# .NET Core CRUD Operation - Version 8 - README

## Overview 

This repository demonstrates the implementation of CRUD (Create, Read, Update, Delete) operations using .NET Core Version 8. It is designed to provide a clear and concise example of how to perform basic data management tasks in a .NET Core 8 application, leveraging the latest features and best practices introduced in this version.

## Features

- **Create:** Add new records to the database using HTTP POST requests.
- **Read:** Retrieve and display data from the database using HTTP GET requests.
- **Update:** Modify existing records in the database using HTTP PUT or PATCH requests.
- **Delete:** Remove records from the database using HTTP DELETE requests.

## Technology Stack

- **.NET Core 8.0:** The latest version of the .NET Core framework, offering improved performance, security, and features.
- **Entity Framework Core:** An object-relational mapper (ORM) that enables developers to work with a database using .NET objects.
- **SQL Server:** The database management system used for storing and retrieving data.
- **ASP.NET Core MVC:** A framework for building web applications and APIs using the Model-View-Controller design pattern.

## Sample Usage (Docker)

Quickly spin up the application and database using Docker Compose without installing the .NET SDK or SQL Server locally.

**Step 1: Setup**
Create a `.env` file in the `GameZone` directory (where `docker-compose.yml` resides) to set your database password. The password must meet SQL Server complexity requirements (e.g., `StrongPassword123!`).
```text
db_password=YourStrongPassword123!
```
*Note: For local development, you must provide this file. In our Jenkins pipeline, this variable is injected automatically.*

**Step 2: Run**
Navigate to the `GameZone` directory and execute:
```bash
docker-compose up --build
```

**Step 3: Access**
Open your browser and navigate to: [http://localhost:8000](http://localhost:8000)

## CI/CD Pipeline with Jenkins

This project includes a fully automated `Jenkinsfile` for Continuous Integration and Deployment.

**Step 1: Prerequisites**
- Jenkins installed with **Docker** and **Pipeline** plugins.
- **Docker Hub Credentials**: Configure credentials with ID `dockerhub` in Jenkins.
- **Global Environment Variable**: Go to *Manage Jenkins -> System -> Global properties* and add a variable named `db_password` with your desired SQL Server password.

**Step 2: Setup**
Create a new "Pipeline" job in Jenkins and point it to this repository.

**Step 3: Run**
Trigger a build. The pipeline will automatically:
1.  **Build & Push**: Build the Docker image and push it to Docker Hub.
2.  **Deploy**: Deploy the application using `docker compose`.

## Getting Started

### Prerequisites

- **.NET Core SDK 8.0:** Ensure that the .NET Core SDK version 8.0 is installed on your machine. You can download it from the [.NET Download](https://dotnet.microsoft.com/download) page.
- **SQL Server:** Install SQL Server or use an existing instance. You may also use SQL Server Express or any other compatible database system.

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/tarekadelkamal/Dot-Net-Core-8-CRUD-Operation.git
