using System;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Data.Repositories;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Results;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Controllers
{
//    [Authorize(Roles = "Teacher")]
    public class ResultController : Controller
    {
        private readonly Messages _messages;
        private readonly PeSportsTrackingContext _context;

        public ResultController(Messages messages
        ,PeSportsTrackingContext context) 
        {
            _messages = messages;
            _context = context;
        }
        
        public IActionResult ExerciseList()
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery());
            var model = exercises.Select(x => new ExerciseVm
            {
                Id = x.Id,
                Name = x.Name,
                Comment = x.Comment
            });
            return View(model);
        }
        public IActionResult ClassList(int exerciseId)
        {
            //kontrolli kas exercise on olemas

            var classes = _messages.Dispatch(new GetClassListQuery());
            var resultVm = new ResultVm
            {
                ExerciseId = exerciseId,
                Classes = classes.Select(x => new ClassVm
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToList(),
            };
            return View(resultVm);
        }
        
        public IActionResult AddResult(int selectedExerciseId,int classId, int gender)
        {
            //kontrolli kas exercise on olemas
            var aclass = _messages.Dispatch(new GetClassQuery(classId));

            var exercise = _messages.Dispatch(new GetExerciseQuery(selectedExerciseId));
            var model = new ResultVm
            {
                ClassId = aclass.Id,
                ExerciseId = exercise.Id,
                ClassName = aclass.Name,
                ExerciseName = exercise.Name,
                IsTime = exercise.Unit.IsTime,
                Students = aclass.Students.Where(x=>x.Gender == (Gender)gender).Select(x=>new StudentVm
                {
                    Name = x.Name,
                    Id = x.Id,
                    Results = _context.Results.Where(s=>s.StudentId == x.Id && s.ExerciseId == exercise.Id && s.CreatedOn>DateTime.Today).Select(o=>o.Value.ToString()).ToList()
                }).ToList()
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult AddResult(AddResultVm model)
        {
            var aclass = _messages.Dispatch(new GetClassQuery(model.ClassId));
            var exercise = _messages.Dispatch(new GetExerciseQuery(model.SelectedExerciseId));
            var student = _messages.Dispatch(new GetStudentQuery(model.StudentId));

            var result = new Result(student, exercise.Id, new ResultValue(exercise.Unit.Name, model.Result));
            
            _context.Results.Add(result);
            _context.SaveChanges();
            
            return RedirectToAction("AddResult",new {selectedExerciseId = exercise.Id,classId = aclass.Id,gender = (int)student.Gender});
        }

    }
}