using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookingManagementSystem.Models.DTO
{
    /// <summary>
    /// Login Model
    /// </summary>
    public class DTOUSR02
    {
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
    }
}