using System.Linq;
using Core.AppServices;
using Core.AppServices.Units;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class AddUnitCommandTests
    {
        [Test]
        public void AddUnitCommand_Adds_Unit()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var addUnitCommandHandler = new AddUnitCommand.AddUnitCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new AddUnitCommand
            {
                Name = "name"
            };

            // Act
            var result = addUnitCommandHandler.Handle(command);
            var unit = provider.GetService<PeSportsTrackingContext>().Units.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(unit.Name,Is.EqualTo("name"));
        }
    }
}