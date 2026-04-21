using AutoMapper;
using Cart.Service.BLL.Dtos;
using Cart.Service.BLL.Services.Interfaces;
using Cart.Service.DAL.Entities;
using Cart.Service.DAL.Repositories.Interfaces;

namespace Cart.Service.BLL.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(Guid cartId, CancellationToken cancellationToken)
        {
            var list = new List<ProductDto>();
            await foreach (var product in _productRepository.GetProductsByCartIdAsync(cartId, cancellationToken))
            {
                list.Add(_mapper.Map<ProductDto>(product));
            }
            return list;
        }

        public async Task AddProductAsync(Guid cartId, ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddProductToCartAsync(cartId, product, cancellationToken);
        }

        public async Task DeleteProductAsync(Guid cartId, int productId, CancellationToken cancellationToken)
        {
            await _productRepository.RemoveProductFromCartAsync(cartId, productId, cancellationToken);
        }
    }
}
