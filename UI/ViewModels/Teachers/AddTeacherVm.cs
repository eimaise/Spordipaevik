using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Teachers
{
    public class AddTeacherVm
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}