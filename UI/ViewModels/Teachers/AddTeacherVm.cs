using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Teachers
{
    public class AddTeacherVm
    {
        [EmailAddress(ErrorMessage = "Email ei ole valiidne")]
        [Required(ErrorMessage = "Sisesta email")]
        public string Email { get; set; }
    }
}