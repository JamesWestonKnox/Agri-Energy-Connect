# Agri-Energy Connect

Agri-Energy Connect is a web platform designed to bridge the gap between farmers and green energy companies by showcasing sustainable agricultural products and solutions.

This ReadMe file will provide instructions on setting up the development enviroment, running the prototype and explanation of the diffrent user roles and their functions.

---
# Setting up the development enviroment and running the prototype

## Prerequisites
- Visual Studio 2022
- .NET 8

## Setup
1. Open Visual Studio and either open the solution included in this package or import the GitHub repository.
2. Navigate to tools - Nuget Package Manager and ensure the following packages are installed:
   - Microsoft.AspNetCore.Authentication.Cookies
   - Microsoft.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.Sqlite
   - Microsoft.EntityFrameworkCore.Tools
3. Open up a terminal in the root folder of the project.
4. Run the command 'dotnet restore'
5. Go to build - Build solution or press CTRL + SHIFT + B to build the project.
6. Once built either press the run button or press F5.

The application should open in your default browser automatically.

---
# User roles and system functionality

## Employee
### Default account
Username: Emp1

Password: password
### Functionality
- Create farmer account with all essential details.
- View all products.
- View specific farmers products.
- Filter products by type and date range.
## Farmer
### Default account
Username: Farmer1

Password: 12345
### Functionality
- View all products on marketplace.
- Filter products on marketplace according to type and date range.
- View and add their own products.

---
