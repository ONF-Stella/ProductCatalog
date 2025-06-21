# ProductCatalog.Web

A simple product catalog web application built with ASP.NET Core MVC, Dapper, and SQL Server.

## Features

- List all products
- Search/filter products by name or description
- View product details
- Create new products
- Edit existing products
- Delete products

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Dapper (micro-ORM)
- SQL Server
- Bootstrap (for UI styling)

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 or later

### Setup Instructions

1. **Clone the repository:**
   git clone https://github.com/ONF-Stella/ProductCatalog.git cd ProductCatalog.Web

2. **Configure the database:**
- Create a SQL Server database (Already included in project for Database script under "Database" folder)

3. **Set the connection string:**
- Update the 'DefaultConnection' string in 'appsettings.json'   
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=ProductCatalogDb;Trusted_Connection=True;"
  }

4. **Restore NuGet packages:**
- Dapper
- Microsoft.Data.SqlClient
- System.Data.SqlClient
- Bootstrap
  
5. **Run the application:**

## Project Structure

- 'Controllers/' - MVC controllers for handling requests
- 'Views/Products/' - Razor views for CRUD operations
- 'Infrastructure/ProductRepository.cs' - Dapper-based data access
- 'Models/Product.cs' - Product entity
- 'Models/ErrorViewModel.cs' - Error model for error views
