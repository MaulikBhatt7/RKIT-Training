﻿using System;

namespace TravelBookingManagementSystem.Handlers.Exceptions
{
    /// <summary>
    /// Custom exception class for handling forbidden access errors.
    /// </summary>
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ForbiddenAccessException(string message) : base(message)
        {
            // The base constructor of the Exception class is called with the provided message.
        }
    }
}