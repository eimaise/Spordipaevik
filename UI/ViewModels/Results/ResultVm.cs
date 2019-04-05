using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.ViewModels.Results
{
    public class ResultVm
    {
        public int ClassId { get; set; }
        public int ExerciseId { get; set; }
        public string ClassName { get; set; }
        public string ExerciseName { get; set; }
        public List<ClassVm> Classes { get; set; } = new List<ClassVm>();
        public List<StudentVm> Students { get; set; } = new List<StudentVm>();
        
        public string Result { get; set; }
        public bool IsTime { get; set; }

    }
    public class AddResultVm
    {
        public int ClassId { get; set; }
        public int SelectedExerciseId { get; set; }
        public int StudentId { get; set; }
        public string ClassName { get; set; }
        public string ExerciseName { get; set; }
        public decimal Result { get; set; }
    }

    public class ClassVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}