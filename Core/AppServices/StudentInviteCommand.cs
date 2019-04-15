using System;
using Core.Data;
using Core.Data.Entities;
using NHibernate.Cfg.MappingSchema;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public sealed class StudentInviteCommand : ICommand
    {
        public string Token { get; }
        public Student Student { get; }

        public StudentInviteCommand(string token, Student student)
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
                command.Student.AddInvite(new Invite(command.Student.Id, command.Token, false, command.Student.Email));
                _context.Students.Update(command.Student);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}