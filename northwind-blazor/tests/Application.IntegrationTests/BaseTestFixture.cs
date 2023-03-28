using static Testing;

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