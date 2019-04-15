using System.Collections.Generic;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Exercises;

namespace WebApplication2.Controllers
{
//    [Authorize(Roles = "Teacher")]
    public class ExerciseController : Controller
    {
        private readonly Messages _messages;

        public ExerciseController(Messages messages)
        {
            _messages = messages;
        }

        public IActionResult Index()
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery());
            return View(exercises);
        }
        public IActionResult Create()
        {
            var units = _messages.Dispatch(new GetUnitListQuery());
            
            var model = new AddExerciseVm
            {
                Units = units.ToList()
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(AddExerciseVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var unit =_messages.Dispatch(new GetUnitQuery(model.Selected));
            if (unit == null)
            {
                return new NotFoundResult();
            }
            _messages.Dispatch(new AddExerciseCommand(unit.Id,model.Name,model.Comment));
            
            return RedirectToAction(nameof(Index));
        }
    }
}