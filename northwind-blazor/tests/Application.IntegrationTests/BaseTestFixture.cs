using static northwind_blazor.Application.SubcutaneousTests.Testing;

namespace northwind_blazor.Application.SubcutaneousTests
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
