USE DatabaseFirstDevelopmentUsingEFCorePowerToolsDB

CREATE VIEW BookDetails AS
SELECT
    B.ID AS BookID,
    B.Name AS BookName,
    B.YearPublished,
    A.FirstName AS AuthorFirstName,
    A.LastName AS AuthorLastName,
    C.ID AS CategoryID,
    C.Name AS CategoryName
FROM
    Books B
JOIN
    Authors A ON B.AuthorID = A.ID
LEFT JOIN
    Books_Categories BC ON B.ID = BC.BookID
LEFT JOIN
    Categories C ON BC.CategoryID = C.ID;