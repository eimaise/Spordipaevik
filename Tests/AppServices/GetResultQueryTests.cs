using System.Linq;
using Core.AppServices.Results;
using Core.AppServices.Students;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class GetResultQueryTests
    {
        [Test]
        public void Handle_Returns_Result()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>(o => o.UseInMemoryDatabase("test"),
                ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            var context = provider.GetService<PeSportsTrackingContext>();
            context.Results.Add(new Result {Id = 1, ExerciseId = 12});
            context.SaveChanges();
            var resultQueryHandler =
                new GetResultQuery.GetResultQueryHandler(provider.GetService<PeSportsTrackingContext>());
            var query = new GetResultQuery(1);

            // Act
            var result = resultQueryHandler.Handle(query);

            // Assert
            Assert.That(result.ExerciseId, Is.EqualTo(12));
        }

        [Test]
        public void handle_returns_Correct_Result()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>(o => o.UseInMemoryDatabase("test"),
                ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            var context = provider.GetService<PeSportsTrackingContext>();
            context.Results.Add(new Result {Id = 1, ExerciseId = 12});
            context.Results.Add(new Result {Id = 2, ExerciseId = 22});

            context.SaveChanges();
            var resultQueryHandler =
                new GetResultQuery.GetResultQueryHandler(provider.GetService<PeSportsTrackingContext>());
            var query = new GetResultQuery(2);

            // Act
            var result = resultQueryHandler.Handle(query);

            // Assert
            Assert.That(result.ExerciseId, Is.EqualTo(22));
        }
    }
}