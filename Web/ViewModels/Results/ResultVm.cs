using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.ViewModels.Results
{
    public class LeaderBoardResultListVm
    {
        public int Year { get; set; }
        public int ExerciseId { get; set; }
        public int ClassNumber { get; set; }
        public int Gender { get; set; }
        public List<LeaderBoardResultVm> LeaderBoardResult = new List<LeaderBoardResultVm>();
    }
    public class LeaderBoardResultVm
    {
        public decimal ResultValue { get; set; }
        public string Name { get; set; }
        public DateTime  DateTime{ get; set; }
        public string ClassName { get; set; }
    }
    
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
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Result { get; set; }
    }

    public class ClassVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}