using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Data.Entities;

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
    public class ExerciseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int ClassId{ get; set; }
    }
}