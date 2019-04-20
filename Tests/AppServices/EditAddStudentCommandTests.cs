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
    public class EditAddStudentCommandTests
    {
        [Test]
        public void EditAddStudentCommand_Adds_Student()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var editAddStudentCommandHandler = new EditAddStudentCommand.EditAddStudentCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new EditAddStudentCommand();
            command.Name = "name";

            // Act
            var result = editAddStudentCommandHandler.Handle(command);
            var student = provider.GetService<PeSportsTrackingContext>().Students.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(student.Name,Is.EqualTo("name"));
        }
        [Test]
        public void EditAddStudentCommand_Adds_Student_With_stc()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var editAddStudentCommandHandler = new EditAddStudentCommand.EditAddStudentCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new EditAddStudentCommand();
            command.StudentCardNumber = "card";

            // Act
            var result = editAddStudentCommandHandler.Handle(command);
            var student = provider.GetService<PeSportsTrackingContext>().Students.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(student.StudentCardNumber,Is.EqualTo("card"));
        }
        [Test]
        public void EditAddStudentCommand_Adds_Student_with_Email()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var editAddStudentCommandHandler = new EditAddStudentCommand.EditAddStudentCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new EditAddStudentCommand();
            command.Email = "email";

            // Act
            var result = editAddStudentCommandHandler.Handle(command);
            var student = provider.GetService<PeSportsTrackingContext>().Students.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(student.Email,Is.EqualTo("email"));
        }
        [Test]
        public void EditAddStudentCommand_Adds_Student_with_SchoolclassID()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var editAddStudentCommandHandler = new EditAddStudentCommand.EditAddStudentCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new EditAddStudentCommand();
            command.SchoolClassId = 1;

            // Act
            var result = editAddStudentCommandHandler.Handle(command);
            var student = provider.GetService<PeSportsTrackingContext>().Students.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(student.SchoolClassId,Is.EqualTo(1));
        }
        [Test]
        public void EditAddStudentCommand_Adds_Student_with_gemder()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PeSportsTrackingContext>( o => o.UseInMemoryDatabase("test"), ServiceLifetime.Transient);
            var provider = serviceCollection.BuildServiceProvider();
            
            var editAddStudentCommandHandler = new EditAddStudentCommand.EditAddStudentCommandHandler(provider.GetService<PeSportsTrackingContext>());
            var command = new EditAddStudentCommand();
            command.Gender = Gender.Woman;

            // Act
            var result = editAddStudentCommandHandler.Handle(command);
            var student = provider.GetService<PeSportsTrackingContext>().Students.FirstOrDefault();
            
            // Assert
            Assert.That(result.IsSuccess,Is.True);
            Assert.That(student.Gender,Is.EqualTo(Gender.Woman));
        }
      
    }
}