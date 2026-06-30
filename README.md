# Summer Practice Library

Library .NET 10 API created with purpose of learning Entity Framework and repository pattern.

## [UPDATE] Github Codespaces

### 1. Setup codespace
1. Click below button to create an own codespace:

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/stefandr99/SummerPractice.Library?quickstart=1)

2. Create new 
3. Wait up to 5 minutes to install and initiate project tools and dependencies
4. Right click on Library.Infrastructure project and choose: "Open in Integrated Terminal"
5. run ```dotnet ef database update``` to apply initial migration (*the one which creates the tables*)
6. On the left side (most probably the last one), there is an icon as a *server* which is the SQL Server icon
7. Click "Add connection"
    - **Profile name**: ```Localdb```
    - **Server name**: ```127.0.0.1```
    - **Trust server certificate**: check
    - **Authentication type**: ```SQL login```
    - **User name**: ```sa```
    - **Password**: ```p@ssw0rd123```
    - **Save password**: check
    - **Connect**
8. Now you'll be able to access the database and query tables directly in codespace

### 2. Exercise 1 - add a new migration

1. Add a new column ```decimal``` in ```Book``` entity: ```Rating```
2. Uncomment lines 18-20 from ```DbContext```
3. Right click on Library.Infrastructure project
4. Click "Open in Integrated Terminal"
5. Create a new migration with meaningful name (use ```dotnet ef migrations add ...``` command)
6. Update dabase to apply new migration ```dotnet ef database update```
7. Check new column in database
8. Uncomment line 60 in ```BookHandler``` (to map new rating property)

#### Test changes
1. Right click on Library.API project
2. Click "Open in Integrated Terminal"
3. Run ```dotnet run```
4. 2 options:
    - a popup might appear that app is running at specific port, click ```Open in browser``` - swagger should be opened, you can test endpoints, create books and authors, get and search
    - go to link displayed in terminal after: ```Now listening on: ```

### 3. Exercise 2 - implement get top books

1. Run INSERT SQL command from file: ```Scripts/booksSeed.sql``` in tour codespace
2. New flow in application: **get books by rating with authors**
3. Uncomment line 78 in ```BookHandler``` (to map new rating property)
3. Implement ```GetTopRatedBooksAsync``` method in ```BookRepository``` respecting following requirements:
    - Published after 2010
    - Rating >= 4
    - Include Author
    - Order by Rating descending
5. Test endpoint ```GET /api/books/top```


## I. Setup

### I.1. Create database

1. Go to ```scripts``` folder
2. Open powershell in this folder
3. Run: ```.\createDatabase.ps1```
4. In case you get ```cannot be loaded
because running scripts is disabled on this system```
Run ```Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser``` and try again

### I.2. Install dotnet tool

1. Open powershell
2. Run ```dotnet tool install --global dotnet-ef```
3. Check ```dotnet ef --version```

### I.3. Run first migration

1. In Visual Studio, open Library solution
2. Right click on Library.Infrastructure project
3. Click "Open in terminal"
4. Run in terminal ```dotnet ef migrations add InitialMigration```
5. Check migration in ```Migrations``` folder
6. Run ```dotnet ef database update``` to apply migration
7. Open SSMS, choose MSSQLLocalDB server, check ```LibraryDb``` tables
7. In case migrations do not work: 
    - copy content of file ```createDatabases.sql```
    - paste in SSMS query tab
    - run / F5

## Errors
1. ```cannot be loaded because running scripts is disabled on this system```
    
    **Solution**: Run in Powershell ```Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser```

2. Migration update fails with similar issues: "network issue", "server cannot be found", etc.

    **Context**: [here](https://github.com/stefandr99/SummerPractice.Library/blob/exercises/1_search-books-by-title/Library.API/appsettings.json) is configuration file of the application where an important part is present: **connectionString**.
    Connection string is the "bridge" between application and database. It tells application where database can be found (our case: ```(localdb)\\MSSQLLocalDB```).

    **Solution**: 
    - SQL server instance has a different name than the one in connection string;
    - ```(localdb)\\MSSQLLocalDB``` is the default server name;
    - replace this part with the name of your server - you can see server name in SSMS just after you open SSMS application or after connection in the left side panel.

## II. Exercise 1

1. Checkout to branch ```exercises/1_search-books-by-title```
    - if vs not working, open git bash in project folder and run ```git checkout exercises/1_search-books-by-title```
2. Pull changes before any implementation
    - via VS: Git changes right tab -> Pull (arrow down icon)
    - git bash: ```git pull```
3. Implement method ```SearchAsync``` from ```BookRepository```
4. **Return all books from database which have in title term sent as parameter ordered by Title**
5. Hints:
    - use LINQ methods
    - use ```.ToListAsync()``` to make method async (**async - not in scope for this session**)
6. Test method implementation by calling ```api/books/search``` endpoint
    - database is empty: before testing search flow, add 1-2 authors and 1-2 books in database via create endpoints

## III. Exercise 2

1. Checkout to branch ```exercises/2_create-new-migration```
    - if VS not working, open git bash in project folder and run ```git checkout exercises/2_create-new-migration```
2. Pull changes before any implementation
    - via VS: Git changes right tab -> Pull (arrow down icon)
    - git bash: ```git pull```
3. Add a new column ```decimal``` in ```Book``` entity: ```Rating```
4. Uncomment lines 18-20 from ```DbContext```
4. Create a new migration with meaningful name
    - Info: Right click on Library.Infrastructure project and click "Open in terminal"
    - Hint: use ```dotnet ef migrations add MigrationName```
5. Run ```dotnet ef database update``` to apply migration
    - if erros check error section above;
6. Check table ```Book``` in SSMS

## IV. Exercise 3
1. Checkout to branch ```exercises/3_get-top-books-with-rating```
    - if vs not working, open git bash in project folder and run ```git checkout exercises/3_get-top-books-with-rating```
2. Run INSERT SQL command from file: ```Scripts/booksSeed.sql```
3. A new flow has been added in application: **get books by rating with authors**
4. Implement ```GetTopRatedBooksAsync``` method in ```BookRepository``` respecting following requirements:
    - Published after 2010
    - Rating >= 4
    - Include Author
    - Order by Rating descending
5. Test endpoint ```GET /api/books/top```

Last branch: ```final-details``` - pull again changes

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/stefandr99/SummerPractice.Library?quickstart=1)