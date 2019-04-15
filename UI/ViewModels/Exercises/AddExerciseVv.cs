using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.Data.Entities;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.ViewModels.Exercises
{
    public class AddExerciseVm
    {
        [Required(ErrorMessage ="Sisesta nimi")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public string Comment { get; set; }
        public string UnitName { get; set; }
        public List<Unit> Units { get; set; } = new List<Unit>();
        public int Selected { get; set; }
    }
    public class LeaderboardListVm
    {

        public List<ExerciseVm> Exercises { get; set; } = new List<ExerciseVm>();
        public List<int> Classes { get; private set; } = new[] {1,2,3,4,5,6,7,8,9,10,11,11,12}.ToList();

        public int SelectedClassId { get; set; }
    }
    public class ExerciseListVm
    {
        public List<ExerciseVm> Exercises { get; set; } = new List<ExerciseVm>();
        public List<ClassVm> Classes { get; set; } = new List<ClassVm>();
        public int SelectedClassId { get; set; }
    }
    public class ExerciseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int ClassId{ get; set; }
    }
}