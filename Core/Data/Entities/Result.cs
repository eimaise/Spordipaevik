using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Entities
{
    public class Result : BaseEntity
    {
        public Result()
        {
            
        }
        public Result(Student student,int  exerciseId,ResultValue resultValue)
        {
            CreatedOn = DateTime.Now;
            ClassName = student.SchoolClass.Name;
            ResultValue = resultValue;
            ExerciseId = exerciseId;
            StudentId = student.Id;
        }

        public DateTime CreatedOn { get; private set; }

        public string ClassName { get; private set; }
        public virtual Student Student { get; private set; }
        public int StudentId { get; private set; }
        public virtual Exercise Exercise { get; private set; }
        public int ExerciseId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; private set; }
        public TimeSpan Time { get; private set; }
        public ResultValue ResultValue { get; private  set; }
    }

    public class ResultValue : ValueObject<ResultValue>
    {
        public string UnitName { get; set; }
        public decimal Value { get; set; }

        public ResultValue(string unitName, decimal value)
        {
            UnitName = unitName;
            Value = value;
        }
    }

//    public class DateTimeRange : ValueObject<DateTimeRange>
//    {
//        public DateTimeRange(DateTime start, DateTime end)
//        {
//            Start = start;
//            End = end;
//        }
//        public DateTime Start { get; set; }
//        public DateTime End { get; set; }
//
//    }
}