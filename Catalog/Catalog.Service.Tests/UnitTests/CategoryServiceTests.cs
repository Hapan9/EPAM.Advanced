using AutoMapper;
using Catalog.Service.BLL.Dto;
using Catalog.Service.BLL.Services;
using Catalog.Service.DAL.Enteties;
using Catalog.Service.DAL.Repositories.Interfaces;
using Moq;

namespace Catalog.Service.Tests.UnitTests
{
    [Collection("UnitTests")]
    public sealed class CategoryServiceTests
    {
        Mock<ICategoryRepository> _categoryRepositoryMock;
        Mock<IMapper> _mapperMock;

        public CategoryServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
        }

        [Fact]
        public async Task CreateAsync_ShouldCallRepository()
        {
            //Arrange
            var service = new CategoryService(_categoryRepositoryMock.Object, _mapperMock.Object);

            //Act
            await service.CreateAsync(It.IsAny<CategoryDto>(), It.IsAny<CancellationToken>());

            //Assert
            _categoryRepositoryMock.Verify(m => m.CreateAsync(It.IsAny<Category>(), It.IsAny<CancellationToken>()), Times.Once);
            _mapperMock.Verify(m => m.Map<Category>(It.IsAny<CategoryDto>()), Times.Once);
        }
    }
}
