# RecipeShare

RecipeShare is a web application designed to help users discover, share, and manage recipes. It features a responsive frontend built with Razor Pages, a robust ASP.NET Core REST API, and a SQL Server database for data storage.

---

## Running the Project with Docker

This project uses **Docker Compose** to orchestrate both the ASP.NET Core application and a SQL Server database.

### Prerequisites

* **Docker** and **Docker Compose** installed on your machine.
* At least **4GB of RAM** allocated to Docker for SQL Server to run smoothly.

### Steps to Run

1.  **Clone the repository:**

2.  **Start the containers:**
    Navigate to the root of the project (where `docker-compose.yml` is located) and run:
    ```bash
    docker-compose up --build
    ```
    This command will:
    * Build the ASP.NET Core application image.
    * Start a SQL Server 2019 container with your database data persisted in `./Databases/sql-server`.
    * Start the ASP.NET Core application, which connects to the SQL Server container.

3.  **Access the application:**
    Open your web browser and go to:
    ```
    http://localhost:7069
    ```

4.  **Stopping the containers:**
    When you're done, stop the containers with:
    ```bash
    docker-compose down
    ```

### Notes

* The SQL Server container exposes port `1433` internally, mapped to port `10000` on your host machine.
* The ASP.NET Core app runs on port `7069`.
* The connection string for the application is configured to connect to the SQL Server container using its service name, `sql-server-db`.
* The database data is persistently stored locally in the `./Databases/sql-server` folder on your host machine.

---

## Project Documentation

This section details the architecture and implementation of the RecipeShare project, covering the database structure, web frontend (Razor Pages), backend API, and automated unit testing. It includes design decisions, trade-offs, and the rationale behind each layer.

---

### Benchmark stopwatch results

500 sequential GET requests to `/api/recipes` in Release mode.

BenchmarkDotNet summary:

| Method               | Mean    | Error    | StdDev   | Allocated |
|----------------------|--------:|---------:|---------:|----------:|
| SequentialGetRecipes | 2.548 s | 0.0491 s | 0.0585 s |   6.83 MB |

**Average latency per request:** ~5.10 ms

## Additional Features

- **Dockerfile**  
  Containerization support for easy deployment and environment consistency.

- **GitHub Actions Workflow**  
  Automated CI/CD pipeline for building, testing, and deploying the application. 

- **Search and Filter**  
  Dynamic search and filtering functionality to improve data navigation and user experience.

## Walkthrough video link

https://www.loom.com/share/4eb8ef636111471e8d62fa61c5f8b4e9?sid=2ef52f11-5aec-403f-953c-902bdc06dddb