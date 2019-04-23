using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Results
{
    public class AddResultVm
    {
        public int ClassId { get; set; }
        public int SelectedExerciseId { get; set; }
        public int StudentId { get; set; }
        public string ClassName { get; set; }
        public string ExerciseName { get; set; }
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Result { get; set; }
    }
}