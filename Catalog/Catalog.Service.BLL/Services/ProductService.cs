using AutoMapper;
using Catalog.Service.BLL.Dto;
using Catalog.Service.BLL.Services.Interfaces;
using Catalog.Service.DAL.Entities;
using Catalog.Service.DAL.Repositories.Interfaces;

namespace Catalog.Service.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _productRepository.GetAsync(c => c.Id == id, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<ProductDto>(category);
        }

        public async Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await _productRepository.GetListAsync(_ => true, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<List<ProductDto>>(categories);
        }

        public async Task CreateAsync(ProductDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Product>(dto);
            await _productRepository.CreateAsync(category, cancellationToken).ConfigureAwait(false);

            await _productRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Guid id, ProductDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Product>(dto, opt =>
            {
                opt.AfterMap((_, c) => c.Id = id);
            });
            await _productRepository.UpdateAsync(category, cancellationToken).ConfigureAwait(false);

            await _productRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(c => c.Id == id, cancellationToken).ConfigureAwait(false);

            await _productRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
