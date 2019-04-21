using System;
using System.Collections.Generic;

namespace Core.Data.Entities
{
    public class SchoolClass : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        private ICollection<Student> _students;
        public bool IsFinished { get; set; }

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