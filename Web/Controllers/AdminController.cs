using System.Linq;
using Core;
using Core.AppServices;
using Core.AppServices.Classes;
using Core.AppServices.Classss;
using Core.AppServices.Students;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApplication2.Mappers;
using WebApplication2.ViewModels.SchoolClasses;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ISecureTokenGenerator _secureTokenGenerator;
        private readonly Messages _messages;
        private readonly IStudentMapper _studentMapper;
        private readonly IUrlHelper _urlHelper;

        public AdminController(IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            ISecureTokenGenerator secureTokenGenerator,
            Messages messages, IStudentMapper studentMapper)
        {
            _secureTokenGenerator = secureTokenGenerator;
            _messages = messages;
            _studentMapper = studentMapper;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
s
        public IActionResult Index(AdminStudentsListVm model)
        {
            if (model == null)
            {
                model = new AdminStudentsListVm();
            }

            return View(model);
        }
        public IActionResult AddClass()
        {
            return View();
        }
        public IActionResult SchoolClasses()
        {
            var schoolClasses = _messages.Dispatch(new GetClassListQuery());
           var model =  schoolClasses.Select(x => new SchoolClassVm
            {
                Name = x.Name
            });
            return View(model);
        }
        [HttpPost]
        public IActionResult AddClass(AddSchoolClassVm model)
        {
            if (!ModelState.IsValid)
            {
              return View();
            }

            _messages.Dispatch(command: new AddClassCommand(model.Name));
            TempData["message"] = "Klass edukalt lisatud";
            return RedirectToAction("AddClass");
        }

        public IActionResult NotRegisteredStudents()
        {
            var notRegisteredStudents = _messages.Dispatch(new GetStudentListQuery(false));
            var model = _studentMapper.ToStudentsListVm(notRegisteredStudents);

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SendRegistrationInvite(int studentId)
        {
            var student = _messages.Dispatch(new GetStudentQuery(studentId));
            if (student == null)
            {
                return new NotFoundResult();
            }

            var studentInviteCommand = new StudentInviteCommand(_secureTokenGenerator.Generate(20), student);
            _messages.Dispatch(studentInviteCommand);
            TempData["message"] = "Kutse edukalt saadetud";

            return RedirectToAction("FindStudent", "Admin", new {name = student.Name});
        }

        public IActionResult FindStudent(string name)
        {
            var students = _messages.Dispatch(new GetStudentListQuery(name: name));

            var model = _studentMapper.ToStudentsListVm(students);
            return View("Index", model);
        }

        public IActionResult AdminSettings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeClassNumbers()
        {
            _messages.Dispatch(new ChangeClassNumberCommand());
            TempData["successmessage"] = "Perioodi uuendamine õnnestus";
            return RedirectToAction("AdminSettings");
        }
    }
}