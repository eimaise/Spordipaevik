using System.Linq;
using Core.Data;
using CSharpFunctionalExtensions;

namespace Core.AppServices
{
    public class ChangeClassNumberCommand : ICommand
    {
        public class ChangeClassNumberCommandHandler : ICommandHandler<ChangeClassNumberCommand>
        {
            private readonly PeSportsTrackingContext _context;

            public ChangeClassNumberCommandHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(ChangeClassNumberCommand command)
            {
                var classes = _context.Classes.Where(x => !x.IsClosed);
                foreach (var schoolClass in classes)
                {
                    var classNumber = Helpers.GetClassNumberFromClassName(schoolClass.Name);
                    if (classNumber == 12)
                    {
                        schoolClass.IsClosed = true;
                    }
                    else
                    {
                        var newClassNumber = classNumber + 1;
                        schoolClass.Name = schoolClass.Name.Replace(classNumber.ToString(), newClassNumber.ToString());
                        _context.Classes.Update(schoolClass);
                    }
                }

                _context.SaveChanges();
                return Result.Ok();
            }
        }
    }
}