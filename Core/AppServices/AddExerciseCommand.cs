using Core.Data;
using Core.Data.Entities;
using Result = CSharpFunctionalExtensions.Result;

namespace Core.AppServices
{
    public sealed class AddExerciseCommand : ICommand
    {
        public int UnitId{ get; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public AddExerciseCommand(int unitId, string name, string comment)
        {
            UnitId = unitId;
            Name = name;
            Comment = comment;
        }

        //todo : kõik handlerid peaks olema internal seal klassid.
        public class AddExerciseCommandHandler : ICommandHandler<AddExerciseCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public AddExerciseCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(AddExerciseCommand command)
            {
                var exercise = new Exercise(command.UnitId)
                {
                    Name = command.Name,
                    Comment= command.Comment,
                };
                _context.Exercises.Add(exercise);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}