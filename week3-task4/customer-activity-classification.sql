use EcommAppDb;

SELECT 
    c.first_name + ' ' + c.last_name AS full_name,

    COUNT(o.order_status) AS total_orders,

    IIF(COUNT(o.order_status) > 10, 'Premium',
        IIF(COUNT(o.order_status) >= 5, 'Regular', 'Basic')
    ) AS customer_category

FROM customers c
LEFT JOIN orders o 
    ON c.customer_id = o.customer_id

GROUP BY c.first_name, c.last_name;

select * from orders;