using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models.Enum
{
    /// <summary>
    /// Enum Entry Type of operation Add or Edit.
    /// </summary>
    public enum EnmEntryType
    {
        /// <summary>
        /// Specifies the api request is for Add operation.
        /// </summary>
        A,
        /// <summary>
        /// Specifies the api request is for Edit operation.
        /// </summary>
        E,
        /// <summary>
        /// Specifies the api request is for Delete operation.
        /// </summary>
        D
    }
}