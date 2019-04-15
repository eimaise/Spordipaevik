using Core.Data;
using CSharpFunctionalExtensions;

namespace Core.AppServices
{
    public class EditResultCommand : ICommand
    {
        public int Id { get; set; }
        public decimal ResultValue { get; set; }

        public EditResultCommand(int id, decimal resultValue)
        {
            Id = id;
            ResultValue = resultValue;
        }
     

        public class EditResultCommandHandler : ICommandHandler<EditResultCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public EditResultCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(EditResultCommand command)
            {
                var result = _context.Results.Find(command.Id);
                if (result == null)
                {
                    return Result.Fail("Sellist tulemust ei leitud");
                }
                result.ChangeResultValue(command.ResultValue);
                _context.Results.Update(result);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}