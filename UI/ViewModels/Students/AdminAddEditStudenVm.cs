using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Data.Entities;

namespace WebApplication2.ViewModels.Students
{
    public class AdminAddEditStudenVm
    {
        public int Id { get; set; }
        [DisplayName("Nimi")]
        [Required(ErrorMessage = "Nimi on kohustuslik")]
        public string Name { get; set; }
        [DisplayName("Sugu")]
        public Gender Gender { get; set; }
        [DisplayName("Õpilaspileti number")]
        [Required(ErrorMessage = "Õpilaspileti nr on kohustuslik")]
        public string StudentCardNumber { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public int SchoolClassId { get; set; }
        public List<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
    }
}