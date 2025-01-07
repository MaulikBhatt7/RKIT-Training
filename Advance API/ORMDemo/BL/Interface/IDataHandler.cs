using ORMDemo.Models.Enum;
using ORMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMDemo.BL.Interface
{
    /// <summary>
    /// Interface for handling data operations of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of data to handle.</typeparam>
    public interface IDataHandler<T> where T : class
    {
        /// <summary>
        /// Gets or sets the type of opration (Edit, Add).
        /// </summary>
        EnmType Type { get; set; }

        ///// <summary>
        ///// Performs pre-save operations on the data object before saving.
        ///// </summary>
        ///// <param name="objDto">The data object to be saved.</param>
        //void PreSave(T objDto);

        ///// <summary>
        ///// Validates the data before saving.
        ///// </summary>
        ///// <returns>A response indicating whether the validation was successful.</returns>
        //Response Validation();

        ///// <summary>
        ///// Saves the data.
        ///// </summary>
        ///// <returns>A response indicating the result of the save operation.</returns>
        //Response Save();
    }
}