using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

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
        /// Can be 0 for new records.
        /// </summary>
        [JsonProperty("R01101")]
        [Range(0, int.MaxValue, ErrorMessage = "User ID must be 0 or a positive integer.")]
        public int R01F01 { get; set; }

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

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string R01F04 { get; set; }
    }
}
