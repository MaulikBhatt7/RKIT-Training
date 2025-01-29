using BlogManagementSystem.Models.DTO;
using BlogManagementSystem.Models;

namespace BlogManagementSystem.BL
{
    /// <summary>
    /// Interface for blog business logic operations.
    /// </summary>
    public interface IBLBLog
    {
        /// <summary>
        /// Retrieves all blog records.
        /// </summary>
        /// <returns>Response object containing blog data or error message.</returns>
        Response GetAllBlogs();

        /// <summary>
        /// Retrieves a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object containing blog data or error message.</returns>
        Response GetBlogByID(int id);

        /// <summary>
        /// Prepares the blog entity for saving (add/edit).
        /// </summary>
        /// <param name="objDTOBLG01">DTO object for blog.</param>
        void PreSave(DTOBLG01 objDTOBLG01);

        /// <summary>
        /// Validates the save operation for add/edit.
        /// </summary>
        /// <returns>Response object indicating validation result.</returns>
        Response ValidationSave();

        /// <summary>
        /// Saves the blog record (add/edit).
        /// </summary>
        /// <returns>Response object indicating save result.</returns>
        Response Save();

        /// <summary>
        /// Deletes a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object indicating deletion result.</returns>
        Response Delete(int id);
    }
}
