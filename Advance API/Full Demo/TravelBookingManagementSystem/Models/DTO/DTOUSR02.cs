using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password hash cannot exceed 100 characters.")]
        public string R01F03 { get; set; }
    }
}
