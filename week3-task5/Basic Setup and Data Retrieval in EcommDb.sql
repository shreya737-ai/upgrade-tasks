-- Create Database


USE EcommDb;

-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

-- Create Brands Table
CREATE TABLE Brands (
    BrandID INT PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL
);

-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    BrandID INT,
    CategoryID INT,
    Price DECIMAL(10,2),
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Create Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    City VARCHAR(50),
    Email VARCHAR(100)
);

-- Create Stores Table
CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100),
    City VARCHAR(50)
);

-- Insert Categories
INSERT INTO Categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes'),
(5,'Accessories');

-- Insert Brands
INSERT INTO Brands VALUES
(1,'Trek'),
(2,'Electra'),
(3,'Haro'),
(4,'Ritchey'),
(5,'Surly');

-- Insert Products
INSERT INTO Products VALUES
(1,'Trek Marlin 7',1,1,850.00),
(2,'Electra Cruiser',2,2,650.00),
(3,'Haro Flightline',3,1,720.00),
(4,'Ritchey Road Logic',4,2,1200.00),
(5,'Surly Big Dummy',5,3,1500.00);

-- Insert Customers
INSERT INTO Customers VALUES
(1,'Rahul','Sharma','Delhi','rahul@gmail.com'),
(2,'Anita','Verma','Mumbai','anita@gmail.com'),
(3,'Raj','Patel','Ahmedabad','raj@gmail.com'),
(4,'Sneha','Reddy','Hyderabad','sneha@gmail.com'),
(5,'Arjun','Nair','Bangalore','arjun@gmail.com');

-- Insert Stores
INSERT INTO Stores VALUES
(1,'Bike World','Delhi'),
(2,'Cycle Mart','Mumbai'),
(3,'Urban Bikes','Bangalore'),
(4,'Speed Cycles','Hyderabad'),
(5,'City Bikes','Ahmedabad');

-- Query 1: Retrieve all products with brand and category
SELECT 
    p.ProductName,
    b.BrandName,
    c.CategoryName,
    p.Price
FROM Products p
JOIN Brands b ON p.BrandID = b.BrandID
JOIN Categories c ON p.CategoryID = c.CategoryID;

-- Query 2: Customers from a specific city (example: Bangalore)
SELECT *
FROM Customers
WHERE City = 'Bangalore';

-- Query 3: Total number of products in each category
SELECT 
    c.CategoryName,
    COUNT(p.ProductID) AS TotalProducts
FROM Categories c
LEFT JOIN Products p ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName;