CREATE FUNCTION dbo.CountBooksInCategory_FN
(
    @CategoryID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Count INT;

    SELECT @Count = COUNT(*)
    FROM Books B
    LEFT JOIN Books_Categories BC ON B.ID = BC.BookID
    WHERE BC.CategoryID = @CategoryID;

    RETURN @Count;
END;

CREATE PROCEDURE CountBooksInCategory_SP
(
    @CategoryID INT,
    @BookCount INT OUTPUT
)
AS
BEGIN
    SELECT @BookCount = COUNT(*)
    FROM Books B
    LEFT JOIN Books_Categories BC ON B.ID = BC.BookID
    WHERE BC.CategoryID = @CategoryID;
END;