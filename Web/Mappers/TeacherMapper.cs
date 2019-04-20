using System.Collections.Generic;
using Core.Data.Entities;
using WebApplication2.ViewModels.Students;
using WebApplication2.ViewModels.Teachers;

namespace WebApplication2.Mappers
{
    public interface ITeacherMapper
    {
        TeacherListVm ToStudentsListVm(List<ApplicationUser> teachers);
    }

    public class TeacherMapper : ITeacherMapper
    {
        public TeacherListVm ToStudentsListVm(List<ApplicationUser> teachers)
        {
            var model = new TeacherListVm();

            foreach (var teacher in teachers)
            {
                model.Teachers.Add(new TeacherVm()
                {
                    Name = teacher.Name,
                    Email = teacher.Email
                });
            }

            return model;
        }
    }
}