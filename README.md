# ASP.NET Core Blazor Server + ElectronNET.API

## 1.0.0

Basic CRUD using ASP.NET Core Blazor Server

Reference: https://www.youtube.com/watch?v=PFOknwtulcM&list=PLTVK2lirpnSjv-Ieoxj_F35ECC_J1L9ax&index=3

Environment & tools
1. Visual Studio 2022 Community
2. NET 6.0.6
3. Dapper as ORM

## 1.0.1
Electron.NET added.

This extension allow to execute this aplication like Desktop application.

This tutorial uses a ASP.NET Core Blazor Server using .NET 5.0:

https://www.c-sharpcorner.com/blogs/create-desktop-application-using-blazor-electron

Unlike .NET 5.0 and previous versions, .NET 6.0 and .NET 7.0 merged program.cs and startup.cs into a single class

- Add ElectronNET.API from Nuget in BlazorServerCRUD.UI
- Add compatibility with Electron, modifying program.cs // RSV. Electron.NET
- Open 'cmd as administrator' 

   > cd C:/.../BlazorServerCRUD.UI
   
   > electronize init
   
   > electronize start

After inilizating ElectronNET.API, you can start the desktop application from Visual Studio 2022 as well, selecting Electron.NET app

NOTE: electronize start /watch

With this option, you can modify source code and the changes are displayed automatically (it's not necessary to restart the application)

Reference: https://www.youtube.com/watch?v=At7CmMGNbwA&list=PLTVK2lirpnSjv-Ieoxj_F35ECC_J1L9ax&index=6

## 1.0.2
Add identity using Scaffolding

1. Install CodeGeneartion.Design using nuget package manager

   PM> Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.7 

2. Add identity using Scaffolding:

   BlazorServerCRUD.UI --> Right button in mouse --> New Scaffolding Item --> Identity

   In this option, create new BlazorServerCRUDContext.cs and AppUser.cs 

3. Change references to BlazorServerCRUDContextConnection to SqlConnection and remove BlazorServerCRUDContextConnection from appsettings.json

   NOTE: With this change, EF works with our existing connection

4. Install EF to use Code First and Migrations using nuget package manager

PM> Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore -version 6.0.7

5. Add first migration. This migration creates a class that it defines the User tables in the database

PM> Add-Migration CreateIdentitySchema

6. Execute pending migrations

PM> Update-Database

Reference: https://learn.microsoft.com/es-es/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=visual-studio