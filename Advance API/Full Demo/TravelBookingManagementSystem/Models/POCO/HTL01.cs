using System;

namespace TravelBookingManagementSystem.Models.POCO
{
    /// <summary>
    /// Plain Old CLR Object (POCO) for hotel information (HTL01).
    /// This class represents the hotel entity for the database or internal processing.
    /// </summary>
    public class HTL01
    {
        /// <summary>
        /// Gets or sets the hotel ID.
        /// </summary>
        public int L01F01 { get; set; }

        /// <summary>
        /// Gets or sets the hotel name.
        /// </summary>
        public string L01F02 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string L01F03 { get; set; }

        /// <summary>
        /// Gets or sets the price per night.
        /// </summary>
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Gets or sets the hotel rating.
        /// </summary>
        public float L01F05 { get; set; }

        /// <summary>
        /// Gets or sets the number of available rooms.
        /// </summary>
        public int L01F06 { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime L01F07 { get; set; }

        /// <summary>
        /// Gets or sets the update timestamp.
        /// </summary>
        public DateTime L01F08 { get; set; }
    }
}
