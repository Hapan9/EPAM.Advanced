using AutoFixture.Xunit2;
using AutoMapper;
using Cart.Service.BLL.Dtos;
using Cart.Service.BLL.Services;
using Cart.Service.DAL.Entities;
using Cart.Service.DAL.Repositories.Interfaces;
using Moq;

namespace Cart.Service.Tests.UnitTests
{
    [Collection("UnitTests")]
    public sealed class CartServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductRepository> _productRepository;

        public CartServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _productRepository = new Mock<IProductRepository>();
        }

        [Theory, AutoData]
        public async Task GetAllProductsAsync_ShouldCallRepository(List<Product> products)
        {
            //Arrange
            _productRepository.Setup(r => r.GetProductsByCartIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(products.ToAsyncEnumerable());
            var service = new CartService(_productRepository.Object, _mapperMock.Object);

            //Act
            await service.GetAllProductsAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>());

            //Assert
            _mapperMock.Verify(m => m.Map<ProductDto>(It.IsAny<Product>()), times: Times.Exactly(products.Count()));
            _productRepository.Verify(m => m.GetProductsByCartIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), times: Times.Once);
        }

        [Theory, AutoData]
        public async Task AddProductAsync_ShouldCallRepository(Product product)
        {
            //Arrange
            _mapperMock.Setup(m => m.Map<Product>(It.IsAny<ProductDto>())).Returns(product);
            var service = new CartService(_productRepository.Object, _mapperMock.Object);

            //Act
            await service.AddProductAsync(It.IsAny<Guid>(), It.IsAny<ProductDto>(), It.IsAny<CancellationToken>());

            //Assert
            _mapperMock.Verify(m => m.Map<Product>(It.IsAny<ProductDto>()), times: Times.Once);
            _productRepository.Verify(m => m.AddProductToCartAsync(It.IsAny<Guid>(), It.Is<Product>(p => p == product), It.IsAny<CancellationToken>()), times: Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldCallRepository()
        {
            //Arrange
            var service = new CartService(_productRepository.Object, _mapperMock.Object);

            //Act
            await service.DeleteProductAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<CancellationToken>());

            //Assert
            _productRepository.Verify(m => m.RemoveProductFromCartAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), times: Times.Once);
        }
    }
}
