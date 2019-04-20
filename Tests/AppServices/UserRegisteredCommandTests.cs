using System.Linq;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class TeacherRegistrationCommandTests
    {
        [Test]
        public void AddUnitCommand_Adds_Unit()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var addUnitCommandHandler = new TeacherRegistrationCommand.TeacherRegistrationCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new TeacherRegistrationCommand("token","email");

            // Act
            var result = addUnitCommandHandler.Handle(command);
             var registration = provider.GetService<PeSportsTrackingContext>().Registrations.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(registration.Token,Is.EqualTo("token"));
            Assert.That(registration.Email,Is.EqualTo("email"));
        }
    }
}