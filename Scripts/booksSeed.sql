DECLARE @Robert UNIQUEIDENTIFIER = NEWID();
DECLARE @Martin UNIQUEIDENTIFIER = NEWID();

INSERT INTO Authors
(
    Id,
    Name,
    IsDeleted
)
VALUES
(@Robert, 'Robert C. Martin', 0),
(@Martin, 'Martin Fowler', 0);


INSERT INTO Books
(
    Id,
    Title,
    PublicationYear,
    Rating,
    AuthorId,
    IsDeleted
)
VALUES
(NEWID(), 'Clean Architecture', 2017, 4.9, @Robert, 0),

(NEWID(), 'Refactoring', 2018, 4.8, @Martin, 0),

(NEWID(), 'The Clean Coder', 2011, 4.3, @Robert, 0),

(NEWID(), 'Some Average Book', 2020, 3.7, @Martin, 0),

(NEWID(), 'Clean Code', 2008, 5.0, @Robert, 0),

(NEWID(), 'Legacy Systems', 2005, 3.2, @Martin, 0);