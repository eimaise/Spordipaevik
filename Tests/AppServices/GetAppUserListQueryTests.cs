using System.Collections.Generic;
using System.Linq;
using Core.AppServices;
using Core.AppServices.AppUsers;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests.AppServices
{
    [TestFixture]
    public class GetAppUserListQueryTests
    {
        private GetAppUserListQuery _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new GetAppUserListQuery();
            
        }
//
//        [Test]
//        public void METHOD()
//        {
//            var context = new PeSportsTrackingContext(new DbContextOptions<PeSportsTrackingContext>());
//            context.Students = new DbSet<Student>();
//            var getStudentQueryHandler = new GetStudentQuery.GetStudentQueryHandler();
//            var _sutt = getStudentQueryHandler;
//            // Act
//            _sut.
//            // Assert
//        }
    }
}