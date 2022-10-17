using SmartRental.Operations.Commands;
using System.Net;
using System.Net.Http.Json;

namespace SmartRental.IntegrationTest
{
    [TestClass]
    public class CustomerEndpointTests
    {
        [TestMethod]
        public async Task Get_Customer_Returns_OK()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.GetAsync("/api/customer");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Customer_Returns_Created()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/customer", new CreateCustomer { GivenName = "Test", City = "Test", DateOfBirth = DateTime.Parse("01/01/2001"), PostalCode = "Test", Street = "Test", Surname = "Test" });

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Customer_Returns_BadRequest()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/customer", new CreateCustomer());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}