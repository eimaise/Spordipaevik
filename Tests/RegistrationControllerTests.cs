using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.AppServices;
using Core.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using WebApplication2;
using WebApplication2.Controllers;
using WebApplication2.Mappers;
using WebApplication2.ViewModels.Registrations;
using WebApplication2.ViewModels.Students;

namespace Tests
{
    [TestFixture]
    public class RegistrationControllerTests
    {
        private RegistrationController _sut;
        private Mock<UserManager<ApplicationUser>> _userManager;
        private Mock<Messages> _messages;
        private TempDataDictionary _tempData;

        [SetUp]
        public void Setup()
        {
            _messages = new Mock<Messages>();
            _userManager = MockUserManager(_users);
            var httpContext = new DefaultHttpContext();
            _tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            _sut = new RegistrationController(_userManager.Object, null,
                _messages.Object)
            {
                TempData = _tempData
            };
        }

        [Test]
        public void RegisterStudent_returns_ViewResult_WithModel()
        {
            // Act
            var result = (ViewResult) _sut.RegisterStudent("123");
            var resultModel = (RegisterVm) result.Model;

            // Assert
            Assert.That(result.Model, Is.TypeOf<RegisterVm>());
            Assert.That(resultModel.Token, Is.EqualTo("123"));
        }


        [Test]
        public async Task RegisterStudent_returns_ViewResult_WithModel_When_ModelState_is_Not_Valid()
        {
            var model = new RegisterVm();
            _sut.ModelState.AddModelError("eror","error");

            // Act
            var result = await  _sut.RegisterStudent(model);
            var view = (ViewResult) result;
            var resultModel = (RegisterVm) view.Model;

            // Assert
            Assert.That(resultModel, Is.TypeOf<RegisterVm>());
        }

        [Test]
        public async Task RegisterStudent_returns_jsonResult_When_Invite_Is_Null()
        {
            var model = new RegisterVm();

            // Act
            var actionResult = await  _sut.RegisterStudent(model);
            var result = (JsonResult) actionResult;

            // Assert
            Assert.That(result.Value, Is.EqualTo("Midagi läks valesti, võta ühendust kooli administraatoriga või proovi uuesti"));
        }

        [Test]
        public async Task RegisterStudent_returns_jsonResult_When_Invite_Is_Used()
        {
            var model = new RegisterVm();
            _messages.Setup(x => x.Dispatch(It.IsAny<GetInviteByTokenQuery>()))
                .Returns(new Invite(123, "token", true, "test@test.ee"));

            // Act
            var actionResult = await  _sut.RegisterStudent(model);
            var result = (JsonResult) actionResult;

            // Assert
            Assert.That(result.Value, Is.EqualTo("Midagi läks valesti, võta ühendust kooli administraatoriga või proovi uuesti"));
        }

        [Test]
        public async Task RegisterStudent_returns_jsonResult_When_student_is_not_found()
        {
            var model = new RegisterVm
            {
                StudentCardNr = "studentcrnr"
            };
            _messages.Setup(x => x.Dispatch(It.IsAny<GetInviteByTokenQuery>()))
                .Returns(new Invite(123, "token", false, "test@test.ee"));

            _messages.Setup(x => x.Dispatch(It.IsAny<GetStudentQuery>()))
                .Returns((Student)null);
            // Act
            var actionResult = await  _sut.RegisterStudent(model);
            var result = (JsonResult) actionResult;

            // Assert
            Assert.That(result.Value, Is.EqualTo("Sellist õpilast ei leitud"));
        }

        [Test]
        public async Task RegisterStudent_returns_jsonResult_When_student_studentCard_nr_Dot_Not_Match_model_Student_CardNr()
        {
            var model = new RegisterVm
            {
                StudentCardNr = "studentcrnr"
            };
            _messages.Setup(x => x.Dispatch(It.IsAny<GetInviteByTokenQuery>()))
                .Returns(new Invite(123, "token", false, "test@test.ee"));

            _messages.Setup(x => x.Dispatch(It.IsAny<GetStudentQuery>()))
                .Returns(new Student());
            // Act
            var actionResult = await  _sut.RegisterStudent(model);
            var result = (JsonResult) actionResult;

            // Assert
            Assert.That(result.Value, Is.EqualTo("Vale õpilaspileti number"));
        }

        [Test]
        public async Task RegisterStudent_returns_ViewResultWithModel()
        {
            var model = new RegisterVm
            {
                StudentCardNr = "studentcrnr",
                Password = "Password123"
            };
            _messages.Setup(x => x.Dispatch(It.IsAny<GetInviteByTokenQuery>()))
                .Returns(new Invite(123, "token", false, "test@test.ee"));

            _messages.Setup(x => x.Dispatch(It.IsAny<GetStudentQuery>()))
                .Returns(new Student{StudentCardNumber = "studentcrnr"});

            _userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), "Password123"))
                .Returns(Task.FromResult(new IdentityResult()));

            // Act
            var actionResult = await  _sut.RegisterStudent(model);
            var view = (ViewResult) actionResult;
            var resultModel = (RegisterVm) view.Model;

            // Assert
            Assert.That(resultModel, Is.TypeOf<RegisterVm>());
        }

        private List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser() {Name = "name1"},
            new ApplicationUser() {Name = "name2"},
        };



        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success)
                .Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }
    }
}