using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using NUnit.Framework;
using WebApplication2.Mappers;
using WebApplication2.ViewModels.Students;

namespace Tests
{
    [TestFixture]
    public class StudentMapperTests
    {
        private StudentMapper _sut;
        private Mock<IUrlHelperFactory> _urlHelperFactory;
        private Mock<IActionContextAccessor> _actionContextAccessor;
        private Mock<IUrlHelper> _urlHlper;

        [SetUp]
        public void Setup()
        {
            _urlHelperFactory = new Mock<IUrlHelperFactory>();
            _actionContextAccessor = new Mock<IActionContextAccessor>();
            _urlHlper = new Mock<IUrlHelper>();

            _urlHelperFactory.Setup(x => x.GetUrlHelper(It.IsAny<ActionContext>())).Returns(
                _urlHlper.Object);
            _sut = new StudentMapper(_urlHelperFactory.Object,_actionContextAccessor.Object);
        }

        [Test]
        public void ToAdminAddEditStudentVm_Maps_Email()
        {
            var student = new Student
            {
                Email = "email"
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.Email,Is.EqualTo("email"));
        }
        
        [Test]
        public void ToAdminAddEditStudentVm_Return_Empty_AdminAddEditStudentVm_When_Student_IsNULL()
        {
         
            // Act
            var result = _sut.ToAdminAddEditStudentVm(null);
            
            // Assert
            Assert.That(result,Is.TypeOf<AdminAddEditStudenVm>());

            Assert.That(result.Email,Is.EqualTo(null));
        }
        
        [Test]
        public void ToAdminAddEditStudentVm_Maps_Name()
        {
            var student = new Student
            {
                Name = "Name"
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.Name,Is.EqualTo("Name"));
        }
        
        [Test]
        public void ToAdminAddEditStudentVm_Maps_Gender()
        {
            var student = new Student
            {
                Gender = Gender.Man
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.Gender,Is.EqualTo(Gender.Man));
        }
        
        [Test]
        public void ToAdminAddEditStudentVm_Maps_Gender_Woman()
        {
            var student = new Student
            {
                Gender = Gender.Woman
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.Gender,Is.EqualTo(Gender.Woman));
        }
        [Test]
        public void ToAdminAddEditStudentVm_Maps_Id()
        {
            var student = new Student
            {
                Id = 1
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.Id,Is.EqualTo(1));
        }
        [Test]
        public void ToAdminAddEditStudentVm_Maps_CardNr()
        {
            var student = new Student
            {
                StudentCardNumber = "StudentCardNumber"
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.StudentCardNumber,Is.EqualTo("StudentCardNumber"));
        }
        [Test]
        public void ToAdminAddEditStudentVm_Maps_ClassID()
        {
            var student = new Student
            {
                SchoolClassId = 2
            };
            // Act
            var result = _sut.ToAdminAddEditStudentVm(student);
            
            // Assert
            Assert.That(result.SchoolClassId,Is.EqualTo(2));
        }
        
        [Test]
        public void ToStudentsListVm_Maps_ActivationLink()
        {
            var student = new Student
            {
            };
            var students = new List<Student>
            {
                student
            };
            
            // Act
            var result = _sut.ToStudentsListVm(students);
            
            // Assert
            Assert.That(result.Students.FirstOrDefault().ActivationLink,Is.EqualTo(""));
        }
        [Test]
        public void ToStudentsListVm_Maps_InviteSent()
        {
            var student = new Student
            {
            };
            var students = new List<Student>
            {
                student
            };
            
            // Act
            var result = _sut.ToStudentsListVm(students);
            
            // Assert
            Assert.That(result.Students.FirstOrDefault().InviteSent,Is.EqualTo(false));
        }
        [Test]
        public void ToStudentsListVm_Maps_StudentCardNr()
        {
            var student = new Student
            {
                StudentCardNumber = "StudentCardNumber"
            };
            var students = new List<Student>
            {
                student
            };
            
            // Act
            var result = _sut.ToStudentsListVm(students);
            
            // Assert
            Assert.That(result.Students.FirstOrDefault().StudentCardNr,Is.EqualTo("StudentCardNumber"));
        }
        [Test]
        public void ToStudentsListVm_Maps_Email()
        {
            var student = new Student
            {
                Email = "Email"
            };
            var students = new List<Student>
            {
                student
            };
            
            // Act
            var result = _sut.ToStudentsListVm(students);
            
            // Assert
            Assert.That(result.Students.FirstOrDefault().Email,Is.EqualTo("Email"));
        }
        [Test]
        public void ToStudentsListVm_Maps_Name()
        {
            var student = new Student
            {
                Name = "Name"
            };
            var students = new List<Student>
            {
                student
            };
            
            // Act
            var result = _sut.ToStudentsListVm(students);
            
            // Assert
            Assert.That(result.Students.FirstOrDefault().Name,Is.EqualTo("Name"));
        }
    }
}