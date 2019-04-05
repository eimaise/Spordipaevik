using Core;
using Core.AppServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Teachers;

namespace WebApplication2.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ISecureTokenGenerator _secureTokenGenerator;
        private readonly Messages _messages;

        public TeacherController(ISecureTokenGenerator secureTokenGenerator,Messages messages)
        {
            _secureTokenGenerator = secureTokenGenerator;
            _messages = messages;
        }
        
        [HttpPost]
        public IActionResult AddTeacher(AddTeacherVm model)
        {
            _messages.Dispatch(new TeacherRegistrationCommand(_secureTokenGenerator.Generate(20), model.Email));
            return RedirectToAction("Teachers");
        }
        public IActionResult AddTeacher()
        {
            return View();
        }
        public IActionResult Teachers()
        {
            var teachers = _messages.Dispatch(new GetAppUserListQuery("Teacher"));
            return View(teachers);
        }
    }
}