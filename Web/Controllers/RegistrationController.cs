using System.Threading.Tasks;
using Core;
using Core.AppServices;
using Core.AppServices.Invite;
using Core.AppServices.Registrations;
using Core.AppServices.Students;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Registrations;

namespace WebApplication2.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Messages _messages;

        public RegistrationController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, Messages messages)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messages = messages;
        }

        public async Task<IActionResult> RegisterStudent(string token)
        {
            await _signInManager.SignOutAsync();
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

                if (student.StudentCardNumber != model.StudentCardNr)
                {
                    ModelState.AddModelError("","Õpilaspileti number ei ole õige");
                    return View(model);

                }
                var user = new ApplicationUser
                {
                    UserName = student.StudentCardNumber.Replace(" ","")
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, Role.Student);

                if (result.Succeeded)
                {
                    _messages.Dispatch(new UserRegisteredCommand(student));
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

                return View(model);
            }

            return View(model);
        }
    }
}