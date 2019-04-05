using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Services;
using WebApplication2.ViewModels.Exercises;

namespace WebApplication2.Controllers
{
    public class SchoolClassesController : Controller
    {
        private readonly PeSportsTrackingContext _context;
        private readonly IChartDataFactory _chartDataFactory;
        private readonly Messages _messages;
        private readonly IResultService _resultService;

        public SchoolClassesController(PeSportsTrackingContext context, IChartDataFactory chartDataFactory,
            Messages messages,IResultService resultService)
        {
            _context = context;
            _chartDataFactory = chartDataFactory;
            _messages = messages;
            _resultService = resultService;
        }
        public IActionResult List()
        {
            var classes = _context.Classes;
            return View(classes);
        }
        public IActionResult ExerciseList(int classId)
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery());
            var model = new ClassResultVm
            {
                ClassId = classId
            };
            foreach (var exercise in exercises)
            {
                model.Exercises.Add(new ExerciseVm
                {
                    Name = exercise.Name,
                    Id = exercise.Id
                });
            }
            return View(model);
        }

        public IActionResult ClassResults(int exerciseId, int classId)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            var students = _messages.Dispatch(new GetClassQuery(classId)).Students;
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(students.Select(x => x.Id).ToList(),exercise.Id));
            var resultUniqueDates = _resultService.GetUniqueDates(results);

            var model = new ClassResultVm
            {
                SelectedExerciseId = exerciseId,
                ClassId = classId,
                Dates = resultUniqueDates.ToList()
            };
            return View(model);
        }

//        public IActionResult GetData2(int exerciseId,int classId)
//        {
//                var exercise =  _context.Exercises.FirstOrDefault(x=>x.Id == exerciseId);
//                var students = _context.Students.Where(x => x.SchoolClassId == classId).ToList();
//                var result = _context.Results.Where(x=>students.Contains(x.Student) && x.ExerciseId == exercise.Id);
//                var rrr = new Dictionary<string, List<decimal>>();
//                
//                foreach (var student in students)
//                {
//                    rrr.Add(student.Name, result.Where(x => x.Student == student)?.Select(x => x.Value).ToList());
//                }
//                var names = rrr.Keys;
//                var values = rrr.Values;
//                var dates = result.Select(x => x.CreatedOn.Date.ToShortDateString()).Distinct().ToList();
//                var tulemused = new {dates = dates,exerciseName = exercise.Name, unit = exercise.Unit.Name, tulemused = new {names = rrr.Keys, values = rrr.Values}};
//                return Json(tulemused);
//        }
        
        public IActionResult GetData(int exerciseId,int classId)
        {
            var exercise = _messages.Dispatch(new GetExerciseQuery(exerciseId));
            var students = _messages.Dispatch(new GetClassQuery(classId)).Students;
            var results = _messages.Dispatch(new GetStudentsResultsInExerciseQuery(students.Select(x => x.Id).ToList(),exercise.Id));
            var cData = _chartDataFactory.CreateChartDatalist(results);

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

    public interface IChartDataFactory
    {
        ChartDataList CreateChartDatalist(List<Result> results);
    }

    public class ChartDataFactory : IChartDataFactory
    {
        private readonly IResultService _resultService;

        public ChartDataFactory(IResultService resultService)
        {
            _resultService = resultService;
        }
        //todo : tuleks vb natuke refaktoreerida
        public ChartDataList CreateChartDatalist(List<Result> results)
        {
            var cData = new ChartDataList();
            var uniqueDates = _resultService.GetUniqueDates(results);
//            var allUniqueDates = results.OrderBy(x => x.CreatedOn.Date).Select(x=>x.CreatedOn.Date.ToShortDateString()).Distinct().ToList();
            var students = results.Select(x => x.Student.Name).Distinct().ToList();
            //for getting biggest value
            results = results.OrderByDescending(x => x.Value).ToList();
            cData.Dates = uniqueDates.Select(x=>x.Date.ToShortDateString()).ToList();
            foreach (var date in uniqueDates)
            {
                var resultsInDate = results.Where(x => x.CreatedOn.Date == date).ToList();
                foreach (var student in students)
                {
                  
                    var studentResult =  resultsInDate.FirstOrDefault(x => x.Student.Name == student);
                    if (studentResult == null)
                    {  
                        var loccdata = cData.ChartData.FirstOrDefault(x => x.Name == student);
                        if (loccdata == null)
                        {
                            var chartDataloc = new ChartData
                            {
                                Name = student,
                            };
                            chartDataloc.Results.Add(null);
                            cData.ChartData.Add(chartDataloc);
                        }
                        else
                        {
                            loccdata.Results.Add(null);
                        }
                    }
                    else
                    {
                        var loccdata = cData.ChartData.FirstOrDefault(x => x.Name == student);
                        if (loccdata == null)
                        {
                            var chartDataloc = new ChartData
                            {
                                Name = student,
                            };
                            chartDataloc.Results.Add(studentResult.Value);
                            cData.ChartData.Add(chartDataloc);
                        } 
                        else
                        {
                            loccdata.Results.Add(studentResult.Value);
                        }
                    }
                }
            }

            return cData;
        }
    }
    public class ChartDataList
    {
        public List<string> Dates { get; set; } = new List<string>();
        public List<ChartData> ChartData { get; set; } = new List<ChartData>();
    }
    public class ChartData
    {
        public string Name { get; set; }
        public List<decimal?> Results { get; set; } = new List<decimal?>();
    }
    public class ClassResultVm
    {
        public int SelectedExerciseId { get; set; }
        public int ClassId { get; set; }
        public List<DateTime> Dates { get; set; }
            
        public List<ExerciseVm> Exercises{ get; set; } = new List<ExerciseVm>();
    }
}