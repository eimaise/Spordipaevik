using System;
using System.Collections.Generic;
using WebApplication2.ViewModels.Exercises;

namespace WebApplication2.ViewModels
{
    public class ClassResultVm
    {
        public int SelectedExerciseId { get; set; }
        public int ClassId { get; set; }
        public int Gender { get; set; }
        public List<DateTime> Dates { get; set; }

        public List<ExerciseVm> Exercises{ get; set; } = new List<ExerciseVm>();
    }
}