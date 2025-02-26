# **MySQL High CPU Usage Investigation in PMM (Query Analytics - QAN)**

## **Step 1: Simulating High CPU Usage with Bulk Insert Query**
To analyze high CPU usage in PMM, we executed the following bulk **INSERT query**:

```sql
INSERT INTO `orders_96` (
    `index`, `Order_ID`, `Date`, `Status`, `Fulfilment`, `Sales_Channel`, 
    `Ship_Service_Level`, `Style`, `SKU`, `Category`, `Size`, `ASIN`, 
    `Courier_Status`, `Qty`, `Currency`, `Amount`, `Ship_City`, `Ship_State`, 
    `Ship_Postal_Code`, `Ship_Country`, `Promotion_IDs`, `B2B`, `Fulfilled_By`
) 
VALUES 
  (...)
  /* 1,28,975 records inserted */
```

This query inserted **1,28,975 records**, creating a **high CPU load** in MySQL.

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
4. Locate the **INSERT INTO orders_96** query.

### **🔹 Query Details in PMM QAN**

| **Metric**        | **Value**                                      |
|------------------|---------------------------------|
| **Query Count**  | 13 executions (low QPS)        |
| **Total Query Time** | 24.43 sec (33.9% of total load) |
| **Avg Query Time** | 1.88 sec per execution       |
| **Lock Time** | 2.31 sec (30.52% of total) |
| **Rows Affected** | 20,540 rows per execution |

---

## **Step 4: Analyzing Query Impact in PMM Dashboards**

### **🔹 Check Query Load in QAN**
1. Navigate to **PMM → Query Analytics (QAN)**.
2. Sort queries by **CPU Time** and **Execution Time**.
3. Click on the **INSERT INTO orders_96** query to check **Query Execution Stats**.

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

