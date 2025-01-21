using System;

namespace TravelBookingManagementSystem.Models.POCO
{
    /// <summary>
    /// Plain Old CLR Object (POCO) for user information (USR01).
    /// This class represents the user entity for the database or internal processing.
    /// </summary>
    public class USR01
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// Gets or sets the user role (Admin or User).
        /// </summary>
        public string R01F05 { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime R01F06 { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the update timestamp.
        /// </summary>
        public DateTime R01F07 { get; set; }
    }
}
