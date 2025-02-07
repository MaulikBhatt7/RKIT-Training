-- Create a function to calculate factorial
CREATE OR REPLACE FUNCTION calculate_factorial(n INT)
RETURNS BIGINT AS $$
DECLARE
    result BIGINT := 1;
    i INT;
BEGIN
    IF n < 0 THEN
        RAISE EXCEPTION 'Input must be a non-negative integer';
    END IF;

    FOR i IN 1..n LOOP
        result := result * i;
    END LOOP;

    RETURN result;
END;
$$ LANGUAGE plpgsql;



-- Test the function
SELECT calculate_factorial(5); -- Output: 120
SELECT calculate_factorial(0); -- Output: 1