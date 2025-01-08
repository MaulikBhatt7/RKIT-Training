using CRUDDemo.BL.Interface;
using CRUDDemo.Models.DTO;
using CRUDDemo.Models.POCO;
using CRUDDemo.Models;
using CRUDDemo.Models.Enum;
using System.Configuration;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CRUDDemo.Extension;
using System.Data;
using System;

namespace CRUDDemo.BL
{
    /// <summary>
    /// Business logic class for handling student data operations.
    /// Supports CRUD operations such as Add, Edit, Retrieve, and Delete.
    /// </summary>
    public class BLStudent : IDataHandler<DTOSTD01>
    {
        private STD01 _objSTD01; // Student object for processing.
        private int _id; // Student ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.

        /// <summary>
        /// Specifies the type of operation (Add, Edit, etc.).
        /// </summary>
        public EnmEntryType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BLStudent"/> class.
        /// Sets up the database connection and initializes the response object.
        /// </summary>
        public BLStudent()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MB Connection"].ConnectionString;
            _objResponse = new Response();
        }

        /// <summary>
        /// Retrieves all student records from the database.
        /// </summary>
        /// <returns>List of students represented as <see cref="STD01"/> objects.</returns>
        public List<STD01> GetAllStudents()
        {
            List<STD01> lstStudents = new List<STD01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(
                    "SELECT D01F01, D01F02, D01F03, D01F04, D01F05, D01F06 FROM STD01",
                    connection))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map database fields to the STD01 object.
                            STD01 objSTD01 = new STD01
                            {
                                D01F01 = reader.GetInt32("D01F01"),
                                D01F02 = reader.GetString("D01F02"),
                                D01F03 = reader.GetInt32("D01F03"),
                                D01F04 = reader.GetInt32("D01F04"),
                                D01F05 = reader.GetInt32("D01F05"),
                                D01F06 = reader.GetChar("D01F06")
                            };
                            lstStudents.Add(objSTD01);
                        }
                    }
                }
            }
            return lstStudents;
        }

        /// <summary>
        /// Retrieves a specific student record by ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>The student object if found, otherwise null.</returns>
        public STD01 GetStudentByID(int id)
        {
            STD01 objSTD01 = new STD01();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(
                    "SELECT D01F01, D01F02, D01F03, D01F04, D01F05, D01F06 FROM STD01 WHERE D01F01 = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objSTD01.D01F01 = reader.GetInt32("D01F01");
                            objSTD01.D01F02 = reader.GetString("D01F02");
                            objSTD01.D01F03 = reader.GetInt32("D01F03");
                            objSTD01.D01F04 = reader.GetInt32("D01F04");
                            objSTD01.D01F05 = reader.GetInt32("D01F05");
                            objSTD01.D01F06 = reader.GetChar("D01F06");
                        }
                    }
                }
            }
            return objSTD01;
        }

        /// <summary>
        /// Validates and fetches a student before deletion.
        /// </summary>
        /// <param name="id">Student ID.</param>
        /// <returns>Student object if valid for deletion, otherwise null.</returns>
        public STD01 PreDelete(int id) => GetStudentByID(id);

        /// <summary>
        /// Validates the deletion of a student record.
        /// </summary>
        /// <param name="objSTD01">Student object to validate.</param>
        /// <returns>Response indicating whether deletion is valid or not.</returns>
        public Response ValidationDelete(STD01 objSTD01)
        {
            if (objSTD01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Student Not Found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a student record by ID.
        /// </summary>
        /// <param name="id">Student ID to delete.</param>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Delete(int id)
        {
            STD01 student = PreDelete(id);
            Response validationResponse = ValidationDelete(student);

            if (validationResponse.IsError)
                return validationResponse;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("DELETE FROM STD01 WHERE D01F01 = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Data Deleted Successfully";
            return _objResponse;
        }

        /// <summary>
        /// Prepares a student object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTO">Data Transfer Object containing student data.</param>
        public void PreSave(DTOSTD01 objDTO)
        {
            _objSTD01 = objDTO.Convert<STD01>();

            // Assign grade based on marks.
            if (_objSTD01.D01F05 >= 90) _objSTD01.D01F06 = 'A';
            else if (_objSTD01.D01F05 >= 80) _objSTD01.D01F06 = 'B';
            else if (_objSTD01.D01F05 >= 70) _objSTD01.D01F06 = 'C';
            else if (_objSTD01.D01F05 >= 60) _objSTD01.D01F06 = 'D';
            else if (_objSTD01.D01F05 >= 35) _objSTD01.D01F06 = 'E';
            else _objSTD01.D01F06 = 'F';

            if (Type == EnmEntryType.E && _objSTD01.D01F01 > 0)
            {
                _id = _objSTD01.D01F01;
            }
        }

        /// <summary>
        /// Validates the save operation (Add or Edit).
        /// </summary>
        /// <returns>Response indicating whether the save is valid or not.</returns>
        public Response Validation()
        {
            if (Type == EnmEntryType.E)
            {
                if (_id <= 0)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct ID";
                    return _objResponse;
                }

                if (GetStudentByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Student Not Found";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves a student record (Insert or Update).
        /// </summary>
        /// <returns>Response indicating the result of the operation.</returns>
        public Response Save()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    if (Type == EnmEntryType.A)
                    {
                        using (var command = new MySqlCommand(
                            "INSERT INTO STD01 (D01F02, D01F03, D01F04, D01F05, D01F06) VALUES (@D01F02, @D01F03, @D01F04, @D01F05, @D01F06)",
                            connection))
                        {
                            command.Parameters.AddWithValue("@D01F02", _objSTD01.D01F02);
                            command.Parameters.AddWithValue("@D01F03", _objSTD01.D01F03);
                            command.Parameters.AddWithValue("@D01F04", _objSTD01.D01F04);
                            command.Parameters.AddWithValue("@D01F05", _objSTD01.D01F05);
                            command.Parameters.AddWithValue("@D01F06", _objSTD01.D01F06);
                            command.ExecuteNonQuery();
                            _objResponse.Message = "Data Added Successfully";
                        }
                    }
                    else
                    {
                        using (var command = new MySqlCommand(
                            "UPDATE STD01 SET D01F02 = @D01F02, D01F03 = @D01F03, D01F04 = @D01F04, D01F05 = @D01F05, D01F06 = @D01F06 WHERE D01F01 = @D01F01",
                            connection))
                        {
                            command.Parameters.AddWithValue("@D01F02", _objSTD01.D01F02);
                            command.Parameters.AddWithValue("@D01F03", _objSTD01.D01F03);
                            command.Parameters.AddWithValue("@D01F04", _objSTD01.D01F04);
                            command.Parameters.AddWithValue("@D01F05", _objSTD01.D01F05);
                            command.Parameters.AddWithValue("@D01F06", _objSTD01.D01F06);
                            command.Parameters.AddWithValue("@D01F01", _objSTD01.D01F01);
                            command.ExecuteNonQuery();
                            _objResponse.Message = "Data Updated Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }
    }
}
