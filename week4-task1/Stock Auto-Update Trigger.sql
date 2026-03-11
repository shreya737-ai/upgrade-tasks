USE EcommDb;
GO

/* =========================================
   AFTER INSERT Trigger to Auto Update Stock
   ========================================= */

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN inserted i 
                ON s.product_id = i.product_id 
               AND s.store_id = i.store_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            THROW 50001, 'Stock is insufficient. Order cannot be completed.', 1;
        END

        -- Update stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
            ON s.product_id = i.product_id
           AND s.store_id = i.store_id;

    END TRY

    BEGIN CATCH

        -- Rollback if any error occurs
        ROLLBACK TRANSACTION;

        -- Return error message
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage,16,1);

    END CATCH
END;
GO


/* =========================================
   Test Example
   ========================================= */

-- Example insert (trigger will automatically reduce stock)
INSERT INTO order_items(order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1,1,2,3,500,0.10);