using Core.Data;

namespace Core.AppServices.Students
{
    public sealed class GetStudentQuery : IQuery<Data.Entities.Student> 
    {
        public GetStudentQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }


        public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, Data.Entities.Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Data.Entities.Student Handle(GetStudentQuery query)
            {
                return _context.Students.Find(query.Id);
            }
        }
    }
}