using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public class EditAddStudentCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCardNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int SchoolClassId { get; set; }

        public EditAddStudentCommand()
        {
            
        }

        public EditAddStudentCommand(int id, string name, string studentCardNumber, string email, Gender gender, int schoolClassId)
        {
            Id = id;
            Name = name;
            StudentCardNumber = studentCardNumber;
            Email = email;
            Gender = gender;
            SchoolClassId = schoolClassId;
        }

        public class EditAddStudentCommandHandler : ICommandHandler<EditAddStudentCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public EditAddStudentCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(EditAddStudentCommand command)
            {
                var student = _context.Students.Find(command.Id);
                if (student == null)
                {
                    student = new Student();
                    _context.Students.Add(student);
                    _context.SaveChanges();

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