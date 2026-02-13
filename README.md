# Flume Mini Wallet ??

API REST para gestión de billetera digital desarrollada con .NET 8 y arquitectura limpia (Clean Architecture).

## ?? Características

- Gestión de usuarios
- Registro de transacciones (ingresos y egresos)
- Consulta de balance por usuario
- Patrón CQRS con MediatR
- Entity Framework Core
- SQL Server

## ?? Prerequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) o SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)

## ?? Instalación

### 1. Clonar el repositorio
```bash
git clone https://github.com/tu-usuario/flume-mini-wallet.git
cd flume-mini-wallet
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Configurar la base de datos

Edita el archivo `appsettings.json` en el proyecto `FlumeMiniWallet.API`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FlumeWalletDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Ejecutar migraciones
```bash
dotnet ef database update --project src/Flume.Infrastructure --startup-project src/FlumeMiniWallet.API
```

### 5. Ejecutar la aplicación
```bash
dotnet run --project src/FlumeMiniWallet.API
```

La API estará disponible en: `https://localhost:7001` o `http://localhost:5001`

## ?? Endpoints

### Usuarios

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/v1/users` | Obtener todos los usuarios |
| POST | `/api/v1/users` | Crear un nuevo usuario |
| GET | `/api/v1/users/{id}/balance` | Obtener balance de un usuario |

### Transacciones

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/v1/transaction/user/{userId}` | Obtener transacciones por usuario |
| POST | `/api/v1/transaction` | Crear una nueva transacción |

## ?? Ejemplos de uso

### Crear un usuario
```bash
POST /api/v1/users
Content-Type: application/json

{
  "name": "Juan Pérez",
  "email": "juan@example.com"
}
```

### Crear una transacción
```bash
POST /api/v1/transaction
Content-Type: application/json

{
  "type": "income",
  "amount": 1000.50,
  "description": "Salario mensual",
  "userId": 1
}
```

### Consultar balance
```bash
GET /api/v1/users/1/balance
```

**Respuesta:**
```json
{
  "userId": 1,
  "totalIncome": 5000.00,
  "totalExpense": 2300.50,
  "balance": 2699.50
}
```

## ??? Arquitectura
```
??? FlumeMiniWallet.API          # Capa de presentación (Controllers)
??? Flume.Application            # Lógica de aplicación (CQRS, DTOs, Handlers)
??? Flume.Domain                 # Entidades y lógica de dominio
??? Flume.Infrastructure         # Persistencia (EF Core, Repositories)
```

## ??? Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MediatR (CQRS)
- SQL Server
- Swagger/OpenAPI

## ?? Notas adicionales

- El proyecto utiliza el patrón **Repository** y **Unit of Work**
- Implementa **CQRS** usando MediatR
- Sigue principios de **Clean Architecture**

## ?? Autor

Tu Nombre - [@tu-usuario](https://github.com/tu-usuario)

## ?? Licencia

Este proyecto está bajo la Licencia MIT.