using System;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Core;
using Core.AppServices;
using Core.AppServices.Classes;
using Core.AppServices.Excercise;
using Core.AppServices.Students;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication2.Mappers;
using WebApplication2.Services;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Results;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly IChartDataService _chartDataService;
        private readonly Messages _messages;
        private readonly IStudentMapper _studentMapper;

        public StudentController(PeSportsTrackingContext context,
            IChartDataService chartDataService,
            Messages messages,
            IStudentMapper studentMapper)
        {
            _context = context;
            _chartDataService = chartDataService;
            _messages = messages;
            _studentMapper = studentMapper;
        }

        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult AddStudent(int id)
        {
            var student = _messages.Dispatch(new GetStudentQuery(id));

            var schoolClasses = _messages.Dispatch(new GetClassListQuery());

            var model = _studentMapper.ToAdminAddEditStudentVm(student);
            model.SchoolClasses = schoolClasses;

            return View(model);
        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public IActionResult AddStudent(AdminAddEditStudenVm model)
        {
            if (!ModelState.IsValid)
            {
                var schoolClasses = _messages.Dispatch(new GetClassListQuery());
                model.SchoolClasses = schoolClasses;
                return View(model);
            }

            var editStudentCommand = new EditAddStudentCommand(model.Id, model.Name, model.StudentCardNumber, model.Email,
                model.Gender, model.SchoolClassId);
            _messages.Dispatch(editStudentCommand);
            TempData["studentWasEdited"] = "Õpilase uuendamine õnnestus";
            return RedirectToAction("AddStudent", new {name = model.Name});
        }

        public IActionResult Student(int id)
        {
            var student = _messages.Dispatch(new GetStudentQuery(id));
            return View(student);
        }

        public IActionResult Index(string name)
        {
            var students = _messages.Dispatch(new GetStudentListQuery(name: name));
            return View(students);
        }

        public IActionResult StudentDateResults(DateTime date, int exerciseId, int studentId)
        {
            var excercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));

            var allResult = _context.Results.Where(x =>
                x.StudentId == studentId && x.ExerciseId == excercise.Id && x.CreatedOn.Date == date);

            return View(allResult);
        }
     

        public IActionResult StudentResult(int id)
        {
            var student = _messages.Dispatch(new GetStudentQuery(id));
            var excercise = _context.Exercises.FirstOrDefault();

            var allResult = _context.Results.Where(x => x.StudentId == id && x.ExerciseId == excercise.Id)
                .OrderByDescending(x => x.ResultValue.Value);
            var model = _studentMapper.ToStudentExerciseVm(excercise, student);
            foreach (var result in allResult)
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

        public IActionResult GetData(int studentId, int exerciseId)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(new[]{studentId}.ToList(),exercise.Id));
            var data = _chartDataService.CreateChartDatalist(results.ToList());
            var jsonResult = new
            {
                dates = data.Dates, exerciseName = exercise.Name, unit = exercise.Unit.Name,
                tulemused = new
                    {names = data.ChartData.Select(x => x.Name), values = data.ChartData.Select(x => x.Results)}
            };
            return Json(jsonResult);
        }
    }
}