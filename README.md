# Medical Appointments API

REST API for managing **medical appointments**, built with **ASP.NET Core (.NET 8)** as a university project. It handles doctors, secretaries, users and appointments, with JWT authentication and a layered architecture.

## Features

- **Authentication** with JWT bearer tokens
- **Doctors, secretaries and users**: full registration and management
- **Appointments**: scheduling and management of medical appointments
- **Validation** of every input with FluentValidation
- **API documentation** with Swagger

## Tech stack

| Purpose | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 8) |
| Database | SQL Server, Entity Framework Core (migrations) |
| Mapping | AutoMapper |
| Validation | FluentValidation |
| Auth | JWT Bearer |
| Docs | Swagger (Swashbuckle) |

## Architecture

The solution is split into projects by responsibility:

```
ConsultaMedica/
├── ConsultaMedica/   # Web API: controllers, validation, mapping profiles, Program.cs
├── Dominio/          # Domain: entities and DTOs
├── Interface/        # Repository and service interfaces
├── Service/          # Business rules
└── InfraEstrutura/   # EF Core context, repositories and migrations
```

Controllers depend only on service interfaces, and services depend only on repository interfaces, keeping each layer decoupled and easy to test.

## Getting started

**Requirements:** .NET 8 SDK and SQL Server (LocalDB works for development).

1. Set your connection string and JWT settings in `appsettings.json` (or with `dotnet user-secrets`).
2. Apply the migrations:

```bash
dotnet ef database update --project ConsultaMedica/InfraEstrutura --startup-project ConsultaMedica/ConsultaMedica
```

3. Run the API:

```bash
dotnet run --project ConsultaMedica/ConsultaMedica
```

4. Open Swagger at `/swagger` to explore the endpoints.

## Related

Frontend: [ConsultaMedicaFrontEnd](https://github.com/PedroFabrin/ConsultaMedicaFrontEnd)

## Author

**Pedro Fabrin**, Backend Developer (Python, FastAPI, AI/LLMs)

[LinkedIn](https://www.linkedin.com/in/pedro-henrique-parizoto-fabrin-08765325b) · [GitHub](https://github.com/PedroFabrin)
