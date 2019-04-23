using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Entities
{
    public class Result : BaseEntity
    {
        public Result()
        {
            
        }
        public Result(Student student,int exerciseId,ResultValue resultValue,DateTime createdOn)
        {
            CreatedOn = createdOn;
            ClassNumber = Helpers.GetClassNumberFromClassName(student.SchoolClass.Name);
            SchoolClassId = student.SchoolClassId;
            ResultValue = resultValue;
            ExerciseId = exerciseId;
            StudentId = student.Id;
            Student = student;
        }

        public DateTime CreatedOn { get; private set; }

        public int ClassNumber { get; private set; }
        public virtual Student Student { get; private set; }
        public int StudentId { get; private set; }
        public int SchoolClassId { get; private set; }
        public virtual Exercise Exercise { get; private set; }
        public int ExerciseId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public virtual ResultValue ResultValue { get; private  set; }
        public bool IsTodaysResult => CreatedOn > DateTime.Today;

        public void ChangeResultValue(decimal resultValue)
        {
            ResultValue.Value = resultValue;
        }
    }
}