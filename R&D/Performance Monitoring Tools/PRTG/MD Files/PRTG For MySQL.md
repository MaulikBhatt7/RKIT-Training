# MySQL Monitoring in PRTG

PRTG provides various **MySQL monitoring sensors** that allow you to track **performance, availability, and query execution**. Here's a **complete list of MySQL-related metrics** you can monitor directly in PRTG.

---

## **✅ Built-in MySQL Sensors in PRTG**

These sensors are natively available in PRTG for MySQL monitoring.

### **1️⃣ MySQL v2 Sensor (Recommended)**

This is the most commonly used sensor for monitoring MySQL. It provides:

- **Connection Time** ⏳ → Checks if MySQL is responding.
- **Uptime** 🕒 → Measures how long MySQL has been running.
- **Threads Connected** 👥 → Number of active connections.
- **Threads Running** ⚙️ → Currently executing queries.
- **Slow Queries** 🐌 → Number of queries taking longer than `long_query_time`.
- **Query Cache Hits & Misses** 🎯 → Performance of query caching.
- **Select, Insert, Update, Delete Counts** 📊 → Query activity tracking.
- **Temporary Tables Created on Disk** 💾 → Measures expensive disk I/O operations.

📌 **How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"MySQL v2 Sensor"**.

---

### **2️⃣ MySQL Custom Query Sensor**

- Lets you execute **custom SQL queries** and monitor the results.
- You can run **performance metrics, failed transactions, table sizes, etc.**
- **Alternative:** Use **ADO SQL Sensor** or **ODBC SQL Sensor** (see below).

📌 **Note:** If this sensor is missing, use alternative methods like **PRTG HTTP Sensor with a custom API**.

---

### **3️⃣ ADO SQL Sensor (For Running Queries)**

- Can **run SQL queries** against a MySQL database.
- Requires **MySQL ODBC Driver** installation.
- Used for **monitoring slow queries, row counts, or specific table conditions**.

📌 **How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"ADO SQL Sensor"**.

---

### **4️⃣ ODBC SQL Sensor (Alternative to ADO SQL Sensor)**

- Works similarly to the **ADO SQL Sensor**.
- Requires configuring an **ODBC Data Source** for MySQL.
- Good for **complex queries** or **monitoring database transactions**.

📌 **How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"ODBC SQL Sensor"**.

---

### **5️⃣ File Content Sensor (Monitor MySQL Slow Query Logs)**

- Monitors MySQL **slow query log files**.
- Detects **new slow queries** and generates alerts.
- Requires **slow query log enabled** in MySQL.

📌 **How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"File Content Sensor"**.

---

### **6️⃣ HTTP Advanced Sensor (For External MySQL Monitoring via API)**

- Calls a **custom API script** (PHP/Python) that retrieves MySQL metrics.
- Used when **MySQL Custom Query Sensor is unavailable**.
- Example: Fetch **number of slow queries** using an API.

📌 **How to Add**:  
Go to **PRTG Web Interface** → Select **Device (MySQL Server)** → Click **"Add Sensor"** → Search for **"HTTP Advanced Sensor"**.

---

## **📌 Summary: What You Can Monitor Directly in PRTG**

| Sensor                        | What It Monitors                                                                                                  |
| ----------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| **MySQL v2 Sensor**           | Connection time, uptime, slow queries, query cache, active threads, query counts (SELECT, INSERT, UPDATE, DELETE) |
| **MySQL Custom Query Sensor** | Run custom SQL queries to track specific database performance                                                     |
| **ADO SQL Sensor**            | Run SQL queries using ADO connection (requires ODBC setup)                                                        |
| **ODBC SQL Sensor**           | Run SQL queries using ODBC (alternative to ADO SQL Sensor)                                                        |
| **File Content Sensor**       | Monitor slow query logs (`slow.log`)                                                                              |
| **HTTP Advanced Sensor**      | Call an external API that fetches MySQL performance data                                                          |
