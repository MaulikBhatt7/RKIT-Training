# Step 1: Backup the 'college' database into a file
mysqldump -u root -p college > college.sql

# Step 2: Drop the 'college' database to simulate data loss
mysql -u root -p -e "DROP DATABASE college;"

# Step 3: Create the 'college' database again
mysql -u root -p -e "CREATE DATABASE college;"

# Step 4: Restore the 'college' database from the backup file
mysql -u root -p college < college.sql
