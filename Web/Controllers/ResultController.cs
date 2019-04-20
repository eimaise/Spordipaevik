using System;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Results;
using WebApplication2.ViewModels.Students;
using Result = Core.Data.Entities.Result;

namespace WebApplication2.Controllers
{
//    [Authorize(Roles = "Teacher")]
    public class ResultController : Controller
    {
        private readonly Messages _messages;
        private readonly PeSportsTrackingContext _context;
        private readonly IResultService _resultService;
        private readonly IChartDataService _chartDataService;

        public ResultController(Messages messages
            , PeSportsTrackingContext context,
            IResultService resultService,
            IChartDataService chartDataService)
        {
            _messages = messages;
            _context = context;
            _resultService = resultService;
            _chartDataService = chartDataService;
        }

        public IActionResult ExerciseList(string name)
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery(name));
            if (exercises == null)
            {
                return new NotFoundResult();
            }

            var classes = _messages.Dispatch(new GetClassListQuery());
            if (classes == null)
            {
                return new NotFoundResult();
            }

            var model = new ExerciseListVm();
            var classesvm = classes.Select(x => new ClassVm
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            model.Classes = classesvm.OrderBy(x=>Helpers.GetClassNumberFromClassName(x.Name)).ToList();

            var modelexer = exercises.Select(x => new ExerciseVm
            {
                Id = x.Id,
                Name = x.Name,
                Comment = x.Comment
            }).ToList();
            model.Exercises = modelexer;
            return View(model);
        }

        public IActionResult AddResult(int selectedExerciseId, int selectedClassId, int gender)
        {
            var aclass = _messages.Dispatch(new GetClassQuery(selectedClassId));
            if (aclass == null)
            {
                return new NotFoundResult();
            }

            var exercise = _messages.Dispatch(new GetExerciseQuery(selectedExerciseId));
            if (exercise == null)
            {
                return new NotFoundResult();
            }

            var model = new ResultVm
            {
                ClassId = aclass.Id,
                ExerciseId = exercise.Id,
                ClassName = aclass.Name,
                ExerciseName = exercise.Name,
                IsTime = exercise.Unit.IsTime,
                Students = aclass.Students.Where(x => x.Gender == (Gender) gender).Select(x => new StudentVm
                {
                    Name = x.Name,
                    Id = x.Id,
                    Results = x.Results.Where(r => r.IsTodaysResult && r.ExerciseId == exercise.Id)
                        .Select(o => new StudentVm.ResultVm
                        {
                            Id = o.Id,
                            ResultValue = o.ResultValue.Value.ToString()
                        }).ToList(),
                    BestResult = x.Results.Where(r => r.ExerciseId == exercise.Id && !r.IsTodaysResult)
                        .OrderByDescending(r => r.ResultValue.Value).Select(r => r.ResultValue.Value.ToString())
                        .FirstOrDefault()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddResult(AddResultVm model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var aclass = _messages.Dispatch(new GetClassQuery(model.ClassId));
            if (aclass == null)
            {
                return new NotFoundResult();
            }

            var exercise = _messages.Dispatch(new GetExerciseQuery(model.SelectedExerciseId));
            if (exercise == null)
            {
                return new NotFoundResult();
            }

            var student = _messages.Dispatch(new GetStudentQuery(model.StudentId));
            if (student == null)
            {
                return new NotFoundResult();
            }

            var result = new Result(student, exercise.Id, new ResultValue(exercise.Unit.Name, model.Result),
                DateTime.Now);

            _context.Results.Add(result);
            _context.SaveChanges();

            return RedirectToAction("AddResult",
                new {selectedExerciseId = exercise.Id, selectedClassId = aclass.Id, gender = (int) student.Gender});
        }

        public IActionResult EditResult(int resultId)
        {
            var result = _messages.Dispatch(new GetResultQuery(resultId));
            if (result == null)
            {
                return new NotFoundResult();
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult EditResult(int resultId, decimal resultValue)
        {
            var result = _messages.Dispatch(new GetResultQuery(resultId));
            if (result == null)
            {
                return new NotFoundResult();
            }

            _messages.Dispatch(new EditResultCommand(resultId, resultValue));
            return RedirectToAction(nameof(AddResult),
                new
                {
                    selectedExerciseId = result.ExerciseId, selectedClassId = result.SchoolClassId,
                    gender = (int) result.Student.Gender
                });
        }

        public IActionResult Leaderboard(string name)
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery(name));
            if (exercises == null)
            {
                return new NotFoundResult();
            }

            var model = new LeaderboardListVm();
            var modelexer = exercises.Select(x => new ExerciseVm
            {
                Id = x.Id,
                Name = x.Name,
                Comment = x.Comment
            }).ToList();
            model.Exercises = modelexer;
            return View(model);
        }

        public IActionResult LeaderboardResults(int exerciseId, int classNumber, int gender, int year = 500)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            if (exercise == null)
            {
                return new NotFoundResult();
            }

            var results = _messages.Dispatch(new GetClassNumberResultsQuery(exercise.Id, classNumber)).Where(x=>x.CreatedOn > DateTime.Now.AddYears(-year));
            results = results.Distinct(new StudentComparer()).ToList();
            var model = new LeaderBoardResultListVm();
            model.Gender = gender;
            model.ExerciseId = exerciseId;
            model.ClassNumber = classNumber;
            foreach (var result in results)
            {
                model.LeaderBoardResult.Add(new LeaderBoardResultVm
                {
                    ResultValue = result.ResultValue.Value,
                    Name = result.Student.Name,
                    DateTime = result.CreatedOn,
                });
            }

            return View(model);
        }
    }
}