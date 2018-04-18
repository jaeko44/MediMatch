# MediMatch
Medical Matching Service for the Australian Population

# Instructions to Run

- Install NodeJS
- Install Visual Studio 2017 with ASP.net Core Packages

```
- Navigate to MediMatchRMIT Folder
- Open in Terminal

- Run following command

> npm install

> dotnet ef migrations add [migration name] 
> dotnet ef database update

OR use Package Manager in Visual Studio 

PM> Add-Migration [migration name] 
PM> Update-Database


- Open Project in Visual Studio

Run IIS Express Server

OR

> dotnet run

```

Main Directory Purposes:

```


ClientApp/ - This holds the Application Logic for our Front-End - but not our whole view.

Controllers/ - This holds the Back-End Controller/ - Logic for Our API & MVC Application.

Data/ - This holds our Entity Framework Connections & Models in a Context Class.

Migrations/ - This holds our migrations when Generated so you can create the Database.

Models/ - This holds our Objects Data Models and what Data they will store in the Database.

Views/ - This holds our MVC Views which will be used for Authentication, and as a shell around ClientApp.

wwwroot/ - This contains our third party JavaScript & CSS Libraries.

```
