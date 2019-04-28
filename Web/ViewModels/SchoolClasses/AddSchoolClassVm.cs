using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.SchoolClasses
{
    public class AddSchoolClassVm
    {
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vigane klassi nimi")]
        [Required(ErrorMessage = "Klassi nimi on puudu")]
        public string Name { get; set; }
    }
}