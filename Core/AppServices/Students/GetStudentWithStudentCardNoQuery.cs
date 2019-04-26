using System.Linq;
using Core.Data;

namespace Core.AppServices.Students
{
    public sealed class GetStudentWithStudentCardNoQuery : IQuery<Data.Entities.Student> 
    {
        public GetStudentWithStudentCardNoQuery(string studentCardNumber)
        {
            StudentCardNumber = studentCardNumber;
        }

        public string StudentCardNumber { get; }


        public class GetStudentWithStudentCardNoQueryHandler : IQueryHandler<GetStudentWithStudentCardNoQuery, Data.Entities.Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentWithStudentCardNoQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Data.Entities.Student Handle(GetStudentWithStudentCardNoQuery query)
            {
                return _context.Students.FirstOrDefault(x => x.StudentCardNumber == query.StudentCardNumber);
            }
        }
    }
}