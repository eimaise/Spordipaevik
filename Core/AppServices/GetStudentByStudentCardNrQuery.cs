using System;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetStudentByStudentCardNrQuery : IQuery<Student> 
    {
        public GetStudentByStudentCardNrQuery(string studentCardnr)
        {
            StudentCardnr = studentCardnr;
        }
        public string StudentCardnr { get; }


        public class GetStudentByStudentCardNrQueryHandler : IQueryHandler<GetStudentByStudentCardNrQuery, Student>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentByStudentCardNrQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Student Handle(GetStudentByStudentCardNrQuery query)
            {
                var st = _context.Students.ToList();
                
                return _context.Students.FirstOrDefault(x=>x.StudentCardNumber.Equals(query.StudentCardnr,StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}