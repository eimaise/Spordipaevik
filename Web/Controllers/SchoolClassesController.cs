using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.ViewModels;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.Controllers
{
    public class SchoolClassesController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly IChartDataService _chartDataService;
        private readonly Messages _messages;
        private readonly IResultService _resultService;

        public SchoolClassesController(PeSportsTrackingContext context, IChartDataService chartDataService,
            Messages messages,IResultService resultService)
        {
            _context = context;
            _chartDataService = chartDataService;
            _messages = messages;
            _resultService = resultService;
        }
        public IActionResult List(string name)
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery(name));
            var classes = _messages.Dispatch(new GetClassListQuery());
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

        public IActionResult ClassResults(int exerciseId, int classId,int gender)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            if (exercise == null)
            {
                return new NotFoundResult();
            }
            var students = _messages.Dispatch(new GetClassQuery(classId)).Students.Where(x=>x.Gender==(Gender)gender);
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(students.Select(x => x.Id).ToList(),exercise.Id));
            var resultUniqueDates = _resultService.GetUniqueDates(results);

            var model = new ClassResultVm
            {
                SelectedExerciseId = exerciseId,
                ClassId = classId,
                Dates = resultUniqueDates.ToList(),
                Gender = gender
            };
            return View(model);
        }
        
        public IActionResult GetSchoolClassResults(int exerciseId,int classId,int gender,DateTime dateTime)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            var students = _messages.Dispatch(new GetClassQuery(classId)).Students.Where(x=>x.Gender==(Gender)gender);
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(students.Select(x => x.Id).ToList(),exercise.Id,dateTime));
            var isCurrentUserTeacher = User.IsInRole(Role.Teacher);
                
            var cData = _chartDataService.CreateChartDatalist(results);

            var names = cData.ChartData.Select(x => x.Name);
            var values = cData.ChartData.Select(x => x.Results);
            var dates = cData.Dates;
            var jsonResult = new {dates = dates,exerciseName = exercise.Name, unit = exercise.Unit.Name, tulemused = new {names = names, values = values}};
            return Json(jsonResult);
        }
        
        public IActionResult ResultInDay(DateTime date,int exerciseId,int classId)
        {
            var exercise =  _context.Exercises.FirstOrDefault(x=>x.Id == exerciseId);
            var students = _context.Students.Where(x => x.SchoolClassId == classId);
            var results = _context.Results.Where(x=>students.Contains(x.Student) && x.ExerciseId == exercise.Id && x.CreatedOn.Date == date);

            return View(results);
        }
        
    }
  

}