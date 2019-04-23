using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.AppServices;
using Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ExerciseController : Controller
    {
        private readonly Messages _messages;

        public ExerciseController(Messages messages)
        {
            _messages = messages;
        }

        public IActionResult Index(string name)
        {
            var exercises = _messages.Dispatch(new GetExerciseListQuery(name));
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
            var exercises = _messages.Dispatch(new GetExerciseListQuery());
            if (exercises.Any(x => x.Name.Equals(model.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                ModelState.AddModelError("", "Sellise nimega harjutus on juba olemas");
            }

            if (!ModelState.IsValid)
            {
                model.Units = _messages.Dispatch(new GetUnitListQuery()).ToList();
                return View(model);
            }

            var unit = _messages.Dispatch(new GetUnitQuery(model.Selected));
            if (unit == null)
            {
                return new NotFoundResult();
            }

            _messages.Dispatch(new AddExerciseCommand(unit.Id, model.Name, model.Comment));

            return RedirectToAction(nameof(Index));
        }
    }
}