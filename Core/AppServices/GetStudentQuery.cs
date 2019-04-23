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
}