using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Operations.Commands;
using System.Net;
using System.Net.Http.Json;

namespace SmartRental.IntegrationTest
{
    [TestClass]
    public class RentalEndpointTests
    {
        [TestMethod]
        public async Task Get_Rental_Returns_OK()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.GetAsync("/api/rental");

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Rental_Returns_Created()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/rental", new CreateRental { CarId = 1, CustomerId = 1, LicenceNumber = "124362287", PersonalDocumentNumber = 12398636, PersonalDocumentType = PersonalIdentification.IdentificationType.NationalId, PickupDateTime = DateTime.Now, Price = 10, ReturnDateTime = DateTime.Now.AddDays(2) });

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Rental_Returns_Conflict()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/rental", new CreateRental { CarId = 1, CustomerId = 1, LicenceNumber = "124362287", PersonalDocumentNumber = 12398636, PersonalDocumentType = PersonalIdentification.IdentificationType.NationalId, PickupDateTime = DateTime.Now, Price = 10, ReturnDateTime = DateTime.Now.AddDays(1) });

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
        }

        [TestMethod]
        public async Task Post_Rental_Returns_BadRequest()
        {
            var client = AssemblyInitializer
                .WebApplicationFactory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/rental", new CreateRental());

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}