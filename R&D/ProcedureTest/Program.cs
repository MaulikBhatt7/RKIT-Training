using System;
using MySql.Data.MySqlClient;

namespace TestProcedure
{
    class TestingProcedure
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter choice : ");
            Console.WriteLine("1 - MySQL");
            Console.WriteLine("2 - PostgreSQL");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) {
                case 1:
                    MySQLTesting objMySQLTesting = new MySQLTesting();
                    objMySQLTesting.Test();
                    break;
                case 2:
                    PostgreSQLTesting objPostgreSQLTesting = new PostgreSQLTesting();
                    objPostgreSQLTesting.Test();
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

        }
    }
}
