CREATE Database Table_Structure

CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

select * from Products;