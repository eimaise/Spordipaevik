using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Students;

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
        public IActionResult MyInfo()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return new UnauthorizedResult();
            }
            
            return View();
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
        
        public IActionResult StudentResult(int id)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(id));
            var user = _userManager.GetUserAsync(User).Result;
//            var student = _messages.Dispatch(new GetStudentWithStudentCardNoQuery(user.UserName));
            var student = _messages.Dispatch(new GetStudentQuery(10));

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
            return View();
        }
    }

    public class UserInfoVm
    {
    
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}