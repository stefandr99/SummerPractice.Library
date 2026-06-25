# Summer Practice Library

Library .NET 10 API created with purpose of learning Entity Framework and repository pattern.

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

## II. Exercise 1

1. Checkout to branch ```exercises/1_search-books-by-title```
    - if vs not working, open git bash in project folder and run ```git checkout exercises/1_search-books-by-title```
1. Implement method ```SearchAsync``` from ```BookRepository```
2. Return all books from database which have in title term sent as parameter
3. Hints:
    - use ```.ToListAsync()``` to make method async (**async - not in scope for this session**)
4. Test method implementation by calling ```api/books/search``` endpoint

## III. Exercise 2

1. Checkout to branch ```exercises/2_create-new-migration```
    - if vs not working, open git bash in project folder and run ```git checkout exercises/2_create-new-migration```
2. Add a new column in ```Book``` entity: ```Rating```
3. Create a new migration with meaningful name
    - Info: Right click on Library.Infrastructure project and click "Open in terminal"
    - Hint: use ```dotnet ef migrations add MigrationName```
4. Run ```dotnet ef database update``` to apply migration
5. Check table ```Book``` in SSMS

## IV. Exercise 3
1. Checkout to branch ```exercises/3_get-books-with-rating```
    - if vs not working, open git bash in project folder and run ```git checkout exercises/3_get-books-with-rating```
2. Run INSERT SQL command from file: ```Scripts/booksSeed.sql```
2. A new flow has been added in application: **get books by rating with authors**
3. Implement ```GetTopRatedBooksAsync``` method in ```BookRepository``` respecting following requirements:
    - Published after 2010
    - Rating >= 4
    - Include Author
    - Order by Rating descending
4. Test endpoint ```GET /api/books/top```

Last branch: ```final-details```