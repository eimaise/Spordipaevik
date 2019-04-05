using System.Collections.Generic;
using System.Linq;
using WebApplication2.Controllers;

namespace WebApplication2.ViewModels.Students
{
    public class StudentExerciseVm
    {
        public string ExerciseName { get; set; }
        public List<StudentResultVm> StudentResults { get; set; } = new List<StudentResultVm>();
        public decimal? BiggestValue => StudentResults.OrderByDescending(x => x.Value).FirstOrDefault()?.Value;
        public int ExerciseId { get; set; }
        public int StudentId { get; set; }
    }
}