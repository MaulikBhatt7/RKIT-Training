using BlogManagementSystem.BL;
using BlogManagementSystem.Models;
using BlogManagementSystem.Models.DTO;
using BlogManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLBlogController : ControllerBase
    {
        private readonly BLBlog _objBLBlog;
        private readonly ILogger<CLBlogController> _logger;
        private Response _objResponse;

        public CLBlogController(BLBlog objBLBlog, ILogger<CLBlogController> logger, Response objResponse)
        {
            _objBLBlog = objBLBlog;
            _logger = logger;
            _objResponse = objResponse;
        }

        [HttpGet]
        [Route("get-all-blogs")]
        public IActionResult GetAllBlogs()
        {
            _objResponse = _objBLBlog.GetAllBlogs();
            return Ok(_objResponse);
        }

        [HttpGet]
        [Route("get-blog-by-id")]
        public IActionResult GetBlogByID(int id)
        {
            _objResponse = _objBLBlog.GetBlogByID(id);
            return Ok(_objResponse);
        }

        [HttpDelete]
        [Route("delete-blog")]
        public IActionResult Delete(int id)
        {
            _objResponse = _objBLBlog.Delete(id);  // Delete student and get response.
            return Ok(_objResponse);  // Return response message.
        }

        [HttpPost]
        [Route("add-blog")]
        public IActionResult AddBlog(DTOBLG01 objDTOBLG01)
        {
            // Check Validation 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _objBLBlog.Type = EnmType.A;  // Set operation type to "Add".
            _objBLBlog.PreSave(objDTOBLG01);  // Prepare data for saving.
            _objResponse = _objBLBlog.ValidationSave();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBlog.Save();  // Save the new blog if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }


        [HttpPut]
        [Route("update-blog")]
        public IActionResult UpdateBlog(DTOBLG01 objDTOBLG01)
        {

            // Check Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _objBLBlog.Type = EnmType.E;  // Set operation type to "Edit".
            _objBLBlog.PreSave(objDTOBLG01);  // Prepare data for saving.
            _objResponse = _objBLBlog.ValidationSave();  // Validate data before saving.
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBlog.Save();  // Save the updated blog if no validation errors.
            }
            return Ok(_objResponse);  // Return response with operation result.
        }
    }
}
