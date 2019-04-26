using System;
using System.Linq;
using Core.Data;

namespace Core.AppServices.Students
{
    public sealed class GetStudentByStudentCardNrQuery : IQuery<Data.Entities.Student> 
    {
        public GetStudentByStudentCardNrQuery(string studentCardnr)
        {
            StudentCardnr = studentCardnr;
        }
        public string StudentCardnr { get; }


        public class GetStudentByStudentCardNrQueryHandler : IQueryHandler<GetStudentByStudentCardNrQuery, Data.Entities.Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentByStudentCardNrQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Data.Entities.Student Handle(GetStudentByStudentCardNrQuery query)
            {
                var st = _context.Students.ToList();
                
                return _context.Students.FirstOrDefault(x=>x.StudentCardNumber.Equals(query.StudentCardnr,StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}