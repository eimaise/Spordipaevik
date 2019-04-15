using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetStudentQuery : IQuery<Student> 
    {
        public GetStudentQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }


        public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Student Handle(GetStudentQuery query)
            {
                return _context.Students.Find(query.Id);
            }
        }
    }
    public sealed class GetStudentWithStudentCardNoQuery : IQuery<Student> 
    {
        public GetStudentWithStudentCardNoQuery(string studentCardNumber)
        {
            StudentCardNumber = studentCardNumber;
        }

        public string StudentCardNumber { get; }


        public class GetStudentWithStudentCardNoQueryHandler : IQueryHandler<GetStudentWithStudentCardNoQuery, Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentWithStudentCardNoQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Student Handle(GetStudentWithStudentCardNoQuery query)
            {
                return _context.Students.FirstOrDefault(x => x.StudentCardNumber == query.StudentCardNumber);
            }
        }
    }
}