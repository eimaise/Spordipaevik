
using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public sealed class TeacherRegistrationCommand : ICommand
    {
        public string Token { get; }
        public string Email { get; }

        public TeacherRegistrationCommand(string token, string email)
        {
            Token = token;
            Email = email;
        }

        public class TeacherRegistrationCommandHandler : ICommandHandler<TeacherRegistrationCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public TeacherRegistrationCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(TeacherRegistrationCommand command)
            {
                var registration = new TeacherRegistration()
                {
                    Token = command.Token,
                    Email = command.Email,
                };
                _context.Registrations.Add(registration);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}