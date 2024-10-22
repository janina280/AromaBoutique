# Perfume Ecommerce
An online perfume store developed using ASP.NET Core MVC and SQL Server, offering a premium range of perfumes with advanced features for a seamless shopping experience.

### Description
Aroma Boutique is an e-commerce platform designed to offer a wide selection of perfumes. Built with ASP.NET Core MVC and SQL Server, the store provides users with an easy and intuitive interface to browse, search, and purchase perfumes. Users can view detailed information about each product, add items to their shopping cart or wish list, and take advantage of special promotions. The application includes both user and administrator functionalities, allowing for secure profile management and content updates.

### Getting Started
Dependencies
* .NET 6.0 SDK or higher
* SQL Server (for database storage)
* Visual Studio 2022 (or any IDE that supports .NET development)
* Bootstrap 5 (for styling)
* Entity Framework Core (for ORM)

### Installing
Clone the Repository:
```
git clone https://github.com/janina280/Aroma-Boutique.git
cd Aroma-Boutique
```

Open the project in Visual Studio:
Launch Visual Studio.
Open the solution file AromaBoutique.sln.

### Configure the database:
Set up your SQL Server connection string in appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=AromaBoutiqueDB;Trusted_Connection=True;"
}
```

Run the migrations to create the database schema:
```
Update-Database
```

Build the project:
* Restore NuGet packages and build the solution in Visual Studio.

Executing program
* Run the web application from Visual Studio by pressing F5 or selecting "Start Debugging".

Open your browser and navigate to the local URL (usually http://localhost:5000 or http://localhost:5001).

You will now be able to:

Browse perfumes, view detailed product pages, and add items to the shopping cart or wish list.

Use the advanced search feature to filter perfumes by price or name.

View current promotions on the dedicated promotions page.

Register, log in, and manage user profiles.

Administrator functionalities:

Add or remove perfumes, brands, and promotions from the admin panel.
