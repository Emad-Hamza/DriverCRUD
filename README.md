# DriverCRUD #

## Requirements ##

- .NET 7.0+
- Supported databases:
  - MySQL 5.7+



## Local environment Installation ##

1. Build the project and its dependencies
```bash
dotnet build
```
2. Import the attached database driver_crud.sql on your mysql server

3. Change the database connection string accordingly in appsetings.json

4. Start the app
```bash
dotnet run
```

## Urls:

- API swagger documentation: /swagger/index.html

## Notes:

- The GET /Driver API returns the drivers list in alphabetical order.
- To be able to get one of the driver's full name alphabetized (GET getAlphabetalizedName/{Id}) make sure to use a valid ID from the response of the GET /Driver in the path.