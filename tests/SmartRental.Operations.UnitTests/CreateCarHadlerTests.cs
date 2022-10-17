using Microsoft.EntityFrameworkCore;
using Moq;
using SmartRental.Infrastructure.Database;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Operations.Commands;
using SmartRental.Operations.Internal.Handlers;

namespace SmartRental.Operations.UnitTests
{
    [TestClass]
    public class CreateCarHadlerTests
    {
        private static Mock<ICarStore> _carStore = new Mock<ICarStore>();

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            switch(TestContext.TestName)
            {
                case nameof(ValidCommand_Returns_Entity):
                    {
                        _carStore
                            .Setup(cs => cs.AddCarAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(Results.ValidResult);
                        break;
                    }
                case nameof(DuplicateRegistrationNumberCommand_Throws_OperationException):
                    {
                        _carStore
                            .Setup(cs => cs.RegistrationNumberExistsAsync(It.IsAny<string>()))
                            .ReturnsAsync(true);
                        break;
                    }
                case nameof(StoreException_EncapsulatedWith_OperationException):
                    {
                        _carStore
                            .Setup(cs => cs.AddCarAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .ThrowsAsync(new StoreException("Testing store exception!", new DbUpdateException()));
                        break;
                    }
                default:
                    throw new InvalidOperationException($"Mock is not setup for {TestContext.TestName} test.");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _carStore.Reset();
        }

        [TestMethod]
        public async Task ValidCommand_Returns_Entity()
        {
            var handler = new CreateCarHadler(_carStore.Object);

            var result = await handler.ExecuteAsync(Values.ValidCommand);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICar));
            Assert.AreEqual(Results.ValidResult, result);
        }

        [TestMethod]
        public async Task DuplicateRegistrationNumberCommand_Throws_OperationException()
        {
            var handler = new CreateCarHadler(_carStore.Object);

            Func<Task> action = async () => await handler.ExecuteAsync(Values.DuplicateRegistrationNumberCommand);

            await Assert.ThrowsExceptionAsync<OperationException>(action, "We couldn't process your request!");
        }


        [TestMethod]
        public async Task StoreException_EncapsulatedWith_OperationException()
        {
            var handler = new CreateCarHadler(_carStore.Object);

            Func<Task> action = async () => await handler.ExecuteAsync(Values.DuplicateRegistrationNumberCommand);

            await Assert.ThrowsExceptionAsync<OperationException>(action, "We have encountered issue while trying to save car to the database.");
        }

        private class Values
        {
            public static CreateCar ValidCommand = new CreateCar { Name = "Test", RegistrationNumber = "Test" };
            public static CreateCar DuplicateRegistrationNumberCommand = new CreateCar { Name = "Test", RegistrationNumber = "SKODA1" };
        }

        private class Results
        {
            public static ICar ValidResult = new CarEntity { Id = 1, Name = Values.ValidCommand.Name, RegistrationNumber = Values.ValidCommand.RegistrationNumber };
            public static ICar DuplicateRegistrationNumberResult = new CarEntity { Id = 1, Name = Values.DuplicateRegistrationNumberCommand.Name, RegistrationNumber = Values.DuplicateRegistrationNumberCommand.RegistrationNumber };
        }
    }
}