# MySQL Monitoring in PRTG

PRTG provides various **MySQL monitoring sensors** that allow you to track **performance, availability, and query execution**. Here's a **complete list of MySQL-related metrics** you can monitor directly in PRTG.

---

## **Built-in MySQL Sensors in PRTG**

These sensors are natively available in PRTG for MySQL monitoring.

### **1. MySQL v2 Sensor (Recommended)**

This is the most commonly used sensor for monitoring MySQL. It provides:

- **Connection Time** → Checks if MySQL is responding.
- **Uptime** → Measures how long MySQL has been running.
- **Threads Connected** → Number of active connections.
- **Threads Running** → Currently executing queries.
- **Slow Queries** → Number of queries taking longer than `long_query_time`.
- **Query Cache Hits & Misses** → Performance of query caching.
- **Select, Insert, Update, Delete Counts** → Query activity tracking.
- **Temporary Tables Created on Disk** → Measures expensive disk I/O operations.

**How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"MySQL v2 Sensor"**.

---

### **2. MySQL Custom Query Sensor**

- Lets you execute **custom SQL queries** and monitor the results.
- You can run **performance metrics, failed transactions, table sizes, etc.**
- **Alternative:** Use **ADO SQL Sensor** or **ODBC SQL Sensor** (see below).

**Note:** If this sensor is missing, use alternative methods like **PRTG HTTP Sensor with a custom API**.

---

### **3. ADO SQL Sensor (For Running Queries)**

- Can **run SQL queries** against a MySQL database.
- Requires **MySQL ODBC Driver** installation.
- Used for **monitoring slow queries, row counts, or specific table conditions**.

**How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"ADO SQL Sensor"**.

---

### **4. ODBC SQL Sensor (Alternative to ADO SQL Sensor)**

- Works similarly to the **ADO SQL Sensor**.
- Requires configuring an **ODBC Data Source** for MySQL.
- Good for **complex queries** or **monitoring database transactions**.

**How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"ODBC SQL Sensor"**.

---

### **5. File Content Sensor (Monitor MySQL Slow Query Logs)**

- Monitors MySQL **slow query log files**.
- Detects **new slow queries** and generates alerts.
- Requires **slow query log enabled** in MySQL.

**How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"File Content Sensor"**.

---

### **6. HTTP Advanced Sensor (For External MySQL Monitoring via API)**

- Calls a **custom API script** (PHP/Python) that retrieves MySQL metrics.
- Used when **MySQL Custom Query Sensor is unavailable**.
- Example: Fetch **number of slow queries** using an API.

**How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"HTTP Advanced Sensor"**.

---

## **Summary: What You Can Monitor Directly in PRTG**

| Sensor                        | What It Monitors                                                                                                  |
| ----------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| **MySQL v2 Sensor**           | Connection time, uptime, slow queries, query cache, active threads, query counts (SELECT, INSERT, UPDATE, DELETE) |
| **MySQL Custom Query Sensor** | Run custom SQL queries to track specific database performance                                                     |
| **ADO SQL Sensor**            | Run SQL queries using ADO connection (requires ODBC setup)                                                        |
| **ODBC SQL Sensor**           | Run SQL queries using ODBC (alternative to ADO SQL Sensor)                                                        |
| **File Content Sensor**       | Monitor slow query logs (`slow.log`)                                                                              |
| **HTTP Advanced Sensor**      | Call an external API that fetches MySQL performance data                                                          |

## **Comparison of PRTG Monitor vs. PMM for MySQL Monitoring**

PRTG Network Monitor and **Percona Monitoring and Management (PMM)** are both monitoring tools, but they have different focuses and capabilities. Below is a comparison highlighting what each tool offers uniquely and what is common between them.

---

## **1. Features Available in PMM but Not in PRTG**

| Feature                                     | PMM                                                     |
| ------------------------------------------- | ------------------------------------------------------- |
| **Deep MySQL Query Performance Analysis**   | Yes                                                     |
| **Query Execution Plan Analysis**           | Yes                                                     |
| **Slow Query Log Analysis**                 | Yes                                                     |
| **In-Depth MySQL Performance Metrics**      | Yes (Buffer Pool, InnoDB Metrics, Row Operations, etc.) |
| **Real-Time Query Profiling**               | Yes                                                     |
| **Custom Query Performance Dashboards**     | Yes                                                     |
| **Advanced Alerting with Integration**      | Yes (Grafana + AlertManager)                            |
| **Open-source and Customizable**            | Yes                                                     |
| **Database-Specific Security Insights**     | Yes                                                     |
| **Replication Lag Monitoring**              | Yes (Detailed with GTID-based replication analysis)     |
| **Full-Stack Monitoring (DB, OS, Queries)** | Yes                                                     |
| **Containerized Deployment**                | Yes (Docker, Kubernetes support)                        |

**Why PMM is Strong Here?**

- PMM is built specifically for **MySQL and other databases**, offering **detailed performance insights** rather than just uptime monitoring.
- The **Query Analytics (QAN)** feature is **very powerful** and provides **detailed execution plan insights**.
- Since it's **open-source**, it is **highly customizable** for **deep MySQL analysis**.

---

## **2. Features Available in PRTG but Not in PMM**

| Feature                                                                 | PRTG                                                    |
| ----------------------------------------------------------------------- | ------------------------------------------------------- |
| **Agentless Monitoring**                                                | Yes                                                     |
| **Network Traffic & Bandwidth Monitoring**                              | Yes                                                     |
| **SNMP-Based Monitoring**                                               | Yes                                                     |
| **Multi-Device & Multi-Sensor Support**                                 | Yes (Supports various protocols - SNMP, WMI, SSH, etc.) |
| **Out-of-the-Box Email & SMS Alerts**                                   | Yes                                                     |
| **Windows Service & Process Monitoring**                                | Yes                                                     |
| **Hardware Health Monitoring (CPU, RAM, Storage, etc.)**                | Yes                                                     |
| **Multi-Vendor Support (Routers, Switches, Firewalls, etc.)**           | Yes                                                     |
| **Prebuilt MySQL Sensors (Uptime, Query Count, Cache Hit Ratio, etc.)** | Yes                                                     |

**Why PRTG is Strong Here?**

- **Comprehensive Network Monitoring**: Unlike PMM, PRTG **monitors entire IT infrastructure** (servers, network devices, applications, etc.).
- **Agentless Monitoring**: Unlike PMM, which requires installation and setup, PRTG **doesn’t need agents** on MySQL servers for basic monitoring.
- **Better Windows Integration**: **PRTG is optimized for Windows environments**, making it easy to install and configure.

---

## **3. Features Available in Both**

| Feature                                | PMM                                    | PRTG                                           |
| -------------------------------------- | -------------------------------------- | ---------------------------------------------- |
| **MySQL Uptime Monitoring**            | Yes                                    | Yes                                            |
| **MySQL Query Performance Metrics**    | Yes (Detailed with execution plans)    | Yes (Basic query count, cache hit ratio, etc.) |
| **Real-Time Performance Monitoring**   | Yes                                    | Yes                                            |
| **Dashboard Visualization**            | Grafana-based                          | PRTG Web UI                                    |
| **Custom Alerting**                    | Yes                                    | Yes                                            |
| **Multi-Database Support**             | Yes (MySQL, PostgreSQL, MongoDB, etc.) | Yes (Basic MySQL & SQL Server monitoring)      |
| **API Integration for External Tools** | Yes (REST API & Grafana Plugins)       | Yes (PRTG API)                                 |

---

## **4. Which is Better for MySQL Monitoring?**

### **Choose PMM if:**

- You need **detailed MySQL query performance analysis** (e.g., slow query logs, query execution plans).
- You want **deep MySQL-specific performance monitoring**.
- You prefer an **open-source, highly customizable solution**.
- You need **query analytics (QAN) and real-time profiling**.
- You work with **large-scale database environments**.
- You want **better integration with MySQL Replication and performance tuning tools**.

### **Choose PRTG if:**

- You need **general infrastructure monitoring** (not just MySQL).
- You want **easy setup with out-of-the-box sensors**.
- You prefer **agentless monitoring**.
- You need **network traffic, server health, and process monitoring** along with MySQL.
- You work in a **Windows-heavy environment**.

---

## **5. Final Verdict**

- **If MySQL performance tuning is your priority → PMM is the better choice**.
- **If general IT infrastructure monitoring is your priority → PRTG is better**.
- **For a hybrid approach, you can use both together**:
  - **PRTG for infrastructure monitoring** (server health, uptime, general MySQL metrics).
  - **PMM for deep MySQL performance analysis** (query execution, slow queries, optimization).
