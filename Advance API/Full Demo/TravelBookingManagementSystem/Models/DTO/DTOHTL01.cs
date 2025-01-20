using Newtonsoft.Json;
using System;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Hotel information (DTOHTL01).
    /// This class is used for adding or updating hotel details.
    /// </summary>
    public class DTOHTL01
    {
        /// <summary>
        /// Gets or sets the hotel ID (for update operations).
        /// </summary>
        [JsonProperty("L01101")]
        public int L01F01 { get; set; }

        /// <summary>
        /// Gets or sets the hotel name.
        /// </summary>
        [JsonProperty("L01102")]
        public string L01F02 { get; set; }

        /// <summary>
        /// Gets or sets the city of the hotel.
        /// </summary>
        [JsonProperty("L01103")]
        public string L01F03 { get; set; }

        /// <summary>
        /// Gets or sets the price per night at the hotel.
        /// </summary>
        [JsonProperty("L01104")]
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Gets or sets the hotel rating.
        /// </summary>
        [JsonProperty("L01105")]
        public float L01F05 { get; set; }

        /// <summary>
        /// Gets or sets the number of available rooms at the hotel.
        /// </summary>
        [JsonProperty("L01106")]
        public int L01F06 { get; set; }
    }
}
