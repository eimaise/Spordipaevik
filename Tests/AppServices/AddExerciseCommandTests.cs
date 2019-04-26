using System.Linq;
using Core.AppServices;
using Core.AppServices.Excercise;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class AddExerciseCommandTests
    {
        [Test]
        public void AddExerciseCommand_Adds_Exercise()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>(
                o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var addUnitCommandHandler = new AddExerciseCommand.AddExerciseCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new AddExerciseCommand(2,"name","comment");

            // Act
            var result = addUnitCommandHandler.Handle(command);
            var exercise = provider.GetService<PeSportsTrackingContext>().Exercises.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(exercise.Name,Is.EqualTo("name"));
            Assert.That(exercise.Comment,Is.EqualTo("comment"));
        }
    }
}