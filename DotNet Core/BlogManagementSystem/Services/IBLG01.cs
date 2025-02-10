﻿namespace BlogManagementSystem.Services
{
    /// <summary>
    /// Interface of BLG01 Model.
    /// </summary>
    public interface IBLG01
    {
        /// <summary>
        /// ID
        /// </summary>
        public int G01F01 { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public string G01F02 { get; set; }


        /// <summary>
        /// Content.
        /// </summary>
        public string G01F03 { get; set; }

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
