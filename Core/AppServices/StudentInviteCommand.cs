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
        public int StudentId { get; }

        public StudentInviteCommand(string token, int studentId)
        {
            Token = token;
            StudentId = studentId;
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
                var invite = new Invite
                {
                    Token = command.Token,
                    StudentId = command.StudentId,
                };
                _context.Invites.Add(invite);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}