# **MySQL High CPU Usage Investigation in PMM (Query Analytics - QAN)**

## **Step 1: Simulating High CPU Usage with Bulk Insert Query**
To analyze high CPU usage in PMM, we executed the following bulk **INSERT query**:

```sql
INSERT INTO test_cpu (id, name)
SELECT
  t.n,
  CONCAT('CPU_', t.n)
FROM
  (
    SELECT
      (
        a.N + (10 * b.N) + (100 * c.N) + (1000 * d.N) + (10000 * e.N)
      ) AS n
    FROM
      (
        SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
      ) a,
      (
        SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
      ) b,
      (
        SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
      ) c,
      (
        SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
      ) d,
      (
        SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9
      ) e
  ) t;
```

This query inserted **100,000 records**, creating a **high CPU load** in MySQL.

---

## **Step 2: Measuring CPU Usage from Prometheus Metrics**
To check the **CPU usage caused by this query**, we use the following **Prometheus query**:

```promql
100 * rate(process_cpu_seconds_total{service_name="mysql"}[5m]) / count(node_cpu_seconds_total{mode="user"})
```

This query calculates **MySQL's CPU consumption** as a percentage of total user CPU time over the last **5 minutes**.

---

## **Step 3: Checking PMM Query Analytics (QAN)**

### **🔹 Viewing the Query in QAN**
1. Navigate to **PMM → Query Analytics (QAN)**.
2. Set the **time range** to match the period when the **CPU usage spiked**.
3. Filter queries by **highest CPU Time**.
4. Locate the **INSERT INTO test_cpu** query.

### **🔹 Query Details in PMM QAN**

| **Metric**        | **Value**                                      |
|------------------|---------------------------------|
| **Query Count**  | 1 execution (low QPS)        |
| **Total Query Time** | 1.63 sec (97.51% of total load) |
| **Avg Query Time** | 1.63 sec per execution       |
| **Lock Time** | 288.00 µs (19.73% of total) |
| **Rows Examined** | 50 rows per execution |
| **Full Join** | 4 per query |
| **Full Scan** | 1 per query |
| **No index used** | 1 |
| **Rows Affected** | 100,000 rows per execution |
| **Tmp Tables** | 5 per query |

### Metrics Explanation

#### **Query Count**
- **Rate/Second**: The number of queries executed per second.
- **Sum**: Total number of queries executed.
- **Per Query Stats**: The average number of queries executed per query.

#### **Query Time**
- **Rate/Second**: The amount of time spent executing queries per second.
- **Sum**: Total time taken by all queries.
- **Per Query Stats**: The average time taken per query.

#### **Lock Time**
- **Rate/Second**: The amount of time queries were locked per second.
- **Sum**: Total lock time for all queries.
- **Per Query Stats**: The average lock time per query.

#### **Rows Examined**
- **Rate/Second**: The number of rows examined per second.
- **Sum**: Total number of rows examined by all queries.
- **Per Query Stats**: The average number of rows examined per query.

#### **Full Join**
- **Rate/Second**: The number of full joins executed per second.
- **Sum**: Total number of full joins executed by all queries.
- **Per Query Stats**: The average number of full joins per query.

#### **Full Scan**
- **Rate/Second**: The number of full scans executed per second.
- **Sum**: Total number of full scans executed by all queries.
- **Per Query Stats**: The average number of full scans per query.

#### **No Index Used**
- **Rate/Second**: The number of queries executed without using an index per second.
- **Sum**: Total number of queries executed without using an index.
- **Per Query Stats**: The average number of queries executed without using an index per query.

#### **Rows Affected**
- **Rate/Second**: The number of rows affected by queries per second.
- **Sum**: Total number of rows affected by all queries.
- **Per Query Stats**: The average number of rows affected per query.

#### **Tmp Tables**
- **Rate/Second**: The number of temporary tables created per second.
- **Sum**: Total number of temporary tables created by all queries.
- **Per Query Stats**: The average number of temporary tables created per query.

---

## **Step 4: Analyzing Query Impact in PMM Dashboards**

### **🔹 Check Query Load in QAN**
1. Navigate to **PMM → Query Analytics (QAN)**.
2. Sort queries by **CPU Time** and **Execution Time**.
3. Click on the **INSERT INTO test_cpu** query to check **Query Execution Stats**.

### **🔹 Analyze MySQL Instance in PMM**
1. Navigate to **PMM → MySQL Instance Summary**.
2. Check the following key metrics:
   - **Threads Running** → Spikes indicate contention.
   - **Temporary Tables Created** → High numbers suggest query inefficiencies.
   - **InnoDB Buffer Pool Usage** → Monitors memory impact.

### **🔹 Check CPU Usage Impact**
1. Navigate to **PMM → Node Summary**.
2. Look for:
   - **CPU Usage (%)** – Is MySQL consuming most of it?
   - **I/O Wait (%)** – High values indicate storage bottlenecks.
   - **Memory Usage** – Ensures MySQL isn't swapping.

---

## **Step 5: Identifying the Root Cause of High CPU Usage in PMM**
Now that we have analyzed MySQL's performance metrics in PMM QAN, MySQL Instance Summary, and Node Summary, let's correlate this data to determine the exact cause of high CPU usage.

### **🔍 Step 5.1: Identify the Primary Cause Using PMM Dashboards**

#### **1️⃣ Check PMM → MySQL Instance Summary**
- Look at **Threads Running** → Are too many active queries causing CPU contention?
- Check **Temporary Tables Created** → Are excessive temp tables slowing execution?
- Analyze **Handler Read Metrics** → High **Handler_read_rnd_next** may indicate full table scans.

#### **2️⃣ Check PMM → MySQL InnoDB Metrics**
- Look at **Buffer Pool Reads & Writes** → Is the buffer pool overloaded?
- Check **Row Operations** → High row operations may indicate inefficient queries.
- Analyze **InnoDB Log Waits** → High values suggest transaction bottlenecks.

#### **3️⃣ Check PMM → Node Summary**
- Look at **CPU Usage by Process** → Is MySQL the top CPU consumer?
- Check **I/O Wait Percentage** → High I/O wait suggests storage bottlenecks.
- Analyze **Load Average** → If consistently high, MySQL is overloading the system.

### **📌 Step 5.2: Verify if the Identified Cause Matches the Original High CPU Spike**
- Cross-check findings with **PMM QAN, MySQL Instance Summary, and Node Summary**.
- If MySQL’s CPU consumption aligns with the **INSERT query execution time**, we have confirmed our high CPU usage cause.
- If multiple queries contribute, analyze them separately in **QAN**.

---

## **Conclusion**

Based on the metrics, the **INSERT INTO test_cpu** query significantly impacted the CPU usage:

- **High Query Time**: The query took 1.63 seconds on average, accounting for 97.51% of the total load.
- **Rows Affected**: The query affected 100,000 rows, indicating a high volume of data processing.
- **Full Join and Full Scan**: The query involved multiple full joins and full scans, which are CPU-intensive operations.
- **Temporary Tables**: The query created 5 temporary tables, suggesting inefficiencies.

Overall, the query is confirmed to be a major contributor to high CPU usage.