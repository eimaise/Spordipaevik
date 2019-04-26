using System;
using System.Collections.Generic;

namespace Core.Data.Entities
{
    public class SchoolClass : BaseEntity
    {
        public SchoolClass(string name, bool isFinished = false)
        {
            Name = name;
            CreatedOn = DateTime.Now;
            IsFinished = isFinished;
        }
        public string Name { get; private set; }
        public DateTime CreatedOn { get; private set; }
        private ICollection<Student> _students;
        public bool IsFinished { get; private set; }

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

        public void SetFinishedStatus(bool status)
        {
            IsFinished = status;
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
    }


}