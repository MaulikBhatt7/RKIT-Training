using Newtonsoft.Json;
using System;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Flight information (DTOFLT01).
    /// This class is used for adding or updating flight details.
    /// </summary>
    public class DTOFLT01
    {
        /// <summary>
        /// Gets or sets the flight ID (for update operations).
        /// </summary>
        [JsonProperty("T01101")]
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the flight number.
        /// </summary>
        [JsonProperty("T01102")]
        public string T01F02 { get; set; }

        /// <summary>
        /// Gets or sets the departure city.
        /// </summary>
        [JsonProperty("T01103")]
        public string T01F03 { get; set; }

        /// <summary>
        /// Gets or sets the arrival city.
        /// </summary>
        [JsonProperty("T01104")]
        public string T01F04 { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [JsonProperty("T01105")]
        public DateTime T01F05 { get; set; }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        [JsonProperty("T01106")]
        public DateTime T01F06 { get; set; }

        /// <summary>
        /// Gets or sets the price of the flight.
        /// </summary>
        [JsonProperty("T01107")]
        public decimal T01F07 { get; set; }

        /// <summary>
        /// Gets or sets the airline name.
        /// </summary>
        [JsonProperty("T01108")]
        public string T01F08 { get; set; }
    }
}
