using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices.Classes
{
    public class AddClassCommand : ICommand
    {
        public AddClassCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public class AddClassCommandHandler : ICommandHandler<AddClassCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public AddClassCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(AddClassCommand command)
            {
                var schoolClass = new SchoolClass(command.Name);
                _context.Classes.Add(schoolClass);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}