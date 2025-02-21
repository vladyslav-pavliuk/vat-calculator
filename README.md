# VAT Calculator API

The **VAT Calculator API** is a .NET Core application that calculates Net, Gross, and VAT amounts for purchases in Austria. It provides a RESTful API endpoint to perform these calculations based on user input.

---

## Getting Started

### 1. Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/vladyslav-pavliuk/vat-calculator.git
```

### 2. Build and Run the Application

#### Option 1: Run with Docker

1. Build and start the Docker container:

   ```bash
   docker-compose up --build
   ```

   The API will be available at `http://localhost:8080`.

#### Option 2: Run Locally

1. Navigate to the project directory:

   ```bash
   cd VatCalculator
   ```

2. Restore dependencies and build the project:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5191`.
---

## API Documentation

The API is documented using Swagger. Once the application is running, you can access the Swagger UI at:

- **Local**: `http://localhost:5000/swagger`
- **Docker**: `http://localhost:8080/swagger`

---

## Endpoints

### Calculate VAT Amounts

- **URL**: `/api/vat`
- **Method**: `POST`
- **Request Body**:

  ```json
  {
      "netAmount": 100,      // Optional
      "grossAmount": 120,    // Optional
      "vatAmount": 20,       // Optional
      "vatRate": 20          // Required (10, 13, or 20)
  }
  ```

- **Response**:

  ```json
  {
      "netAmount": 100,
      "grossAmount": 120,
      "vatAmount": 20
  }
  ```

- **Error Responses**:
  - `400 Bad Request`: Invalid input or validation errors.
