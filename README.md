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

![Screenshot 2024-06-08 215707](https://github.com/user-attachments/assets/6151a6f2-c644-4ccf-a5ac-2a37d1bed734)

![Screenshot 2024-06-08 222403](https://github.com/user-attachments/assets/6145f11d-b27a-4fc4-8607-163f89593ff5)

![Screenshot 2024-06-08 215832](https://github.com/user-attachments/assets/b4f4a474-47be-4ed1-812b-ff1154cb73e2)

![Screenshot 2024-06-08 223609](https://github.com/user-attachments/assets/fd690434-16ac-4883-8653-9c6b22cc69a3)

Browse perfumes, view detailed product pages, and add items to the shopping cart or wish list.
![Screenshot 2024-06-09 192710](https://github.com/user-attachments/assets/b44e6006-c76a-4367-b35a-fa14987611b5)

![Screenshot 2024-06-08 223802](https://github.com/user-attachments/assets/75919f3c-97f1-4f27-b40f-963afa9a0e18)

![Screenshot 2024-06-09 193424](https://github.com/user-attachments/assets/a42d1d55-a3b1-4505-aeab-5fdad5fe4299)

![Screenshot 2024-06-09 192926](https://github.com/user-attachments/assets/db87c67f-6958-402c-92f8-ac21711c66fc)

![Screenshot 2024-06-08 222633](https://github.com/user-attachments/assets/a4a32ab5-624c-4f1b-85dc-2c1a9ad9734d)

![Screenshot 2024-06-08 222654](https://github.com/user-attachments/assets/b129aa21-73f7-419a-a2e5-6379895e684a)

![Screenshot 2024-06-08 222616](https://github.com/user-attachments/assets/f275f1ef-a683-4cd3-b754-7bfa92b17e14)

Use the advanced search feature to filter perfumes by price or name.

![Screenshot 2024-06-08 223123](https://github.com/user-attachments/assets/975ee01f-b4ea-4ba2-bec5-54a225b9a7eb)

View current promotions on the dedicated promotions page.

Register, log in, and manage user profiles.

![Screenshot 2024-06-08 215742](https://github.com/user-attachments/assets/b24dde3a-1e61-4572-8adb-bd058aeddcee)

![Screenshot 2024-06-08 215804](https://github.com/user-attachments/assets/a4628b00-7837-491d-8a21-5ad9de0c39d1)

![Screenshot 2024-06-08 222257](https://github.com/user-attachments/assets/588cb614-1844-4f06-b939-5cb2caf803fe)

Administrator functionalities:

![Screenshot 2024-06-08 215918](https://github.com/user-attachments/assets/cd349792-27d7-46be-8180-4f59a53c9896)

Add or remove perfumes, brands, and promotions from the admin panel.
