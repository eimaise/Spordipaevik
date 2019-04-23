using System.Collections.Generic;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.ViewModels.Exercises
{
    public class ExerciseListVm
    {
        public List<ExerciseVm> Exercises { get; set; } = new List<ExerciseVm>();
        public List<ClassVm> Classes { get; set; } = new List<ClassVm>();
        public int SelectedClassId { get; set; }
    }
}