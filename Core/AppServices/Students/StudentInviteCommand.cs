using Core.Data;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices.Students
{
    public sealed class StudentInviteCommand : ICommand
    {
        public string Token { get; }
        public Data.Entities.Student Student { get; }

        public StudentInviteCommand(string token, Data.Entities.Student student)
        {
            Token = token;
            Student = student;
        }

        public class StudentInviteCommandHandler : ICommandHandler<StudentInviteCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public StudentInviteCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(StudentInviteCommand command)
            {
                command.Student.AddInvite(new Data.Entities.Invite(command.Student.Id, command.Token, false, command.Student.Email));
                _context.Students.Update(command.Student);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}