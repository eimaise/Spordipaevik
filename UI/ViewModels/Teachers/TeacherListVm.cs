using System.Collections.Generic;

namespace WebApplication2.ViewModels.Teachers
{
    public class TeacherListVm
    {
        public List<TeacherVm> Teachers = new List<TeacherVm>();
    }

    public class TeacherVm
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}