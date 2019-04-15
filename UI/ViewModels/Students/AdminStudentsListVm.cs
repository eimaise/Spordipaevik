using System.Collections.Generic;

namespace WebApplication2.ViewModels.Students
{
    public class AdminStudentsListVm
    {
        public List<AdminStudentVm> Students { get; set; } = new List<AdminStudentVm>();
    }
}