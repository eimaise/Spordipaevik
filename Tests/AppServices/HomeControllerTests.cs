using System.Net;
using System.Threading.Tasks;
using Core.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public async Task HomeController()
        {
            var factory = new WebApplicationFactory<WebApplication2.Startup>();
            var hostServiceProvider = factory.Server.Host.Services;

            factory.WithWebHostBuilder(c => c.ConfigureServices(s =>
            {
                // teoreetiliselt saab siin service'eid ülekirjutada
                s.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"));
            }));
            
            using (var scope = hostServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PeSportsTrackingContext>();
            }

            var client = factory.CreateClient();
            
            // Act
            var response = await client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}