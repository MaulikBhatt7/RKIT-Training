using CRUDDemo.Models.Enum;
using CRUDDemo.Models;
using CRUDDemo.Models.POCO;

namespace CRUDDemo.BL.Interface
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
        EnmEntryType Type { get; set; }

        /// <summary>
        /// Performs pre-save operations on the data object before deleting.
        /// </summary>
        /// <param name="id">ID of student</param>
        /// <returns>Object of STD01</returns>
        STD01 PreDelete(int id);

        /// <summary>
        /// Validates the data before deleting.
        /// </summary>
        /// <param name="objSTD01"></param>
        /// <returns>Object of Response</returns>
        Response ValidationDelete(STD01 objSTD01);

        /// <summary>
        /// Delete the data
        /// </summary>
        /// <param name="id">ID of student</param>
        /// <returns>Object of Response</returns>
        Response Delete(int id);

        /// <summary>
        /// Performs pre-save operations on the data object before saving.
        /// </summary>
        /// <param name="objDto">The data object to be saved.</param>
        void PreSave(T objDto);

        /// <summary>
        /// Validates the data before saving.
        /// </summary>
        /// <returns>A response indicating whether the validation was successful.</returns>
        Response Validation();

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>A response indicating the result of the save operation.</returns>
        Response Save();
    }

}