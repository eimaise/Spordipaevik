using System.Collections.Generic;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApplication2.Controllers;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Mappers
{
    public interface IStudentMapper
    {
        AdminStudentsListVm ToStudentsListVm(List<Student> students);
        AdminAddEditStudenVm ToAdminAddEditStudentVm(Student student);
    }

    public class StudentMapper : IStudentMapper
    {
        private readonly IUrlHelper _urlHelper;

        public StudentMapper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        public AdminStudentsListVm ToStudentsListVm(List<Student> students)
        {
            var model = new AdminStudentsListVm();

            foreach (var student in students)
            {
                var token = student.Invite?.Token;
                var link = "";
                if (token != null)
                {
                    link = _urlHelper.Action("RegisterStudent", "Registration", new {token});
                }

                model.Students.Add(new AdminStudentVm
                {
                    InviteSent = student.InviteSent,
                    StudentCardNr = student.StudentCardNumber,
                    Id = student.Id,
                    Email = student.Email,
                    RegisteredInSystem = student.RegisteredInSystem,
                    ActivationLink = link,
                    Name = student.Name
                });
            }

            return model;
        }

        public AdminAddEditStudenVm ToAdminAddEditStudentVm(Student student)
        {
            if (student == null)
            {
                return new AdminAddEditStudenVm();
            }
            return new AdminAddEditStudenVm
            {
                Email = student.Email,
                Name = student.Name,
                Id = student.Id,
                Gender = student.Gender,
                StudentCardNumber = student.StudentCardNumber,
                SchoolClassId = student.SchoolClassId
            };
        }
    }
}