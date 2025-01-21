using System;

namespace TravelBookingManagementSystem.Models.POCO
{
    /// <summary>
    /// Plain Old CLR Object (POCO) for booking information (BOK01).
    /// This class represents the booking entity for the database or internal processing.
    /// </summary>
    public class BOK01
    {
        /// <summary>
        /// Gets or sets the booking ID.
        /// </summary>
        public int K01F01 { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string K01F02 { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        public string K01F03 { get; set; }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        public DateTime K01F04 { get; set; }

        /// <summary>
        /// Gets or sets the type of booking (flight or hotel).
        /// </summary>
        public string K01F05 { get; set; }

        /// <summary>
        /// Gets or sets the reference ID (flight_id or hotel_id).
        /// </summary>
        public int K01F06 { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime K01F07 { get; set; }

        /// <summary>
        /// Gets or sets the update timestamp.
        /// </summary>
        public DateTime K01F08 { get; set; }

        /// <summary>
        /// Gets or sets the User ID.
        /// </summary>
        public int K01F09 { get; set; }
    }
}
