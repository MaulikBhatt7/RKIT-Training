# Query Analysis Documentation

**Date:** 2025-02-27  
**Analyst:** MaulikBhatt7

## Query

```sql
SELECT
  ProductName,
  SaleDate,
  Quantity,
  Price,
  Discount
FROM
  ProductSales
WHERE
  SaleDate BETWEEN '2024-01-01'
  AND '2024-12-31' -- Indexed
  AND CustomerID = 101 -- Indexed
  AND Quantity > 10 -- Not Indexed
  AND Price > 50.00 -- Not Indexed
  AND Discount < 5.00
LIMIT
  0, 50000
```

## Query Analysis

### Query Time Distribution

- **Lock Time:** 33.98%
- **Other:** 66.02%

### Metrics

| Metric         | Rate/Second | Sum         | Per Query Stats             |
|----------------|-------------|-------------|-----------------------------|
| **Query Count**| <0.01 QPS   | 2.00        | 12.5% of total, 1.00        |
| **Query Time** | <0.01 load  | 1.09 ms     | 1.08% of total, 545.90 µs   |
| **Lock Time**  | <0.01       | 371.00 µs   | 7.11% of total, 33.98% of query time, 185.50 µs |
| **Rows Sent**  | <0.01       | 2.00        | 4.88% of total, 1.00        |
| **Rows Examined** | <0.01    | 2.00        | 0.85% of total, 1.00 per row sent, 1.00 |

### Explanation of Metrics

- **Query Count:** The number of times the query was executed.
- **Query Time:** The total time taken to execute the query.
- **Lock Time:** The time during which the query was waiting for locks.
- **Rows Sent:** The number of rows returned by the query.
- **Rows Examined:** The number of rows examined to return the result set.

### EXPLAIN Table

The `EXPLAIN` statement provides information about how MySQL executes a query. Below is the EXPLAIN output for the given query:

| id | select_type | table        | partitions | type | possible_keys              | key            | key_len | ref   | rows | filtered | Extra       |
|----|-------------|--------------|------------|------|----------------------------|----------------|---------|-------|------|----------|-------------|
| 1  | SIMPLE      | ProductSales | NULL       | ref  | idx_SaleDate,idx_CustomerID| idx_CustomerID | 4       | const | 2    | 3.70     | Using where |

### Explanation of EXPLAIN Table Fields

- **id:** The SELECT identifier. This is useful for identifying which SELECT statement corresponds to which row in the output.
- **select_type:** The type of SELECT query. In this case, `SIMPLE` indicates a simple SELECT query without any subqueries or unions.
- **table:** The table to which the row of output refers.
- **partitions:** The partitions that are accessed by the query. `NULL` indicates that partitions are not used.
- **type:** The join type. `ref` indicates that a non-unique index or a unique index (with a constant) is used.
- **possible_keys:** The indexes that could be used to find the rows in the table.
- **key:** The key actually used to find the rows.
- **key_len:** The length of the key used.
- **ref:** The columns or constants compared to the key.
- **rows:** The number of rows MySQL believes it must examine to execute the query.
- **filtered:** An estimate of the percentage of rows that will be returned by the query.
- **Extra:** Additional information about how MySQL will execute the query. `Using where` indicates that a WHERE clause is being used to filter rows.

## Conclusion

This query retrieves product sales data for the year 2024 for a specific customer (CustomerID = 101) with additional conditions on quantity, price, and discount. The analysis indicates that the query is efficient in terms of rows examined and rows sent, but lock time constitutes a significant portion of the query time, which might need optimization.
