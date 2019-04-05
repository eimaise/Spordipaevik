using System.Collections.Generic;
using Core.Data.Entities;
using WebApplication2.Data.Entities;

namespace WebApplication2.ViewModels.Students
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<string> Results { get; set; } = new List<string>();
    }
    public class AddStudentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string StudentCardNumber { get; set; }
        public string Email { get; set; }
        public int SchoolClassId { get; set; }
        public IEnumerable<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
    }
}