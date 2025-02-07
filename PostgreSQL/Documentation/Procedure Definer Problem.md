# Procedure and Privilege Management in MySQL and PostgreSQL

## MySQL

### Scenario

In MySQL, we have two users:

1. **procedure_user**: This user has the privileges to create procedures and insert into a specific table.
2. **tester_user**: This user does not have direct insert privileges on the table but can execute the procedure created by `procedure_user`.

### Steps to Implement

1. **Create Users and Grant Privileges**

   ```sql
   CREATE USER 'procedure_user'@'localhost' IDENTIFIED BY 'password';
   CREATE USER 'tester_user'@'localhost' IDENTIFIED BY 'password';

   GRANT CREATE PROCEDURE, INSERT ON `your_database`.`your_table` TO 'procedure_user'@'localhost';
   ```

2. **Create the Procedure**

   ```sql
   DELIMITER //

   CREATE PROCEDURE your_database.insert_procedure(IN param1 INT, IN param2 VARCHAR(255))
   BEGIN
       INSERT INTO your_table (column1, column2) VALUES (param1, param2);
   END //

   DELIMITER ;
   ```

3. **Grant Execution Privilege to `tester_user`**

   ```sql
   GRANT EXECUTE ON PROCEDURE your_database.insert_procedure TO 'tester_user'@'localhost';
   ```

4. **Test the Procedure Execution**

   ```sql
   -- As tester_user
   CALL your_database.insert_procedure(1, 'test');
   ```

With these steps, `tester_user` can call the procedure but cannot insert directly into the table.

## PostgreSQL

### Scenario

In PostgreSQL, we have similar users:

1. **procedure_user**: This user creates the procedure and has insert privileges on the table.
2. **tester_user**: This user can execute the procedure but does not have direct insert privileges on the table.

### Concepts of Security Definer and Security Invoker

- **Security Definer**: The procedure runs with the privileges of the user who created it (the definer).
- **Security Invoker**: The procedure runs with the privileges of the user who invokes it (the invoker).

### Steps to Implement

1. **Create Users and Grant Privileges**

   ```sql
   CREATE USER procedure_user WITH PASSWORD 'password';
   CREATE USER tester_user WITH PASSWORD 'password';

   GRANT INSERT ON TABLE your_table TO procedure_user;
   ```

2. **Create the Procedure with Security Definer**

   ```sql
   CREATE OR REPLACE PROCEDURE insert_procedure(param1 INT, param2 VARCHAR)
   LANGUAGE plpgsql
   SECURITY DEFINER
   AS $$
   BEGIN
       INSERT INTO your_table (column1, column2) VALUES (param1, param2);
   END;
   $$;

   GRANT EXECUTE ON PROCEDURE insert_procedure TO tester_user;
   ```

With `SECURITY DEFINER`, `tester_user` can execute the procedure using `procedure_user`'s privileges.

3. **Create the Procedure with Security Invoker**

   ```sql
   CREATE OR REPLACE PROCEDURE insert_procedure_invoker(param1 INT, param2 VARCHAR)
   LANGUAGE plpgsql
   SECURITY INVOKER
   AS $$
   BEGIN
       INSERT INTO your_table (column1, column2) VALUES (param1, param2);
   END;
   $$;

   GRANT INSERT ON TABLE your_table TO tester_user;
   ```

With `SECURITY INVOKER`, the procedure will use the privileges of the user executing the procedure. Therefore, `tester_user` needs direct insert privileges on the table.

### Detailed Explanation

#### Creating Users and Granting Privileges

- **MySQL**:

  - We create two users: `procedure_user` and `tester_user`.
  - `procedure_user` is granted the privileges to create procedures and insert into the table.
  - `tester_user` does not have direct insert privileges.

- **PostgreSQL**:
  - We create two users: `procedure_user` and `tester_user`.
  - `procedure_user` is granted the privilege to insert into the table.
  - `tester_user` does not have direct insert privileges initially.

#### Creating Procedures

- **MySQL**:

  - A procedure `insert_procedure` is created by `procedure_user` that inserts data into the table.
  - We use `DELIMITER` to change the default delimiter temporarily to allow the procedure creation.

- **PostgreSQL**:
  - Two procedures are created: one with `SECURITY DEFINER` and one with `SECURITY INVOKER`.
  - `SECURITY DEFINER` allows `tester_user` to execute the procedure using `procedure_user`'s privileges.
  - `SECURITY INVOKER` requires `tester_user` to have direct insert privileges to execute the procedure.

#### Granting Execution Privileges

- **MySQL**:

  - `tester_user` is granted the privilege to execute the procedure.

- **PostgreSQL**:
  - For `SECURITY DEFINER`, `tester_user` is granted the privilege to execute the procedure.
  - For `SECURITY INVOKER`, `tester_user` is granted the insert privilege on the table.

### Summary

- **MySQL**: Use `GRANT EXECUTE` to allow `tester_user` to execute the procedure without direct insert privileges.
- **PostgreSQL**:
  - Use `SECURITY DEFINER` to allow `tester_user` to execute the procedure using `procedure_user`'s privileges.
  - Use `SECURITY INVOKER` to require `tester_user` to have direct insert privileges to execute the procedure.

This comprehensive documentation covers the step-by-step implementation of procedures and privilege management in both MySQL and PostgreSQL, providing a clear understanding of the concepts and their practical applications.
