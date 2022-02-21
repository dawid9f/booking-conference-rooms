# System for rental of conference rooms
This project was created for the university (Databases Subject)
## General info
This app was created in .NET Core. This project includes several functionalities, such as a list of all reservations, along with their details, booking, employee panel. The interface has been implemented in Polish.

## Preview
[screen shots](https://github.com/dawid9f/booking-conference-rooms/blob/master/scr.pdf)
## Technologies
Project is created with:
* ASP .NET Core MVC
* MS SQL
* Bootstrap

## Setup
To run this project:
1. Download project files
2. Edit connection string in file SRSK/SRSK/Models/Database.cs
```
public BazaDanych() {
    StringPolaczenia = 
        "Server=SERVERNAME;" +
        "Database=DATABASENAME;" +
        "Trusted_Connection=True;";

    Polaczenie = new SqlConnection(StringPolaczenia);
}
```
3. *You can use the database import file for the test
[srskBaza.bacpac](https://github.com/dawid9f/booking-conference-rooms/blob/master/srskBaza.bacpac)
