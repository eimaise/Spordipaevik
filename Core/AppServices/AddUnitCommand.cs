using Core.Data;
using WebApplication2.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
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
}