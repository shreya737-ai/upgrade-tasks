use EcommAppDb;

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS product_info, list_price,
    (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS category_avg_price,
    list_price - (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS price_difference
FROM products p1
WHERE list_price > (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
);