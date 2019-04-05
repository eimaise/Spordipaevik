
using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public sealed class InviteUsedCommand : ICommand
    {
        public Invite Invite{ get; }

        public InviteUsedCommand(Invite invite)
        {
            Invite = invite;
        }

        public class InviteUsedCommandHandler : ICommandHandler<InviteUsedCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public InviteUsedCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(InviteUsedCommand command)
            {
                command.Invite.Used = true;
                _context.Invites.Update(command.Invite);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}