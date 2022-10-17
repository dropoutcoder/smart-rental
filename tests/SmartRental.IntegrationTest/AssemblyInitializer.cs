using Microsoft.AspNetCore.Mvc.Testing;

namespace SmartRental.IntegrationTest
{
    [TestClass]
    internal class AssemblyInitializer
    {
        public static WebApplicationFactory<Program> WebApplicationFactory { get; private set; }

        [AssemblyInitialize]
        public static void Initialize(TestContext textContext)
        {
            WebApplicationFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    // remove or replace services
                });
        }
    }
}
