# Item Counter API

The **Item Counter API** is a RESTful API that counts how many times each item appears in a list. It is built using ASP.NET Core 9.0 and includes Swagger for API documentation.

## Features

- Count occurrences of items in a list.
- Swagger UI for easy API exploration.
- HTTPS redirection for secure communication.
- Configurable port via the `PORT` environment variable.

## Requirements

- .NET 9.0 SDK or later
- Visual Studio 2022 or any compatible IDE

## Getting Started

### Clone the Repository
git clone <repository-url> cd ItemCounterApi

### Build and Run

1. Restore dependencies: dotnet restore
   
2. Build the project:dotnet build

3. Run the application:dotnet run
   
   4. The API will be available at `http://localhost:80` by default or at the port specified in the `PORT` environment variable.

### Swagger Documentation

Once the application is running, you can access the Swagger UI at:http://localhost:80

This provides a user-friendly interface to explore and test the API endpoints.

## API Endpoints

### Base URL

http://<host>:<port>
### Endpoints

#### `POST /api/itemcount`

**Description**: Accepts a list of items and returns a count of how many times each item appears.

**Request Body**: { "items": ["item1", "item2", "item1", "item3"] }
**Response**:{ "item1": 2, "item2": 1, "item3": 1 }

### Environment Variables

- `PORT`: Specifies the port on which the application will run. Defaults to `80` if not set.

## Project Structure

- `Program.cs`: Configures the application, services, and middleware.
- `Controllers/ItemCountController.cs`: Contains the API logic for counting items.
- `Models/ItemRequest.cs`: Defines the request model for the API.
- `ItemCounterApi.csproj`: Project file with dependencies and build settings.

## Dependencies

- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) (v9.0.4)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore) (v6.5.0)


