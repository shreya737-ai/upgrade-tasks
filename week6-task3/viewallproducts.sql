CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price
    FROM Products;
END
GO