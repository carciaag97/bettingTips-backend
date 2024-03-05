using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResellBackendCore.Database.Dtos.CategoryDto;
using ResellBackendCore.Services;

namespace ResellBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/category")]
    public class CategoryController :BaseController
    {
        public CategoryService categoryService { get; set; }
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("create-category")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateCategory([FromBody] AddCategoryDto categoryDto)
        {
            try
            {
                var result = await categoryService.CreateCategory(categoryDto);
                return Ok(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
             
        }
    }
}
