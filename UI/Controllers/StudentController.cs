using System;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.ViewModels.Results;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly IChartDataFactory _chartDataFactory;
        private readonly Messages _messages;

        public StudentController(PeSportsTrackingContext context, IChartDataFactory chartDataFactory,Messages messages)
        {
            _context = context;
            _chartDataFactory = chartDataFactory;
            _messages = messages;
        }

        public IActionResult AddStudent(int id)
        {
            // kas selline klass on olemas
            var schoolClasses = _context.Classes;
            var student = _context.Students.Find(id);

            var model = new AddStudentVm();
            if (student != null)
            {
                model.Email = student.Email;
                model.Name = student.Name;
                model.Id = student.Id;
                model.Gender = student.Gender;
                model.StudentCardNumber = student.StudentCardNumber;
                model.SchoolClassId = student.SchoolClassId;
            }

            model.SchoolClasses = schoolClasses;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentVm model)
        {
            var student = _context.Students.Find(model.Id);
            if (student == null)
            {
                student = new Student();
                ToStudent(student, model);
                _context.Students.Add(student);
            }
            else
            {
                ToStudent(student, model);
                _context.Students.Update(student);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new {name = model.Name});
        }

        private void ToStudent(Student student, AddStudentVm model)
        {
            student.StudentCardNumber = model.StudentCardNumber;
            student.Gender = model.Gender;
            student.Email = model.Email;
            student.Name = model.Name;
            student.SchoolClassId = model.SchoolClassId;
        }

        public IActionResult Student(int id)
        {
            var students = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(students);
        }

        public IActionResult Index(string name)
        {
            var students = _context.Students.Where(x => x.Name.Contains(name));
            return View(students);
        }
        public IActionResult StudentDateResults(DateTime date, int exerciseId, int studentId)
        {
            var excercise = _context.Exercises.FirstOrDefault();
            var allResult = _context.Results.Where(x =>
                x.StudentId == studentId && x.ExerciseId == excercise.Id && x.CreatedOn.Date == date);

            return View(allResult);
        }

        public IActionResult StudentResult(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            var excercise = _context.Exercises.FirstOrDefault();

            var allResult = _context.Results.Where(x => x.StudentId == id && x.ExerciseId == excercise.Id)
                .OrderByDescending(x => x.Value);
            var model = new StudentExerciseVm
            {
                ExerciseName = excercise.Name,
                ExerciseId = excercise.Id,
                StudentId = student.Id
            };
            foreach (var result in allResult)
            {
                if (!model.StudentResults.Any(x => x.Date == result.CreatedOn.Date))
                {
                    model.StudentResults.Add(new StudentResultVm
                    {
                        Value = result.Value,
                        Date = result.CreatedOn.Date,
                        ClassName = result.ClassName
                    });
                }
            }

            return View(model);
        }

        public IActionResult GetData(int studentId,int exerciseId)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            var results =  _messages.Dispatch(new GetStudentQuery(studentId)).Results;
            var data = _chartDataFactory.CreateChartDatalist(results.ToList());
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