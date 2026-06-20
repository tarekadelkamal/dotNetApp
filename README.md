# GameZone - .NET Core 8 CRUD Application

## What is this App?

**GameZone** is a web application built using **.NET Core 8 MVC**. It demonstrates the implementation of CRUD (Create, Read, Update, Delete) operations using the latest features and best practices introduced in .NET Core 8. 

The application uses **Entity Framework Core** as its ORM (Object-Relational Mapper) to interact with a **SQL Server** database, providing a robust backend for managing game-related data.

## DevOps Tools

This project incorporates modern DevOps practices and tools to ensure seamless development, continuous integration, and deployment:

- **Docker:** Containerizes the application and database for consistent environments across development and production.
- **Docker Compose:** Orchestrates multi-container setups locally (Application + SQL Server).
- **Jenkins:** A fully automated, parameterized CI/CD pipeline (`Jenkinsfile`) that handles building, pushing Docker images to Docker Hub, and deploying the application.
- **Kubernetes (K8s) & Helm:** Provides enterprise-grade container orchestration. Helm charts are included in the `k8s/helm-charts` directory to package the Kubernetes manifests, manage environment configurations (`staging` vs `production`), and streamline deployments and rollbacks.

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

## CI/CD Pipeline (Jenkins to Kubernetes via Helm)

This repository includes a highly parameterized Jenkins pipeline (`Jenkinsfile`) that automates building the Docker image and orchestrating deployments using **Helm** to a Kubernetes cluster. It supports deploying to separate environments (`staging`, `production`) and rolling back to previous states seamlessly.

### Prerequisites:
- A running **Kubernetes** cluster.
- **Jenkins** installed and configured to connect to your Kubernetes cluster.
- **Helm v3** installed on the Jenkins worker nodes.
- **Docker Hub Credentials**: Configured in Jenkins with the ID `dockerhub`.

### Pipeline Parameters:
When executing the pipeline, you will be prompted with a Jenkins UI form containing:
- **ACTION**: Choose whether to run a new `Deploy` or perform a `Rollback`.
- **ENVIRONMENT**: Select the target environment (`staging` or `production`). Helm uses this to deploy to the respective namespace (e.g., `--namespace staging`) and load the correct environment-specific overrides (`values-staging.yaml` or `values-production.yaml`).
- **REVISION**: If rolling back, specify the exact Helm revision number. Setting to `0` reverts to the immediately previous release.

### Pipeline Stages:
The pipeline defined in `GameZone/Jenkinsfile` consists of the following stages:

**1. Build & Push (Deploy Action Only):**
- Logs into Docker Hub using the `dockerhub` credentials securely via standard input.
- Builds the application Docker image using `docker compose build webapp`.
- Tags the built image dynamically using the Jenkins `BUILD_NUMBER` (e.g., `tarek2020/dotnetapp:12`).
- Pushes the versioned image to Docker Hub.

**2. Deploy with Helm (Deploy Action Only):**
- Utilizes the Helm chart located in `k8s/helm-charts` to manage Kubernetes resources (Deployments, Services, Ingress, Secrets, PVCs).
- Dynamically injects the `BUILD_NUMBER` as the image tag (`--set app.image.tag=...`).
- Applies the target environment's specific values overrides (`-f values-<environment>.yaml`).
- Automatically creates the isolated Kubernetes namespace if it doesn't already exist (`--create-namespace`).

**3. Rollback with Helm (Rollback Action Only):**
- Skips the build/push steps entirely.
- Leverages Helm's native rollback functionality (`helm rollback`) to immediately revert the targeted environment (namespace) to the specified revision, ensuring quick disaster recovery without needing to rebuild code.

### How to Run:
1. Create a new Jenkins Pipeline Job and point it to this GitHub repository.
2. Ensure the `Jenkinsfile` path is correctly set.
3. Trigger **"Build Now"** once to parse the parameters.
4. On subsequent runs, use **"Build with Parameters"** to select your `ACTION` and target `ENVIRONMENT` before execution.
