# [StudentShadow API](https://github.com/MrMaximeliom/Dairy.git)

**StudentShadow API** is an API developed using .NET Core technologies. It provides the required api for a Student Shadow Application,
which is an application used to monitor students and their daily school tasks by their parents.
The API was built to achive the maximum efficiency, speed and minimal latency.



<br />

> Features


- `.NET version`: **v6.0.0**
- Uses **EF** package as ORM with support to **Postgresql** database
- Modular design, clean codebase
- Token-Based Authentication using JWT
- Following **Repository Pattern with Unit Of Work architecture**
- Support via **Github**

<br />

## ✨ Code-base structure

The project is coded following to the repository pattern with unit of work archeticture:

```bash
< PROJECT ROOT >
   |
   |-- Conists/                               
   # Contains all the constants that the application requires
   |    |-- OrderBy.cs                    
   # Defines the constants that are used in the process of ordering query reaults
   |
   |-- Controllers/
   # Implements the conrollers that are used in each endpoint
   |    |
   |    |-- ErrorController.cs/                          
   # Implements the required functions for error handling endpoints
   |    |-- Usercontroller.cs                 
   # Implements the required controllers for the endpoints that provides the CRUD operations of the users
   |    |
   |
   |-- Data/                
   # Contains the DB context file
   |    |--ApplicationDBContext.cs               
   # Handels the connection to the DB providers and configures the application's models  
   |    
   |-- Migrations/
   # Contains the migrations files used by EF to manage the databse engine 
   | 
   |-- Models/
   # Contains the models that are used to represent the DB  tables. 
   |    |    |-- User.cs                
   # Defines the properties of the user that will be stired in the database.
   |    |    |-- Model.cs                
   # Defines the endpoints for the model named 'note'
   |    
   |-- ModelsConfiguration/                     
   # Contains the models' configuration
   |
   |-- Services/             
   # Represents the services used by the application
   |    |-- IGenericRepository.cs
   # Defines an interface for the CRUD opearations
   |    |-- GenericRepository/
   # Implements the methods defined in the IGenericRepository
   |    
   |-- Unit Tests/
   # Implements the unit tests on the controllers
   |    
   |-- Unit Of Work/
   # Implements the following:
   |-- IUnitOfWork/
   # Defines an interface for the Unit Of Work
   |    |-- IUnitOfWork.cs
   # Defines an interface for Unit Of Work
   |    |-- UnitOfWork.cs
   # Implements the interface of UnitOfWork
   |
   |-- appsettings.json
   # Contains settings for the application
   |
   |-- diary_database_model.mwb
   # contains the definition of the ERD model of database design for diary endpoint
   ************************************************************************
```
