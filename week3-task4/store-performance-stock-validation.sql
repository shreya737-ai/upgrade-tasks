use EcommAppDb;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,

    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue

FROM stores s

JOIN orders o 
    ON s.store_id = o.store_id

JOIN order_items oi 
    ON o.order_id = oi.order_id

JOIN products p 
    ON oi.product_id = p.product_id

JOIN stocks st 
    ON st.product_id = p.product_id 
    AND st.store_id = s.store_id

GROUP BY s.store_name, p.product_name

HAVING SUM(st.quantity) = 0;