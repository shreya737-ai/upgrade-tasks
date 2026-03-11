USE EcommDb;
GO

/* =========================================
   Stored Procedure 1: Total Sales Per Store
   ========================================= */
CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(ISNULL(oi.quantity * oi.list_price * (1 - oi.discount),0)) AS total_sales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_name;
END;
GO


/* =========================================
   Stored Procedure 2: Orders by Date Range
   ========================================= */
CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        o.order_id,
        o.order_date,
        c.first_name + ' ' + c.last_name AS customer_name,
        s.store_name
    FROM orders o
    JOIN customers c ON o.customer_id = c.customer_id
    JOIN stores s ON o.store_id = s.store_id
    WHERE o.order_date BETWEEN @StartDate AND @EndDate;
END;
GO


/* =========================================
   Scalar Function: Calculate Price After Discount
   ========================================= */
CREATE FUNCTION fn_CalculateDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN ISNULL(@price,0) * (1 - ISNULL(@discount,0));
END;
GO


/* =========================================
   Table-Valued Function: Top 5 Selling Products
   ========================================= */
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(ISNULL(oi.quantity,0)) AS total_quantity_sold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY total_quantity_sold DESC
);
GO


/* =========================================
   Example Execution
   ========================================= */

-- Execute stored procedure
EXEC sp_TotalSalesPerStore;

EXEC sp_GetOrdersByDateRange '2022-01-01','2022-12-31';

-- Use scalar function
SELECT dbo.fn_CalculateDiscountPrice(1000,0.10) AS price_after_discount;

-- Use table-valued function
SELECT * FROM dbo.fn_Top5SellingProducts();