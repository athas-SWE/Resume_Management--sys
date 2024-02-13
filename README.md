Resume Management
Prerequisites
.NET 7.0 SDK
Node.js (for npm)
MS SQL Server (or SQL Server Express)

Installation Steps
Clone the repository: git clone <repository-url>
Navigate to the backend directory: cd backend
Restore .NET dependencies: dotnet restore
Create and configure the database connection in appsettings.json
Apply database migrations: dotnet ef database update
Run the backend server: dotnet run


Frontend Setup
Navigate to the frontend directory: cd frontend
Install dependencies: npm install
Start the development server: npm start

Accessing the Application
Backend API: http://localhost:5000
Frontend UI: http://localhost:3000

Notes

Ensure that the backend server is running before launching the frontend application.
Customize the application as needed by modifying the codebase and database schema.
For production deployment, consider configuring environment-specific settings and securing sensitive data.

