# MediMatch
Medical Matching Service for the Australian Population

Demo of app can be found here: http://medimatchrmit-dev-as.azurewebsites.net/ 

# Instructions to Run

- Install NodeJS
- Install Visual Studio 2017 with ASP.net Core Packages

```
- Navigate to MediMatchRMIT Folder
- Open windows command lines

- Run following command

> npm install

> dotnet ef migrations add [migration name] 

OR use Package Manager in Visual Studio (recommended)

PM> Add-Migration [migration name] 

- Open Project in Visual Studio

Run IIS Express Server

OR

> dotnet run

```

## Main Directory Purposes:

```
ClientApp/ - This holds the Application Logic for our Front-End - but not our whole view.

Controllers/ - This holds the Back-End Controller/ - Logic for Our API & MVC Application.

Data/ - This holds our Entity Framework Connections & Models in a Context Class.

Migrations/ - This holds our migrations when Generated so you can create the Database.

Models/ - This holds our Objects Data Models and what Data they will store in the Database.

Views/ - This holds our MVC Views which will be used for Authentication, and as a shell around ClientApp.

wwwroot/ - This contains our third party JavaScript & CSS Libraries.

```

# Project License

|							  |                                          |
|:----------------------------|:-----------------------------------------|
| **Author:**		          | Jonathan Phillipos [jaeko44](https://github.com/jaeko44)
| **Project Manager:**        | Johanna Raymond 
| **Front-End Development**   | James Cushing 
| **Technical Documentation** | Colin Possamai
|							  | Xiaoli Xu
| **Mentor**				  | Ashan Morshed
| **Copyright:**			  | Copyright (c) 2018 RMIT
| **License:**				  | Apache License, Version 2.0
