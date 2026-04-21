using Cart.Service.BLL.Dtos;
using Cart.Service.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var list = await _cartService.GetAllProductsAsync(id, cancellationToken).ConfigureAwait(false);

            return Ok(list);
        }

        [HttpPost("{id:guid}")]
        public async Task<IActionResult> Create([FromRoute] Guid id, [FromBody] ProductDto productDto, CancellationToken cancellationToken)
        {
            await _cartService.AddProductAsync(id, productDto, cancellationToken).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("{id:guid}/product/{prodctId:int}")]
        public async Task<IActionResult> Create([FromRoute] Guid id, [FromRoute] int prodctId, CancellationToken cancellationToken)
        {
            await _cartService.DeleteProductAsync(id, prodctId, cancellationToken).ConfigureAwait(false);

            return Ok();
        }
    }
}
