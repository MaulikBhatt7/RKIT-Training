CREATE OR REPLACE FUNCTION get_all_orders_function()
RETURNS TABLE (order_record orders) AS $$
BEGIN
    RETURN QUERY SELECT fulfilled_by FROM orders;
END;
$$ LANGUAGE plpgsql;

SELECT * FROM get_all_orders_function();



