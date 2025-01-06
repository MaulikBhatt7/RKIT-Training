using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using LINQDemo.Models;
using System;

namespace LINQDemo
{
    /// <summary>
    /// Repository class to manage database operations for Student entities.
    /// </summary>
    public class StudentRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        public StudentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MB Connection"].ConnectionString;
        }

        /// <summary>
        /// Retrieves all students from the database.
        /// </summary>
        /// <returns>A list of <see cref="StudentModel"/> objects.</returns>
        public IEnumerable<StudentModel> GetAllStudents()
        {
            List<StudentModel> lstStudents = new List<StudentModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("GetAllStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstStudents.Add(new StudentModel
                            {
                                Id = reader.GetInt32("student_id"),
                                Name = reader.GetString("student_name"),
                                Age = reader.GetInt32("age"),
                                CityID = reader.GetInt32("city_id"),
                                Marks = reader.GetDecimal("marks"),
                                Grade = reader.GetString("grade")
                            });
                        }
                    }
                }
            }

            return lstStudents;
        }

        /// <summary>
        /// Retrieves all cities from the database.
        /// </summary>
        /// <returns>A list of <see cref="City"/></returns>
        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            // Create connection to MySQL
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Define the SELECT query
                    string query = "SELECT city_id,city_name FROM city";

                    // Create the command
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Execute the query and get a data reader
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read the data and populate the list
                            while (reader.Read())
                            {
                                cities.Add(new City
                                {
                                    CityId = reader.GetInt32("city_id"),
                                    CityName = reader.GetString("city_name")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur
                    Console.WriteLine(ex.Message);
                }
            }

            return cities;
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="studentId">The ID of the student to retrieve.</param>
        /// <returns>A <see cref="StudentModel"/> object if found; otherwise, null.</returns>
        public StudentModel GetStudentById(int studentId)
        {
            StudentModel student = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("GetStudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new StudentModel
                            {
                                Id = reader.GetInt32("student_id"),
                                Name = reader.GetString("student_name"),
                                Age = reader.GetInt32("age"),
                                CityID = reader.GetInt32("city_id"),
                                Marks = reader.GetDecimal("marks"),
                                Grade = reader.GetString("grade")
                            };
                        }
                    }
                }
            }

            return student;
        }

        /// <summary>
        /// Adds a new student to the database.
        /// </summary>
        /// <param name="student">The <see cref="StudentModel"/> object containing student details.</param>
        /// <returns>The number of rows affected.</returns>
        public int AddStudent(StudentModel student)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", student.Id);
                    command.Parameters.AddWithValue("@studentName", student.Name);
                    command.Parameters.AddWithValue("@studentAge", student.Age);
                    command.Parameters.AddWithValue("@cityId", student.CityID);
                    command.Parameters.AddWithValue("@studentMarks", student.Marks);
                    command.Parameters.AddWithValue("@studentGrade", student.Grade);

                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates an existing student in the database.
        /// </summary>
        /// <param name="student">The <see cref="StudentModel"/> object containing updated student details.</param>
        /// <returns>The number of rows affected.</returns>
        public int UpdateStudent(StudentModel student)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", student.Id);
                    command.Parameters.AddWithValue("@studentName", student.Name);
                    command.Parameters.AddWithValue("@studentAge", student.Age);
                    command.Parameters.AddWithValue("@cityId", student.CityID);
                    command.Parameters.AddWithValue("@studentMarks", student.Marks);
                    command.Parameters.AddWithValue("@studentGrade", student.Grade);

                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a student from the database by their ID.
        /// </summary>
        /// <param name="studentId">The ID of the student to delete.</param>
        /// <returns>The number of rows affected.</returns>
        public int DeleteStudent(int studentId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", studentId);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}