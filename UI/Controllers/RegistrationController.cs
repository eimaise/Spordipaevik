using System.Threading.Tasks;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Registrations;

namespace WebApplication2.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Messages _messages;

        public RegistrationController(PeSportsTrackingContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, Messages messages)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _messages = messages;
        }

        public IActionResult RegisterStudent(string token)
        {
            var model = new RegisterVm
            {
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterVm model)
        {
            if (ModelState.IsValid)
            {
                var invite = _messages.Dispatch(new GetInviteByTokenQuery(model.Token));

                if (invite == null || invite.Used)
                {
                    return Json("Midagi läks valesti, võta ühendust kooli administraatoriga või proovi uuesti");
                }


                var student = _messages.Dispatch(new GetStudentQuery(invite.StudentId));
                if (student == null)
                {
                    return Json("Sellist õpilast ei leitud");
                }

//                else
//                {
//                    userName = invite.Email;
//                    role = "Teacher";
//                }
                var user = new ApplicationUser
                {
                    UserName = invite.Student.StudentCardNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, Role.Student);

                if (result.Succeeded)
                {
                    _messages.Dispatch(new InviteUsedCommand(invite));
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View();
            }

            return View();
        }
    }
}