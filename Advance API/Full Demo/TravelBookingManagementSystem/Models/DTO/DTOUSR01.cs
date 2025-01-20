using Newtonsoft.Json;
using System;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for User information (DTOUSR01).
    /// This class is used for adding or updating user details.
    /// </summary>
    public class DTOUSR01
    {
        /// <summary>
        /// Gets or sets the user ID (for update operations).
        /// </summary>
        [JsonProperty("R01101")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [JsonProperty("R01102")]
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        [JsonProperty("R01103")]
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("R01104")]
        public string R01F04 { get; set; }

    }
}
