using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices.Students
{
    public class EditAddStudentCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCardNumber { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public int? SchoolClassId { get; set; }
        public bool? ShouldResultsBeHidden { get; set; }


        public EditAddStudentCommand()
        {
        }

        public EditAddStudentCommand(int id, string name, string studentCardNumber, string email, Gender? gender,
            int schoolClassId)
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

            public CSharpFunctionalExtensions.Result Handle(EditAddStudentCommand command)
            {
                var student = _context.Students.Find(command.Id);
                if (student == null)
                {
                    student = new Data.Entities.Student();
                    _context.Students.Add(student);
                    _context.SaveChanges();
                }

                if (!string.IsNullOrWhiteSpace(command.StudentCardNumber))
                {
                    student.StudentCardNumber = command.StudentCardNumber;
                }

                if (command.Gender.HasValue)
                {
                    student.Gender = command.Gender.Value;
                }

                if (!string.IsNullOrWhiteSpace(command.Email))
                {
                    student.Email = command.Email;
                }

                if (!string.IsNullOrWhiteSpace(command.Name))
                {
                    student.Name = command.Name;
                }

                if (command.SchoolClassId.HasValue)
                {
                    student.SchoolClassId = command.SchoolClassId.Value;
                }

                if (command.ShouldResultsBeHidden.HasValue)
                {
                    student.HiddenResults = command.ShouldResultsBeHidden.Value;
                }

                _context.Students.Update(student);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}