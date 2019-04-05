using System;
using System.Collections.Generic;
using Core.Data.Entities;

namespace WebApplication2.Data.Entities
{
    public class SchoolClass : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        private ICollection<Student> _students;

        public virtual ICollection<Student> Students
        {
            get
            {
                return _students ?? (_students = new List<Student>());
            }
            set
            {
                _students = value;
            }
        }
    }
}