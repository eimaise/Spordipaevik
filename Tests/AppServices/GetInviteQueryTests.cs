using Core.AppServices.Invites;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class GetInviteQueryTests
    {
        [Test]
        public void Handle_Returns_Result()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>(o => o.UseInMemoryDatabase("test"),
                ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            var context = provider.GetService<PeSportsTrackingContext>();
            context.Invites.Add(new Invite (12,"token",false,"tes@test.ee"){Id = 1});
            context.SaveChanges();
            var handler =
                new GetInviteQuery.GetInviteQueryHandler(provider.GetService<PeSportsTrackingContext>());
            var query = new GetInviteQuery(1);

            // Act
            var result = handler.Handle(query);

            // Assert
            Assert.That(result.StudentId, Is.EqualTo(12));
        }

        [Test]
        public void Handle_Returns_Result_CorrectResult()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>(o => o.UseInMemoryDatabase("test"),
                ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            var context = provider.GetService<PeSportsTrackingContext>();
            context.Invites.Add(new Invite (12,"token",false,"tes@test.ee"){Id = 1});
            context.Invites.Add(new Invite (99,"token",false,"tes@test.ee"){Id = 12});

            context.SaveChanges();
            var handler =
                new GetInviteQuery.GetInviteQueryHandler(provider.GetService<PeSportsTrackingContext>());
            var query = new GetInviteQuery(12);

            // Act
            var result = handler.Handle(query);

            // Assert
            Assert.That(result.StudentId, Is.EqualTo(99));
        }
    }
}