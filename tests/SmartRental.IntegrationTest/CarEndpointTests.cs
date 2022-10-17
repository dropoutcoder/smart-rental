using SmartRental.Operations.Commands;
using System.Net;
using System.Net.Http.Json;

namespace SmartRental.IntegrationTest
{
    [TestClass]
    public class CarEndpointTests
    {
        [TestMethod]
        public async Task Get_Car_Returns_OK()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.GetAsync("/api/car");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Car_Returns_Created()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/car", new CreateCar { Name = "Test", RegistrationNumber = "Test" });

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Car_Returns_Conflict()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/car", new CreateCar { Name = "Test", RegistrationNumber = "SKODA1" });

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
        }


        [TestMethod]
        public async Task Post_Car_Returns_BadRequest()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/car", new CreateCar());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}