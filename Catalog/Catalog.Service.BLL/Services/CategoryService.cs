using AutoMapper;
using Catalog.Service.BLL.Dto;
using Catalog.Service.BLL.Services.Interfaces;
using Catalog.Service.DAL.Enteties;
using Catalog.Service.DAL.Repositories.Interfaces;

namespace Catalog.Service.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(c => c.Id == id, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetListAsync(_ => true, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task CreateAsync(CategoryDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.CreateAsync(category, cancellationToken).ConfigureAwait(false);

            await _categoryRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Guid id, CategoryDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(dto, opt =>
            {
                opt.AfterMap((_, c) => c.Id = id);
            });
            await _categoryRepository.UpdateAsync(category, cancellationToken).ConfigureAwait(false);

            await _categoryRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(c => c.Id == id, cancellationToken).ConfigureAwait(false);

            await _categoryRepository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
