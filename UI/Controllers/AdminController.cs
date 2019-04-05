using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly ISecureTokenGenerator _secureTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Messages _messages;
        private readonly IUrlHelper _urlHelper;

        public AdminController(PeSportsTrackingContext context, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor,
            ISecureTokenGenerator secureTokenGenerator, UserManager<ApplicationUser> userManager,
            Messages messages)
        {
            _context = context;
            _secureTokenGenerator = secureTokenGenerator;
            _userManager = userManager;
            _messages = messages;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);

        }

        public IActionResult Index(NotRegisteredStudentsListVm model)
        {
            if (model == null)
            {
                
                model = new NotRegisteredStudentsListVm();                
            }
            
            return View(model);
        }
        
        public IActionResult NotRegisteredStudents()
        {
            var notRegisteredStudents = _messages.Dispatch(new GetStudentListQuery(false));
            var model = new NotRegisteredStudentsListVm();
            
            foreach (var student in notRegisteredStudents)
            {
                var token = _context.Invites.FirstOrDefault(x => x.StudentId == student.Id)?.Token;
                var link ="";
                if (token != null)
                {
                    link = _urlHelper.Action("RegisterStudent", "Registration", new {token});
                }
               
            model.NotRegisteredStudents.Add(new NotRegisteredStudentVm
            {
                InviteSent = student.InviteSent,
                StudentCardNr = student.StudentCardNumber,
                Id = student.Id,
                Email = string.IsNullOrWhiteSpace(student.Email) ? student.Email : "Email on puudu",
                RegisteredInSystem = student.RegisteredInSystem,
                ActivationLink = link
            });
            }
            return View("Index",model);
        }
        
       [HttpPost] 
        public IActionResult SendRegistrationInvite(int studentId)
        {
            var student = _context.Students.Find(studentId);
            var notRegisteredStudents = _messages.Dispatch(new GetStudentListQuery(false));

            student.InviteSent = true;
            var studentInviteCommand = new StudentInviteCommand(_secureTokenGenerator.Generate(20),student.Id);
            _messages.Dispatch(studentInviteCommand);
           
            TempData["message"] = "Reminder successfully sent";
            
            
            return RedirectToAction("FindStudent","Admin",new{name = student.Name});
        }
        public IActionResult FindStudent(string name)
        {
          
            var students = _messages.Dispatch(new GetStudentListQuery(name:name));

            var model = new NotRegisteredStudentsListVm();
            
            foreach (var student in students)
            {
                var token = student.Invite?.Token;
                var link ="";
                if (token != null)
                {
                    link =  _urlHelper.Action("RegisterStudent", "Registration", new {token});
                }
              
                model.NotRegisteredStudents.Add(new NotRegisteredStudentVm
                {
                    InviteSent = student.InviteSent,
                    StudentCardNr = student.StudentCardNumber,
                    Id = student.Id,
                    Email = student.Email,
                    RegisteredInSystem = student.RegisteredInSystem,
                    ActivationLink = link
                });
            }
            return View("Index",model);

        }
    }

    public class NotRegisteredStudentsListVm
    {
        public List<NotRegisteredStudentVm> NotRegisteredStudents { get; set; } = new List<NotRegisteredStudentVm>();
    }
    public class NotRegisteredStudentVm
    {
        public int Id { get; set; }
        public string StudentCardNr { get; set; }
        public bool InviteSent { get; set; }
        public string Email { get; set; }
        public bool RegisteredInSystem { get; set; }
        public string ActivationLink { get; set; }
    }
}