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
