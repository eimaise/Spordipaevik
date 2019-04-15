using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public class EditStudentCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCardNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int SchoolClassId { get; set; }


        public EditStudentCommand(int id, string name, string studentCardNumber, string email, Gender gender, int schoolClassId)
        {
            Id = id;
            Name = name;
            StudentCardNumber = studentCardNumber;
            Email = email;
            Gender = gender;
            SchoolClassId = schoolClassId;
        }

        public class EditStudentCommandHandler : ICommandHandler<EditStudentCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public EditStudentCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(EditStudentCommand command)
            {
                var student = _context.Students.Find(command.Id);
                if (student == null)
                {
                    student = new Student();
                    _context.Students.Add(student);
                }
                student.StudentCardNumber = command.StudentCardNumber;
                student.Gender = command.Gender;
                student.Email = command.Email;
                student.Name = command.Name;
                student.SchoolClassId = command.SchoolClassId;
                _context.Students.Update(student);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}