using Newtonsoft.Json;
using System;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Booking information (DTOBOK01).
    /// This class is used for adding or updating booking details.
    /// </summary>
    public class DTOBOK01
    {
        /// <summary>
        /// Gets or sets the booking ID (for update operations).
        /// </summary>
        [JsonProperty("K01101")]
        public int K01F01 { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        [JsonProperty("K01102")]
        public string K01F02 { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        [JsonProperty("K01103")]
        public string K01F03 { get; set; }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        [JsonProperty("K01104")]
        public DateTime K01F04 { get; set; }

        /// <summary>
        /// Gets or sets the type of booking (flight or hotel).
        /// </summary>
        [JsonProperty("K01105")]
        public string K01F05 { get; set; }

        /// <summary>
        /// Gets or sets the reference ID (flight_id or hotel_id).
        /// </summary>
        [JsonProperty("K01106")]
        public int K01F06 { get; set; }
    }
}
