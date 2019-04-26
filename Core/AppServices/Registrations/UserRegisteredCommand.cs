using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices.Registrations
{
    public sealed class UserRegisteredCommand : ICommand
    {
        public Data.Entities.Student Student{ get; }

        public UserRegisteredCommand(Data.Entities.Student student)
        {
            Student = student;
        }

        public class InviteUsedCommandHandler : ICommandHandler<UserRegisteredCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public InviteUsedCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(UserRegisteredCommand command)
            {
                var student = command.Student;
                student.MarkInviteUsed();
                _context.Students.Update(command.Student);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}