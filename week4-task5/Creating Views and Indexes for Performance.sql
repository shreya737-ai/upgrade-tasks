USE EcommDb;
GO

-- View 1: Product Details (Product, Brand, Category, Model Year, Price)
CREATE VIEW vw_ProductDetails AS
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;
GO

-- Test View
SELECT * FROM vw_ProductDetails;
GO


-- View 2: Order Summary (Customer, Store, Staff)
CREATE VIEW vw_OrderSummary AS
SELECT 
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_date
FROM orders o
JOIN customers c ON o.customer_id = c.customer_id
JOIN stores s ON o.store_id = s.store_id
JOIN staffs st ON o.staff_id = st.staff_id;
GO

-- Test View
SELECT * FROM vw_OrderSummary;
GO


-- Create Indexes on frequently used foreign key columns
CREATE INDEX idx_products_brand ON products(brand_id);
CREATE INDEX idx_products_category ON products(category_id);

CREATE INDEX idx_orders_customer ON orders(customer_id);
CREATE INDEX idx_orders_store ON orders(store_id);
CREATE INDEX idx_orders_staff ON orders(staff_id);

CREATE INDEX idx_order_items_product ON order_items(product_id);
CREATE INDEX idx_order_items_order ON order_items(order_id);
GO


-- Example Query to Test Performance
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;
GO