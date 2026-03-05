use EcommAppDb;

INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
   OR order_date < DATEADD(YEAR, -1, GETDATE());

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

SELECT c.customer_id, c.first_name
FROM customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM orders o
    WHERE o.customer_id = c.customer_id
    AND o.order_status <> 1
);

SELECT 
    order_id,
    required_date,

    CASE 
        WHEN required_date < GETDATE() THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status

FROM orders;