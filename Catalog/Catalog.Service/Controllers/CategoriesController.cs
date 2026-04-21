using Catalog.Service.BLL.Dto;
using Catalog.Service.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto, CancellationToken cancellationToken)
        {
            await _categoryService.CreateAsync(dto, cancellationToken).ConfigureAwait(false);

            return Ok();
        }
    }
}
