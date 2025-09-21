# ToDo API

A robust and scalable ToDoList service implementing CRUD operations with best practices in architecture and code quality. Built with .NET, Entity Framework, RabbitMQ, MassTransit and following Onion Architecture principles.

## Features

- **Minimal API**: Create, read, update, and delete todo items using Minimal API
- **Onion Architecture**: Clean separation of concerns for maintainability
- **Repository Pattern**: Better data access abstraction
- **Entity Framework Integration**: Efficient data access with In-Memory Database
- **Async/Await**: Using .NET Concurrency for better performance
- **Docker Support**: Containerized for easy deployment
- **RabbitMQ Integration**: Asynchronous task handling with MassTransit


## Project Structure

```
ToDoList/
│   Domain/                    # Domain entities and interfaces
│   Infrastructure/            # Data access and external 
│   Application/               # Business logic and use cases
│   API/                       # Web API and controllers
├── Dockerfile                 # Container configuration
├── docker-compose.yaml        # Docker compose configuration
└── README.md
```

## ToDo Schema

Each ToDo item contains the following fields:

| Field | Type | Description |
|-------|------|-------------|
| Id | GUID | Unique identifier |
| Title | string | Title of the ToDo item |
| CreatedDate | DateTime | Creation timestamp |
| IsDeleted | bool | Soft delete flag |

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todos` | Retrieve all todo items |
| GET | `/api/todos/{id}` | Retrieve a specific todo item by ID |
| POST | `/api/todos` | Create a new todo item and add to RabbitMQ|
| PUT | `/api/todos/{id}` | Update an existing todo item |
| DELETE | `/api/todos/{id}` | Soft delete a todo item |

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker (optional, for containerized deployment)

### Using Docker

1. Clone the repository:
```bash
git clone <repository-url>
cd ToDoList.API
```

2. Run the docker compose:
```bash
docker compose up
```

The API will be available at `https://localhost:8081` or `http://localhost:8080`.