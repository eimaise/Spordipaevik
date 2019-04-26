using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices.Units
{
    public sealed class AddUnitCommand : ICommand
    {
        public string Name { get; set; }

        public class AddUnitCommandHandler : ICommandHandler<AddUnitCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public AddUnitCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(AddUnitCommand command)
            {
                var unit = Unit.CreateTimeUnit(command.Name);
                _context.Units.Add(unit);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
    public sealed class EditAppUserCommand : ICommand
    {
        public bool HideResults{ get; set; }
        public ApplicationUser User{ get; set; }

        public EditAppUserCommand(bool hideResults, ApplicationUser user)
        {
            HideResults = hideResults;
            User = user;
        }

        public class AddUnitCommandHandler : ICommandHandler<EditAppUserCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public AddUnitCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(EditAppUserCommand command)
            {
                var user = command.User;
                command.User.HideResults = command.HideResults;
                _context.Persons.Update(user);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}