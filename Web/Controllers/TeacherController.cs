using System.Linq;
using Core;
using Core.AppServices;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Mappers;
using WebApplication2.ViewModels.Teachers;

namespace WebApplication2.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ISecureTokenGenerator _secureTokenGenerator;
        private readonly Messages _messages;
        private readonly ITeacherMapper _teacherMapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherController(ISecureTokenGenerator secureTokenGenerator,
            Messages messages,
            ITeacherMapper teacherMapper,
            UserManager<ApplicationUser> userManager)
        {
            _secureTokenGenerator = secureTokenGenerator;
            _messages = messages;
            _teacherMapper = teacherMapper;
            _userManager = userManager;
        }
        
        [HttpPost]
        public IActionResult AddTeacher(AddTeacherVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
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
            var model = _teacherMapper.ToStudentsListVm(teachers);
            return View(model);
        }
    }
}