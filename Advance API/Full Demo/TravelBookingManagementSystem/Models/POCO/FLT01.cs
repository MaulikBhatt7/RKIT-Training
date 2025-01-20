using System;

namespace TravelBookingManagementSystem.Models.POCO
{
    /// <summary>
    /// Plain Old CLR Object (POCO) for flight information (FLT01).
    /// This class represents the flight entity for the database or internal processing.
    /// </summary>
    public class FLT01
    {
        /// <summary>
        /// Gets or sets the flight ID.
        /// </summary>
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        public string T01F02 { get; set; }

        /// <summary>
        /// Gets or sets the departure city.
        /// </summary>
        public string T01F03 { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        public string T01F04 { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        public DateTime T01F05 { get; set; }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        public DateTime T01F06 { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal T01F07 { get; set; }

        /// <summary>
        /// Gets or sets the airline.
        /// </summary>
        public string T01F08 { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime T01F09 { get; set; }

        /// <summary>
        /// Gets or sets the update timestamp.
        /// </summary>
        public DateTime T01F10 { get; set; }
    }
}
