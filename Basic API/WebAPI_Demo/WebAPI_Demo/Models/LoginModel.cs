using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Demo.Models
{
    /// <summary>
    /// Model representing the login credentials for authentication.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}