using Catalog.Service.Tests.IntegrationTests.Utils;

namespace Catalog.Service.Tests.IntegrationTests.Abstraction
{
    public abstract class IntegrationTest
    {
        protected readonly BaseTestFixture App;

        protected IntegrationTest()
        {
            App = new BaseTestFixture();
        }
    }
}
