namespace BlogManagementSystem.Models.POCO
{
    /// <summary>
    /// POCO model for Blog Table
    /// </summary>
    public class BLG01
    {
        /// <summary>
        /// ID
        /// </summary>
        public int G01F01 { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public string G01F02 { get; set; } = String.Empty;


        /// <summary>
        /// Content.
        /// </summary>
        public string G01F03 { get; set; } = String.Empty;

        /// <summary>
        /// CreatedAt.
        /// </summary>
        public DateTime G01F04 { get; set; }
        
        /// <summary>
        /// UpdatedAt.
        /// </summary>
        public DateTime G01F05 { get; set; }
    }
}
