using System;
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