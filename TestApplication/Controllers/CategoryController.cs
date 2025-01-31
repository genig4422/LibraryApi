using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DataConnection.Services;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryServices _categoryService;

        public CategoryController(CategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add-category")]
        public IActionResult AddCategory([FromBody] CategoryVM category)
        {
           
            _categoryService.AddCategory(category);
            return Ok(category);
        }

        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        
        [HttpDelete("remove-category-by-id/{id}")]
        public IActionResult RemoveCategoryById(int id)
        {

          _categoryService.RemoveCategoryByID(id);
            return Ok();
           
        }


        [HttpPut("update-category-by-id/{id}")]
        public IActionResult UpdateCategoryById(int id, [FromBody] CategoryVM category)
        {
          

            var updatedCategory = _categoryService.UpdateCategoryById(id, category);
            return Ok(updatedCategory);
        }
    }
}
