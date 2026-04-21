using AutoFixture.Xunit2;
using Catalog.Service.BLL.Dto;
using Catalog.Service.Tests.IntegrationTests.Abstraction;
using Newtonsoft.Json;
using System.Text;

namespace Catalog.Service.Tests.IntegrationTests
{
    [Collection("IntegrationTests")]
    public sealed class CategoryTests : IntegrationTest
    {
        [Theory, AutoData]
        public async Task Test1(CategoryDto dto)
        {
            //Arrange
            var message = new StringContent(JsonConvert.SerializeObject(dto), encoding: Encoding.UTF8, "application/json");

            //Act
            using var responseMessage = await App.Client.PostAsync($"api/Categories", message);

            //Assert
            responseMessage.EnsureSuccessStatusCode();
            Assert.Contains(App.Context.Categories, c => c.Name == dto.Name);
        }
    }
}
