using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Core.AppServices;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Students;
using WebApplication2.ViewModels.User;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Messages _messages;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            Messages messages)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messages = messages;
        }
        public async Task<IActionResult> MyInfo()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return new UnauthorizedResult();
            }
            var user = await _userManager.GetUserAsync(User);
            var isStudent = await _userManager.IsInRoleAsync(user, Role.Student);
            var model = new UserInfoVm
            {
                IsStudent = isStudent,
                IsResultsHidden = user.HideResults
            };
            return View(model);
        }
        public IActionResult ExerciseList()
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery());
            var modelexer = exercises.Select(x => new ExerciseVm
            {
                Id = x.Id,
                Name = x.Name,
                Comment = x.Comment
            }).ToList();
            return View(modelexer);
        }
        
        public async Task<IActionResult> StudentResult(int id)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(id));
            var user = await _userManager.GetUserAsync(User);
            var student = _messages.Dispatch(new GetStudentByStudentCardNrQuery(user.UserName));

            if (student == null)
            {
                return NotFound();
            }
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(new[]{student.Id}.ToList(),exercise.Id));

            var model = new StudentExerciseVm
            {
                ExerciseName = exercise.Name,
                ExerciseId = exercise.Id,
                StudentId = student.Id
            };
            foreach (var result in results)
            {
                if (!model.StudentResults.Any(x => x.Date == result.CreatedOn.Date))
                {
                    model.StudentResults.Add(new StudentResultVm
                    {
                        Value = result.ResultValue.Value,
                        Date = result.CreatedOn.Date,
                        ClassName = result.Student.SchoolClass.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult MyInfo(UserInfoVm model)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return new UnauthorizedResult();
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Paroolid ei ole samad ");
                return View(model);
            }
            var user =  _userManager.GetUserAsync(User).Result;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,model.Password);
            var result =  _userManager.UpdateAsync(user).Result;
            if (!result.Succeeded)
            {
               throw new InvalidOperationException();
            }
            return RedirectToAction("MyInfo");
        }

        [HttpPost]
        public async Task<IActionResult>  ChangeResultStatus(UserInfoVm model)
        {
            var user = await _userManager.GetUserAsync(User);
            _messages.Dispatch(new EditAppUserCommand(!user.HideResults, user));
            var editstudentCommand = new EditAddStudentCommand();
            editstudentCommand.ShouldResultsBeHidden = !user.HideResults;
            _messages.Dispatch(editstudentCommand);
            return RedirectToAction("MyInfo");
        }
    }

 
}