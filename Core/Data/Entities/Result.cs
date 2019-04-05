using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Data.Entities;

namespace Core.Data.Entities
{
    public class Result : BaseEntity
    {
        public Result()
        {
            CreatedOn = DateTime.Now;

        }

        public DateTime CreatedOn { get; set; }

        public string ClassName { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        public TimeSpan Time { get; set; }

    }
}